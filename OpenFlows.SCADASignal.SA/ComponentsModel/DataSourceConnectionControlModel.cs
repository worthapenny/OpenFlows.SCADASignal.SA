using Haestad.Domain;
using Haestad.Framework.Application;
using OpenFlows.SCADASignal.SA.Components.Database;
using OpenFlows.SCADASignal.SA.Components.OPC;
using OpenFlows.SCADASignal.SA.ComponentsModel.Database;
using OpenFlows.SCADASignal.SA.ComponentsModel.OPC;
using OpenFlows.SCADASignal.SA.ComponentsModel.Shared;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.ComponentsModel;

public class DataSourceConnectionControlModel : HaestadUserControlModel
{
    #region Constructor
    public DataSourceConnectionControlModel(IApplicationModel appModel)
        : base("DataSourceConnectionControlModel", appModel)
    {
        DatabaseConnectionConfigControlModel = new DatabaseConnectionConfigControlModel(appModel);
        HOPCConnectionConfigControlModel = new HOPCConnectionConfigControlModel(appModel);
        PreviewSCADADataControlModel = new PreviewSCADADataControlModel(appModel);
        SignalsImportFromFileControlModel = new SignalsImportFromFileControlModel(appModel);
    }
    #endregion

    #region Public Methods
    public bool DeleteDataSource(ISupportElement dataSourceElement)
    {
        if (dataSourceElement != null)
        {
            Log.Information($"About to delete '{dataSourceElement.Id}: {dataSourceElement.Label}'");
            this.SupportManager.Delete(dataSourceElement.Id);
            return true;
        }
        return false;
    }

    public Control GetOPCHistoricalControl(int dataSourceId)
    {
        var control = new HOPCConnectionConfigControl();

        if (dataSourceId > 0)
        {
            HOPCConnectionConfigControlModel.DataSourceId = dataSourceId;
            HOPCConnectionConfigControlModel.HOPCSourceControlModel.DataSourceId = dataSourceId;
            HOPCConnectionConfigControlModel.SignalUnitControlModel.DataSourceId = dataSourceId;
            HOPCConnectionConfigControlModel.SignalTransformationControlModel.DataSourceId = dataSourceId;
        }

        control.LoadUserControl(HOPCConnectionConfigControlModel);
        control.HOPCSourceControl.LoadUserControl(HOPCConnectionConfigControlModel.HOPCSourceControlModel);
        control.SignalTransformationControl.LoadUserControl(HOPCConnectionConfigControlModel.SignalTransformationControlModel);
        control.SignalUnitControl.LoadUserControl(HOPCConnectionConfigControlModel.SignalUnitControlModel);

        Log.Debug($"OPCHistoric control loaded");
        return control;
    }

    public Control GetDatabaseConnectionControl(int dataSourceId)
    {
        var control = new DatabaseConnectionConfigControl();

        if (dataSourceId > 0)
        {
            DatabaseConnectionConfigControlModel.DataSourceId = dataSourceId;
            DatabaseConnectionConfigControlModel.DatabaseConnectionControlModel.DataSourceId = dataSourceId;
            DatabaseConnectionConfigControlModel.SignalTransformationControlModel.DataSourceId = dataSourceId;
            DatabaseConnectionConfigControlModel.SignalUnitControlModel.DataSourceId = dataSourceId;
            DatabaseConnectionConfigControlModel.SignalsImportFromDatabaseControlModel.DataSourceId = dataSourceId;
        }

        control.LoadUserControl(DatabaseConnectionConfigControlModel);
        control.DatabaseConnectionControl.LoadUserControl(DatabaseConnectionConfigControlModel.DatabaseConnectionControlModel);
        control.SignalUnitControl.LoadUserControl(DatabaseConnectionConfigControlModel.SignalUnitControlModel);
        control.SignalTransformationControl.LoadUserControl(DatabaseConnectionConfigControlModel.SignalTransformationControlModel);
        control.SignalsImportFromDatabaseControl.LoadUserControl(DatabaseConnectionConfigControlModel.SignalsImportFromDatabaseControlModel);


        Log.Debug($"Database connection control loaded");
        return control;
    }

    public IEnumerable<ISupportElement> GetDataSources()
    {
        return this.SupportManager.Elements().Cast<ISupportElement>();
    }
    public override void Dispose()
    {
        DatabaseConnectionConfigControlModel.Dispose();
        base.Dispose();
    }
    #endregion

    #region Public Properties
    public DatabaseConnectionConfigControlModel DatabaseConnectionConfigControlModel { get; }
    public HOPCConnectionConfigControlModel HOPCConnectionConfigControlModel { get; }
    public PreviewSCADADataControlModel PreviewSCADADataControlModel { get; }
    public SignalsImportFromFileControlModel SignalsImportFromFileControlModel { get; }
    #endregion

    #region Private Properties
    private IDomainDataSet DomainDataSet => AppManager.Instance.DomainDataSet;

    private ISupportElementManager SupportManager
    {
        get
        {
            if (_supportManager == null)
                _supportManager = DomainDataSet.SupportElementManager((int)SupportElementType.ScadaDataSource);
            return _supportManager;
        }
    }
    #endregion

    #region Fields
    ISupportElementManager _supportManager;
    #endregion
}
