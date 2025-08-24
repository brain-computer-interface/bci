namespace SpikeDetectorRMS
{
    partial class SpikeDetectorRMSControl
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
            splcSD = new SplitContainer();
            lbxDetectedSpikes = new ListBox();
            btLoad = new Button();
            btSave = new Button();
            btCalculate = new Button();
            label1 = new Label();
            lbWindowSize = new Label();
            lbRMS = new Label();
            numTextBox2 = new ControlsUI.NumTextBox();
            numTextBox1 = new ControlsUI.NumTextBox();
            ntbRMS = new ControlsUI.NumTextBox();
            panel1 = new Panel();
            trbTime = new TrackBar();
            pnCharts = new Panel();
            chartsControl1 = new ControlsUI.ChartsControl();
            ((System.ComponentModel.ISupportInitialize)splcSD).BeginInit();
            splcSD.Panel1.SuspendLayout();
            splcSD.Panel2.SuspendLayout();
            splcSD.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trbTime).BeginInit();
            pnCharts.SuspendLayout();
            SuspendLayout();
            // 
            // splcSD
            // 
            splcSD.Dock = DockStyle.Fill;
            splcSD.Location = new Point(0, 0);
            splcSD.Name = "splcSD";
            // 
            // splcSD.Panel1
            // 
            splcSD.Panel1.Controls.Add(lbxDetectedSpikes);
            splcSD.Panel1.Controls.Add(btLoad);
            splcSD.Panel1.Controls.Add(btSave);
            splcSD.Panel1.Controls.Add(btCalculate);
            splcSD.Panel1.Controls.Add(label1);
            splcSD.Panel1.Controls.Add(lbWindowSize);
            splcSD.Panel1.Controls.Add(lbRMS);
            splcSD.Panel1.Controls.Add(numTextBox2);
            splcSD.Panel1.Controls.Add(numTextBox1);
            splcSD.Panel1.Controls.Add(ntbRMS);
            splcSD.Panel1MinSize = 200;
            // 
            // splcSD.Panel2
            // 
            splcSD.Panel2.Controls.Add(panel1);
            splcSD.Panel2.Controls.Add(pnCharts);
            splcSD.Size = new Size(1205, 724);
            splcSD.SplitterDistance = 329;
            splcSD.TabIndex = 0;
            // 
            // lbxDetectedSpikes
            // 
            lbxDetectedSpikes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lbxDetectedSpikes.FormattingEnabled = true;
            lbxDetectedSpikes.Location = new Point(13, 218);
            lbxDetectedSpikes.Name = "lbxDetectedSpikes";
            lbxDetectedSpikes.Size = new Size(301, 424);
            lbxDetectedSpikes.TabIndex = 9;
            lbxDetectedSpikes.SelectedIndexChanged += lbxDetectedSpikes_SelectedIndexChanged;
            // 
            // btLoad
            // 
            btLoad.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btLoad.Location = new Point(10, 692);
            btLoad.Name = "btLoad";
            btLoad.Size = new Size(304, 29);
            btLoad.TabIndex = 8;
            btLoad.Text = "Load";
            btLoad.UseVisualStyleBackColor = true;
            btLoad.Click += btLoad_Click;
            // 
            // btSave
            // 
            btSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            btSave.Location = new Point(10, 657);
            btSave.Name = "btSave";
            btSave.Size = new Size(304, 29);
            btSave.TabIndex = 7;
            btSave.Text = "Save";
            btSave.UseVisualStyleBackColor = true;
            btSave.Click += btSave_Click;
            // 
            // btCalculate
            // 
            btCalculate.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btCalculate.Location = new Point(10, 176);
            btCalculate.Name = "btCalculate";
            btCalculate.Size = new Size(304, 29);
            btCalculate.TabIndex = 6;
            btCalculate.Text = "Calculate";
            btCalculate.UseVisualStyleBackColor = true;
            btCalculate.Click += btCalculate_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 119);
            label1.Name = "label1";
            label1.Size = new Size(174, 20);
            label1.TabIndex = 5;
            label1.Text = "Block size, window count";
            // 
            // lbWindowSize
            // 
            lbWindowSize.AutoSize = true;
            lbWindowSize.Location = new Point(15, 73);
            lbWindowSize.Name = "lbWindowSize";
            lbWindowSize.Size = new Size(121, 20);
            lbWindowSize.TabIndex = 4;
            lbWindowSize.Text = "Window Size, ms";
            // 
            // lbRMS
            // 
            lbRMS.AutoSize = true;
            lbRMS.Location = new Point(15, 26);
            lbRMS.Name = "lbRMS";
            lbRMS.Size = new Size(39, 20);
            lbRMS.TabIndex = 3;
            lbRMS.Text = "RMS";
            // 
            // numTextBox2
            // 
            numTextBox2.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numTextBox2.Location = new Point(190, 116);
            numTextBox2.MaxValue = 0L;
            numTextBox2.MinValue = 0L;
            numTextBox2.Mode = ControlsUI.NumTextBox.MODE.DEC;
            numTextBox2.Name = "numTextBox2";
            numTextBox2.Size = new Size(124, 27);
            numTextBox2.TabIndex = 2;
            numTextBox2.Value = 0L;
            // 
            // numTextBox1
            // 
            numTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            numTextBox1.Location = new Point(142, 70);
            numTextBox1.MaxValue = 0L;
            numTextBox1.MinValue = 0L;
            numTextBox1.Mode = ControlsUI.NumTextBox.MODE.DEC;
            numTextBox1.Name = "numTextBox1";
            numTextBox1.Size = new Size(172, 27);
            numTextBox1.TabIndex = 1;
            numTextBox1.Value = 0L;
            // 
            // ntbRMS
            // 
            ntbRMS.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            ntbRMS.Location = new Point(60, 23);
            ntbRMS.MaxValue = 0L;
            ntbRMS.MinValue = 0L;
            ntbRMS.Mode = ControlsUI.NumTextBox.MODE.DEC;
            ntbRMS.Name = "ntbRMS";
            ntbRMS.Size = new Size(254, 27);
            ntbRMS.TabIndex = 0;
            ntbRMS.Value = 0L;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            panel1.Controls.Add(trbTime);
            panel1.Location = new Point(3, 676);
            panel1.Name = "panel1";
            panel1.Size = new Size(866, 45);
            panel1.TabIndex = 1;
            // 
            // trbTime
            // 
            trbTime.Dock = DockStyle.Fill;
            trbTime.Location = new Point(0, 0);
            trbTime.Name = "trbTime";
            trbTime.Size = new Size(866, 45);
            trbTime.TabIndex = 0;
            // 
            // pnCharts
            // 
            pnCharts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnCharts.Controls.Add(chartsControl1);
            pnCharts.Location = new Point(3, 3);
            pnCharts.Name = "pnCharts";
            pnCharts.Size = new Size(866, 657);
            pnCharts.TabIndex = 0;
            // 
            // chartsControl1
            // 
            chartsControl1.Dock = DockStyle.Fill;
            chartsControl1.Location = new Point(0, 0);
            chartsControl1.Name = "chartsControl1";
            chartsControl1.Size = new Size(866, 657);
            chartsControl1.TabIndex = 0;
            // 
            // SpikeDetectorRMSControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splcSD);
            Name = "SpikeDetectorRMSControl";
            Size = new Size(1205, 724);
            splcSD.Panel1.ResumeLayout(false);
            splcSD.Panel1.PerformLayout();
            splcSD.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splcSD).EndInit();
            splcSD.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trbTime).EndInit();
            pnCharts.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private SplitContainer splcSD;
        private ControlsUI.ChartsControl chartsControl1;
        private Panel pnCharts;
        private Panel panel1;
        private TrackBar trbTime;
        private Label label1;
        private Label lbWindowSize;
        private Label lbRMS;
        private ControlsUI.NumTextBox numTextBox2;
        private ControlsUI.NumTextBox numTextBox1;
        private ControlsUI.NumTextBox ntbRMS;
        private ListBox lbxDetectedSpikes;
        private Button btLoad;
        private Button btSave;
        private Button btCalculate;
    }
}
