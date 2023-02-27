using System.ComponentModel;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.Components.Support;
public partial class Separator : UserControl
{
    public Separator()
    {
        InitializeComponent();

        SeparatorText = string.Empty;
    }

    [PropertyTab("Custom")]
    [Browsable(true)]
    [Category("Custom")]
    [Description("Display text on top of the line")]
    public string SeparatorText
    {
        get => this.labelLabel.Text;
        set => this.labelLabel.Text = value;
    }

}
