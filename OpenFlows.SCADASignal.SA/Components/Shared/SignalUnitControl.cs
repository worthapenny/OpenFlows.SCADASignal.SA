using Haestad.Framework.Windows.Forms.Components;
using Haestad.Support.Units;
using OpenFlows.SCADASignal.SA.ComponentsModel.Shared;
using OpenFlows.SCADASignal.SA.Extensions;
using System.Windows.Forms;
using static Haestad.Support.Units.UnitConversionManager;

namespace OpenFlows.SCADASignal.SA.Components.Shared;
public partial class SignalUnitControl : HaestadUserControl
{
    #region Constructor
    public SignalUnitControl()
    {
        InitializeComponent();
    }
    #endregion

    #region Overridden Methods
    protected override void InitializeVisually()
    {
        this.AutoScroll = true;
        this.AutoScrollMinSize = new System.Drawing.Size(0, (int)(Height * 1.1));
        base.InitializeVisually();
    }
    protected override void InitializeBindings()
    {
        this.inputComboBoxFieldUnitSystem.ComboBox.BindToEnum<UnitSystemIndex>();

        this.inputComboBoxFieldConcentration.ComboBox.BindToDimension(Dimension.Concentration);
        this.inputComboBoxFieldDemand.ComboBox.BindToDimension(Dimension.Flow);
        this.inputComboBoxFieldFlow.ComboBox.BindToDimension(Dimension.Flow);
        this.inputComboBoxFieldFlowSetting.ComboBox.BindToDimension(Dimension.Flow);
        this.inputComboBoxFieldHG.ComboBox.BindToDimension(Dimension.Length);
        this.inputComboBoxFieldHGS.ComboBox.BindToDimension(Dimension.Length);
        this.inputComboBoxFieldLevel.ComboBox.BindToDimension(Dimension.Length);
        this.inputComboBoxFieldPower.ComboBox.BindToDimension(Dimension.Power);
        this.inputComboBoxFieldPressure.ComboBox.BindToDimension(Dimension.Pressure);
        this.inputComboBoxFieldRelativeClosure.ComboBox.BindToDimension(Dimension.Percent);


        base.InitializeBindings();
    }
    protected override void InitializeEvents()
    {
        UnitIndex GetUnitIndex(ComboBox comboBox) =>
            UnitConversionManager.Current.UnitIndexFor(comboBox.SelectedItem as Unit);


        this.buttonInitialize.Click += (s, e) =>
        {
            var unitSystemIndex = (UnitConversionManager.UnitSystemIndex)this.inputComboBoxFieldUnitSystem.ComboBox.SelectedValue;
            InitializeFieldByUnitSystemIndex(unitSystemIndex);
        };

        if (SignalUnitControlModel.DataSourceId > 0)
        {
            this.inputComboBoxFieldConcentration.ComboBox.SelectedValueChanged += (s, e) => SignalUnitControlModel.ConcentrationUnitIndex = GetUnitIndex(this.inputComboBoxFieldConcentration.ComboBox);
            this.inputComboBoxFieldDemand.ComboBox.SelectedValueChanged += (s, e) => SignalUnitControlModel.DemandUnitIndex = GetUnitIndex(this.inputComboBoxFieldDemand.ComboBox);
            this.inputComboBoxFieldFlow.ComboBox.SelectedValueChanged += (s, e) => SignalUnitControlModel.FlowUnitIndex = GetUnitIndex(this.inputComboBoxFieldFlow.ComboBox);
            this.inputComboBoxFieldFlowSetting.ComboBox.SelectedValueChanged += (s, e) => SignalUnitControlModel.FlowSettingUnitIndex = GetUnitIndex(this.inputComboBoxFieldFlowSetting.ComboBox);
            this.inputComboBoxFieldHG.ComboBox.SelectedValueChanged += (s, e) => SignalUnitControlModel.HydraulicGradeUnitIndex = GetUnitIndex(this.inputComboBoxFieldHG.ComboBox);
            this.inputComboBoxFieldHGS.ComboBox.SelectedValueChanged += (s, e) => SignalUnitControlModel.HydraulicGradeSettingUnitIndex = GetUnitIndex(this.inputComboBoxFieldHGS.ComboBox);
            this.inputComboBoxFieldLevel.ComboBox.SelectedValueChanged += (s, e) => SignalUnitControlModel.LevelUnitIndex = GetUnitIndex(this.inputComboBoxFieldLevel.ComboBox);
            this.inputComboBoxFieldPower.ComboBox.SelectedValueChanged += (s, e) => SignalUnitControlModel.PowerUnitIndex = GetUnitIndex(this.inputComboBoxFieldPower.ComboBox);
            this.inputComboBoxFieldPressure.ComboBox.SelectedValueChanged += (s, e) => SignalUnitControlModel.PressureUnitIndex = GetUnitIndex(this.inputComboBoxFieldPressure.ComboBox);
            this.inputComboBoxFieldRelativeClosure.ComboBox.SelectedValueChanged += (s, e) => SignalUnitControlModel.RelativeClosureUnitIndex = GetUnitIndex(this.inputComboBoxFieldRelativeClosure.ComboBox);
        }

        base.InitializeEvents();
    }
    protected override void InitializeText()
    {
        if (SignalUnitControlModel.DataSourceId > 0)
        {
            var unitManager = UnitConversionManager.Current;
            this.inputComboBoxFieldConcentration.ComboBox.SelectedItem = unitManager.UnitAt(SignalUnitControlModel.ConcentrationUnitIndex);
            this.inputComboBoxFieldDemand.ComboBox.SelectedItem = unitManager.UnitAt(SignalUnitControlModel.DemandUnitIndex);
            this.inputComboBoxFieldFlow.ComboBox.SelectedItem = unitManager.UnitAt(SignalUnitControlModel.FlowUnitIndex);
            this.inputComboBoxFieldFlowSetting.ComboBox.SelectedItem = unitManager.UnitAt(SignalUnitControlModel.FlowSettingUnitIndex);
            this.inputComboBoxFieldHG.ComboBox.SelectedItem = unitManager.UnitAt(SignalUnitControlModel.HydraulicGradeUnitIndex);
            this.inputComboBoxFieldHGS.ComboBox.SelectedItem = unitManager.UnitAt(SignalUnitControlModel.HydraulicGradeSettingUnitIndex);
            this.inputComboBoxFieldLevel.ComboBox.SelectedItem = unitManager.UnitAt(SignalUnitControlModel.LevelUnitIndex);
            this.inputComboBoxFieldPower.ComboBox.SelectedItem = unitManager.UnitAt(SignalUnitControlModel.PowerUnitIndex);
            this.inputComboBoxFieldPressure.ComboBox.SelectedItem = unitManager.UnitAt(SignalUnitControlModel.PressureUnitIndex);
            this.inputComboBoxFieldRelativeClosure.ComboBox.SelectedItem = unitManager.UnitAt(SignalUnitControlModel.RelativeClosureUnitIndex);
        }
    }
    #endregion

    #region Private Methods
    private void InitializeFieldByUnitSystemIndex(UnitSystemIndex unitSystemIndex)
    {
        if (unitSystemIndex == UnitSystemIndex.UsCustomary)
        {
            this.inputComboBoxFieldConcentration.ComboBox.SelectedItem = Unit.MilligramsPerLiter;
            this.inputComboBoxFieldDemand.ComboBox.SelectedItem = Unit.GallonsPerMinute;
            this.inputComboBoxFieldFlow.ComboBox.SelectedItem = Unit.GallonsPerMinute;
            this.inputComboBoxFieldFlowSetting.ComboBox.SelectedItem = Unit.GallonsPerMinute;
            this.inputComboBoxFieldHG.ComboBox.SelectedItem = Unit.Feet;
            this.inputComboBoxFieldHGS.ComboBox.SelectedItem = Unit.Feet;
            this.inputComboBoxFieldLevel.ComboBox.SelectedItem = Unit.Feet;
            this.inputComboBoxFieldPower.ComboBox.SelectedItem = Unit.Kilowatts;
            this.inputComboBoxFieldPressure.ComboBox.SelectedItem = Unit.PSI;
            this.inputComboBoxFieldRelativeClosure.ComboBox.SelectedItem = Unit.PercentPercent;
        }
        else if (unitSystemIndex == UnitSystemIndex.Si)
        {
            this.inputComboBoxFieldConcentration.ComboBox.SelectedItem = Unit.MilligramsPerLiter;
            this.inputComboBoxFieldDemand.ComboBox.SelectedItem = Unit.LitersPerSecond;
            this.inputComboBoxFieldFlow.ComboBox.SelectedItem = Unit.LitersPerSecond;
            this.inputComboBoxFieldFlowSetting.ComboBox.SelectedItem = Unit.LitersPerSecond;
            this.inputComboBoxFieldHG.ComboBox.SelectedItem = Unit.Meters;
            this.inputComboBoxFieldHGS.ComboBox.SelectedItem = Unit.Meters;
            this.inputComboBoxFieldLevel.ComboBox.SelectedItem = Unit.Meters;
            this.inputComboBoxFieldPower.ComboBox.SelectedItem = Unit.Kilowatts;
            this.inputComboBoxFieldPressure.ComboBox.SelectedItem = Unit.KiloPascals;
            this.inputComboBoxFieldRelativeClosure.ComboBox.SelectedItem = Unit.PercentPercent;
        }
        else
        {
            var message = $"Given unit system '{unitSystemIndex}' is not supported.";
            MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    #endregion

    #region Private Properties
    private SignalUnitControlModel SignalUnitControlModel =>
        UserControlModel as SignalUnitControlModel;
    #endregion
}
