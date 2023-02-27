using OpenFlows.SCADASignal.SA.Components.Shared;

namespace OpenFlows.SCADASignal.SA.Components.OPC
{
    partial class HOPCConnectionConfigControl
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
            this.tabControlOPC = new System.Windows.Forms.TabControl();
            this.tabPageOPCSource = new System.Windows.Forms.TabPage();
            this.hopcSourceControl = new OpenFlows.SCADASignal.SA.Components.OPC.HOPCSourceControl();
            this.tabPageOPCUnit = new System.Windows.Forms.TabPage();
            this.tabPageOPCTransformation = new System.Windows.Forms.TabPage();
            this.signalUnitControl = new OpenFlows.SCADASignal.SA.Components.Shared.SignalUnitControl();
            this.signalTransformationControl = new OpenFlows.SCADASignal.SA.Components.Shared.SignalTransformationControl();
            this.tabControlOPC.SuspendLayout();
            this.tabPageOPCSource.SuspendLayout();
            this.tabPageOPCUnit.SuspendLayout();
            this.tabPageOPCTransformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlOPC
            // 
            this.tabControlOPC.Controls.Add(this.tabPageOPCSource);
            this.tabControlOPC.Controls.Add(this.tabPageOPCUnit);
            this.tabControlOPC.Controls.Add(this.tabPageOPCTransformation);
            this.tabControlOPC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlOPC.Location = new System.Drawing.Point(0, 0);
            this.tabControlOPC.Name = "tabControlOPC";
            this.tabControlOPC.SelectedIndex = 0;
            this.tabControlOPC.Size = new System.Drawing.Size(358, 328);
            this.tabControlOPC.TabIndex = 0;
            // 
            // tabPageOPCSource
            // 
            this.tabPageOPCSource.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageOPCSource.Controls.Add(this.hopcSourceControl);
            this.tabPageOPCSource.Location = new System.Drawing.Point(4, 22);
            this.tabPageOPCSource.Name = "tabPageOPCSource";
            this.tabPageOPCSource.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOPCSource.Size = new System.Drawing.Size(350, 302);
            this.tabPageOPCSource.TabIndex = 0;
            this.tabPageOPCSource.Text = "OPC Source";
            // 
            // hopcSourceControl
            // 
            this.hopcSourceControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hopcSourceControl.HaestadContainerControlModel = null;
            this.hopcSourceControl.Location = new System.Drawing.Point(3, 3);
            this.hopcSourceControl.Name = "hopcSourceControl";
            this.hopcSourceControl.Size = new System.Drawing.Size(344, 296);
            this.hopcSourceControl.TabIndex = 0;
            // 
            // tabPageOPCUnit
            // 
            this.tabPageOPCUnit.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageOPCUnit.Controls.Add(this.signalUnitControl);
            this.tabPageOPCUnit.Location = new System.Drawing.Point(4, 22);
            this.tabPageOPCUnit.Name = "tabPageOPCUnit";
            this.tabPageOPCUnit.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOPCUnit.Size = new System.Drawing.Size(350, 302);
            this.tabPageOPCUnit.TabIndex = 1;
            this.tabPageOPCUnit.Text = "Units";
            // 
            // tabPageOPCTransformation
            // 
            this.tabPageOPCTransformation.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageOPCTransformation.Controls.Add(this.signalTransformationControl);
            this.tabPageOPCTransformation.Location = new System.Drawing.Point(4, 22);
            this.tabPageOPCTransformation.Name = "tabPageOPCTransformation";
            this.tabPageOPCTransformation.Size = new System.Drawing.Size(350, 302);
            this.tabPageOPCTransformation.TabIndex = 2;
            this.tabPageOPCTransformation.Text = "Signal Value Mapping";
            // 
            // signalUnitControl
            // 
            this.signalUnitControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalUnitControl.HaestadContainerControlModel = null;
            this.signalUnitControl.Location = new System.Drawing.Point(3, 3);
            this.signalUnitControl.Name = "signalUnitControl";
            this.signalUnitControl.Size = new System.Drawing.Size(344, 296);
            this.signalUnitControl.TabIndex = 0;
            // 
            // signalTransformationControl
            // 
            this.signalTransformationControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.signalTransformationControl.HaestadContainerControlModel = null;
            this.signalTransformationControl.Location = new System.Drawing.Point(0, 0);
            this.signalTransformationControl.Name = "signalTransformationControl";
            this.signalTransformationControl.Size = new System.Drawing.Size(350, 302);
            this.signalTransformationControl.TabIndex = 0;
            // 
            // HOPCConnectionConfigControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlOPC);
            this.Name = "HOPCConnectionConfigControl";
            this.Size = new System.Drawing.Size(358, 328);
            this.tabControlOPC.ResumeLayout(false);
            this.tabPageOPCSource.ResumeLayout(false);
            this.tabPageOPCUnit.ResumeLayout(false);
            this.tabPageOPCTransformation.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlOPC;
        private System.Windows.Forms.TabPage tabPageOPCSource;
        private HOPCSourceControl hopcSourceControl;
        private System.Windows.Forms.TabPage tabPageOPCUnit;
        private System.Windows.Forms.TabPage tabPageOPCTransformation;
        private SignalUnitControl signalUnitControl;
        private SignalTransformationControl signalTransformationControl;
    }
}
