using System.ComponentModel;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.Components.Support;
public partial class InputField : UserControl
{
    public InputField()
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
    [Description("Set TextBox text")]
    public string Value
    {
        get => this.TextBox.Text;
        set => this.TextBox.Text = value;
    }
}
