using Haestad.Framework.Windows.Forms.Components;
using OpenFlows.SCADASignal.SA.Components.Shared;
using OpenFlows.SCADASignal.SA.ComponentsModel.OPC;

namespace OpenFlows.SCADASignal.SA.Components.OPC;

public partial class HOPCConnectionConfigControl : HaestadUserControl
{
    #region Constructor
    public HOPCConnectionConfigControl()
    {
        InitializeComponent();
    }
    #endregion

    #region Overridden Methods
    protected override void InitializeVisually()
    {
        //this.tabPageOPCUnit.AutoScroll = true;
        //this.tabPageOPCUnit.AutoScrollMinSize = new System.Drawing.Size(0, (int)(this.tabPageOPCUnit.Height * 1.1));
        //base.InitializeVisually();
    }

    #endregion

    #region Public Properties
    public HOPCSourceControl HOPCSourceControl => this.hopcSourceControl;
    public SignalTransformationControl SignalTransformationControl => this.signalTransformationControl;
    public SignalUnitControl SignalUnitControl => this.signalUnitControl;
    #endregion

    #region Private Properties
    private HOPCConnectionConfigControlModel HOPCConnectionConfigControlModel =>
        UserControlModel as HOPCConnectionConfigControlModel;
    #endregion
}
