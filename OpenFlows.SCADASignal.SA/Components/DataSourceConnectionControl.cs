using Haestad.Domain;
using Haestad.Framework.Windows.Forms.Components;
using Haestad.Framework.Windows.Forms.Resources;
using Haestad.SCADA.Domain.Application;
using Haestad.Support.Support;
using OpenFlows.SCADASignal.SA.Components.Database;
using OpenFlows.SCADASignal.SA.Components.Shared;
using OpenFlows.SCADASignal.SA.ComponentsModel;
using OpenFlows.SCADASignal.SA.ComponentsModel.Database;
using OpenFlows.SCADASignal.SA.ComponentsModel.Shared;
using OpenFlows.SCADASignal.SA.Support.Logging;
using Serilog;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.Components;
public partial class DataSourceConnectionControl : HaestadUserControl
{
    #region Constructor
    public DataSourceConnectionControl()
    {
        InitializeComponent();
    }
    #endregion

    #region Overridden Methods
    protected override void InitializeVisually()
    {
        this.toolStripDropDownButtonNew.Image = ((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.New]).ToBitmap();
        this.toolStripMenuItemDatabaseSources.Image = ((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.ScadaDataSource]).ToBitmap();
        this.toolStripMenuItemOPCHistoricalSources.Image = ((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.ScadaPublishToOpc]).ToBitmap();
        this.toolStripButtonDelete.Image = ((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.Delete]).ToBitmap();
        this.toolStripButtonSCADAConnectLog.Image = ((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.Log]).ToBitmap();
        this.toolStripButtonRefresh.Image = ((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.Refresh]).ToBitmap();
        this.toolStripButtonLocalLog.Image = ((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.Report]).ToBitmap();

        this.treeViewDataSources.ImageList = new ImageList();
        this.treeViewDataSources.ImageList.Images.Add((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.ScadaDbConnection]);
        this.treeViewDataSources.ImageList.Images.Add((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.SelectAll]);
        base.InitializeVisually();
    }
    protected override void InitializeEvents()
    {
        this.treeViewDataSources.AfterSelect += (s, e) => NodeSelectionChanged(e);
        
        // Add Database Connection
        this.toolStripMenuItemDatabaseSources.Click += (s, e) =>
        {
            ClearControls();
            var dataSourceElement = DataSourceConnectionControlModel.DatabaseConnectionConfigControlModel.AddSource();
            AddDatabaseConnectionControl(dataSourceElement);
            AddTreeNode(dataSourceElement);
        };


        // Add OPC Historical Connection
        this.toolStripMenuItemOPCHistoricalSources.Click += (s, e) =>
        {
            ClearControls();
            var dataSourceElement = DataSourceConnectionControlModel.HOPCConnectionConfigControlModel.AddSource();
            AddHOPCSourceControl(dataSourceElement);
            AddTreeNode(dataSourceElement);
        };

        // Delete a data source
        this.toolStripButtonDelete.Click += (s, e) =>
        {
            var deleted = DeleteSelectedDataSource();

            if (deleted)
                LoadDataSourcesToTreeView();
        };

        // Show SCADA Log
        this.toolStripButtonSCADAConnectLog.Click += (s, e) =>
        {
            var localAppDataDir = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            var scadaLogFilePath = Path.Combine(localAppDataDir, @"Bentley", "SCADAConnect", "10", "SCADAConnect.log");

            Log.Debug($"About to open up a log file. Path: {scadaLogFilePath}");
            Process.Start(scadaLogFilePath);
        };

        // Refresh
        this.toolStripButtonRefresh.Click += (s, e) => LoadDataSourcesToTreeView();

        // Local Log
        this.toolStripButtonLocalLog.Click += (s, e) => ShowLocalLog();

        base.InitializeEvents();
    }
    #endregion

    #region Public Methods
    public void LoadDataSourcesToTreeView()
    {
        this.treeViewDataSources.Nodes.Clear();
        foreach (var dataSourceSupportElement in DataSourceConnectionControlModel.GetDataSources())
        {
            var supportNode = new TreeNode(dataSourceSupportElement.Label, 0, 1);
            supportNode.Tag = dataSourceSupportElement;

            this.treeViewDataSources.Nodes.Add(supportNode);
        }
    }
    #endregion

    #region Private Methods
    private void AddTreeNode(ISupportElement dataSourceElement)
    {
        var node = new TreeNode(dataSourceElement.Label, 0, 1);
        node.Tag = dataSourceElement;
        this.treeViewDataSources.Nodes.Add(node);
    }
    private void ClearControls()
    {
        this.splitContainerDataSource.Panel1.Controls.Clear();
        this.tabPageImportTagsFromFile.Controls.Clear();
        this.tabPagePreview.Controls.Clear();
    }
    private void NodeSelectionChanged(TreeViewEventArgs e)
    {
        var dataSourceElement = GetDataSourceElement(e.Node);
        if (dataSourceElement != null)
            LoadDataSourceControl(dataSourceElement);
    }

    private ISupportElement GetDataSourceElement(TreeNode node)
    {
        if (node?.Tag != null && node?.Tag is ISupportElement)
            return (ISupportElement)node.Tag;

        return null;
    }

    private void LoadDataSourceControl(ISupportElement dataSourceSupportElement)
    {
        ClearControls();

        var sourceTypeField = dataSourceSupportElement.SupportElementField(StandardFieldName.ScadaDatasourceType);
        var sourceType = (ScadaDatasourceType)sourceTypeField.GetValue(dataSourceSupportElement.Id);

        switch (sourceType)
        {
            case ScadaDatasourceType.Database:
                AddDatabaseConnectionControl(dataSourceSupportElement);
                break;

            case ScadaDatasourceType.OPCHistorical:
                AddHOPCSourceControl(dataSourceSupportElement);
                break;

            case ScadaDatasourceType.Citect:
            case ScadaDatasourceType.OPCRealTime:
            default:
                MessageBox.Show(this, $"This data source '{dataSourceSupportElement.Label}' is not supported.");
                break;
        }

        //
        // Preview SCADA Data
        var dataPreviewControl = new PreviewSCADADataControl();
        dataPreviewControl.Dock = DockStyle.Fill;
        this.tabPagePreview.Controls.Add(dataPreviewControl);
        
        var dataPreviewControlModel = new PreviewSCADADataControlModel(AppManager.Instance.AppModel);
        dataPreviewControlModel.DataSourceElement = GetDataSourceElement(this.treeViewDataSources.SelectedNode);
        dataPreviewControl.LoadUserControl(dataPreviewControlModel);
        dataPreviewControl.LoadTags();

       
        //
        // Import SCADA Tags From File Control
        var signalImporterFromFileControl = new SignalsImportFromFileControl();
        signalImporterFromFileControl.Dock = DockStyle.Fill;
        this.tabPageImportTagsFromFile.Controls.Add(signalImporterFromFileControl);

        // List to signal importer from file
        signalImporterFromFileControl.SCADATagItemsChanged += (s, e) => dataPreviewControl.LoadTags();

        // Listen to signal importer from Db
        var signalImporterFromDb = this.DataSourceConnectionControlModel.DatabaseConnectionConfigControlModel.SignalsImportFromDatabaseControlModel;
        if(signalImporterFromDb != null)
            signalImporterFromDb.SignalsImported += (s, e) => dataPreviewControl.LoadTags();

        var signalImporterFromFileControlModel = new SignalsImportFromFileControlModel(AppManager.Instance.AppModel);
        signalImporterFromFileControlModel.DataSourceElementId = dataSourceSupportElement.Id;
        signalImporterFromFileControl.LoadUserControl(signalImporterFromFileControlModel);
    }

    private void AddHOPCSourceControl(ISupportElement dataSourceSupportElement)
    {
        this.splitContainerDataSource.Panel1.Controls.Clear();
        var control = DataSourceConnectionControlModel.GetOPCHistoricalControl(dataSourceSupportElement.Id);
        control.Dock = DockStyle.Fill;

        this.splitContainerDataSource.Panel1.Controls.Add(control);
        this.splitContainerDataSource.SplitterDistance = (int)(this.splitContainerDataSource.Height * 0.5);
    }

    private void AddDatabaseConnectionControl(ISupportElement dataSourceSupportElement)
    {
        this.splitContainerDataSource.Panel1.Controls.Clear();
        var control = DataSourceConnectionControlModel.GetDatabaseConnectionControl(dataSourceSupportElement.Id);
        control.Dock = DockStyle.Fill;

        this.splitContainerDataSource.Panel1.Controls.Add(control);
        this.splitContainerDataSource.SplitterDistance = (int)(this.splitContainerDataSource.Height * 0.6);
    }

    private bool DeleteSelectedDataSource()
    {
        var deleted = false;
        if (this.treeViewDataSources.SelectedNode != null
            && this.treeViewDataSources.SelectedNode.Tag != null)
        {
            var element = (ISupportElement)this.treeViewDataSources.SelectedNode.Tag;

            var message = $"Are you sure to delete '{element.Id}: {element.Label}' data source?";
            var response = MessageBox.Show(this, message, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            Log.Debug($"Confirmation dialog shown. Message: {message}");

            if (response == DialogResult.Yes)
            {
                Log.Information($"About to delete. '{element.Id}: {element.Label}'");
                deleted = DataSourceConnectionControlModel.DeleteDataSource(element);
            }
            else
            {
                Log.Debug($"User cancelled the delete prompt.");
            }
        }

        Log.Information($"Was delete successful: {deleted}");
        return deleted;
    }
    private void ShowLocalLog()
    {
        var logFilePath = Logging.GetLogFilePath();
        Process.Start(logFilePath);
    }
    
    #endregion

    #region Private Properties
    private DataSourceConnectionControlModel DataSourceConnectionControlModel =>
        UserControlModel as DataSourceConnectionControlModel;
    #endregion

}
