using NeuroInterfaces;

namespace SpikeDetectorRMS
{
    public class SpikeDetectorRMS : IDetectedSpikes
    {
        SpikeDetectorRMSControl _control = new SpikeDetectorRMSControl();
        IBrainRawData _rawData = null;
        public IBrainRawData BrainRawData 
        {
            get
            {
                return _rawData;
            }
            set
            {
                _rawData = value;
            }
        }

        public SpikeDetectorRMS()
        {
        }

        #region IDetectedSpikes

        /// <inheritdoc />
        public string MethodName { get { return "RMS"; } }

        /// <inheritdoc />
        public List<Tuple<string, Type>> Parameters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <inheritdoc />
        public ushort MinDigitValue { get; set; }

        /// <inheritdoc />
        public ushort MaxDigitValue { get; set; }

        /// <inheritdoc />
        public double MinAnalogValue { get; set; }

        /// <inheritdoc />
        public double MaxAnalogValue { get; set; }

        /// <inheritdoc />
        public double SamplingRate { get; set; }

        public int[] ChannelIdx { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int[] Channels { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        /// <inheritdoc />
        public double PeekRelation { get; set; }
        public long[] PeakTimes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int SpikeSize { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public List<ushort[]> Spikes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISpikesClustered SpikesClustered { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ISpikesTrains SpikesTrains { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public Control Control
        {
            get
            {
                return _control;
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public event IDetectedSpikes.OnDetectedSpikesEventHandler OnDetectedSpikes;

        #endregion

        public void Clear() { }

        public void Calculate()
        {

        }
    }



}
