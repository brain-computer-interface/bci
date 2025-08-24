namespace ControlsUI
{
    partial class ChartsControl
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

        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            fpHotmap = new ScottPlot.WinForms.FormsPlot();
            fpSignal = new ScottPlot.WinForms.FormsPlot();
            fpWaveform = new ScottPlot.WinForms.FormsPlot();
            fpRasterPlot = new ScottPlot.WinForms.FormsPlot();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35.9073372F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 64.09267F));
            tableLayoutPanel1.Controls.Add(fpHotmap, 0, 0);
            tableLayoutPanel1.Controls.Add(fpSignal, 1, 0);
            tableLayoutPanel1.Controls.Add(fpWaveform, 0, 1);
            tableLayoutPanel1.Controls.Add(fpRasterPlot, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(777, 484);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // fpHotmap
            // 
            fpHotmap.DisplayScale = 1.25F;
            fpHotmap.Dock = DockStyle.Fill;
            fpHotmap.Location = new Point(3, 3);
            fpHotmap.Name = "fpHotmap";
            fpHotmap.Size = new Size(273, 236);
            fpHotmap.TabIndex = 0;
            // 
            // fpSignal
            // 
            fpSignal.DisplayScale = 1.25F;
            fpSignal.Dock = DockStyle.Fill;
            fpSignal.Location = new Point(282, 3);
            fpSignal.Name = "fpSignal";
            fpSignal.Size = new Size(492, 236);
            fpSignal.TabIndex = 1;
            // 
            // fpWaveform
            // 
            fpWaveform.DisplayScale = 1.25F;
            fpWaveform.Dock = DockStyle.Fill;
            fpWaveform.Location = new Point(3, 245);
            fpWaveform.Name = "fpWaveform";
            fpWaveform.Size = new Size(273, 236);
            fpWaveform.TabIndex = 2;
            // 
            // fpRasterPlot
            // 
            fpRasterPlot.DisplayScale = 1.25F;
            fpRasterPlot.Dock = DockStyle.Fill;
            fpRasterPlot.Location = new Point(282, 245);
            fpRasterPlot.Name = "fpRasterPlot";
            fpRasterPlot.Size = new Size(492, 236);
            fpRasterPlot.TabIndex = 3;
            // 
            // ChartsControl
            // 
            Controls.Add(tableLayoutPanel1);
            Name = "ChartsControl";
            Size = new Size(777, 484);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private TableLayoutPanel tlpCharts;
        private TableLayoutPanel tableLayoutPanel1;
        private ScottPlot.WinForms.FormsPlot fpHotmap;
        private ScottPlot.WinForms.FormsPlot fpSignal;
        private ScottPlot.WinForms.FormsPlot fpWaveform;
        private ScottPlot.WinForms.FormsPlot fpRasterPlot;
    }
}
