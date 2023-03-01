using Haestad.Framework.Windows.Forms.Components;
using Haestad.SCADA.Domain;
using OpenFlows.SCADASignal.SA.ComponentsModel.Database;
using OpenFlows.SCADASignal.SA.Extensions;
using System;
using System.Windows.Forms;

namespace OpenFlows.SCADASignal.SA.Components.Database;
public partial class DatabaseConnectionControl : HaestadUserControl
{
    #region Constructor
    public DatabaseConnectionControl()
    {
        InitializeComponent();
    }
    #endregion

    #region Overridden Methods
    protected override void InitializeVisually()
    {
        this.AutoScroll = true;
        this.AutoScrollMinSize = new System.Drawing.Size(0, 1000);
        base.InitializeVisually();
    }
    protected override void InitializeBindings()
    {
        this.inputComboBoxFieldDataSourceFormat.ComboBox.BindToEnum<DatabaseDataSourceFormat>();
        this.inputComboBoxFieldDataSourceType.ComboBox.BindToEnum<DatabaseDataSourceType>();

        // Data Source Label
        this.inputFieldDataSourceLabel.TextBox.DataBindings.Add(nameof(TextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.DataSourceLabel));

        // Data Source Type
        this.inputComboBoxFieldDataSourceType.ComboBox.DataBindings.Add(nameof(ComboBox.SelectedValue), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.DatabaseDataSourceType));

        // File Path and/or Connection String
        this.inputFieldFilePath.TextBox.DataBindings.Add(nameof(TextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.DataFilePath));
        //BindControlsToConnectionStringOrDbPath();

        // Connection String
        this.richTextBoxDbConnectionConnectionString.DataBindings.Add(nameof(RichTextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.ConnectionString));

        // DateTime Delimiter
        this.inputFieldDbConnectionDateTimeDelimiter.TextBox.DataBindings.Add(nameof(TextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.QueryDateTimeDelimiter));

        // Table Name
        this.inputFieldTable.TextBox.DataBindings.Add(nameof(TextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.TableName));

        // Data Source Format
        this.inputComboBoxFieldDataSourceFormat.ComboBox.DataBindings.Add(nameof(ComboBox.SelectedValue), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.SourceFormat));

        // ?
        BindControlsToDataSqlBox();

        // Tag
        this.inputFieldTagField.TextBox.DataBindings.Add(nameof(TextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.SignalColumnName));

        // Value
        this.inputFieldValueField.TextBox.DataBindings.Add(nameof(TextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.ValueColumnName));

        // Timestamp
        this.inputFieldTimeStampField.TextBox.DataBindings.Add(nameof(TextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.TimestampColumnName));

        // Questionable
        DatabaseConnectionControlModel.QuestionableColumnName = string.Empty;

        // Custom SQL?
        this.checkBoxCustomSQL.DataBindings.Add(nameof(CheckBox.Checked), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.UseCustomizedSQL));

        // Custom SQL statements
        BindControlToCustomSQLStatements();


        base.InitializeBindings();
    }
    protected override void InitializeEvents()
    {
        //this.inputComboBoxFieldDataSourceType.ComboBox.SelectedValueChanged += ComboBoxDbConnectionDataSourceType_SelectedValueChanged;
        this.inputComboBoxFieldDataSourceFormat.ComboBox.SelectedValueChanged += ComboBoxSourceFormat_SelectedValueChanged;
        this.checkBoxCustomSQL.CheckedChanged += CheckBoxCustomSQL_CheckedChanged;

        base.InitializeEvents();
    }
    public override void UnloadUserControl()
    {
        DatabaseConnectionControlModel.Dispose();
        base.UnloadUserControl();
    }
    #endregion

    #region Event Handlers
    //private void ComboBoxDbConnectionDataSourceType_SelectedValueChanged(object sender, EventArgs e)
    //{
    //    var selectedText = this.inputComboBoxFieldDataSourceType.ComboBox.SelectedText;
    //    var useConnectionString = !(selectedText.StartsWith("Excel") || selectedText.StartsWith("Access"));
    //    DatabaseConnectionControlModel.UseConnectionString = useConnectionString;
    //}
    private void CheckBoxCustomSQL_CheckedChanged(object sender, EventArgs e)
    {
        this.richTextBoxAvailableSignals.Enabled = this.checkBoxCustomSQL.Checked;
        this.richTextBoxDataSQL.Enabled = this.checkBoxCustomSQL.Checked;
        this.richTextBoxDateTimeRangeSQL.Enabled = this.checkBoxCustomSQL.Checked;

        DatabaseConnectionControlModel.UseCustomizedSQL = this.checkBoxCustomSQL.Checked;
        BindControlToCustomSQLStatements();

    }
    private void ComboBoxSourceFormat_SelectedValueChanged(object sender, EventArgs e)
    {
        BindControlsToDataSqlBox();
    }
    #endregion

    #region Private Methods
    private void BindControlsToDataSqlBox()
    {
        this.richTextBoxDataSQL.DataBindings.Clear();

        // Data Sql
        if (DatabaseConnectionControlModel.SourceFormat == Haestad.SCADA.Domain.DatabaseDataSourceFormat.OneValuePerRow)
            this.richTextBoxDataSQL.DataBindings.Add(nameof(RichTextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.SignalDataSQLQueryOVPR));

        else
            this.richTextBoxDataSQL.DataBindings.Add(nameof(RichTextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.SignalDataSQLQueryMVPR));

    }
    private void BindControlToCustomSQLStatements()
    {
        this.richTextBoxAvailableSignals.DataBindings.Clear();
        this.richTextBoxDataSQL.DataBindings.Clear();
        this.richTextBoxDateTimeRangeSQL.DataBindings.Clear();

        if (DatabaseConnectionControlModel.UseCustomizedSQL)
        {
            // Available signal sql
            this.richTextBoxAvailableSignals.DataBindings.Add(nameof(RichTextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.AvailableSignalsSQLQuery));

            // Data Sql
            if (DatabaseConnectionControlModel.SourceFormat == Haestad.SCADA.Domain.DatabaseDataSourceFormat.OneValuePerRow)
                this.richTextBoxDataSQL.DataBindings.Add(nameof(RichTextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.SignalDataSQLQueryOVPR));

            else
                this.richTextBoxDataSQL.DataBindings.Add(nameof(RichTextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.SignalDataSQLQueryMVPR));

            // Date/Time range sql
            this.richTextBoxDateTimeRangeSQL.DataBindings.Add(nameof(RichTextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.DateTimeRangeSQLQuery));

        }

        else
        {
            this.richTextBoxAvailableSignals.DataBindings.Add(nameof(RichTextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.AvailableSignalsSQLQueryDefault));
            this.richTextBoxDataSQL.DataBindings.Add(nameof(RichTextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.SignalDataSQLQueryDefault));
            this.richTextBoxDateTimeRangeSQL.DataBindings.Add(nameof(RichTextBox.Text), DatabaseConnectionControlModel, nameof(DatabaseConnectionControlModel.DateTimeRangeSQLQueryDefault));
        }
    }
    #endregion

    #region Private Properties
    private DatabaseConnectionControlModel DatabaseConnectionControlModel =>
        UserControlModel as DatabaseConnectionControlModel;
    #endregion

}
