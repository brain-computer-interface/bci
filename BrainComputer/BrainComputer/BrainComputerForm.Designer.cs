namespace BrainComputer
{
    partial class BrainComputerForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            msMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            deviceToolStripMenuItem = new ToolStripMenuItem();
            analysisToolStripMenuItem = new ToolStripMenuItem();
            filtersToolStripMenuItem = new ToolStripMenuItem();
            spikesDetectionToolStripMenuItem = new ToolStripMenuItem();
            spikesClusteringToolStripMenuItem = new ToolStripMenuItem();
            morphologyReconstructionToolStripMenuItem = new ToolStripMenuItem();
            programToolStripMenuItem = new ToolStripMenuItem();
            pnCharts = new Panel();
            fpCharts = new ScottPlot.WinForms.FormsPlot();
            pnTimeLine = new Panel();
            tbrTimeLine = new TrackBar();
            pnHeatMap = new Panel();
            fpHotMap = new ScottPlot.WinForms.FormsPlot();
            ttSampleNum = new ToolTip(components);
            pbProgress = new ProgressBar();
            tmRender = new System.Windows.Forms.Timer(components);
            lbInfo = new Label();
            msMenu.SuspendLayout();
            pnCharts.SuspendLayout();
            pnTimeLine.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tbrTimeLine).BeginInit();
            pnHeatMap.SuspendLayout();
            SuspendLayout();
            // 
            // msMenu
            // 
            msMenu.ImageScalingSize = new Size(20, 20);
            msMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, deviceToolStripMenuItem, analysisToolStripMenuItem, programToolStripMenuItem });
            msMenu.Location = new Point(0, 0);
            msMenu.Name = "msMenu";
            msMenu.Size = new Size(800, 28);
            msMenu.TabIndex = 0;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openToolStripMenuItem, saveToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(46, 24);
            fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(128, 26);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(128, 26);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(125, 6);
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(128, 26);
            exitToolStripMenuItem.Text = "Exit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // deviceToolStripMenuItem
            // 
            deviceToolStripMenuItem.Name = "deviceToolStripMenuItem";
            deviceToolStripMenuItem.Size = new Size(112, 24);
            deviceToolStripMenuItem.Text = "Brain Devices";
            // 
            // analysisToolStripMenuItem
            // 
            analysisToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { filtersToolStripMenuItem, spikesDetectionToolStripMenuItem, spikesClusteringToolStripMenuItem, morphologyReconstructionToolStripMenuItem });
            analysisToolStripMenuItem.Name = "analysisToolStripMenuItem";
            analysisToolStripMenuItem.Size = new Size(76, 24);
            analysisToolStripMenuItem.Text = "Analysis";
            // 
            // filtersToolStripMenuItem
            // 
            filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            filtersToolStripMenuItem.Size = new Size(276, 26);
            filtersToolStripMenuItem.Text = "Filters";
            filtersToolStripMenuItem.Click += filtersToolStripMenuItem_Click;
            // 
            // spikesDetectionToolStripMenuItem
            // 
            spikesDetectionToolStripMenuItem.Name = "spikesDetectionToolStripMenuItem";
            spikesDetectionToolStripMenuItem.Size = new Size(276, 26);
            spikesDetectionToolStripMenuItem.Text = "Spikes Detection";
            // 
            // spikesClusteringToolStripMenuItem
            // 
            spikesClusteringToolStripMenuItem.Name = "spikesClusteringToolStripMenuItem";
            spikesClusteringToolStripMenuItem.Size = new Size(276, 26);
            spikesClusteringToolStripMenuItem.Text = "Spikes Clustering";
            // 
            // morphologyReconstructionToolStripMenuItem
            // 
            morphologyReconstructionToolStripMenuItem.Name = "morphologyReconstructionToolStripMenuItem";
            morphologyReconstructionToolStripMenuItem.Size = new Size(276, 26);
            morphologyReconstructionToolStripMenuItem.Text = "Morphology Reconstruction";
            // 
            // programToolStripMenuItem
            // 
            programToolStripMenuItem.Name = "programToolStripMenuItem";
            programToolStripMenuItem.Size = new Size(80, 24);
            programToolStripMenuItem.Text = "Program";
            // 
            // pnCharts
            // 
            pnCharts.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnCharts.Controls.Add(fpCharts);
            pnCharts.Location = new Point(354, 31);
            pnCharts.Name = "pnCharts";
            pnCharts.Size = new Size(446, 430);
            pnCharts.TabIndex = 1;
            // 
            // fpCharts
            // 
            fpCharts.DisplayScale = 1.25F;
            fpCharts.Dock = DockStyle.Fill;
            fpCharts.Location = new Point(0, 0);
            fpCharts.Name = "fpCharts";
            fpCharts.Size = new Size(446, 430);
            fpCharts.TabIndex = 0;
            // 
            // pnTimeLine
            // 
            pnTimeLine.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnTimeLine.Controls.Add(tbrTimeLine);
            pnTimeLine.Location = new Point(0, 467);
            pnTimeLine.Name = "pnTimeLine";
            pnTimeLine.Size = new Size(800, 67);
            pnTimeLine.TabIndex = 2;
            // 
            // tbrTimeLine
            // 
            tbrTimeLine.Dock = DockStyle.Fill;
            tbrTimeLine.Location = new Point(0, 0);
            tbrTimeLine.Maximum = 100;
            tbrTimeLine.Name = "tbrTimeLine";
            tbrTimeLine.Size = new Size(800, 67);
            tbrTimeLine.SmallChange = 10;
            tbrTimeLine.TabIndex = 0;
            tbrTimeLine.TickFrequency = 10;
            tbrTimeLine.TickStyle = TickStyle.Both;
            tbrTimeLine.Scroll += tbrTimeLine_Scroll;
            // 
            // pnHeatMap
            // 
            pnHeatMap.Controls.Add(fpHotMap);
            pnHeatMap.Location = new Point(3, 34);
            pnHeatMap.Name = "pnHeatMap";
            pnHeatMap.Size = new Size(345, 313);
            pnHeatMap.TabIndex = 3;
            // 
            // fpHotMap
            // 
            fpHotMap.DisplayScale = 1.25F;
            fpHotMap.Dock = DockStyle.Fill;
            fpHotMap.Location = new Point(0, 0);
            fpHotMap.Name = "fpHotMap";
            fpHotMap.Size = new Size(345, 313);
            fpHotMap.TabIndex = 0;
            // 
            // pbProgress
            // 
            pbProgress.Location = new Point(7, 356);
            pbProgress.Name = "pbProgress";
            pbProgress.Size = new Size(341, 19);
            pbProgress.TabIndex = 4;
            // 
            // tmRender
            // 
            tmRender.Tick += tmRender_Tick;
            // 
            // lbInfo
            // 
            lbInfo.AutoSize = true;
            lbInfo.Location = new Point(5, 382);
            lbInfo.Name = "lbInfo";
            lbInfo.Size = new Size(0, 20);
            lbInfo.TabIndex = 5;
            // 
            // BrainComputerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 536);
            Controls.Add(lbInfo);
            Controls.Add(pbProgress);
            Controls.Add(pnHeatMap);
            Controls.Add(pnTimeLine);
            Controls.Add(pnCharts);
            Controls.Add(msMenu);
            MainMenuStrip = msMenu;
            Name = "BrainComputerForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Brain Computer Interface";
            Load += BrainComputerForm_Load;
            msMenu.ResumeLayout(false);
            msMenu.PerformLayout();
            pnCharts.ResumeLayout(false);
            pnTimeLine.ResumeLayout(false);
            pnTimeLine.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)tbrTimeLine).EndInit();
            pnHeatMap.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip msMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem deviceToolStripMenuItem;
        private ToolStripMenuItem analysisToolStripMenuItem;
        private ToolStripMenuItem programToolStripMenuItem;
        private Panel pnCharts;
        private Panel pnTimeLine;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Panel pnHeatMap;
        private ScottPlot.WinForms.FormsPlot fpHotMap;
        private TrackBar tbrTimeLine;
        private ToolTip ttSampleNum;
        private ScottPlot.WinForms.FormsPlot fpCharts;
        private ProgressBar pbProgress;
        private System.Windows.Forms.Timer tmRender;
        private Label lbInfo;
        private ToolStripMenuItem spikesDetectionToolStripMenuItem;
        private ToolStripMenuItem spikesClusteringToolStripMenuItem;
        private ToolStripMenuItem morphologyReconstructionToolStripMenuItem;
        private ToolStripMenuItem filtersToolStripMenuItem;
    }
}
