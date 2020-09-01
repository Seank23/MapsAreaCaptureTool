namespace RenderDoc_Area_Capture
{
    partial class RenderDocAreaCapture
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenderDocAreaCapture));
            this.panel1 = new System.Windows.Forms.Panel();
            this.rtbResult = new System.Windows.Forms.RichTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSelCoordLower = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSelCoordUpper = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.txtCamAlt = new System.Windows.Forms.TextBox();
            this.chbCustomQuality = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LblQuality = new System.Windows.Forms.Label();
            this.tbQuality = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.axMap1 = new AxMapWinGIS.AxMap();
            this.chbAlignCaptures = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuality)).BeginInit();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMap1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.chbAlignCaptures);
            this.panel1.Controls.Add(this.rtbResult);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtSelCoordLower);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtSelCoordUpper);
            this.panel1.Controls.Add(this.btnCalculate);
            this.panel1.Controls.Add(this.txtCamAlt);
            this.panel1.Controls.Add(this.chbCustomQuality);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.LblQuality);
            this.panel1.Controls.Add(this.tbQuality);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(964, 28);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(303, 755);
            this.panel1.TabIndex = 0;
            // 
            // rtbResult
            // 
            this.rtbResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbResult.Location = new System.Drawing.Point(0, 323);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.ReadOnly = true;
            this.rtbResult.Size = new System.Drawing.Size(303, 432);
            this.rtbResult.TabIndex = 11;
            this.rtbResult.Text = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 49);
            this.label3.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Lower-Right:";
            // 
            // txtSelCoordLower
            // 
            this.txtSelCoordLower.Location = new System.Drawing.Point(106, 46);
            this.txtSelCoordLower.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.txtSelCoordLower.Name = "txtSelCoordLower";
            this.txtSelCoordLower.Size = new System.Drawing.Size(177, 22);
            this.txtSelCoordLower.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(20, 0, 3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Upper-Left:";
            // 
            // txtSelCoordUpper
            // 
            this.txtSelCoordUpper.Location = new System.Drawing.Point(106, 17);
            this.txtSelCoordUpper.Margin = new System.Windows.Forms.Padding(3, 3, 20, 3);
            this.txtSelCoordUpper.Name = "txtSelCoordUpper";
            this.txtSelCoordUpper.Size = new System.Drawing.Size(177, 22);
            this.txtSelCoordUpper.TabIndex = 7;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(87, 255);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(132, 34);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtCamAlt
            // 
            this.txtCamAlt.Location = new System.Drawing.Point(87, 127);
            this.txtCamAlt.Name = "txtCamAlt";
            this.txtCamAlt.Size = new System.Drawing.Size(107, 22);
            this.txtCamAlt.TabIndex = 4;
            this.txtCamAlt.Visible = false;
            this.txtCamAlt.TextChanged += new System.EventHandler(this.txtCamAlt_TextChanged);
            // 
            // chbCustomQuality
            // 
            this.chbCustomQuality.AutoSize = true;
            this.chbCustomQuality.Location = new System.Drawing.Point(206, 130);
            this.chbCustomQuality.Name = "chbCustomQuality";
            this.chbCustomQuality.Size = new System.Drawing.Size(77, 21);
            this.chbCustomQuality.TabIndex = 3;
            this.chbCustomQuality.Text = "Custom";
            this.chbCustomQuality.UseVisualStyleBackColor = true;
            this.chbCustomQuality.CheckedChanged += new System.EventHandler(this.chbCustomQuality_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 130);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Quality:";
            // 
            // LblQuality
            // 
            this.LblQuality.AutoSize = true;
            this.LblQuality.Location = new System.Drawing.Point(73, 158);
            this.LblQuality.MinimumSize = new System.Drawing.Size(146, 17);
            this.LblQuality.Name = "LblQuality";
            this.LblQuality.Size = new System.Drawing.Size(146, 17);
            this.LblQuality.TabIndex = 1;
            this.LblQuality.Text = "High";
            this.LblQuality.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbQuality
            // 
            this.tbQuality.Location = new System.Drawing.Point(87, 119);
            this.tbQuality.Maximum = 3;
            this.tbQuality.Name = "tbQuality";
            this.tbQuality.Size = new System.Drawing.Size(111, 56);
            this.tbQuality.TabIndex = 0;
            this.tbQuality.Value = 2;
            this.tbQuality.Scroll += new System.EventHandler(this.tbQuality_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1267, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveAsToolStripMenuItem,
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // axMap1
            // 
            this.axMap1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axMap1.Enabled = true;
            this.axMap1.Location = new System.Drawing.Point(0, 28);
            this.axMap1.Name = "axMap1";
            this.axMap1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axMap1.OcxState")));
            this.axMap1.Size = new System.Drawing.Size(964, 755);
            this.axMap1.TabIndex = 2;
            // 
            // chbAlignCaptures
            // 
            this.chbAlignCaptures.AutoSize = true;
            this.chbAlignCaptures.Location = new System.Drawing.Point(28, 196);
            this.chbAlignCaptures.Name = "chbAlignCaptures";
            this.chbAlignCaptures.Size = new System.Drawing.Size(122, 21);
            this.chbAlignCaptures.TabIndex = 12;
            this.chbAlignCaptures.Text = "Align Captures";
            this.chbAlignCaptures.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(23, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Settings:";
            // 
            // RenderDocAreaCapture
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 783);
            this.Controls.Add(this.axMap1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RenderDocAreaCapture";
            this.Text = "MapsAreaCaptureTool";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuality)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axMap1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label LblQuality;
        private System.Windows.Forms.TrackBar tbQuality;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chbCustomQuality;
        private System.Windows.Forms.TextBox txtCamAlt;
        private AxMapWinGIS.AxMap axMap1;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSelCoordLower;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSelCoordUpper;
        private System.Windows.Forms.RichTextBox rtbResult;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.CheckBox chbAlignCaptures;
        private System.Windows.Forms.Label label4;
    }
}

