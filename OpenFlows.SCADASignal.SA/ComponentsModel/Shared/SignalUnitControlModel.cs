using Haestad.Domain;
using Haestad.Framework.Application;
using Haestad.Support.Support;
using static Haestad.Support.Units.UnitConversionManager;

namespace OpenFlows.SCADASignal.SA.ComponentsModel.Shared;

public class SignalUnitControlModel : HaestadUserControlModel
{
    #region Constructor
    public SignalUnitControlModel(IApplicationModel appModel)
        : base("SignalUnitControlModel", appModel)
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
    public ISupportElementManager DataSourceManager => AppManager.Instance.DomainDataSet.SupportElementManager((int)SupportElementType.ScadaDataSource);
    /// <summary>
    /// Data source DataSourceId
    /// </summary>
    public int DataSourceId { get; set; }

    public UnitIndex HydraulicGradeUnitIndex
    {
        get => (UnitIndex)SupportField(StandardFieldName.ScadaUnit_HydraulicGrade).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaUnit_HydraulicGrade).SetValue(DataSourceId, (int)value);
    }
    public UnitIndex PressureUnitIndex
    {
        get => (UnitIndex)SupportField(StandardFieldName.ScadaUnit_Pressure).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaUnit_Pressure).SetValue(DataSourceId, (int)value);
    }
    public UnitIndex LevelUnitIndex
    {
        get => (UnitIndex)SupportField(StandardFieldName.ScadaUnit_Level).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaUnit_Level).SetValue(DataSourceId, (int)value);
    }
    public UnitIndex DemandUnitIndex
    {
        get => (UnitIndex)SupportField(StandardFieldName.ScadaUnit_Demand).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaUnit_Demand).SetValue(DataSourceId, (int)value);
    }
    public UnitIndex FlowUnitIndex
    {
        get => (UnitIndex)SupportField(StandardFieldName.ScadaUnit_Flow).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaUnit_Flow).SetValue(DataSourceId, (int)value);
    }
    public UnitIndex FlowSettingUnitIndex
    {
        get => (UnitIndex)SupportField(StandardFieldName.ScadaUnit_FlowSetting).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaUnit_FlowSetting).SetValue(DataSourceId, (int)value);
    }
    public UnitIndex HydraulicGradeSettingUnitIndex
    {
        get => (UnitIndex)SupportField(StandardFieldName.ScadaUnit_HydraulicGradeSetting).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaUnit_HydraulicGradeSetting).SetValue(DataSourceId, (int)value);
    }
    public UnitIndex ConcentrationUnitIndex
    {
        get => (UnitIndex)SupportField(StandardFieldName.ScadaUnit_Concentration).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaUnit_Concentration).SetValue(DataSourceId, (int)value);
    }
    public UnitIndex RelativeClosureUnitIndex
    {
        get => (UnitIndex)SupportField(StandardFieldName.ScadaUnit_RelativeClosure).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaUnit_RelativeClosure).SetValue(DataSourceId, (int)value);
    }
    public UnitIndex PowerUnitIndex
    {
        get => (UnitIndex)SupportField(StandardFieldName.ScadaUnit_Power).GetValue(DataSourceId);
        set => SupportField(StandardFieldName.ScadaUnit_Power).SetValue(DataSourceId, (int)value);
    }
    #endregion
}
