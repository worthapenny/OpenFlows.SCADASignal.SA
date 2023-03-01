using Haestad.Framework.Windows.Forms.Components;
using Haestad.Framework.Windows.Forms.Resources;
using Haestad.Support.Support;
using OpenFlows.SCADASignal.SA.ComponentsModel.Database;
using OpenFlows.SCADASignal.SA.Support.IO;
using Serilog;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.Components.Database;

public partial class SignalsImportFromDatabaseControl : HaestadUserControl
{
    #region Public Events
    public event EventHandler<EventArgs> SignalItemsChanged;
    #endregion

    #region Constructor
    public SignalsImportFromDatabaseControl()
    {
        InitializeComponent();
    }
    #endregion

    #region Overridden Methods
    protected override void InitializeVisually()
    {
        this.toolStripButtonImport.Image = ((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.Import]).ToBitmap();
        this.toolStripButtonLoadSignals.Image = ((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.DownstreamArrow]).ToBitmap();

        base.InitializeVisually();
    }
    protected override void InitializeEvents()
    {
        this.toolStripButtonLoadSignals.Click += (s, e) => LoadSignalsFromDatabase();
        this.toolStripButtonImport.Click += (s, e) => ImportSelectedSignals();

        base.InitializeEvents();
    }
    //public override void UnloadUserControl()
    //{
    //    SignalsImportFromDatabaseControlModel.LoadSignalsFromDatabase();
    //    base.UnloadUserControl();
    //}
    #endregion

    #region Public Methods
    public void LoadSignalsFromDatabase()
    {
        this.listViewSignals.Items.Clear();
        this.listViewSignals.Columns.Clear();
        this.listViewSignals.Columns.Add("Signal/Tag", 200);

        var signals = SignalsImportFromDatabaseControlModel.LoadSignalsFromDatabase();

        foreach (var signal in signals)
        {
            var item = new ListViewItem(new string[] { signal.Name }) { Checked = true };
            this.listViewSignals.Items.Add(item);
        }

        SignalItemsChanged?.Invoke(this, EventArgs.Empty);
    }
    #endregion

    #region Private Methods



    private void ImportSelectedSignals()
    {
        var signals = new List<SCADASignalInfo>();
        foreach (ListViewItem item in this.listViewSignals.Items)
        {
            if (item.Checked)
                signals.Add(new SCADASignalInfo(item.Text));
        }

        var importCount = SignalsImportFromDatabaseControlModel.AppendSignals(signals);
        if (importCount > 0)
        {
            var message = $"'{importCount}' number of tags were imported to data source of '{SignalsImportFromDatabaseControlModel.DataSourceElement.Label}';";
            Log.Information(message);
            MessageBox.Show(this, message, "Import Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
    #endregion

    #region Private Properties
    private SignalsImportFromDatabaseControlModel SignalsImportFromDatabaseControlModel =>
        UserControlModel as SignalsImportFromDatabaseControlModel;
    #endregion
}
