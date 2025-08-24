using BrainComputer.BrainRaw;
using BrainComputer.Collections;
using NeuroInterfaces;
using ScottPlot;
using System.Collections;
using System.Threading.Tasks;

namespace BrainComputer
{
    /// <summary>
    /// Brain Computer Form class
    /// </summary>
    public partial class BrainComputerForm : Form
    {
        private IBrainRawData brainRawData = null;
        private BrainRawImportBRW brainRawImportBRW = new BrainRawImportBRW();
        private BrainRawExportBRW brainRawExportBRW = new BrainRawExportBRW();
        private bool[,] _selection;
        private int _selection_cnt = 0;
        private ScottPlot.IColormap _turbo = new ScottPlot.Colormaps.Turbo();
        private ScottPlot.Panels.ColorBar _turbo_cb;
        private const int _min_signal_points_count = 30000;

        private Hashtable _tableIAdaptee = null;
        private SpikeDetectorCollection _spikeDetectors = null;
        private SpikeDetectionForm _spikeDetectionForm =  new SpikeDetectionForm();

        /// <summary>
        /// Brain Computer Form
        /// </summary>
        public BrainComputerForm()
        {
            InitializeComponent();
            LoadModules();
            msMenu.SuspendLayout();

            brainRawImportBRW.OnProgress += BrainRawImportBRW_OnProgress;

            fpHotMap.UserInputProcessor.IsEnabled = true;
            fpHotMap.UserInputProcessor.UserActionResponses.Clear();

            var pixelSelectButton = ScottPlot.Interactivity.StandardMouseButtons.Left;
            Action<ScottPlot.IPlotControl, ScottPlot.Pixel> pixelSelectAction = (plotControl, pixel) => PixelSelectAction(plotControl, pixel);
            var pixelSelectResponse = new ScottPlot.Interactivity.UserActionResponses.SingleClickResponse(pixelSelectButton, pixelSelectAction);
            fpHotMap.UserInputProcessor.UserActionResponses.Add(pixelSelectResponse);
            fpHotMap.MouseMove += FpHeatMap_MouseMove;

        }

        private void LoadModules()
        {
            // Spike Detectors
            _tableIAdaptee = new Hashtable();
            _spikeDetectors = new SpikeDetectorCollection();
            _spikeDetectors.Load(AppDomain.CurrentDomain.BaseDirectory, ref _tableIAdaptee);
            AddSpikeDetectorMenuItems(_spikeDetectors);
            // Spike Clustering

            // Morphology reconstruction

            // Network train

            // Brain Interface Device
        }


        #region UI Events

        private void BrainRawImportBRW_OnProgress(object sender, int progress)
        {
            if (InvokeRequired)
            {
                Invoke(BrainRawImportBRW_OnProgress, new object[] { sender, progress });
            }
            else
            {
                pbProgress.Value = progress;
                if (progress == 100)
                {
                    brainRawData = brainRawImportBRW;
                    tbrTimeLine.Maximum = Math.Max(0, (int)brainRawData.SamplesCnt - 1 - _min_signal_points_count);
                    tbrTimeLine.Minimum = 0;
                    tbrTimeLine.Value = 0;
                    tbrTimeLine.TickFrequency = 100;
                    _selection = new bool[brainRawData.R, brainRawData.C];
                    for (int r = 0; r < brainRawData.R; ++r)
                    {
                        for (int c = 0; c < brainRawData.C; ++c)
                        {
                            _selection[r, c] = false;
                        }
                    }
                    tmRender.Enabled = true;
                    pbProgress.Visible = false;
                }
            }
        }

        private void BrainComputerForm_Load(object sender, EventArgs e)
        {

        }

        private void tbrTimeLine_Scroll(object sender, EventArgs e)
        {
            ttSampleNum.SetToolTip(tbrTimeLine, tbrTimeLine.Value.ToString());
            tmRender.Enabled = true;
        }

        private void FpHeatMap_MouseMove(object? sender, MouseEventArgs e)
        {
            string text = "";
            if (brainRawData != null)
            {
                Coordinates coordinates = fpHotMap.Plot.GetCoordinates(e.X, e.Y);
                int r = (int)(coordinates.Y + 0.5);
                int c = (int)(coordinates.X + 0.5);

                if (r >= 0 && r < brainRawData.R && c >= 0 && c < brainRawData.C)
                {
                    text = String.Format("R:{0} C:{1}", r, c);
                }
            }
            lbInfo.Text = text;
        }

        public void PixelSelectAction(ScottPlot.IPlotControl plotControl, ScottPlot.Pixel pixel)
        {
            if (_selection == null)
            {
                return;
            }
            Coordinates coordinates = plotControl.Plot.GetCoordinates(pixel.X, pixel.Y);
            int r = (int)(coordinates.Y + 0.5);
            int c = (int)(coordinates.X + 0.5);

            if(r < 0 || c< 0|| r >= _selection.GetLength(0) || c >= _selection.GetLength(1))
            {
                return;
            }

            if (_selection[r, c])
            {
                _selection[r, c] = false;
                _selection_cnt--;
            }
            else
            {
                _selection[r, c] = true;
                _selection_cnt++;
            }

            tmRender.Enabled = true;
        }
        #endregion

        #region Task
        private void tmRender_Tick(object sender, EventArgs e)
        {
            RenderHeatMap(tbrTimeLine.Value);
            RenderChannels(tbrTimeLine.Value);
            tmRender.Enabled = false;
        }

        #endregion

        #region MENU

        #region File
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "brain computer files (*.bc)|*.bc|brain vawe files (*.brw)|*.brw|All files (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    var extension = Path.GetExtension(ofd.FileName);
                    if (extension == ".brw")
                    {
                        brainRawData = null;
                        pbProgress.Visible = true;
                        brainRawImportBRW.Import(ofd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "brain computer files (*.bc)|*.bc|brain vawe files (*.brw)";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    var extension = Path.GetExtension(sfd.FileName);
                    if (extension == ".brw")
                    {
                        brainRawExportBRW.Export(sfd.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        #endregion

        #region Analisys

        private void filtersToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void AddSpikeDetectorMenuItems(SpikeDetectorCollection spikeDetectors)
        {
            List<ToolStripItem> ts = new List<ToolStripItem>();
            foreach (IDetectedSpikes spikeDeteector in spikeDetectors)
            {
                ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
                toolStripMenuItem.Name = spikeDeteector.MethodName;
                toolStripMenuItem.Size = new Size(224, 26);
                toolStripMenuItem.Text = "RMS";
                toolStripMenuItem.Click += SpikeDetectorToolStripMenuItem_Click;
                ts.Add(toolStripMenuItem);
            }
            spikesDetectionToolStripMenuItem.DropDownItems.AddRange(ts.ToArray());
        }

        private void SpikeDetectorToolStripMenuItem_Click(object? sender, EventArgs e)
        {
            if (sender != null)
            {
                string methodName = sender.ToString();
                for (int i = 0; i< _spikeDetectors.Count; ++i)
                {
                    if (methodName == _spikeDetectors[i].MethodName)
                    {
                        _spikeDetectionForm.SetSpikeDetector(_spikeDetectors[i]);
                    }
                }
                _spikeDetectionForm.Show();
            }

        }


        #region Spike Detection

        #endregion

        #endregion

        #endregion

        #region Render

        private void RenderHeatMap(int pos)
        {
            var plot = fpHotMap.Plot;
            plot.Clear();
            if (_turbo_cb != null)
            {
                plot.Remove(_turbo_cb);
            }
            if (brainRawData != null)
            {
                var brw = brainRawData.GetHeatMap(pos);
                var hm = plot.Add.Heatmap(brw);
                hm.FlipVertically = true;
                hm.Colormap = _turbo;
                _turbo_cb = plot.Add.ColorBar(hm);

                plot.Axes.SetLimitsY(bottom: 0, top: brainRawData.R);
                plot.Axes.SetLimitsX(left: 0, right: brainRawData.C);

                if (_selection != null)
                {
                    for (int r = 0; r < _selection.GetLength(0); ++r)
                    {
                        for (int c = 0; c < _selection.GetLength(1); ++c)
                        {
                            if (_selection[r, c])
                            {
                                var rc = plot.Add.Rectangle(c, c + 1, r, r + 1);
                                rc.FillColor = Colors.White;
                                rc.LineStyle.Color= Colors.Black;
                            }
                        }
                    }
                }

            }
            fpHotMap.Refresh();
        }

        private void RenderChannels(int pos)
        {
            var plot = fpCharts.Plot;
            plot.Clear();
            if (brainRawData != null)
            {
                for (int r = 0; r < brainRawData.R; ++r)
                {
                    for (int c = 0; c < brainRawData.C; ++c)
                    {
                        if (!_selection[r, c]) { continue; }
                        double[] values = brainRawData.GetValue(r, c, tbrTimeLine.Value, _min_signal_points_count);
                        if (values == null) { continue; }
                        var signal = fpCharts.Plot.Add.Signal(values);
                        signal.LegendText = String.Format("R:{0} C:{1}", r, c);
                        signal.Data.Period = 1 / brainRawData.SamplingRate;
                        signal.Data.XOffset = tbrTimeLine.Value;
                    }
                }
                plot.Axes.AutoScale();
            }
            fpCharts.Refresh();
        }
        #endregion

    }
}
