namespace OpenFlows.SCADASignal.SA.Components
{
    partial class OpenWaterDatabaseModelControl
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
            this.buttonCreateNew = new System.Windows.Forms.Button();
            this.buttonBrowseOrOpen = new System.Windows.Forms.Button();
            this.textBoxModelFilePath = new System.Windows.Forms.TextBox();
            this.groupBoxModelControl = new System.Windows.Forms.GroupBox();
            this.groupBoxModelControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonCreateNew
            // 
            this.buttonCreateNew.Location = new System.Drawing.Point(6, 21);
            this.buttonCreateNew.Name = "buttonCreateNew";
            this.buttonCreateNew.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateNew.TabIndex = 2;
            this.buttonCreateNew.Text = "Create New";
            this.buttonCreateNew.UseVisualStyleBackColor = true;
            // 
            // buttonBrowseOrOpen
            // 
            this.buttonBrowseOrOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonBrowseOrOpen.Location = new System.Drawing.Point(229, 21);
            this.buttonBrowseOrOpen.Name = "buttonBrowseOrOpen";
            this.buttonBrowseOrOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowseOrOpen.TabIndex = 1;
            this.buttonBrowseOrOpen.Text = "Open";
            this.buttonBrowseOrOpen.UseVisualStyleBackColor = true;
            // 
            // textBoxModelFilePath
            // 
            this.textBoxModelFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxModelFilePath.Location = new System.Drawing.Point(87, 23);
            this.textBoxModelFilePath.Name = "textBoxModelFilePath";
            this.textBoxModelFilePath.Size = new System.Drawing.Size(136, 20);
            this.textBoxModelFilePath.TabIndex = 0;
            // 
            // groupBoxModelControl
            // 
            this.groupBoxModelControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxModelControl.Controls.Add(this.textBoxModelFilePath);
            this.groupBoxModelControl.Controls.Add(this.buttonCreateNew);
            this.groupBoxModelControl.Controls.Add(this.buttonBrowseOrOpen);
            this.groupBoxModelControl.Location = new System.Drawing.Point(0, 3);
            this.groupBoxModelControl.Name = "groupBoxModelControl";
            this.groupBoxModelControl.Size = new System.Drawing.Size(310, 59);
            this.groupBoxModelControl.TabIndex = 2;
            this.groupBoxModelControl.TabStop = false;
            this.groupBoxModelControl.Text = " New Model / Open Existing Model";
            // 
            // OpenWaterDatabaseModelControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxModelControl);
            this.Name = "OpenWaterDatabaseModelControl";
            this.Size = new System.Drawing.Size(313, 64);
            this.groupBoxModelControl.ResumeLayout(false);
            this.groupBoxModelControl.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCreateNew;
        private System.Windows.Forms.Button buttonBrowseOrOpen;
        private System.Windows.Forms.TextBox textBoxModelFilePath;
        private System.Windows.Forms.GroupBox groupBoxModelControl;
    }
}
