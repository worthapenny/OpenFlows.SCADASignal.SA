using OpenFlows.SCADASignal.SA.Components.Support;

namespace OpenFlows.SCADASignal.SA.Components.Shared
{
    partial class SignalTransformationControl
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
            this.groupBoxPump = new System.Windows.Forms.GroupBox();
            this.inputComboBoxFieldPumpType = new OpenFlows.SCADASignal.SA.Components.Support.InputComboBoxField();
            this.inputComboBoxFieldPumpOn = new OpenFlows.SCADASignal.SA.Components.Support.InputComboBoxField();
            this.inputComboBoxFieldPumpOff = new OpenFlows.SCADASignal.SA.Components.Support.InputComboBoxField();
            this.textBoxPumpOnValue = new System.Windows.Forms.TextBox();
            this.textBoxPumpOffValue = new System.Windows.Forms.TextBox();
            this.groupBoxValve = new System.Windows.Forms.GroupBox();
            this.textBoxValveCloseValue = new System.Windows.Forms.TextBox();
            this.textBoxValveActiveValue = new System.Windows.Forms.TextBox();
            this.inputComboBoxFieldValveClosed = new OpenFlows.SCADASignal.SA.Components.Support.InputComboBoxField();
            this.inputComboBoxFieldValveActive = new OpenFlows.SCADASignal.SA.Components.Support.InputComboBoxField();
            this.inputComboBoxFieldValveType = new OpenFlows.SCADASignal.SA.Components.Support.InputComboBoxField();
            this.groupBoxPump.SuspendLayout();
            this.groupBoxValve.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPump
            // 
            this.groupBoxPump.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxPump.Controls.Add(this.textBoxPumpOffValue);
            this.groupBoxPump.Controls.Add(this.textBoxPumpOnValue);
            this.groupBoxPump.Controls.Add(this.inputComboBoxFieldPumpOff);
            this.groupBoxPump.Controls.Add(this.inputComboBoxFieldPumpOn);
            this.groupBoxPump.Controls.Add(this.inputComboBoxFieldPumpType);
            this.groupBoxPump.Location = new System.Drawing.Point(3, 0);
            this.groupBoxPump.Name = "groupBoxPump";
            this.groupBoxPump.Size = new System.Drawing.Size(360, 110);
            this.groupBoxPump.TabIndex = 0;
            this.groupBoxPump.TabStop = false;
            this.groupBoxPump.Text = "Pump Signal Mapping";
            // 
            // inputComboBoxFieldPumpType
            // 
            this.inputComboBoxFieldPumpType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputComboBoxFieldPumpType.Label = "Type";
            this.inputComboBoxFieldPumpType.Location = new System.Drawing.Point(6, 19);
            this.inputComboBoxFieldPumpType.Name = "inputComboBoxFieldPumpType";
            this.inputComboBoxFieldPumpType.Size = new System.Drawing.Size(348, 21);
            this.inputComboBoxFieldPumpType.TabIndex = 0;
            // 
            // inputComboBoxFieldPumpOn
            // 
            this.inputComboBoxFieldPumpOn.Label = "On (0)";
            this.inputComboBoxFieldPumpOn.Location = new System.Drawing.Point(6, 46);
            this.inputComboBoxFieldPumpOn.Name = "inputComboBoxFieldPumpOn";
            this.inputComboBoxFieldPumpOn.Size = new System.Drawing.Size(265, 21);
            this.inputComboBoxFieldPumpOn.TabIndex = 1;
            // 
            // inputComboBoxFieldPumpOff
            // 
            this.inputComboBoxFieldPumpOff.Label = "Off (1)";
            this.inputComboBoxFieldPumpOff.Location = new System.Drawing.Point(6, 73);
            this.inputComboBoxFieldPumpOff.Name = "inputComboBoxFieldPumpOff";
            this.inputComboBoxFieldPumpOff.Size = new System.Drawing.Size(265, 21);
            this.inputComboBoxFieldPumpOff.TabIndex = 3;
            // 
            // textBoxPumpOnValue
            // 
            this.textBoxPumpOnValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPumpOnValue.Location = new System.Drawing.Point(277, 47);
            this.textBoxPumpOnValue.Name = "textBoxPumpOnValue";
            this.textBoxPumpOnValue.Size = new System.Drawing.Size(77, 20);
            this.textBoxPumpOnValue.TabIndex = 2;
            // 
            // textBoxPumpOffValue
            // 
            this.textBoxPumpOffValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPumpOffValue.Location = new System.Drawing.Point(277, 73);
            this.textBoxPumpOffValue.Name = "textBoxPumpOffValue";
            this.textBoxPumpOffValue.Size = new System.Drawing.Size(77, 20);
            this.textBoxPumpOffValue.TabIndex = 4;
            // 
            // groupBoxValve
            // 
            this.groupBoxValve.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxValve.Controls.Add(this.textBoxValveCloseValue);
            this.groupBoxValve.Controls.Add(this.textBoxValveActiveValue);
            this.groupBoxValve.Controls.Add(this.inputComboBoxFieldValveClosed);
            this.groupBoxValve.Controls.Add(this.inputComboBoxFieldValveActive);
            this.groupBoxValve.Controls.Add(this.inputComboBoxFieldValveType);
            this.groupBoxValve.Location = new System.Drawing.Point(3, 116);
            this.groupBoxValve.Name = "groupBoxValve";
            this.groupBoxValve.Size = new System.Drawing.Size(360, 110);
            this.groupBoxValve.TabIndex = 0;
            this.groupBoxValve.TabStop = false;
            this.groupBoxValve.Text = "Valve Signal Mapping";
            // 
            // textBoxValveCloseValue
            // 
            this.textBoxValveCloseValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxValveCloseValue.Location = new System.Drawing.Point(277, 73);
            this.textBoxValveCloseValue.Name = "textBoxValveCloseValue";
            this.textBoxValveCloseValue.Size = new System.Drawing.Size(77, 20);
            this.textBoxValveCloseValue.TabIndex = 4;
            // 
            // textBoxValveActiveValue
            // 
            this.textBoxValveActiveValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxValveActiveValue.Location = new System.Drawing.Point(277, 47);
            this.textBoxValveActiveValue.Name = "textBoxValveActiveValue";
            this.textBoxValveActiveValue.Size = new System.Drawing.Size(77, 20);
            this.textBoxValveActiveValue.TabIndex = 2;
            // 
            // inputComboBoxFieldValveClosed
            // 
            this.inputComboBoxFieldValveClosed.Label = "Closed (2)";
            this.inputComboBoxFieldValveClosed.Location = new System.Drawing.Point(6, 73);
            this.inputComboBoxFieldValveClosed.Name = "inputComboBoxFieldValveClosed";
            this.inputComboBoxFieldValveClosed.Size = new System.Drawing.Size(265, 21);
            this.inputComboBoxFieldValveClosed.TabIndex = 3;
            // 
            // inputComboBoxFieldValveActive
            // 
            this.inputComboBoxFieldValveActive.Label = "Active (0)";
            this.inputComboBoxFieldValveActive.Location = new System.Drawing.Point(6, 46);
            this.inputComboBoxFieldValveActive.Name = "inputComboBoxFieldValveActive";
            this.inputComboBoxFieldValveActive.Size = new System.Drawing.Size(265, 21);
            this.inputComboBoxFieldValveActive.TabIndex = 1;
            // 
            // inputComboBoxFieldValveType
            // 
            this.inputComboBoxFieldValveType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.inputComboBoxFieldValveType.Label = "Type";
            this.inputComboBoxFieldValveType.Location = new System.Drawing.Point(6, 19);
            this.inputComboBoxFieldValveType.Name = "inputComboBoxFieldValveType";
            this.inputComboBoxFieldValveType.Size = new System.Drawing.Size(348, 21);
            this.inputComboBoxFieldValveType.TabIndex = 0;
            // 
            // DatabaseTransformationControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBoxValve);
            this.Controls.Add(this.groupBoxPump);
            this.Name = "DatabaseTransformationControl";
            this.Size = new System.Drawing.Size(366, 232);
            this.groupBoxPump.ResumeLayout(false);
            this.groupBoxPump.PerformLayout();
            this.groupBoxValve.ResumeLayout(false);
            this.groupBoxValve.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPump;
        private InputComboBoxField inputComboBoxFieldPumpType;
        private System.Windows.Forms.TextBox textBoxPumpOffValue;
        private System.Windows.Forms.TextBox textBoxPumpOnValue;
        private InputComboBoxField inputComboBoxFieldPumpOff;
        private InputComboBoxField inputComboBoxFieldPumpOn;
        private System.Windows.Forms.GroupBox groupBoxValve;
        private System.Windows.Forms.TextBox textBoxValveCloseValue;
        private System.Windows.Forms.TextBox textBoxValveActiveValue;
        private InputComboBoxField inputComboBoxFieldValveClosed;
        private InputComboBoxField inputComboBoxFieldValveActive;
        private InputComboBoxField inputComboBoxFieldValveType;
    }
}
