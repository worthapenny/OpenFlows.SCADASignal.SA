using Haestad.Domain;
using Haestad.SCADA.Domain;
using Haestad.SCADA.Domain.Application;
using Haestad.Support.User;
using NUnit.Framework;
using OpenFlows.SCADASignal.SA.Application;
using OpenFlows.SCADASignal.SA.ComponentsModel;
using OpenFlows.SCADASignal.SA.ComponentsModel.Database;
using OpenFlows.SCADASignal.SA.ComponentsModel.OPC;
using OpenFlows.SCADASignal.SA.ComponentsModel.Shared;
using OpenFlows.SCADASignal.SA.Support.IO;
using System;
using System.IO;
using System.Linq;
using static Haestad.Support.Units.UnitConversionManager;

namespace OpenFlows.SCADASignal.SA.Test
{
    [TestFixture]
    public class Tests
    {

        #region Private Properties
        private string ModelFilePath { get; set; }
        private bool IsWaterModelOpen { get; set; }

        private SCADASignalApplicationModel AppModel { get; set; }
        private OpenWaterDatabaseModelControlModel OpenWaterDatabaseModelControlModel { get; set; }
        #endregion


        #region Test Setup

        [OneTimeSetUp]
        public void Init()
        {
            var exampleFivePath = @"C:\Program Files (x86)\Bentley\WaterGEMS\Samples\Example5.wtg.sqlite";
            Assert.That(File.Exists(exampleFivePath), Is.True);

            // if not copied to test dir, copy the example5.wtg
            ModelFilePath = Path.Combine(AppManager.Instance.AppTestDir, "Example5.wtg.sqlite");
            if (!File.Exists(ModelFilePath))
            {
                File.Copy(exampleFivePath, ModelFilePath);
                Assert.That(File.Exists(ModelFilePath), Is.True);
            }

            AppModel = new SCADASignalApplicationModel(null);
            OpenWaterDatabaseModelControlModel = new OpenWaterDatabaseModelControlModel(AppModel);

            // Open up the model
            OpenWaterModelTest();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            CloseWaterModelTest();
        }
        #endregion

        #region Tests - Open and Close WaterModel
        [Test]
        public void OpenWaterModelTest()
        {
            Assert.That(OpenWaterDatabaseModelControlModel, Is.Not.Null);

            OpenWaterDatabaseModelControlModel.ModelDatabaseFilePath = ModelFilePath;
            OpenWaterDatabaseModelControlModel.OpenWaterModel(new NullProgressIndicator());

            Assert.That(OpenWaterDatabaseModelControlModel.DomainDataSet, Is.Not.Null);
            Assert.That(OpenWaterDatabaseModelControlModel.DataSource.IsOpen(), Is.True);

            IsWaterModelOpen = true;
        }

        [Test]
        public void CloseWaterModelTest()
        {
            if (IsWaterModelOpen)
            {
                Assert.That(OpenWaterDatabaseModelControlModel, Is.Not.Null);
                OpenWaterDatabaseModelControlModel.CloseModelDatabase();
                Assert.That(AppManager.Instance.DomainDataSet, Is.Null);

                OpenWaterDatabaseModelControlModel = null;
            }

            Assert.That(true);
        }
        #endregion

        #region Tests - Data Sources - Database
        [Test]
        public void DataSourceDatabaseTest()
        {
            var dataSourceControlModel = new DataSourceConnectionControlModel(AppModel);
            var sources = dataSourceControlModel.GetDataSources().ToList();
            Assert.That(sources.Count, Is.GreaterThanOrEqualTo(2));

            var dbConnConfigModel = new DatabaseConnectionConfigControlModel(AppModel);

            //
            // first connection [Real Time]
            //
            #region First Connection [Real Time]

            var firstConnectionLabel = "SCADA - Real Time";
            var realTimeConnections = sources.Where(s => s.Label == firstConnectionLabel);
            Assert.That(realTimeConnections.Any(), Is.True);

            var realTimeConnection = realTimeConnections.First();
            var dataSourceId = realTimeConnection.Id;
            var dataSourceManager = AppManager.Instance.DomainDataSet.SupportElementManager((int)SupportElementType.ScadaDataSource);

            dbConnConfigModel.DataSourceId = dataSourceId;
            Assert.That(dbConnConfigModel.DataSourceElement.Label, Is.EqualTo(firstConnectionLabel));

            // Test connection
            Assert.That(dbConnConfigModel.TestConnection(), Is.EqualTo(TestConnectionResult.ConnectionOK));

            // Database Source
            var dbSource = dbConnConfigModel.DatabaseConnectionControlModel;
            Assert.That(dbSource.DataSourceType, Is.EqualTo(ScadaDatasourceType.Database));
            Assert.That(dbSource.DatabaseDataSourceType, Is.EqualTo(DatabaseDataSourceType.Excel80));
            Assert.That(dbSource.DataFilePath, Is.EqualTo(@"C:\Program Files (x86)\Bentley\WaterGEMS\Samples\Example5_SCADA.xls"));
            Assert.That(dbSource.ConnectionString, Is.EqualTo(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Program Files (x86)\Bentley\WaterGEMS\Samples\Example5_SCADA.xls;Extended Properties=""Excel 8.0;HDR=Yes;"";"));
            Assert.That(dbSource.QueryDateTimeDelimiter, Is.EqualTo("#"));
            Assert.That(dbSource.TableName, Is.EqualTo("'SCADA Data$'"));
            Assert.That(dbSource.SourceFormat, Is.EqualTo(DatabaseDataSourceFormat.OneValuePerRow));
            Assert.That(dbSource.SignalColumnName, Is.EqualTo("Signal Name"));
            Assert.That(dbSource.ValueColumnName, Is.EqualTo("Data Value"));
            Assert.That(dbSource.TimestampColumnName, Is.EqualTo("DateTime"));
            Assert.That(dbSource.QuestionableColumnName, Is.EqualTo("Questionable"));
            Assert.That(dbSource.IsRealTime, Is.True);
            Assert.That(dbSource.IsHistorical, Is.False);
            Assert.That(dbSource.TimeToleranceBackwardInMinutes, Is.EqualTo(30));
            Assert.That(dbSource.TimeToleranceForwardInMinutes, Is.EqualTo(30));
            Assert.That(dbSource.IsZeroGoodQuality, Is.False);
            Assert.That(dbSource.UseCustomizedSQL, Is.False);

            // Units
            var units = dbConnConfigModel.SignalUnitControlModel;
            Assert.That(units, Is.Not.Null);
            Assert.That(units.HydraulicGradeUnitIndex, Is.EqualTo(UnitIndex.Meters));
            Assert.That(units.PressureUnitIndex, Is.EqualTo(UnitIndex.KiloPascals));
            Assert.That(units.LevelUnitIndex, Is.EqualTo(UnitIndex.Meters));
            Assert.That(units.DemandUnitIndex, Is.EqualTo(UnitIndex.LitersPerSecond));
            Assert.That(units.FlowUnitIndex, Is.EqualTo(UnitIndex.LitersPerSecond));
            Assert.That(units.FlowSettingUnitIndex, Is.EqualTo(UnitIndex.LitersPerSecond));
            Assert.That(units.HydraulicGradeSettingUnitIndex, Is.EqualTo(UnitIndex.Meters));
            Assert.That(units.ConcentrationUnitIndex, Is.EqualTo(UnitIndex.MilligramsPerLiter));
            Assert.That(units.RelativeClosureUnitIndex, Is.EqualTo(UnitIndex.PercentPercent));
            Assert.That(units.PowerUnitIndex, Is.EqualTo(UnitIndex.None)); // NOTE: Not sure why these values are none in the DB

            // Signal Value Mapping
            //--

            // Load total number of available tags
            var signals = dbConnConfigModel.SignalsImportFromDatabaseControlModel.LoadSignalsFromDatabase();
            Assert.That(signals.Count, Is.EqualTo(8));

            // Data Preview
            var previewModel = dataSourceControlModel.PreviewSCADADataControlModel;
            previewModel.DataSourceElement = dataSourceManager.Element(dataSourceId) as ISupportElement;
            var signalsInModel = previewModel.GetSCADASignalElements();
            Assert.That(signalsInModel.Count, Is.EqualTo(8));

            var signal = signalsInModel.Where(s => s.Label == "Flow from Res").First();
            Assert.That(signal, Is.Not.Null);

            previewModel.StartDateTime = new DateTime(2000, 1, 1);
            previewModel.EndDateTime = DateTime.Today;
            var data = previewModel.GetSCADAData(signal);
            Assert.That(data.Count, Is.EqualTo(49));

            Assert.That(data.First().Value, Is.EqualTo(0));
            Assert.That(data.Last().Value, Is.EqualTo(72.6));

            #endregion


            //
            // second connection [Historical]
            //
            #region Second Connection [Historical]

            var seocndConnectionLabel = "SCADA - Historical";
            var historicalTimeConnections = sources.Where(s => s.Label == seocndConnectionLabel);
            Assert.That(historicalTimeConnections.Any(), Is.True);

            var historicalTimeConnection = historicalTimeConnections.First();
            dataSourceId = historicalTimeConnection.Id;
            dataSourceManager = AppManager.Instance.DomainDataSet.SupportElementManager((int)SupportElementType.ScadaDataSource);

            dbConnConfigModel = new DatabaseConnectionConfigControlModel(AppModel);
            dbConnConfigModel.DataSourceId = dataSourceId;
            Assert.That(dbConnConfigModel.DataSourceElement.Label, Is.EqualTo(seocndConnectionLabel));

            // Test connection
            Assert.That(dbConnConfigModel.TestConnection(), Is.EqualTo(TestConnectionResult.ConnectionOK));

            // Database Source
            dbSource = dbConnConfigModel.DatabaseConnectionControlModel;
            Assert.That(dbSource.DataSourceType, Is.EqualTo(ScadaDatasourceType.Database));
            Assert.That(dbSource.DatabaseDataSourceType, Is.EqualTo(DatabaseDataSourceType.Excel80));
            Assert.That(dbSource.DataFilePath, Is.EqualTo(@"C:\Program Files (x86)\Bentley\WaterGEMS\Samples\Example5_SCADA.xls"));
            Assert.That(dbSource.ConnectionString, Is.EqualTo(@"provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Program Files (x86)\Bentley\WaterGEMS\Samples\Example5_SCADA.xls;Extended Properties=""Excel 8.0;HDR=Yes;"";"));
            Assert.That(dbSource.QueryDateTimeDelimiter, Is.EqualTo("#"));
            Assert.That(dbSource.TableName, Is.EqualTo("'SCADA Data$'"));
            Assert.That(dbSource.SourceFormat, Is.EqualTo(DatabaseDataSourceFormat.OneValuePerRow));
            Assert.That(dbSource.SignalColumnName, Is.EqualTo("Signal Name"));
            Assert.That(dbSource.ValueColumnName, Is.EqualTo("Data Value"));
            Assert.That(dbSource.TimestampColumnName, Is.EqualTo("DateTime"));
            Assert.That(dbSource.QuestionableColumnName, Is.EqualTo("Questionable"));
            Assert.That(dbSource.IsRealTime, Is.False);
            Assert.That(dbSource.IsHistorical, Is.True);
            Assert.That(dbSource.TimeToleranceBackwardInMinutes, Is.EqualTo(15));
            Assert.That(dbSource.TimeToleranceForwardInMinutes, Is.EqualTo(15));
            Assert.That(dbSource.IsZeroGoodQuality, Is.False);
            Assert.That(dbSource.UseCustomizedSQL, Is.False);
            Assert.That(dbSource.AvailableSignalsSQLQueryDefault, Is.EqualTo(@"select distinct [Signal Name] from ['SCADA Data$']"));
            Assert.That(dbSource.SignalDataSQLQueryDefault, Is.EqualTo(@"select [Signal Name],[Data Value],[DateTime],[Questionable] from ['SCADA Data$'] where [Signal Name] in (@requestedsignals)  and (([DateTime]>=@startdatetime) and ([DateTime]<=@enddatetime)) "));
            Assert.That(dbSource.DateTimeRangeSQLQueryDefault, Is.EqualTo(@"select Min([DateTime]),Max([DateTime]) from ['SCADA Data$']"));


            // Units
            units = dbConnConfigModel.SignalUnitControlModel;
            Assert.That(units, Is.Not.Null);
            Assert.That(units.HydraulicGradeUnitIndex, Is.EqualTo(UnitIndex.Meters));
            Assert.That(units.PressureUnitIndex, Is.EqualTo(UnitIndex.PSI));
            Assert.That(units.LevelUnitIndex, Is.EqualTo(UnitIndex.Meters));
            Assert.That(units.DemandUnitIndex, Is.EqualTo(UnitIndex.LitersPerSecond));
            Assert.That(units.FlowUnitIndex, Is.EqualTo(UnitIndex.LitersPerSecond));
            Assert.That(units.FlowSettingUnitIndex, Is.EqualTo(UnitIndex.LitersPerSecond));
            Assert.That(units.HydraulicGradeSettingUnitIndex, Is.EqualTo(UnitIndex.Meters));
            Assert.That(units.ConcentrationUnitIndex, Is.EqualTo(UnitIndex.MilligramsPerLiter));
            Assert.That(units.RelativeClosureUnitIndex, Is.EqualTo(UnitIndex.PercentPercent));
            Assert.That(units.PowerUnitIndex, Is.EqualTo(UnitIndex.None)); // NOTE: Not sure why these values are none in the DB

            // Signal Value Mapping
            //--

            // Load total number of available tags
            signals = dbConnConfigModel.SignalsImportFromDatabaseControlModel.LoadSignalsFromDatabase();
            Assert.That(signals.Count, Is.EqualTo(8));

            // Data Preview
            previewModel = dataSourceControlModel.PreviewSCADADataControlModel;
            previewModel.DataSourceElement = dataSourceManager.Element(dataSourceId) as ISupportElement;
            signalsInModel = previewModel.GetSCADASignalElements();
            Assert.That(signalsInModel.Count, Is.EqualTo(8));

            signal = signalsInModel.Where(s => s.Label == "P-12 Flow").First();
            Assert.That(signal, Is.Not.Null);

            previewModel.StartDateTime = new DateTime(2000, 1, 1);
            previewModel.EndDateTime = DateTime.Today;
            data = previewModel.GetSCADAData(signal);
            Assert.That(data.Count, Is.EqualTo(25));

            Assert.That(data.First().Value, Is.EqualTo(-15.86));
            Assert.That(data.Last().Value, Is.EqualTo(57.11));

            #endregion


            //
            // Add New DB Data Source
            // 
            #region Add new DB Data Source
            var dataSourceElement = dbConnConfigModel.AddSource();
            dataSourceId = dataSourceElement.Id;
            Assert.That(dataSourceElement, Is.Not.Null);

            dbConnConfigModel.DataSourceId = dataSourceId;

            // Database Source
            dbSource = dbConnConfigModel.DatabaseConnectionControlModel;
            dbSource.DataSourceType = ScadaDatasourceType.Database;
            dbSource.DatabaseDataSourceType = DatabaseDataSourceType.Excel80;
            dbSource.DataFilePath = @"C:\Program Files (x86)\Bentley\WaterGEMS\Samples\Example5_SCADA.xls";
            //dbSource.ConnectionString =@"provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Program Files (x86)\Bentley\WaterGEMS\Samples\Example5_SCADA.xls;Extended Properties=""Excel 8.0;HDR=Yes;"";";
            dbSource.QueryDateTimeDelimiter = "#";
            dbSource.TableName = "'SCADA Data$'";
            dbSource.SourceFormat = DatabaseDataSourceFormat.OneValuePerRow;
            dbSource.SignalColumnName = "Signal Name";
            dbSource.ValueColumnName = "Data Value";
            dbSource.TimestampColumnName = "DateTime";
            dbSource.IsRealTime = false;
            dbSource.IsHistorical = true;
            dbSource.TimeToleranceBackwardInMinutes = 10;
            dbSource.TimeToleranceForwardInMinutes = 10;
            dbSource.IsZeroGoodQuality = false;
            dbSource.UseCustomizedSQL = false;

            // Test connection
            Assert.That(dbConnConfigModel.TestConnection(), Is.EqualTo(TestConnectionResult.ConnectionOK));

            // Units
            units = dbConnConfigModel.SignalUnitControlModel;
            Assert.That(units, Is.Not.Null);

            units.HydraulicGradeUnitIndex = UnitIndex.Meters;
            units.PressureUnitIndex = UnitIndex.PSI;
            units.LevelUnitIndex = UnitIndex.Meters;
            units.DemandUnitIndex = UnitIndex.LitersPerSecond;
            units.FlowUnitIndex = UnitIndex.LitersPerSecond;
            units.FlowSettingUnitIndex = UnitIndex.LitersPerSecond;
            units.HydraulicGradeSettingUnitIndex = UnitIndex.Meters;
            units.ConcentrationUnitIndex = UnitIndex.MilligramsPerLiter;
            units.RelativeClosureUnitIndex = UnitIndex.PercentPercent;
            units.PowerUnitIndex = UnitIndex.Kilowatts;

            // Signal Value Mapping
            //--


            // Data Preview [There is nothing in the model hence it should be zero at the moment]
            previewModel = dataSourceControlModel.PreviewSCADADataControlModel;
            previewModel.DataSourceElement = dataSourceManager.Element(dataSourceId) as ISupportElement;
            signalsInModel = previewModel.GetSCADASignalElements();
            Assert.That(signalsInModel.Count, Is.EqualTo(0));


            // Load total number of available tags
            signals = dbConnConfigModel.SignalsImportFromDatabaseControlModel.LoadSignalsFromDatabase();
            Assert.That(signals.Count, Is.EqualTo(8));


            // import 
            var newSignals = signals.Select(s => new SCADASignalInfo(s.Name, s.Label)).ToList();
            dbConnConfigModel.SignalsImportFromDatabaseControlModel.AppendSignals(newSignals);

            // Data Preview [There should be something in the model now due to import]            
            signalsInModel = previewModel.GetSCADASignalElements();
            Assert.That(signalsInModel.Count, Is.EqualTo(8));

            // validate SCADA data
            previewModel.StartDateTime = new DateTime(2000, 1, 1);
            previewModel.EndDateTime = DateTime.Today;
            signal = signalsInModel.Where(s => s.SCADATag == "T1 HGL").First();
            data = previewModel.GetSCADAData(signal);
            Assert.That(data.Count, Is.EqualTo(25));

            Assert.That(data.First().Value, Is.EqualTo(177.0));
            Assert.That(data.Last().Value, Is.EqualTo(176.30));

            #endregion


            // Clean up
            dataSourceControlModel.Dispose();
        }
        #endregion

        [Test]
        public void Test()
        {


            //var modelController = new OpenWaterDatabaseModelControlModel(appModel);

            //var newModelFileFullPath = @"C:\Users\akshaya.niraula\Downloads\Test\Test.wtg.sqlite";
            //modelController.CreateNewWaterModelDatabase(newModelFileFullPath);

            //Assert.That(File.Exists(newModelFileFullPath));

            var sqliteFilePath = @"D:\Development\Data\ModelData\Samples\Example5.wtg.sqlite";




            ISupportElementManager supportElementManager =
                AppManager
                    .Instance
                    .DomainDataSet
                    .SupportElementManager((int)SupportElementType.ScadaDataSource);
            var currentSourceCount = supportElementManager.Count;

            var opcSourceId = 0;
            var hOPController = new HOPCSourceControlModel(AppManager.Instance.AppModel);
            hOPController.Label = "Auto HOPC";
            hOPController.HostName = "localhost";
            hOPController.ServerAddress = "Matrikon.OPC.Simulation.1";
            //hOPController.AddSource(out opcSourceId);
            var newDataSourceCount = supportElementManager.Count;

            Assert.That(currentSourceCount + 1, Is.EqualTo(newDataSourceCount));
            Assert.That(opcSourceId, Is.GreaterThan(0));

            // Load Tags
            var addSCADATagsController = new SignalsImportFromFileControlModel(AppManager.Instance.AppModel);
            addSCADATagsController.DataSourceElementId = opcSourceId;
            addSCADATagsController.JsonFilePath = Path.Combine(AppManager.Instance.AppTestDir, "tagsList.json");

            // https://tableconvert.com/excel-to-json
            var jsonContentsRaw = @"[{""Tags"": ""Saw-toothed Waves.Real8"", ""label"": ""Saw-toothed""},{ ""Tags"": ""Square Waves.Real8"",""label"": ""Square"" },{""Tags"": ""Triangle Waves.Real8"",""label"": ""Triangle""}]";
            File.WriteAllText(addSCADATagsController.JsonFilePath, jsonContentsRaw);

            var dataTable = addSCADATagsController.GetSignalInfoTable();
            //var tagAndLabelList = addSCADATagsController.GetTagAndLabelList(
            //    tagColumnName: "Tags",
            //    labelColumnName: "label",
            //    dt: dataTable);

            //Assert.That(tagAndLabelList, Is.Not.Empty);
            //Assert.That(tagAndLabelList.Count, Is.EqualTo(3));

            //// Append to Database
            //var addedTagsCount = addSCADATagsController.AppendNewRawScadaTags(tagAndLabelList);
            //Assert.That(addedTagsCount, Is.EqualTo(3));


            //// Close the model
            //modelController.CloseModelDatabase();
            //Assert.That(modelController.DomainDataSet, Is.Null);
            //Assert.That(modelController.DataSource, Is.Null);

        }

    }
}
