using OpenFlows.SCADASignal.SA.Components.Shared;

namespace OpenFlows.SCADASignal.SA.Components.Database
{
    partial class DatabaseConnectionConfigControl
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
            this.buttonDbConnectionTestConnection = new System.Windows.Forms.Button();
            this.buttonAddUpdate = new System.Windows.Forms.Button();
            this.tabControlDatabase = new System.Windows.Forms.TabControl();
            this.tabPageDbStructure = new System.Windows.Forms.TabPage();
            this.databaseConnectionControl = new OpenFlows.SCADASignal.SA.Components.Database.DatabaseConnectionControl();
            this.tabPageDbUnit = new System.Windows.Forms.TabPage();
            this.signalUnitControl = new OpenFlows.SCADASignal.SA.Components.Shared.SignalUnitControl();
            this.tabPageDbTransformation = new System.Windows.Forms.TabPage();
            this.signalTransformationControl = new OpenFlows.SCADASignal.SA.Components.Shared.SignalTransformationControl();
            this.tabPageImportTags = new System.Windows.Forms.TabPage();
            this.signalsImportFromDatabaseControl1 = new OpenFlows.SCADASignal.SA.Components.Database.SignalsImportFromDatabaseControl();
            this.tabControlDatabase.SuspendLayout();
            this.tabPageDbStructure.SuspendLayout();
            this.tabPageDbUnit.SuspendLayout();
            this.tabPageDbTransformation.SuspendLayout();
            this.tabPageImportTags.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonDbConnectionTestConnection
            // 
            this.buttonDbConnectionTestConnection.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonDbConnectionTestConnection.Location = new System.Drawing.Point(3, 354);
            this.buttonDbConnectionTestConnection.Name = "buttonDbConnectionTestConnection";
            this.buttonDbConnectionTestConnection.Size = new System.Drawing.Size(115, 23);
            this.buttonDbConnectionTestConnection.TabIndex = 15;
            this.buttonDbConnectionTestConnection.Text = "Test Connection";
            this.buttonDbConnectionTestConnection.UseVisualStyleBackColor = true;
            // 
            // buttonAddUpdate
            // 
            this.buttonAddUpdate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAddUpdate.Location = new System.Drawing.Point(265, 354);
            this.buttonAddUpdate.Name = "buttonAddUpdate";
            this.buttonAddUpdate.Size = new System.Drawing.Size(115, 23);
            this.buttonAddUpdate.TabIndex = 16;
            this.buttonAddUpdate.Text = "Add / Update";
            this.buttonAddUpdate.UseVisualStyleBackColor = true;
            this.buttonAddUpdate.Visible = false;
            // 
            // tabControlDatabase
            // 
            this.tabControlDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlDatabase.Controls.Add(this.tabPageDbStructure);
            this.tabControlDatabase.Controls.Add(this.tabPageDbUnit);
            this.tabControlDatabase.Controls.Add(this.tabPageDbTransformation);
            this.tabControlDatabase.Controls.Add(this.tabPageImportTags);
            this.tabControlDatabase.Location = new System.Drawing.Point(0, 3);
            this.tabControlDatabase.Name = "tabControlDatabase";
            this.tabControlDatabase.SelectedIndex = 0;
            this.tabControlDatabase.Size = new System.Drawing.Size(384, 335);
            this.tabControlDatabase.TabIndex = 17;
            // 
            // tabPageDbStructure
            // 
            this.tabPageDbStructure.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDbStructure.Controls.Add(this.databaseConnectionControl);
            this.tabPageDbStructure.Location = new System.Drawing.Point(4, 22);
            this.tabPageDbStructure.Name = "tabPageDbStructure";
            this.tabPageDbStructure.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDbStructure.Size = new System.Drawing.Size(376, 309);
            this.tabPageDbStructure.TabIndex = 0;
            this.tabPageDbStructure.Text = "Db Structure";
            // 
            // databaseConnectionControl
            // 
            this.databaseConnectionControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.databaseConnectionControl.HaestadContainerControlModel = null;
            this.databaseConnectionControl.Location = new System.Drawing.Point(3, 3);
            this.databaseConnectionControl.MinimumSize = new System.Drawing.Size(376, 609);
            this.databaseConnectionControl.Name = "databaseConnectionControl";
            this.databaseConnectionControl.Size = new System.Drawing.Size(376, 609);
            this.databaseConnectionControl.TabIndex = 0;
            // 
            // tabPageDbUnit
            // 
            this.tabPageDbUnit.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDbUnit.Controls.Add(this.signalUnitControl);
            this.tabPageDbUnit.Location = new System.Drawing.Point(4, 22);
            this.tabPageDbUnit.Name = "tabPageDbUnit";
            this.tabPageDbUnit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageDbUnit.Size = new System.Drawing.Size(376, 309);
            this.tabPageDbUnit.TabIndex = 1;
            this.tabPageDbUnit.Text = "Units";
            // 
            // signalUnitControl
            // 
            this.signalUnitControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalUnitControl.HaestadContainerControlModel = null;
            this.signalUnitControl.Location = new System.Drawing.Point(3, 3);
            this.signalUnitControl.Name = "signalUnitControl";
            this.signalUnitControl.Size = new System.Drawing.Size(370, 303);
            this.signalUnitControl.TabIndex = 0;
            // 
            // tabPageDbTransformation
            // 
            this.tabPageDbTransformation.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageDbTransformation.Controls.Add(this.signalTransformationControl);
            this.tabPageDbTransformation.Location = new System.Drawing.Point(4, 22);
            this.tabPageDbTransformation.Name = "tabPageDbTransformation";
            this.tabPageDbTransformation.Size = new System.Drawing.Size(376, 309);
            this.tabPageDbTransformation.TabIndex = 2;
            this.tabPageDbTransformation.Text = "Signal Value Mapping";
            // 
            // signalTransformationControl
            // 
            this.signalTransformationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalTransformationControl.HaestadContainerControlModel = null;
            this.signalTransformationControl.Location = new System.Drawing.Point(0, 0);
            this.signalTransformationControl.Name = "signalTransformationControl";
            this.signalTransformationControl.Size = new System.Drawing.Size(376, 309);
            this.signalTransformationControl.TabIndex = 0;
            // 
            // tabPageImportTags
            // 
            this.tabPageImportTags.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageImportTags.Controls.Add(this.signalsImportFromDatabaseControl1);
            this.tabPageImportTags.Location = new System.Drawing.Point(4, 22);
            this.tabPageImportTags.Name = "tabPageImportTags";
            this.tabPageImportTags.Size = new System.Drawing.Size(376, 309);
            this.tabPageImportTags.TabIndex = 3;
            this.tabPageImportTags.Text = "Import Tags";
            // 
            // signalsImportFromDatabaseControl1
            // 
            this.signalsImportFromDatabaseControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalsImportFromDatabaseControl1.HaestadContainerControlModel = null;
            this.signalsImportFromDatabaseControl1.Location = new System.Drawing.Point(0, 0);
            this.signalsImportFromDatabaseControl1.Name = "signalsImportFromDatabaseControl1";
            this.signalsImportFromDatabaseControl1.Size = new System.Drawing.Size(376, 309);
            this.signalsImportFromDatabaseControl1.TabIndex = 0;
            // 
            // DatabaseConnectionConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlDatabase);
            this.Controls.Add(this.buttonAddUpdate);
            this.Controls.Add(this.buttonDbConnectionTestConnection);
            this.Name = "DatabaseConnectionConfigControl";
            this.Size = new System.Drawing.Size(384, 392);
            this.tabControlDatabase.ResumeLayout(false);
            this.tabPageDbStructure.ResumeLayout(false);
            this.tabPageDbUnit.ResumeLayout(false);
            this.tabPageDbTransformation.ResumeLayout(false);
            this.tabPageImportTags.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button buttonDbConnectionTestConnection;
        private System.Windows.Forms.Button buttonAddUpdate;
        private System.Windows.Forms.TabControl tabControlDatabase;
        private System.Windows.Forms.TabPage tabPageDbStructure;
        private System.Windows.Forms.TabPage tabPageDbUnit;
        private System.Windows.Forms.TabPage tabPageDbTransformation;
        private DatabaseConnectionControl databaseConnectionControl;
        private SignalUnitControl signalUnitControl;
        private SignalTransformationControl signalTransformationControl;
        private System.Windows.Forms.TabPage tabPageImportTags;
        private SignalsImportFromDatabaseControl signalsImportFromDatabaseControl1;
    }
}
