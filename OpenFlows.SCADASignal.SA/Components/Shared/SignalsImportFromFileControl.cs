using Haestad.Framework.Windows.Forms.Components;
using OpenFlows.SCADASignal.SA.ComponentsModel.Shared;
using Serilog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.Components.Shared;
public partial class SignalsImportFromFileControl : HaestadUserControl
{
    #region Events
    public event EventHandler SCADATagItemsChanged;
    #endregion

    #region Constrants
    private const string ExcelToJsonUrl = "https://tableconvert.com/excel-to-json";
    #endregion

    #region Constructor
    public SignalsImportFromFileControl()
    {
        InitializeComponent();
    }
    #endregion

    #region Overridden Methods
    protected override void InitializeEvents()
    {
        this.linkLabelExcelToJson.Click += (s, e) => { Process.Start(ExcelToJsonUrl); };

        this.buttonGetTags.Click += (s, e) => PrepareImport();
        this.buttonDeleteCurrentRawTags.Click += (s, e) => DeleteAllExistingTags();
        this.buttonImportTags.Click += (s, e) => ImportSignalsToModel();

        this.inputComboBoxFieldTag.ComboBox.SelectionChangeCommitted += (s, e) => { SCADATagsImportControlModel.TagColumnName = this.inputComboBoxFieldTag.ComboBox.SelectedValue as string; EnableImportButton(); };
        this.inputComboBoxFieldLabel.ComboBox.SelectionChangeCommitted += (s, e) => { SCADATagsImportControlModel.LabelColumnName = this.inputComboBoxFieldLabel.ComboBox.SelectedValue as string; EnableImportButton(); };
        this.inputComboBoxFieldFormula.ComboBox.SelectionChangeCommitted += (s, e) => { SCADATagsImportControlModel.FormulaColumnName = this.inputComboBoxFieldFormula.ComboBox.SelectedValue as string; EnableImportButton(); };

        base.InitializeEvents();
    }
    #endregion

    #region Private Methods
    private void PrepareImport()
    {
        this.labelTagsInFileCount.Text = string.Empty;

        SCADATagsImportControlModel.LoadJsonPath();

        if (File.Exists(SCADATagsImportControlModel.JsonFilePath))
        {
            var dataTable = SCADATagsImportControlModel.GetSignalInfoTable();
            var headers = SCADATagsImportControlModel.GetTableHeaders(dataTable);
            headers.Insert(0, string.Empty); // so that nothing can be selected in Formula 

            this.inputComboBoxFieldTag.ComboBox.DataSource = new List<string>(headers);
            this.inputComboBoxFieldLabel.ComboBox.DataSource = new List<string>(headers);
            this.inputComboBoxFieldFormula.ComboBox.DataSource = new List<string>(headers);

            this.textBoxCsvFilePath.Text = SCADATagsImportControlModel.JsonFilePath;
            this.labelTagsInFileCount.Text = $"Number of records found: {dataTable.Rows.Count}.";
        }

        EnableImportButton();
    }

    private void ImportSignalsToModel()
    {
        var dataTable = SCADATagsImportControlModel.GetSignalInfoTable();
        var signals = SCADATagsImportControlModel.GetSignalInfoList(dataTable);
        var addedTagsCount = SCADATagsImportControlModel.AppendNewRawScadaTags(signals);

        var message = $"'{addedTagsCount}' number of tags are imported to '{SCADATagsImportControlModel.DataSourceElement.Label}' data source.";
        Log.Information(message);
        MessageBox.Show(this, message, "Tags Imported", MessageBoxButtons.OK, MessageBoxIcon.Information);

        SCADATagItemsChanged?.Invoke(this, EventArgs.Empty);
    }
    private void DeleteAllExistingTags()
    {
        var deletedCount = SCADATagsImportControlModel.DeleteAllRawScadaTags();
        var message = $"Number of deleted tags are: {deletedCount}";

        Log.Information(message);
        MessageBox.Show(this, message, "Delete Tags", MessageBoxButtons.OK, MessageBoxIcon.Information);

        SCADATagItemsChanged?.Invoke(message, EventArgs.Empty);
    }
    private void EnableImportButton()
    {
        var hasTagColName = !string.IsNullOrEmpty(this.inputComboBoxFieldTag.ComboBox.SelectedValue as string);
        var hasLabelColName = !string.IsNullOrEmpty(this.inputComboBoxFieldLabel.ComboBox.SelectedValue as string);

        this.buttonImportTags.Enabled = hasTagColName && hasLabelColName;
    }
    #endregion

    #region Private Properties
    private SignalsImportFromFileControlModel SCADATagsImportControlModel =>
        UserControlModel as SignalsImportFromFileControlModel;

    #endregion
}
