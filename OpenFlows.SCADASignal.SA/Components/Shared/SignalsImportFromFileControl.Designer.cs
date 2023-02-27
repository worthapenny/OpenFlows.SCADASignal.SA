namespace OpenFlows.SCADASignal.SA.Components.Shared
{
    partial class SignalsImportFromFileControl
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
            this.textBoxCsvFilePath = new System.Windows.Forms.TextBox();
            this.buttonGetTags = new System.Windows.Forms.Button();
            this.buttonDeleteCurrentRawTags = new System.Windows.Forms.Button();
            this.buttonImportTags = new System.Windows.Forms.Button();
            this.labelTagsInFileCount = new System.Windows.Forms.Label();
            this.linkLabelExcelToJson = new System.Windows.Forms.LinkLabel();
            this.inputComboBoxFieldTag = new OpenFlows.SCADASignal.SA.Components.Support.InputComboBoxField();
            this.inputComboBoxFieldLabel = new OpenFlows.SCADASignal.SA.Components.Support.InputComboBoxField();
            this.inputComboBoxFieldFormula = new OpenFlows.SCADASignal.SA.Components.Support.InputComboBoxField();
            this.SuspendLayout();
            // 
            // textBoxCsvFilePath
            // 
            this.textBoxCsvFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxCsvFilePath.Location = new System.Drawing.Point(3, 2);
            this.textBoxCsvFilePath.Name = "textBoxCsvFilePath";
            this.textBoxCsvFilePath.Size = new System.Drawing.Size(419, 20);
            this.textBoxCsvFilePath.TabIndex = 0;
            // 
            // buttonGetTags
            // 
            this.buttonGetTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonGetTags.Location = new System.Drawing.Point(428, 0);
            this.buttonGetTags.Name = "buttonGetTags";
            this.buttonGetTags.Size = new System.Drawing.Size(132, 23);
            this.buttonGetTags.TabIndex = 1;
            this.buttonGetTags.Text = "Get Tags (JSON)";
            this.buttonGetTags.UseVisualStyleBackColor = true;
            // 
            // buttonDeleteCurrentRawTags
            // 
            this.buttonDeleteCurrentRawTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteCurrentRawTags.Location = new System.Drawing.Point(428, 116);
            this.buttonDeleteCurrentRawTags.Name = "buttonDeleteCurrentRawTags";
            this.buttonDeleteCurrentRawTags.Size = new System.Drawing.Size(132, 23);
            this.buttonDeleteCurrentRawTags.TabIndex = 3;
            this.buttonDeleteCurrentRawTags.Text = "Delete All Raw Tags";
            this.buttonDeleteCurrentRawTags.UseVisualStyleBackColor = true;
            // 
            // buttonImportTags
            // 
            this.buttonImportTags.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonImportTags.Location = new System.Drawing.Point(428, 145);
            this.buttonImportTags.Name = "buttonImportTags";
            this.buttonImportTags.Size = new System.Drawing.Size(132, 23);
            this.buttonImportTags.TabIndex = 4;
            this.buttonImportTags.Text = "Import Tags (Append)";
            this.buttonImportTags.UseVisualStyleBackColor = true;
            // 
            // labelTagsInFileCount
            // 
            this.labelTagsInFileCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelTagsInFileCount.AutoSize = true;
            this.labelTagsInFileCount.Location = new System.Drawing.Point(0, 155);
            this.labelTagsInFileCount.Name = "labelTagsInFileCount";
            this.labelTagsInFileCount.Size = new System.Drawing.Size(97, 13);
            this.labelTagsInFileCount.TabIndex = 5;
            this.labelTagsInFileCount.Text = "Number of rows: xx";
            // 
            // linkLabelExcelToJson
            // 
            this.linkLabelExcelToJson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkLabelExcelToJson.AutoSize = true;
            this.linkLabelExcelToJson.Location = new System.Drawing.Point(481, 28);
            this.linkLabelExcelToJson.Name = "linkLabelExcelToJson";
            this.linkLabelExcelToJson.Size = new System.Drawing.Size(76, 13);
            this.linkLabelExcelToJson.TabIndex = 2;
            this.linkLabelExcelToJson.TabStop = true;
            this.linkLabelExcelToJson.Text = "Excel to JSON";
            // 
            // inputComboBoxFieldTag
            // 
            this.inputComboBoxFieldTag.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputComboBoxFieldTag.Label = "Tag Col. Name";
            this.inputComboBoxFieldTag.Location = new System.Drawing.Point(3, 28);
            this.inputComboBoxFieldTag.Name = "inputComboBoxFieldTag";
            this.inputComboBoxFieldTag.Size = new System.Drawing.Size(419, 21);
            this.inputComboBoxFieldTag.TabIndex = 6;
            // 
            // inputComboBoxFieldLabel
            // 
            this.inputComboBoxFieldLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputComboBoxFieldLabel.Label = "Label Col. Name";
            this.inputComboBoxFieldLabel.Location = new System.Drawing.Point(3, 55);
            this.inputComboBoxFieldLabel.Name = "inputComboBoxFieldLabel";
            this.inputComboBoxFieldLabel.Size = new System.Drawing.Size(419, 21);
            this.inputComboBoxFieldLabel.TabIndex = 6;
            // 
            // inputComboBoxFieldFormula
            // 
            this.inputComboBoxFieldFormula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputComboBoxFieldFormula.Label = "Folmula Col. Name";
            this.inputComboBoxFieldFormula.Location = new System.Drawing.Point(3, 82);
            this.inputComboBoxFieldFormula.Name = "inputComboBoxFieldFormula";
            this.inputComboBoxFieldFormula.Size = new System.Drawing.Size(419, 21);
            this.inputComboBoxFieldFormula.TabIndex = 6;
            // 
            // SCADATagsImportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inputComboBoxFieldFormula);
            this.Controls.Add(this.inputComboBoxFieldLabel);
            this.Controls.Add(this.inputComboBoxFieldTag);
            this.Controls.Add(this.linkLabelExcelToJson);
            this.Controls.Add(this.labelTagsInFileCount);
            this.Controls.Add(this.buttonImportTags);
            this.Controls.Add(this.buttonDeleteCurrentRawTags);
            this.Controls.Add(this.buttonGetTags);
            this.Controls.Add(this.textBoxCsvFilePath);
            this.Name = "SCADATagsImportControl";
            this.Size = new System.Drawing.Size(560, 171);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxCsvFilePath;
        private System.Windows.Forms.Button buttonGetTags;
        private System.Windows.Forms.Button buttonDeleteCurrentRawTags;
        private System.Windows.Forms.Button buttonImportTags;
        private System.Windows.Forms.Label labelTagsInFileCount;
        private System.Windows.Forms.LinkLabel linkLabelExcelToJson;
        private Support.InputComboBoxField inputComboBoxFieldTag;
        private Support.InputComboBoxField inputComboBoxFieldLabel;
        private Support.InputComboBoxField inputComboBoxFieldFormula;
    }
}
