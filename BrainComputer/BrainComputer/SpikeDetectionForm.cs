using BrainComputer.Collections;
using NeuroInterfaces;

namespace BrainComputer
{
    /// <summary>
    /// Form for spike detectors
    /// </summary>
    internal partial class SpikeDetectionForm : Form
    {
        IDetectedSpikes _spikeDetector = null;

        /// <summary>
        /// Constructor
        /// </summary>
        public SpikeDetectionForm()
        {
            InitializeComponent();
            this.FormClosing += SpikeDetectionForm_FormClosing;
        }

        public new void Show()
        {
            if (_spikeDetector != null)
            {
                this.Controls.Add(_spikeDetector.Control);
                _spikeDetector.Control.Dock = DockStyle.Fill;
                base.Show();
            }
        }

        public void SetSpikeDetector(IDetectedSpikes spikeDetector)
        {
            _spikeDetector = spikeDetector;
        }

        private void SpikeDetectionForm_FormClosing(object? sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                _spikeDetector = null;
                Hide();
            }
        }


    }
}
