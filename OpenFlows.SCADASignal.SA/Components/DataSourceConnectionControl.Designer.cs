namespace OpenFlows.SCADASignal.SA.Components
{
    partial class DataSourceConnectionControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataSourceConnectionControl));
            this.treeViewDataSources = new System.Windows.Forms.TreeView();
            this.splitContainerMain = new System.Windows.Forms.SplitContainer();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripDropDownButtonNew = new System.Windows.Forms.ToolStripDropDownButton();
            this.toolStripMenuItemDatabaseSources = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOPCHistoricalSources = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSCADAConnectLog = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonLocalLog = new System.Windows.Forms.ToolStripButton();
            this.splitContainerDataSource = new System.Windows.Forms.SplitContainer();
            this.tabControlSCADAData = new System.Windows.Forms.TabControl();
            this.tabPagePreview = new System.Windows.Forms.TabPage();
            this.tabPageImportTagsFromFile = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
            this.splitContainerMain.Panel1.SuspendLayout();
            this.splitContainerMain.Panel2.SuspendLayout();
            this.splitContainerMain.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDataSource)).BeginInit();
            this.splitContainerDataSource.Panel2.SuspendLayout();
            this.splitContainerDataSource.SuspendLayout();
            this.tabControlSCADAData.SuspendLayout();
            this.SuspendLayout();
            // 
            // treeViewDataSources
            // 
            this.treeViewDataSources.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewDataSources.Location = new System.Drawing.Point(3, 28);
            this.treeViewDataSources.Name = "treeViewDataSources";
            this.treeViewDataSources.Size = new System.Drawing.Size(156, 394);
            this.treeViewDataSources.TabIndex = 1;
            // 
            // splitContainerMain
            // 
            this.splitContainerMain.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerMain.Location = new System.Drawing.Point(0, 0);
            this.splitContainerMain.Name = "splitContainerMain";
            // 
            // splitContainerMain.Panel1
            // 
            this.splitContainerMain.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerMain.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainerMain.Panel1.Controls.Add(this.treeViewDataSources);
            // 
            // splitContainerMain.Panel2
            // 
            this.splitContainerMain.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerMain.Panel2.Controls.Add(this.splitContainerDataSource);
            this.splitContainerMain.Size = new System.Drawing.Size(608, 425);
            this.splitContainerMain.SplitterDistance = 162;
            this.splitContainerMain.TabIndex = 2;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripDropDownButtonNew,
            this.toolStripButtonDelete,
            this.toolStripButtonSCADAConnectLog,
            this.toolStripButtonRefresh,
            this.toolStripSeparator1,
            this.toolStripButtonLocalLog});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(162, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripDropDownButtonNew
            // 
            this.toolStripDropDownButtonNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButtonNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDatabaseSources,
            this.toolStripMenuItemOPCHistoricalSources});
            this.toolStripDropDownButtonNew.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButtonNew.Image")));
            this.toolStripDropDownButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButtonNew.Name = "toolStripDropDownButtonNew";
            this.toolStripDropDownButtonNew.Size = new System.Drawing.Size(29, 22);
            this.toolStripDropDownButtonNew.Text = "New";
            // 
            // toolStripMenuItemDatabaseSources
            // 
            this.toolStripMenuItemDatabaseSources.Name = "toolStripMenuItemDatabaseSources";
            this.toolStripMenuItemDatabaseSources.Size = new System.Drawing.Size(204, 22);
            this.toolStripMenuItemDatabaseSources.Text = "&Database Sources..";
            // 
            // toolStripMenuItemOPCHistoricalSources
            // 
            this.toolStripMenuItemOPCHistoricalSources.Name = "toolStripMenuItemOPCHistoricalSources";
            this.toolStripMenuItemOPCHistoricalSources.Size = new System.Drawing.Size(204, 22);
            this.toolStripMenuItemOPCHistoricalSources.Text = "OPC &Historical Sources...";
            // 
            // toolStripButtonDelete
            // 
            this.toolStripButtonDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonDelete.Image")));
            this.toolStripButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonDelete.Name = "toolStripButtonDelete";
            this.toolStripButtonDelete.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonDelete.Text = "Delete";
            // 
            // toolStripButtonSCADAConnectLog
            // 
            this.toolStripButtonSCADAConnectLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSCADAConnectLog.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSCADAConnectLog.Image")));
            this.toolStripButtonSCADAConnectLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSCADAConnectLog.Name = "toolStripButtonSCADAConnectLog";
            this.toolStripButtonSCADAConnectLog.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSCADAConnectLog.Text = "SCADAConnect Log";
            // 
            // toolStripButtonRefresh
            // 
            this.toolStripButtonRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonRefresh.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonRefresh.Image")));
            this.toolStripButtonRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonRefresh.Name = "toolStripButtonRefresh";
            this.toolStripButtonRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonRefresh.Text = "Reload";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonLocalLog
            // 
            this.toolStripButtonLocalLog.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonLocalLog.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLocalLog.Image")));
            this.toolStripButtonLocalLog.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLocalLog.Name = "toolStripButtonLocalLog";
            this.toolStripButtonLocalLog.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonLocalLog.Text = "Load log of this tool";
            // 
            // splitContainerDataSource
            // 
            this.splitContainerDataSource.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitContainerDataSource.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDataSource.Location = new System.Drawing.Point(0, 0);
            this.splitContainerDataSource.Name = "splitContainerDataSource";
            this.splitContainerDataSource.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerDataSource.Panel1
            // 
            this.splitContainerDataSource.Panel1.BackColor = System.Drawing.SystemColors.Control;
            // 
            // splitContainerDataSource.Panel2
            // 
            this.splitContainerDataSource.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainerDataSource.Panel2.Controls.Add(this.tabControlSCADAData);
            this.splitContainerDataSource.Size = new System.Drawing.Size(442, 425);
            this.splitContainerDataSource.SplitterDistance = 227;
            this.splitContainerDataSource.TabIndex = 0;
            // 
            // tabControlSCADAData
            // 
            this.tabControlSCADAData.Controls.Add(this.tabPagePreview);
            this.tabControlSCADAData.Controls.Add(this.tabPageImportTagsFromFile);
            this.tabControlSCADAData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlSCADAData.Location = new System.Drawing.Point(0, 0);
            this.tabControlSCADAData.Name = "tabControlSCADAData";
            this.tabControlSCADAData.SelectedIndex = 0;
            this.tabControlSCADAData.Size = new System.Drawing.Size(442, 194);
            this.tabControlSCADAData.TabIndex = 0;
            // 
            // tabPagePreview
            // 
            this.tabPagePreview.BackColor = System.Drawing.SystemColors.Control;
            this.tabPagePreview.Location = new System.Drawing.Point(4, 22);
            this.tabPagePreview.Name = "tabPagePreview";
            this.tabPagePreview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePreview.Size = new System.Drawing.Size(434, 168);
            this.tabPagePreview.TabIndex = 0;
            this.tabPagePreview.Text = "Data Preview";
            // 
            // tabPageImportTagsFromFile
            // 
            this.tabPageImportTagsFromFile.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageImportTagsFromFile.Location = new System.Drawing.Point(4, 22);
            this.tabPageImportTagsFromFile.Name = "tabPageImportTagsFromFile";
            this.tabPageImportTagsFromFile.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageImportTagsFromFile.Size = new System.Drawing.Size(434, 168);
            this.tabPageImportTagsFromFile.TabIndex = 1;
            this.tabPageImportTagsFromFile.Text = "Import Tags (from File)";
            // 
            // DataSourceConnectionControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerMain);
            this.Name = "DataSourceConnectionControl";
            this.Size = new System.Drawing.Size(608, 425);
            this.splitContainerMain.Panel1.ResumeLayout(false);
            this.splitContainerMain.Panel1.PerformLayout();
            this.splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
            this.splitContainerMain.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainerDataSource.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDataSource)).EndInit();
            this.splitContainerDataSource.ResumeLayout(false);
            this.tabControlSCADAData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TreeView treeViewDataSources;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButtonNew;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDatabaseSources;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOPCHistoricalSources;
        private System.Windows.Forms.ToolStripButton toolStripButtonDelete;
        private System.Windows.Forms.ToolStripButton toolStripButtonSCADAConnectLog;
        private System.Windows.Forms.SplitContainer splitContainerDataSource;
        private System.Windows.Forms.TabControl tabControlSCADAData;
        private System.Windows.Forms.TabPage tabPagePreview;
        private System.Windows.Forms.TabPage tabPageImportTagsFromFile;
        private System.Windows.Forms.ToolStripButton toolStripButtonRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLocalLog;
    }
}
