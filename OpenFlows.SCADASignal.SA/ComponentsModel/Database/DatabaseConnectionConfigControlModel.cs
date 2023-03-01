using Haestad.Domain;
using Haestad.Framework.Application;
using Haestad.SCADA.Domain;
using Haestad.SCADA.Domain.Application;
using OpenFlows.SCADASignal.SA.ComponentsModel.Shared;
using Serilog;

namespace OpenFlows.SCADASignal.SA.ComponentsModel.Database;

public class DatabaseConnectionConfigControlModel : HaestadUserControlModel
{
    #region Constructor
    public DatabaseConnectionConfigControlModel(IApplicationModel appModel)
        : base("DatabaseConnectionConfigControlModel", appModel)
    {
        DatabaseConnectionControlModel = new DatabaseConnectionControlModel(appModel);
        SignalTransformationControlModel = new SignalTransformationControlModel(appModel);
        SignalUnitControlModel = new SignalUnitControlModel(appModel);
        SignalsImportFromDatabaseControlModel = new SignalsImportFromDatabaseControlModel(appModel);
    }
    #endregion

    #region Public Methods
    public TestConnectionResult TestConnection()
    {
        var connection = DatabaseConnectionControlModel.NewDatabaseDataSource().Connection;
        var connectionResult = connection.TestConnection(null);
        Log.Information($"TestConnection result: {connectionResult.ToString()}");

        connection.Dispose();
        return connectionResult;
    }

    public ISupportElement AddSource()
    {
        DataSourceId = DataSourceManager.Add();
        DatabaseConnectionControlModel.DataSourceId = DataSourceId;
        DatabaseConnectionControlModel.DataSourceElement.Label = "Untitled DatabaseDataSource";
        DatabaseConnectionControlModel.DataSourceType = ScadaDatasourceType.Database;


        Log.Information($"New source added. {DataSourceId}: {DatabaseConnectionControlModel.DataSourceElement.Label}");
        return DatabaseConnectionControlModel.DataSourceElement;
    }
    #endregion

    #region Overridden Methods
    public override void Dispose()
    {
        DatabaseConnectionControlModel?.Dispose();
        base.Dispose();
    }
    #endregion

    #region Public Properties
    public int DataSourceId
    {
        get => _dataSourceId;
        set
        {
            _dataSourceId = value;
            DatabaseConnectionControlModel.DataSourceId = value;
            SignalTransformationControlModel.DataSourceId = value;
            SignalUnitControlModel.DataSourceId = value;
            SignalsImportFromDatabaseControlModel.DataSourceId = value;
        }
    }
    public ISupportElementManager DataSourceManager => AppManager.Instance.DomainDataSet.SupportElementManager((int)SupportElementType.ScadaDataSource);
    public ISupportElement DataSourceElement => DataSourceManager.Element(DataSourceId) as ISupportElement;

    public DatabaseConnectionControlModel DatabaseConnectionControlModel { get; }
    public SignalTransformationControlModel SignalTransformationControlModel { get; }
    public SignalUnitControlModel SignalUnitControlModel { get; }
    public SignalsImportFromDatabaseControlModel SignalsImportFromDatabaseControlModel { get; }


    #endregion

    #region Private Properties
    //private DatabaseDataSource DataSource
    //{
    //    get
    //    {
    //        if (_dataSource == null)
    //        {
    //            _dataSource = (DatabaseDataSource)ScadaFactory.NewDatabaseDataSource(
    //                            scadaDataSourceType: DatabaseConnectionControlModel.DatabaseDataSourceType,
    //                            databaseDataSourceFormat: DatabaseConnectionControlModel.SourceFormat,
    //                            dataSourcePath: DatabaseConnectionControlModel.DataFilePath);

    //            if (DatabaseConnectionControlModel.UseConnectionString)
    //                _dataSource.Connection.ConnectionString = DatabaseConnectionControlModel.ConnectionString;
    //        }

    //        return _dataSource;
    //    }
    //}
    #endregion

    #region Private Fields
    //private DatabaseDataSource _dataSource;
    private int _dataSourceId;
    #endregion
}
