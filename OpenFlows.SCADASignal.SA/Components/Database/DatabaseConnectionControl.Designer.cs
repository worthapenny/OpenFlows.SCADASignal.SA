using OpenFlows.SCADASignal.SA.Components.Support;

namespace OpenFlows.SCADASignal.SA.Components.Database
{
    partial class DatabaseConnectionControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelDbConnectionFilePathOrConnectionString = new System.Windows.Forms.Label();
            this.richTextBoxDbConnectionConnectionString = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.richTextBoxAvailableSignals = new System.Windows.Forms.RichTextBox();
            this.labelDataSQL = new System.Windows.Forms.Label();
            this.richTextBoxDataSQL = new System.Windows.Forms.RichTextBox();
            this.labelDateTimeRangeSQL = new System.Windows.Forms.Label();
            this.richTextBoxDateTimeRangeSQL = new System.Windows.Forms.RichTextBox();
            this.checkBoxCustomSQL = new System.Windows.Forms.CheckBox();
            this.inputComboBoxFieldDataSourceFormat = new OpenFlows.SCADASignal.SA.Components.Support.InputComboBoxField();
            this.inputComboBoxFieldDataSourceType = new OpenFlows.SCADASignal.SA.Components.Support.InputComboBoxField();
            this.separator1 = new OpenFlows.SCADASignal.SA.Components.Support.Separator();
            this.separatorFields = new OpenFlows.SCADASignal.SA.Components.Support.Separator();
            this.separatorDbStructure = new OpenFlows.SCADASignal.SA.Components.Support.Separator();
            this.inputFieldTimeStampField = new OpenFlows.SCADASignal.SA.Components.Support.InputField();
            this.inputFieldValueField = new OpenFlows.SCADASignal.SA.Components.Support.InputField();
            this.inputFieldTagField = new OpenFlows.SCADASignal.SA.Components.Support.InputField();
            this.inputFieldTable = new OpenFlows.SCADASignal.SA.Components.Support.InputField();
            this.inputFieldFilePath = new OpenFlows.SCADASignal.SA.Components.Support.InputField();
            this.inputFieldDataSourceLabel = new OpenFlows.SCADASignal.SA.Components.Support.InputField();
            this.inputFieldDbConnectionDateTimeDelimiter = new OpenFlows.SCADASignal.SA.Components.Support.InputField();
            this.SuspendLayout();
            // 
            // labelDbConnectionFilePathOrConnectionString
            // 
            this.labelDbConnectionFilePathOrConnectionString.AutoSize = true;
            this.labelDbConnectionFilePathOrConnectionString.Location = new System.Drawing.Point(3, 84);
            this.labelDbConnectionFilePathOrConnectionString.Name = "labelDbConnectionFilePathOrConnectionString";
            this.labelDbConnectionFilePathOrConnectionString.Size = new System.Drawing.Size(146, 13);
            this.labelDbConnectionFilePathOrConnectionString.TabIndex = 1;
            this.labelDbConnectionFilePathOrConnectionString.Text = "File path or Connection String";
            // 
            // richTextBoxDbConnectionConnectionString
            // 
            this.richTextBoxDbConnectionConnectionString.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDbConnectionConnectionString.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDbConnectionConnectionString.Location = new System.Drawing.Point(3, 100);
            this.richTextBoxDbConnectionConnectionString.Name = "richTextBoxDbConnectionConnectionString";
            this.richTextBoxDbConnectionConnectionString.Size = new System.Drawing.Size(370, 88);
            this.richTextBoxDbConnectionConnectionString.TabIndex = 3;
            this.richTextBoxDbConnectionConnectionString.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 427);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Available Signals SQL statement:";
            // 
            // richTextBoxAvailableSignals
            // 
            this.richTextBoxAvailableSignals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxAvailableSignals.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxAvailableSignals.Enabled = false;
            this.richTextBoxAvailableSignals.Location = new System.Drawing.Point(0, 443);
            this.richTextBoxAvailableSignals.Name = "richTextBoxAvailableSignals";
            this.richTextBoxAvailableSignals.Size = new System.Drawing.Size(373, 34);
            this.richTextBoxAvailableSignals.TabIndex = 10;
            this.richTextBoxAvailableSignals.Text = "";
            // 
            // labelDataSQL
            // 
            this.labelDataSQL.AutoSize = true;
            this.labelDataSQL.Location = new System.Drawing.Point(0, 493);
            this.labelDataSQL.Name = "labelDataSQL";
            this.labelDataSQL.Size = new System.Drawing.Size(108, 13);
            this.labelDataSQL.TabIndex = 2;
            this.labelDataSQL.Text = "Data SQL Statement:";
            // 
            // richTextBoxDataSQL
            // 
            this.richTextBoxDataSQL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDataSQL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDataSQL.Enabled = false;
            this.richTextBoxDataSQL.Location = new System.Drawing.Point(3, 509);
            this.richTextBoxDataSQL.Name = "richTextBoxDataSQL";
            this.richTextBoxDataSQL.Size = new System.Drawing.Size(370, 75);
            this.richTextBoxDataSQL.TabIndex = 11;
            this.richTextBoxDataSQL.Text = "";
            // 
            // labelDateTimeRangeSQL
            // 
            this.labelDateTimeRangeSQL.AutoSize = true;
            this.labelDateTimeRangeSQL.Location = new System.Drawing.Point(0, 602);
            this.labelDateTimeRangeSQL.Name = "labelDateTimeRangeSQL";
            this.labelDateTimeRangeSQL.Size = new System.Drawing.Size(171, 13);
            this.labelDateTimeRangeSQL.TabIndex = 2;
            this.labelDateTimeRangeSQL.Text = "Date/Time Range SQL Statement:";
            // 
            // richTextBoxDateTimeRangeSQL
            // 
            this.richTextBoxDateTimeRangeSQL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxDateTimeRangeSQL.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBoxDateTimeRangeSQL.Enabled = false;
            this.richTextBoxDateTimeRangeSQL.Location = new System.Drawing.Point(3, 618);
            this.richTextBoxDateTimeRangeSQL.Name = "richTextBoxDateTimeRangeSQL";
            this.richTextBoxDateTimeRangeSQL.Size = new System.Drawing.Size(370, 34);
            this.richTextBoxDateTimeRangeSQL.TabIndex = 12;
            this.richTextBoxDateTimeRangeSQL.Text = "";
            // 
            // checkBoxCustomSQL
            // 
            this.checkBoxCustomSQL.AutoSize = true;
            this.checkBoxCustomSQL.Location = new System.Drawing.Point(20, 401);
            this.checkBoxCustomSQL.Name = "checkBoxCustomSQL";
            this.checkBoxCustomSQL.Size = new System.Drawing.Size(154, 17);
            this.checkBoxCustomSQL.TabIndex = 17;
            this.checkBoxCustomSQL.Text = "Customize SQL Statements";
            this.checkBoxCustomSQL.UseVisualStyleBackColor = true;
            // 
            // inputComboBoxFieldDataSourceFormat
            // 
            this.inputComboBoxFieldDataSourceFormat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputComboBoxFieldDataSourceFormat.Label = "Data Source Format";
            this.inputComboBoxFieldDataSourceFormat.Location = new System.Drawing.Point(3, 269);
            this.inputComboBoxFieldDataSourceFormat.Name = "inputComboBoxFieldDataSourceFormat";
            this.inputComboBoxFieldDataSourceFormat.Size = new System.Drawing.Size(370, 21);
            this.inputComboBoxFieldDataSourceFormat.TabIndex = 6;
            // 
            // inputComboBoxFieldDataSourceType
            // 
            this.inputComboBoxFieldDataSourceType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputComboBoxFieldDataSourceType.Label = "Data Source Type";
            this.inputComboBoxFieldDataSourceType.Location = new System.Drawing.Point(3, 27);
            this.inputComboBoxFieldDataSourceType.Name = "inputComboBoxFieldDataSourceType";
            this.inputComboBoxFieldDataSourceType.Size = new System.Drawing.Size(370, 21);
            this.inputComboBoxFieldDataSourceType.TabIndex = 1;
            // 
            // separator1
            // 
            this.separator1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separator1.Location = new System.Drawing.Point(0, 399);
            this.separator1.Name = "separator1";
            this.separator1.SeparatorText = "";
            this.separator1.Size = new System.Drawing.Size(373, 21);
            this.separator1.TabIndex = 11;
            // 
            // separatorFields
            // 
            this.separatorFields.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorFields.Location = new System.Drawing.Point(3, 296);
            this.separatorFields.Name = "separatorFields";
            this.separatorFields.SeparatorText = "Fields";
            this.separatorFields.Size = new System.Drawing.Size(364, 21);
            this.separatorFields.TabIndex = 7;
            // 
            // separatorDbStructure
            // 
            this.separatorDbStructure.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.separatorDbStructure.Location = new System.Drawing.Point(3, 218);
            this.separatorDbStructure.Name = "separatorDbStructure";
            this.separatorDbStructure.SeparatorText = "Db Structure";
            this.separatorDbStructure.Size = new System.Drawing.Size(370, 21);
            this.separatorDbStructure.TabIndex = 4;
            // 
            // inputFieldTimeStampField
            // 
            this.inputFieldTimeStampField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFieldTimeStampField.Label = "Time Stamp Field";
            this.inputFieldTimeStampField.Location = new System.Drawing.Point(3, 371);
            this.inputFieldTimeStampField.Name = "inputFieldTimeStampField";
            this.inputFieldTimeStampField.Size = new System.Drawing.Size(370, 18);
            this.inputFieldTimeStampField.TabIndex = 9;
            this.inputFieldTimeStampField.Value = "";
            // 
            // inputFieldValueField
            // 
            this.inputFieldValueField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFieldValueField.Label = "Value Field";
            this.inputFieldValueField.Location = new System.Drawing.Point(3, 347);
            this.inputFieldValueField.Name = "inputFieldValueField";
            this.inputFieldValueField.Size = new System.Drawing.Size(370, 18);
            this.inputFieldValueField.TabIndex = 8;
            this.inputFieldValueField.Value = "";
            // 
            // inputFieldTagField
            // 
            this.inputFieldTagField.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFieldTagField.Label = "Tag Field";
            this.inputFieldTagField.Location = new System.Drawing.Point(3, 323);
            this.inputFieldTagField.Name = "inputFieldTagField";
            this.inputFieldTagField.Size = new System.Drawing.Size(370, 18);
            this.inputFieldTagField.TabIndex = 7;
            this.inputFieldTagField.Value = "";
            // 
            // inputFieldTable
            // 
            this.inputFieldTable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFieldTable.Label = "Table Name";
            this.inputFieldTable.Location = new System.Drawing.Point(3, 245);
            this.inputFieldTable.Name = "inputFieldTable";
            this.inputFieldTable.Size = new System.Drawing.Size(370, 18);
            this.inputFieldTable.TabIndex = 5;
            this.inputFieldTable.Value = "";
            // 
            // inputFieldFilePath
            // 
            this.inputFieldFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFieldFilePath.Label = "File Path";
            this.inputFieldFilePath.Location = new System.Drawing.Point(3, 54);
            this.inputFieldFilePath.Name = "inputFieldFilePath";
            this.inputFieldFilePath.Size = new System.Drawing.Size(370, 18);
            this.inputFieldFilePath.TabIndex = 2;
            this.inputFieldFilePath.Value = "";
            // 
            // inputFieldDataSourceLabel
            // 
            this.inputFieldDataSourceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFieldDataSourceLabel.Label = "Data Source Label";
            this.inputFieldDataSourceLabel.Location = new System.Drawing.Point(3, 3);
            this.inputFieldDataSourceLabel.Name = "inputFieldDataSourceLabel";
            this.inputFieldDataSourceLabel.Size = new System.Drawing.Size(370, 18);
            this.inputFieldDataSourceLabel.TabIndex = 0;
            this.inputFieldDataSourceLabel.Value = "";
            // 
            // inputFieldDbConnectionDateTimeDelimiter
            // 
            this.inputFieldDbConnectionDateTimeDelimiter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFieldDbConnectionDateTimeDelimiter.Label = "Datetime Delimiter";
            this.inputFieldDbConnectionDateTimeDelimiter.Location = new System.Drawing.Point(3, 194);
            this.inputFieldDbConnectionDateTimeDelimiter.Name = "inputFieldDbConnectionDateTimeDelimiter";
            this.inputFieldDbConnectionDateTimeDelimiter.Size = new System.Drawing.Size(370, 18);
            this.inputFieldDbConnectionDateTimeDelimiter.TabIndex = 4;
            this.inputFieldDbConnectionDateTimeDelimiter.Value = "#";
            // 
            // DatabaseConnectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inputComboBoxFieldDataSourceFormat);
            this.Controls.Add(this.inputComboBoxFieldDataSourceType);
            this.Controls.Add(this.checkBoxCustomSQL);
            this.Controls.Add(this.separator1);
            this.Controls.Add(this.separatorFields);
            this.Controls.Add(this.separatorDbStructure);
            this.Controls.Add(this.richTextBoxDateTimeRangeSQL);
            this.Controls.Add(this.labelDateTimeRangeSQL);
            this.Controls.Add(this.richTextBoxDataSQL);
            this.Controls.Add(this.labelDataSQL);
            this.Controls.Add(this.richTextBoxAvailableSignals);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBoxDbConnectionConnectionString);
            this.Controls.Add(this.labelDbConnectionFilePathOrConnectionString);
            this.Controls.Add(this.inputFieldTimeStampField);
            this.Controls.Add(this.inputFieldValueField);
            this.Controls.Add(this.inputFieldTagField);
            this.Controls.Add(this.inputFieldTable);
            this.Controls.Add(this.inputFieldFilePath);
            this.Controls.Add(this.inputFieldDataSourceLabel);
            this.Controls.Add(this.inputFieldDbConnectionDateTimeDelimiter);
            this.MinimumSize = new System.Drawing.Size(376, 609);
            this.Name = "DatabaseConnectionControl";
            this.Size = new System.Drawing.Size(376, 657);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private InputField inputFieldDbConnectionDateTimeDelimiter;
        private System.Windows.Forms.Label labelDbConnectionFilePathOrConnectionString;
        private System.Windows.Forms.RichTextBox richTextBoxDbConnectionConnectionString;
        private Separator separatorDbStructure;
        private InputField inputFieldTable;
        private InputField inputFieldTagField;
        private Separator separatorFields;
        private InputField inputFieldValueField;
        private InputField inputFieldTimeStampField;
        private Separator separator1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBoxAvailableSignals;
        private System.Windows.Forms.Label labelDataSQL;
        private System.Windows.Forms.RichTextBox richTextBoxDataSQL;
        private System.Windows.Forms.Label labelDateTimeRangeSQL;
        private System.Windows.Forms.RichTextBox richTextBoxDateTimeRangeSQL;
        private System.Windows.Forms.CheckBox checkBoxCustomSQL;
        private InputField inputFieldDataSourceLabel;
        private InputComboBoxField inputComboBoxFieldDataSourceType;
        private InputField inputFieldFilePath;
        private InputComboBoxField inputComboBoxFieldDataSourceFormat;
    }
}
