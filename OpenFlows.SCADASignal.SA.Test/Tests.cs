using Haestad.Domain;
using Haestad.Support.User;
using NUnit.Framework;
using OpenFlows.SCADASignal.SA.Application;
using OpenFlows.SCADASignal.SA.ComponentsModel;
using OpenFlows.SCADASignal.SA.ComponentsModel.OPC;
using OpenFlows.SCADASignal.SA.ComponentsModel.Shared;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenFlows.SCADASignal.SA.Test
{
    [TestFixture]
    public class Tests
    {

        [Test]
        public void Test()
        {
            var appModel = new SCADASignalApplicationModel(null);

            var modelController = new OpenWaterDatabaseModelControlModel(appModel);

            //var newModelFileFullPath = @"C:\Users\akshaya.niraula\Downloads\Test\Test.wtg.sqlite";
            //modelController.CreateNewWaterModelDatabase(newModelFileFullPath);

            //Assert.That(File.Exists(newModelFileFullPath));

            var sqliteFilePath = @"D:\Development\Data\ModelData\Samples\Example5.wtg.sqlite";

            modelController.ModelDatabaseFilePath = sqliteFilePath;
            modelController.OpenWaterModel(new NullProgressIndicator());

            Assert.That(modelController.DomainDataSet, Is.Not.Null);
            Assert.That(modelController.DataSource.IsOpen(), Is.True);
            

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


            // Close the model
            modelController.CloseModelDatabase();
            Assert.That(modelController.DomainDataSet, Is.Null);
            Assert.That(modelController.DataSource, Is.Null);

        }

    }
}
