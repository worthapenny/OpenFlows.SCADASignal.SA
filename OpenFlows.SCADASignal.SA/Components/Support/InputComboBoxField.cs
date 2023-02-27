using System.ComponentModel;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.Components.Support;
public partial class InputComboBoxField : UserControl
{
    public InputComboBoxField()
    {
        InitializeComponent();
    }

    [PropertyTab("Custom")]
    [Browsable(true)]
    [Category("Custom")]
    [Description("Set SeparatorText of the control")]
    public string Label
    {
        get => this.labelLabel.Text;
        set => this.labelLabel.Text = value;
    }

    [PropertyTab("Custom")]
    [Browsable(true)]
    [Category("Custom")]
    [Description("Set the ComboBox")]
    public ComboBox ComboBox => this.comboBox;
}
