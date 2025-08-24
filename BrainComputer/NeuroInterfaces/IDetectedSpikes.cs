namespace NeuroInterfaces
{
    /// <summary>
    /// Interface for represent detected spikes
    /// </summary>
    public interface IDetectedSpikes
    {
        /// <summary>
        /// delegate
        /// </summary>
        /// <param name="sender">IDetectedSpikes</param>
        delegate void OnDetectedSpikesEventHandler(object sender);

        /// <summary>
        /// event
        /// </summary>
        event OnDetectedSpikesEventHandler OnDetectedSpikes;

        /// <summary>
        /// Spike detection method
        /// </summary>
        string MethodName { get; }

        /// <summary>
        /// Method parameters
        /// </summary>
        List<Tuple<string, Type>> Parameters { get; set; }

        /// <summary>
        /// Minimal digital value
        /// </summary>
        ushort MinDigitValue { get; set; }

        /// <summary>
        /// Maximal digital value
        /// </summary>
        ushort MaxDigitValue { get; set; }

        /// <summary>
        /// Minimal analog value
        /// </summary>
        double MinAnalogValue { get; set; }

        /// <summary>
        /// Maximal analog value
        /// </summary>
        double MaxAnalogValue { get; set; }

        /// <summary>
        /// Sampling rate
        /// </summary>
        double SamplingRate { get; set; }

        /// <summary>
        /// Channel indexes
        /// </summary>
        int[] ChannelIdx { get; set; }

        /// <summary>
        /// Channels
        /// </summary>
        int[] Channels { get; set; }

        /// <summary>
        /// Pre/Post peak relation
        /// </summary>
        double PeekRelation { get; set; }

        /// <summary>
        /// Peaks times
        /// </summary>
        long[] PeakTimes { get; set; }

        /// <summary>
        /// Spike size in samples counts
        /// </summary>
        int SpikeSize { get; set; }

        /// <summary>
        /// Spikes forms
        /// </summary>
        List<ushort[]> Spikes { get; set; }

        /// <summary>
        /// Interface for clustered spikes
        /// </summary>
        ISpikesClustered SpikesClustered { get; set; }

        ISpikesTrains SpikesTrains { get; set; }

        /// <summary>
        /// Spike detector control
        /// </summary>
        System.Windows.Forms.Control Control { get; set; }

    }
}
