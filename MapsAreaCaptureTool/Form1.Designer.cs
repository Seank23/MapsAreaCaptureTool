namespace MapsAreaCaptureTool
{
    partial class MapsAreaCaptureTool
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnRemove = new System.Windows.Forms.Button();
            this.chbCentre = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.numOverlap = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.chbAlignCaptures = new System.Windows.Forms.CheckBox();
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
            this.captureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gMapControl = new GMap.NET.WindowsForms.GMapControl();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOverlap)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuality)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.chbCentre);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.numOverlap);
            this.panel1.Controls.Add(this.label5);
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
            this.panel1.Location = new System.Drawing.Point(941, 28);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(326, 755);
            this.panel1.TabIndex = 0;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(166, 267);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(132, 34);
            this.btnRemove.TabIndex = 18;
            this.btnRemove.Text = "Remove";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // chbCentre
            // 
            this.chbCentre.AutoSize = true;
            this.chbCentre.Checked = true;
            this.chbCentre.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCentre.Location = new System.Drawing.Point(148, 222);
            this.chbCentre.Name = "chbCentre";
            this.chbCentre.Size = new System.Drawing.Size(150, 21);
            this.chbCentre.TabIndex = 17;
            this.chbCentre.Text = "Centre to Selection";
            this.chbCentre.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(212, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(20, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "%";
            // 
            // numOverlap
            // 
            this.numOverlap.Location = new System.Drawing.Point(96, 181);
            this.numOverlap.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numOverlap.Name = "numOverlap";
            this.numOverlap.Size = new System.Drawing.Size(107, 22);
            this.numOverlap.TabIndex = 15;
            this.numOverlap.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Overlap:";
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
            // chbAlignCaptures
            // 
            this.chbAlignCaptures.AutoSize = true;
            this.chbAlignCaptures.Checked = true;
            this.chbAlignCaptures.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbAlignCaptures.Location = new System.Drawing.Point(15, 222);
            this.chbAlignCaptures.Name = "chbAlignCaptures";
            this.chbAlignCaptures.Size = new System.Drawing.Size(122, 21);
            this.chbAlignCaptures.TabIndex = 12;
            this.chbAlignCaptures.Text = "Align Captures";
            this.chbAlignCaptures.UseVisualStyleBackColor = true;
            // 
            // rtbResult
            // 
            this.rtbResult.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbResult.Location = new System.Drawing.Point(3, 325);
            this.rtbResult.Margin = new System.Windows.Forms.Padding(0);
            this.rtbResult.Name = "rtbResult";
            this.rtbResult.ReadOnly = true;
            this.rtbResult.Size = new System.Drawing.Size(320, 430);
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
            this.btnCalculate.Location = new System.Drawing.Point(28, 267);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(132, 34);
            this.btnCalculate.TabIndex = 5;
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // txtCamAlt
            // 
            this.txtCamAlt.Location = new System.Drawing.Point(96, 127);
            this.txtCamAlt.Name = "txtCamAlt";
            this.txtCamAlt.Size = new System.Drawing.Size(107, 22);
            this.txtCamAlt.TabIndex = 4;
            this.txtCamAlt.Visible = false;
            this.txtCamAlt.TextChanged += new System.EventHandler(this.txtCamAlt_TextChanged);
            // 
            // chbCustomQuality
            // 
            this.chbCustomQuality.AutoSize = true;
            this.chbCustomQuality.Location = new System.Drawing.Point(215, 130);
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
            this.LblQuality.Location = new System.Drawing.Point(82, 158);
            this.LblQuality.MinimumSize = new System.Drawing.Size(146, 17);
            this.LblQuality.Name = "LblQuality";
            this.LblQuality.Size = new System.Drawing.Size(146, 17);
            this.LblQuality.TabIndex = 1;
            this.LblQuality.Text = "High";
            this.LblQuality.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbQuality
            // 
            this.tbQuality.Location = new System.Drawing.Point(96, 119);
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
            this.fileToolStripMenuItem,
            this.captureToolStripMenuItem});
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
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveAsToolStripMenuItem.Text = "Save As...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.openToolStripMenuItem.Text = "Open...";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // captureToolStripMenuItem
            // 
            this.captureToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.captureToolStripMenuItem.Name = "captureToolStripMenuItem";
            this.captureToolStripMenuItem.Size = new System.Drawing.Size(75, 24);
            this.captureToolStripMenuItem.Text = "Capture";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // gMapControl
            // 
            this.gMapControl.Bearing = 0F;
            this.gMapControl.CanDragMap = true;
            this.gMapControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gMapControl.EmptyTileColor = System.Drawing.Color.Navy;
            this.gMapControl.GrayScaleMode = false;
            this.gMapControl.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.gMapControl.LevelsKeepInMemory = 5;
            this.gMapControl.Location = new System.Drawing.Point(0, 28);
            this.gMapControl.MarkersEnabled = true;
            this.gMapControl.MaxZoom = 2;
            this.gMapControl.MinZoom = 2;
            this.gMapControl.MouseWheelZoomEnabled = true;
            this.gMapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.gMapControl.Name = "gMapControl";
            this.gMapControl.NegativeMode = false;
            this.gMapControl.PolygonsEnabled = true;
            this.gMapControl.RetryLoadTile = 0;
            this.gMapControl.RoutesEnabled = true;
            this.gMapControl.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.gMapControl.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.gMapControl.ShowTileGridLines = false;
            this.gMapControl.Size = new System.Drawing.Size(941, 755);
            this.gMapControl.TabIndex = 2;
            this.gMapControl.Zoom = 0D;
            this.gMapControl.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gMapControl_MouseDoubleClick);
            this.gMapControl.MouseDown += new System.Windows.Forms.MouseEventHandler(this.gMapControl_MouseDown);
            this.gMapControl.MouseUp += new System.Windows.Forms.MouseEventHandler(this.gMapControl_MouseUp);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // MapsAreaCaptureTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1267, 783);
            this.Controls.Add(this.gMapControl);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MapsAreaCaptureTool";
            this.Text = "MapsAreaCaptureTool";
            this.Load += new System.EventHandler(this.MapsAreaCaptureTool_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOverlap)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbQuality)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        private GMap.NET.WindowsForms.GMapControl gMapControl;
        private System.Windows.Forms.ToolStripMenuItem captureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown numOverlap;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbCentre;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
    }
}

