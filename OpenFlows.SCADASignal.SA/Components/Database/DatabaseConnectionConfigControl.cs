using Haestad.Framework.Windows.Forms.Components;
using OpenFlows.SCADASignal.SA.Components.Shared;
using OpenFlows.SCADASignal.SA.ComponentsModel.Database;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.Components.Database;
public partial class DatabaseConnectionConfigControl : HaestadUserControl
{
    #region Constructor
    public DatabaseConnectionConfigControl()
    {
        InitializeComponent();
    }
    #endregion

    #region Overridden Methods
    protected override void InitializeVisually()
    {
        //this.tabPageDbStructure.AutoScroll = true;
        //this.tabPageDbStructure.AutoScrollMinSize = new System.Drawing.Size(0, (int)(this.tabPageDbStructure.Height * 1.1));

        //this.tabPageDbUnit.AutoScroll = true;
        //this.tabPageDbUnit.AutoScrollMinSize = new System.Drawing.Size(0, (int)(this.tabPageDbUnit.Height * 1.1));

        base.InitializeVisually();
    }
    protected override void InitializeEvents()
    {
        this.buttonDbConnectionTestConnection.Click += (s, e) => TestConnection();
        base.InitializeEvents();
    }
    #endregion

    #region Private Methods
    private void TestConnection()
    {
        var testResult = DatabaseConnectionConfigControlModel.TestConnection();
        if (testResult == Haestad.SCADA.Domain.TestConnectionResult.ConnectionOK)
        {
            var message = $"Connection to '{DatabaseConnectionConfigControlModel.DataSourceElement.Label}' is succeeded";
            MessageBox.Show(this, message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        else
        {
            var message = $"Connection Failed. Message: {testResult}";
            MessageBox.Show(this, message, "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    #endregion

    #region Public Properties
    public DatabaseConnectionControl DatabaseConnectionControl => this.databaseConnectionControl;
    public SignalTransformationControl SignalTransformationControl => this.signalTransformationControl;
    public SignalUnitControl SignalUnitControl => this.signalUnitControl;
    public SignalsImportFromDatabaseControl SignalsImportFromDatabaseControl => this.signalsImportFromDatabaseControl1;
    #endregion

    #region Private Properties
    private DatabaseConnectionConfigControlModel DatabaseConnectionConfigControlModel =>
        UserControlModel as DatabaseConnectionConfigControlModel;
    #endregion
}
