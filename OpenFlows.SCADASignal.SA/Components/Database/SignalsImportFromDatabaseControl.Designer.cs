namespace OpenFlows.SCADASignal.SA.Components.Database
{
    partial class SignalsImportFromDatabaseControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignalsImportFromDatabaseControl));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLoadSignals = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonImport = new System.Windows.Forms.ToolStripButton();
            this.listViewSignals = new System.Windows.Forms.ListView();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoadSignals,
            this.toolStripSeparator1,
            this.toolStripButtonImport});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(64, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonLoadSignals
            // 
            this.toolStripButtonLoadSignals.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLoadSignals.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadSignals.Image")));
            this.toolStripButtonLoadSignals.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadSignals.Name = "toolStripButtonLoadSignals";
            this.toolStripButtonLoadSignals.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLoadSignals.Text = "Load All Available Signals";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonImport
            // 
            this.toolStripButtonImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonImport.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonImport.Image")));
            this.toolStripButtonImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonImport.Name = "toolStripButtonImport";
            this.toolStripButtonImport.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonImport.Text = "Import Selected Signals ";
            // 
            // listViewSignals
            // 
            this.listViewSignals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewSignals.CheckBoxes = true;
            this.listViewSignals.FullRowSelect = true;
            this.listViewSignals.GridLines = true;
            this.listViewSignals.HideSelection = false;
            this.listViewSignals.Location = new System.Drawing.Point(0, 28);
            this.listViewSignals.Name = "listViewSignals";
            this.listViewSignals.Size = new System.Drawing.Size(206, 90);
            this.listViewSignals.TabIndex = 1;
            this.listViewSignals.UseCompatibleStateImageBehavior = false;
            this.listViewSignals.View = System.Windows.Forms.View.Details;
            // 
            // SignalsImportFromDatabaseControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listViewSignals);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SignalsImportFromDatabaseControl";
            this.Size = new System.Drawing.Size(206, 118);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadSignals;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonImport;
        private System.Windows.Forms.ListView listViewSignals;
    }
}
