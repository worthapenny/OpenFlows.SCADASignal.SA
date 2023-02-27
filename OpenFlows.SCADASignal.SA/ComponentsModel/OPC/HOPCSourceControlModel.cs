using Haestad.Domain;
using Haestad.Framework.Application;
using Haestad.SCADA.Domain.Application;
using Haestad.Support.Support;
using Serilog;

namespace OpenFlows.SCADASignal.SA.ComponentsModel.OPC;

public class HOPCSourceControlModel : HaestadUserControlModel
{

    #region Constructor
    public HOPCSourceControlModel(IApplicationModel appModel)
        : base("HOPCSourceControlModel", appModel)
    {
    }
    #endregion
    
    #region Private Methods
    private IEditField SupportField(string fieldName)
    {
        return (IEditField)DataSourceManager.SupportElementField(fieldName);
    }
    #endregion

    #region Public Properties
    public int DataSourceId { get; set; }
    public ISupportElement DataSourceElement => (ISupportElement)DataSourceManager.Element(DataSourceId);


    public new string Label {
        get => DataSourceElement.Label;
        set => DataSourceElement.Label = value;
    }
    public ScadaDatasourceType DataSourceType
    {
        get => (ScadaDatasourceType)SupportField(StandardFieldName.ScadaDatasourceType).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaDatasourceType).SetValue(DataSourceId, value);
    }
    public string HostName {
        get => (string)SupportField(StandardFieldName.OPCDatasource_ComputerName).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.OPCDatasource_ComputerName).SetValue(DataSourceId, value);
    }
    public string ServerAddress {
        get => (string)SupportField(StandardFieldName.OPCDatasource_Server).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.OPCDatasource_Server).SetValue(DataSourceId, value);
    }
    #endregion

    #region Private Properties
    private ISupportElementManager DataSourceManager => AppManager.Instance.DomainDataSet.SupportElementManager((int)SupportElementType.ScadaDataSource);
    #endregion
}
