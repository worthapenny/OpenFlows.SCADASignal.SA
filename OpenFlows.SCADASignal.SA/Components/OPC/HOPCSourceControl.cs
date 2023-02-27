using Haestad.Framework.Windows.Forms.Components;
using OpenFlows.SCADASignal.SA.ComponentsModel.OPC;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.Components.OPC;

public partial class HOPCSourceControl : HaestadUserControl
{
    #region Constructor
    public HOPCSourceControl()
    {
        InitializeComponent();
    }
    #endregion

    #region Overridden Methods       
    protected override void InitializeBindings()
    {
        if (HOPCSourceControlModel.DataSourceId > 0)
        {
            this.inputFieldDataSourceLabel.TextBox.DataBindings.Add(nameof(TextBox.Text), HOPCSourceControlModel, nameof(HOPCSourceControlModel.Label));
            this.inputFieldHost.TextBox.DataBindings.Add(nameof(TextBox.Text), HOPCSourceControlModel, nameof(HOPCSourceControlModel.HostName));
            this.inputFieldOPCServer.TextBox.DataBindings.Add(nameof(TextBox.Text), HOPCSourceControlModel, nameof(HOPCSourceControlModel.ServerAddress));
        }

        base.InitializeBindings();
    }
    #endregion

    #region Private Properties
    public HOPCSourceControlModel HOPCSourceControlModel => 
        UserControlModel as HOPCSourceControlModel;
    #endregion

}
