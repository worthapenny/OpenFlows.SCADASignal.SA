using Haestad.Domain;
using Haestad.Framework.Application;
using Haestad.SCADA.Domain.Application;
using OpenFlows.SCADASignal.SA.ComponentsModel.Shared;
using Serilog;

namespace OpenFlows.SCADASignal.SA.ComponentsModel.OPC;

public class HOPCConnectionConfigControlModel : HaestadUserControlModel
{
    #region Constructor
    public HOPCConnectionConfigControlModel(IApplicationModel appModel)
        : base("HOPCConnectionConfigControlModel", appModel)
    {
        HOPCSourceControlModel = new HOPCSourceControlModel(ApplicationModel);
        SignalUnitControlModel = new SignalUnitControlModel(ApplicationModel);
        SignalTransformationControlModel = new SignalTransformationControlModel(ApplicationModel);
    }
    #endregion

    #region Public Methods

    public ISupportElement AddSource()
    {
        DataSourceId = DataSourceManager.Add();
        HOPCSourceControlModel.DataSourceId = DataSourceId;
        HOPCSourceControlModel.DataSourceElement.Label = "Untitled DatabaseDataSource";
        HOPCSourceControlModel.DataSourceType = ScadaDatasourceType.OPCHistorical;

        Log.Information($"New source added. {DataSourceId}: {HOPCSourceControlModel.DataSourceElement.Label}");
        return HOPCSourceControlModel.DataSourceElement;
    }
    #endregion

    #region Public Properties
    public int DataSourceId { get; set; }
    public ISupportElementManager DataSourceManager => AppManager.Instance.DomainDataSet.SupportElementManager((int)SupportElementType.ScadaDataSource);
    public ISupportElement DataSourceElement => DataSourceManager.Element(DataSourceId) as ISupportElement;

    public HOPCSourceControlModel HOPCSourceControlModel { get; }
    public SignalTransformationControlModel SignalTransformationControlModel { get; }
    public SignalUnitControlModel SignalUnitControlModel { get; }
    #endregion
}
