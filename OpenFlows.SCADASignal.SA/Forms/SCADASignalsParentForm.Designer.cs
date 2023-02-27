namespace OpenFlows.SCADASignal.SA.Forms
{
    partial class SCADASignalsParentForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataSourceConnectionControl = new OpenFlows.SCADASignal.SA.Components.DataSourceConnectionControl();
            this.openWaterModelDatabaseControl = new OpenFlows.SCADASignal.SA.Components.OpenWaterDatabaseModelControl();
            this.SuspendLayout();
            // 
            // dataSourceConnectionControl
            // 
            this.dataSourceConnectionControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataSourceConnectionControl.HaestadContainerControlModel = null;
            this.dataSourceConnectionControl.Location = new System.Drawing.Point(12, 81);
            this.dataSourceConnectionControl.Name = "dataSourceConnectionControl";
            this.dataSourceConnectionControl.Size = new System.Drawing.Size(772, 695);
            this.dataSourceConnectionControl.TabIndex = 1;
            // 
            // openWaterModelDatabaseControl
            // 
            this.openWaterModelDatabaseControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openWaterModelDatabaseControl.HaestadContainerControlModel = null;
            this.openWaterModelDatabaseControl.Location = new System.Drawing.Point(12, 12);
            this.openWaterModelDatabaseControl.Name = "openWaterModelDatabaseControl";
            this.openWaterModelDatabaseControl.Size = new System.Drawing.Size(772, 89);
            this.openWaterModelDatabaseControl.TabIndex = 0;
            // 
            // SCADASignalsParentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 788);
            this.Controls.Add(this.dataSourceConnectionControl);
            this.Controls.Add(this.openWaterModelDatabaseControl);
            this.Name = "SCADASignalsParentForm";
            this.helpProviderHaestadForm.SetShowHelp(this, false);
            this.Text = "SCADA Signals SA";
            this.ResumeLayout(false);

        }

        #endregion

        private Components.OpenWaterDatabaseModelControl openWaterModelDatabaseControl;
        private Components.DataSourceConnectionControl dataSourceConnectionControl;
    }
}