using Haestad.Framework.Windows.Forms.Components;
using Haestad.SCADA.Domain.Support;
using OpenFlows.SCADASignal.SA.ComponentsModel.Shared;
using OpenFlows.SCADASignal.SA.Extensions;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.Components.Shared;
public partial class SignalTransformationControl : HaestadUserControl
{
    #region Constructor

    public SignalTransformationControl()
    {
        InitializeComponent();
    }
    #endregion

    #region Overridden Methods
    protected override void InitializeBindings()
    {
        // Pumps
        this.inputComboBoxFieldPumpType.ComboBox.BindToEnum<TransformType>();
        this.inputComboBoxFieldPumpOn.ComboBox.BindToEnum<RelationalOperator>();
        this.inputComboBoxFieldPumpOff.ComboBox.BindToEnum<RelationalOperator>();

        if (SignalTransformationControlModel.DataSourceId > 0)
        {
            this.inputComboBoxFieldPumpType.ComboBox.DataBindings.Add(nameof(ComboBox.SelectedValue), SignalTransformationControlModel, nameof(SignalTransformationControlModel.PumpTransformType));
            this.inputComboBoxFieldPumpOn.ComboBox.DataBindings.Add(nameof(ComboBox.SelectedValue), SignalTransformationControlModel, nameof(SignalTransformationControlModel.PumpOnOperator));
            this.inputComboBoxFieldPumpOff.ComboBox.DataBindings.Add(nameof(ComboBox.SelectedValue), SignalTransformationControlModel, nameof(SignalTransformationControlModel.PumpOffOperator));

            this.textBoxPumpOnValue.DataBindings.Add(nameof(TextBox.Text), SignalTransformationControlModel, nameof(SignalTransformationControlModel.PumpOnRawSignalValue));
            this.textBoxPumpOffValue.DataBindings.Add(nameof(TextBox.Text), SignalTransformationControlModel, nameof(SignalTransformationControlModel.PumpOffRawSignalValue));
        }

        // Valves
        this.inputComboBoxFieldValveType.ComboBox.BindToEnum<TransformType>();
        this.inputComboBoxFieldValveActive.ComboBox.BindToEnum<RelationalOperator>();
        this.inputComboBoxFieldValveClosed.ComboBox.BindToEnum<RelationalOperator>();

        if (SignalTransformationControlModel.DataSourceId > 0)
        {
            this.inputComboBoxFieldValveType.ComboBox.DataBindings.Add(nameof(ComboBox.SelectedValue), SignalTransformationControlModel, nameof(SignalTransformationControlModel.ValveTransformType));
            this.inputComboBoxFieldValveActive.ComboBox.DataBindings.Add(nameof(ComboBox.SelectedValue), SignalTransformationControlModel, nameof(SignalTransformationControlModel.ValveActiveOperator));
            this.inputComboBoxFieldValveClosed.ComboBox.DataBindings.Add(nameof(ComboBox.SelectedValue), SignalTransformationControlModel, nameof(SignalTransformationControlModel.ValveClosedOperator));

            this.textBoxValveActiveValue.DataBindings.Add(nameof(TextBox.Text), SignalTransformationControlModel, nameof(SignalTransformationControlModel.ValveActiveValue));
            this.textBoxValveCloseValue.DataBindings.Add(nameof(TextBox.Text), SignalTransformationControlModel, nameof(SignalTransformationControlModel.ValveClosedValue));
        }


        base.InitializeBindings();
    }
    protected override void InitializeEvents()
    {
        this.inputComboBoxFieldPumpType.ComboBox.SelectedIndexChanged += (s, e) => EnablePumpTransformationControls();
        this.inputComboBoxFieldValveType.ComboBox.SelectedIndexChanged += (s, e) => EnableValveTransformationControls();

        base.InitializeEvents();
    }
    protected override void InitializeVisually()
    {
        EnablePumpTransformationControls();
        EnableValveTransformationControls();
        base.InitializeVisually();
    }
    #endregion

    #region Private Methods
    private void EnablePumpTransformationControls()
    {
        var enable = (TransformType)this.inputComboBoxFieldPumpType.ComboBox.SelectedValue == TransformType.SubstituteTransform
                || (TransformType)this.inputComboBoxFieldPumpType.ComboBox.SelectedValue == TransformType.ThresholdTransform;

        this.inputComboBoxFieldPumpOn.Enabled = enable;
        this.inputComboBoxFieldPumpOff.Enabled = enable;
        this.textBoxPumpOnValue.Enabled = enable;
        this.textBoxPumpOffValue.Enabled = enable;
    }
    private void EnableValveTransformationControls()
    {
        var enable = (TransformType)this.inputComboBoxFieldValveType.ComboBox.SelectedValue == TransformType.SubstituteTransform
                || (TransformType)this.inputComboBoxFieldValveType.ComboBox.SelectedValue == TransformType.ThresholdTransform;


        this.inputComboBoxFieldValveActive.Enabled = enable;
        this.inputComboBoxFieldValveClosed.Enabled = enable;
        this.textBoxValveActiveValue.Enabled = enable;
        this.textBoxValveCloseValue.Enabled = enable;
    }
    #endregion

    #region Private Properties
    private SignalTransformationControlModel SignalTransformationControlModel =>
        UserControlModel as SignalTransformationControlModel;
    #endregion
}
