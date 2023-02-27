using OpenFlows.SCADASignal.SA.Components.Support;

namespace OpenFlows.SCADASignal.SA.Components.OPC
{
    partial class HOPCSourceControl
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
            this.inputFieldDataSourceLabel = new OpenFlows.SCADASignal.SA.Components.Support.InputField();
            this.inputFieldHost = new OpenFlows.SCADASignal.SA.Components.Support.InputField();
            this.inputFieldOPCServer = new OpenFlows.SCADASignal.SA.Components.Support.InputField();
            this.SuspendLayout();
            // 
            // inputFieldDataSourceLabel
            // 
            this.inputFieldDataSourceLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFieldDataSourceLabel.Label = "OPC Source Label";
            this.inputFieldDataSourceLabel.Location = new System.Drawing.Point(3, 3);
            this.inputFieldDataSourceLabel.Name = "inputFieldDataSourceLabel";
            this.inputFieldDataSourceLabel.Size = new System.Drawing.Size(407, 18);
            this.inputFieldDataSourceLabel.TabIndex = 0;
            this.inputFieldDataSourceLabel.Value = "";
            // 
            // inputFieldHost
            // 
            this.inputFieldHost.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFieldHost.Label = "Host Name / Address";
            this.inputFieldHost.Location = new System.Drawing.Point(3, 27);
            this.inputFieldHost.Name = "inputFieldHost";
            this.inputFieldHost.Size = new System.Drawing.Size(407, 18);
            this.inputFieldHost.TabIndex = 1;
            this.inputFieldHost.Value = "";
            // 
            // inputFieldOPCServer
            // 
            this.inputFieldOPCServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputFieldOPCServer.Label = "Server Name";
            this.inputFieldOPCServer.Location = new System.Drawing.Point(3, 51);
            this.inputFieldOPCServer.Name = "inputFieldOPCServer";
            this.inputFieldOPCServer.Size = new System.Drawing.Size(407, 18);
            this.inputFieldOPCServer.TabIndex = 2;
            this.inputFieldOPCServer.Value = "";
            // 
            // HOPCSourceControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.inputFieldOPCServer);
            this.Controls.Add(this.inputFieldHost);
            this.Controls.Add(this.inputFieldDataSourceLabel);
            this.Name = "HOPCSourceControl";
            this.Size = new System.Drawing.Size(414, 76);
            this.ResumeLayout(false);

        }

        #endregion

        private InputField inputFieldDataSourceLabel;
        private InputField inputFieldHost;
        private InputField inputFieldOPCServer;
    }
}
