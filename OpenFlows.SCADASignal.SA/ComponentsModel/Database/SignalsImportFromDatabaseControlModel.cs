using Haestad.Framework.Application;
using Haestad.SCADA.Domain;
using Haestad.SCADA.Domain.Application;
using OpenFlows.SCADASignal.SA.ComponentsModel.Shared;
using OpenFlows.SCADASignal.SA.Support.IO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OpenFlows.SCADASignal.SA.ComponentsModel.Database;

public class SignalsImportFromDatabaseControlModel : HaestadUserControlModel
{
    #region Public Events
    public event EventHandler SignalsImported;
    #endregion

    #region Constructor
    public SignalsImportFromDatabaseControlModel(IApplicationModel appModel)
        : base("SignalsImportFromDatabaseControlModel", appModel)
    {
    }
    #endregion

    #region Public Methods
    public int AppendSignals(List<SCADASignalInfo> signals)
    {
        var importer = new SignalsImportFromFileControlModel(ApplicationModel);
        importer.DataSourceElementId = DataSourceId;
        var importCount = importer.AppendNewRawScadaTags(signals);

        SignalsImported?.Invoke(this, new EventArgs());
        return importCount;
    }

    public List<ScadaSignal> LoadSignalsFromDatabase()
    {
        var scadaAdapter = new ScadaAdapter(AppManager.Instance.DomainDataSet);
        var wrappedDataSource = scadaAdapter.GetOrCreateAndOpenScadaDataSource(DataSourceId, null);

        var signals = wrappedDataSource.DataSource.GetAvailableSignals();
        var signalList = new List<ScadaSignal>();

        if (signals != null)
            signalList = signals.ToList();

        Log.Information($"Found '{signalList.Count}' number of signals on the database.");
        return signalList;
    }
    #endregion

    #region Public Propertise
    public int DataSourceId { get; set; }
    //public DatabaseConnectionControlModel DatabaseConnectionControlModel { get; set; }

    #endregion

    #region Private Properties
    //private DatabaseDataSourceType DataSourceType { get; }
    //private DatabaseDataSourceFormat SourceFormat { get; }
    //private string DataFilePath { get; }
    //private string? ConnectionString { get; }
    //private DatabaseDataSource DatabaseDataSource { get; }
    #endregion
}

