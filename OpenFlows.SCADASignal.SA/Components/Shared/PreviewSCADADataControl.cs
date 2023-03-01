using Haestad.Framework.Windows.Forms.Components;
using Haestad.Framework.Windows.Forms.Resources;
using Haestad.Support.Support;
using OpenFlows.SCADASignal.SA.ComponentsModel.Shared;
using Serilog;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.Components.Shared;
public partial class PreviewSCADADataControl : HaestadUserControl
{
    #region Constructor
    public PreviewSCADADataControl()
    {
        InitializeComponent();
    }
    #endregion

    #region Overridden Methods
    protected override void InitializeEvents()
    {
        this.toolStripButtonSelectAll.Click += (s, e) => SelectAllNodes();
        this.toolStripButtonDelete.Click += (s, e) => DeleteSelectedNodes();
        this.toolStripButtonReload.Click += (s, e) => LoadTags();
        this.treeViewTags.AfterSelect += TagsTreeNodeSelected;
        this.dateTimePickerFrom.ValueChanged += (s, e) => PreviewSCADADataControlModel.StartDateTime = this.dateTimePickerFrom.Value;
        this.dateTimePickerTo.ValueChanged += (s, e) => PreviewSCADADataControlModel.EndDateTime = this.dateTimePickerTo.Value;

        this.listViewData.Columns.Add("Timestamp", 140, HorizontalAlignment.Right);
        this.listViewData.Columns.Add("Value", 100, HorizontalAlignment.Left);
        this.listViewData.Columns.Add("Raw Value", 100, HorizontalAlignment.Left);

        base.InitializeEvents();
    }


    protected override void InitializeText()
    {
        this.dateTimePickerFrom.Value = PreviewSCADADataControlModel.StartDateTime;
        this.dateTimePickerTo.Value = PreviewSCADADataControlModel.EndDateTime;


        base.InitializeText();
    }
    protected override void InitializeVisually()
    {
        this.treeViewTags.ImageList = new ImageList();
        this.treeViewTags.ImageList.Images.Add((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.SCADASignal]);
        this.treeViewTags.ImageList.Images.Add((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.SCADASignalDerived]);
        this.treeViewTags.ImageList.Images.Add((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.SelectAll]);

        this.toolStripButtonSelectAll.Image = ((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.CheckAll]).ToBitmap();
        this.toolStripButtonDelete.Image = ((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.Delete]).ToBitmap();
        this.toolStripButtonReload.Image = ((Icon)GraphicResourceManager.Current[StandardGraphicResourceNames.Refresh]).ToBitmap();

        base.InitializeVisually();
    }

    #endregion

    #region Public Methods
    public void LoadTags()
    {
        var signals = PreviewSCADADataControlModel.GetSCADASignalElements();

        this.treeViewTags.Nodes.Clear();
        foreach (var signal in signals)
        {
            var node = new TreeNode(signal.Label, 0, 2);
            if (signal.IsDerived)
                node = new TreeNode(signal.Label, 1, 2);
            node.Tag = signal;
            this.treeViewTags.Nodes.Add(node);
        }
    }
    #endregion

    #region Private Methods
    private void SelectAllNodes()
    {
        foreach (TreeNode node in this.treeViewTags.Nodes)
            node.Checked = true;
    }
    private void DeleteSelectedNodes()
    {
        foreach (TreeNode node in this.treeViewTags.Nodes)
        {
            if (node.Checked)
                PreviewSCADADataControlModel.DeleteTag(node.Tag as SCADASignalElement);
        }

        // Reload the UI
        LoadTags();
    }

    #endregion

    #region Event Handlers
    private void TagsTreeNodeSelected(object sender, EventArgs e)
    {
        var supportElement = ((SCADASignalElement)this.treeViewTags.SelectedNode.Tag);

        try
        {
            var data = PreviewSCADADataControlModel.GetSCADAData(supportElement);

            this.listViewData.Items.Clear();
            foreach (var tsd in data)
            {
                this.listViewData.Items.Add(
                    new ListViewItem(
                        new string[] {
                        tsd.TimeStamp.ToString(),
                        tsd.Value.ToString() ,
                        tsd.RawValue?.ToString()
                        }));
            }

            Log.Debug($"'{data.Count}' number of data rows loaded from '{supportElement.Label}' source.");
        }
        catch (Exception ex)
        {
            var message = $"...while loading data from external source. Message: {ex.Message}";
            Log.Error(ex, message);

            message += $"\n\n{ex.StackTrace}";
            MessageBox.Show(this, message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
    #endregion

    #region Private Properties
    private PreviewSCADADataControlModel PreviewSCADADataControlModel =>
        UserControlModel as PreviewSCADADataControlModel;

    #endregion
}

#region Helper Classes
[DebuggerDisplay("{ToString()}")]
public class SCADASignalElement
{
    #region Constructor
    public SCADASignalElement()
    {
    }

    public SCADASignalElement(int id, string label, int dataSourceId, string SCADATag)
    {
        Id = id;
        Label = label;
        DataSourceId = dataSourceId;
        this.SCADATag = SCADATag;
    }

    #endregion

    #region Overridden Methods
    public override string ToString()
    {
        return $"{Id}: {Label} [{SCADATag}], Source ID = {DataSourceId}, IsDerived = {IsDerived},  Formula = {Formula}";
    }
    #endregion

    #region Public Properties

    public int Id { get; set; }
    public string Label { get; set; }
    public int DataSourceId { get; set; }
    public bool IsDerived { get; set; } = false;
    public string SCADATag { get; set; }
    public string Formula { get; set; } = string.Empty;
    #endregion
}
#endregion
