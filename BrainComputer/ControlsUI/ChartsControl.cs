using NeuroInterfaces;
using ScottPlot;
using ScottPlot.Colormaps;

namespace ControlsUI
{
    /// <summary>
    /// Charts Control
    /// </summary>
    public partial class ChartsControl : UserControl
    {
        private IDetectedSpikes _detectedSpikes;
        private IBrainRawData _rawData;
        private bool[,] _selection;
        private int _selection_cnt = 0;
        private IColormap _turbo = new Turbo();
        private ScottPlot.Panels.ColorBar _turbo_cb;
        private const int _min_signal_points_count = 30000;

        /// <summary>
        /// ChartsControl constructor
        /// </summary>
        /// <param name="detectedSpikes">detected spikes</param>
        /// <param name="rawData">raw data</param>
        public ChartsControl(IDetectedSpikes detectedSpikes, IBrainRawData rawData)
        {
            _detectedSpikes = detectedSpikes;
            _rawData = rawData;
            _selection = new bool[_rawData.R, _rawData.C];
            InitializeComponent();

            fpHotmap.UserInputProcessor.IsEnabled = true;
            fpHotmap.UserInputProcessor.UserActionResponses.Clear();

            var pixelSelectButton = ScottPlot.Interactivity.StandardMouseButtons.Left;
            Action<ScottPlot.IPlotControl, ScottPlot.Pixel> pixelSelectAction = (plotControl, pixel) => PixelSelectAction(plotControl, pixel);
            var pixelSelectResponse = new ScottPlot.Interactivity.UserActionResponses.SingleClickResponse(pixelSelectButton, pixelSelectAction);
            fpHotmap.UserInputProcessor.UserActionResponses.Add(pixelSelectResponse);
            fpHotmap.MouseMove += FpHotmap_MouseMove;
        }

        /// <summary>
        /// ChartsControl constructor
        /// </summary>
        public ChartsControl()
        {
            InitializeComponent();

            fpHotmap.UserInputProcessor.IsEnabled = true;
            fpHotmap.UserInputProcessor.UserActionResponses.Clear();

            var pixelSelectButton = ScottPlot.Interactivity.StandardMouseButtons.Left;
            Action<ScottPlot.IPlotControl, ScottPlot.Pixel> pixelSelectAction = (plotControl, pixel) => PixelSelectAction(plotControl, pixel);
            var pixelSelectResponse = new ScottPlot.Interactivity.UserActionResponses.SingleClickResponse(pixelSelectButton, pixelSelectAction);
            fpHotmap.UserInputProcessor.UserActionResponses.Add(pixelSelectResponse);
            fpHotmap.MouseMove += FpHotmap_MouseMove;
        }

        #region UI events
        private void FpHotmap_MouseMove(object? sender, MouseEventArgs e)
        {
            string text = "";
            if (_rawData != null)
            {
                Coordinates coordinates = fpHotmap.Plot.GetCoordinates(e.X, e.Y);
                int r = (int)(coordinates.Y + 0.5);
                int c = (int)(coordinates.X + 0.5);

                if (r >= 0 && r < _rawData.R && c >= 0 && c < _rawData.C)
                {
                    text = String.Format("R:{0} C:{1}", r, c);
                }
            }
            //lbInfo.Text = text;
        }

        public void PixelSelectAction(ScottPlot.IPlotControl plotControl, ScottPlot.Pixel pixel)
        {
            Coordinates coordinates = plotControl.Plot.GetCoordinates(pixel.X, pixel.Y);
            int r = (int)(coordinates.Y + 0.5);
            int c = (int)(coordinates.X + 0.5);

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
            //tmRender.Enabled = true;
        }
        #endregion

        #region Render
        /// <summary>
        /// RenderHotmap
        /// </summary>
        /// <param name="pos">position</param>
        public void RenderHotmap(int pos)
        {
            var plot = fpHotmap.Plot;
            plot.Clear();
            if (_turbo_cb != null)
            {
                plot.Remove(_turbo_cb);
            }
            if (_rawData != null)
            {
                var brw = _rawData.GetHeatMap(pos);
                var hm = plot.Add.Heatmap(brw);
                hm.Colormap = _turbo;
                _turbo_cb = plot.Add.ColorBar(hm);

                plot.Axes.SetLimitsY(bottom: _rawData.R, top: 0);
                plot.Axes.SetLimitsX(left: 0, right: _rawData.C);

            }
            fpHotmap.Refresh();
        }

        /// <summary>
        /// RenderWaveform
        /// </summary>
        /// <param name="waveforms">spikes waves forms</param>
        public void RenderWaveform(List<double[]> waveforms)
        {
        }

        /// <summary>
        /// RenderSignal
        /// </summary>
        /// <param name="pos">position</param>
        public void RenderSignal(int pos)
        {
            var plot = fpSignal.Plot;
            plot.Clear();
            if (_rawData != null)
            {
                for (int r = 0; r < _rawData.R; ++r)
                {
                    for (int c = 0; c < _rawData.C; ++c)
                    {
                        if (!_selection[r, c]) { continue; }
                        double[] values = _rawData.GetValue(r, c, pos, _min_signal_points_count);
                        if (values == null) { continue; }
                        var signal = fpSignal.Plot.Add.Signal(values);
                        signal.LegendText = String.Format("R:{0} C:{1}", r, c);
                        signal.Data.Period = 1 / _rawData.SamplingRate;
                        signal.Data.XOffset = pos;
                    }
                }
                plot.Axes.AutoScale();
            }
            fpSignal.Refresh();
        }

        /// <summary>
        /// RenderRasterPlot
        /// </summary>
        /// <param name="pos">position</param>
        public void RenderRasterPlot(int pos)
        {

        }
        #endregion

    }
}
