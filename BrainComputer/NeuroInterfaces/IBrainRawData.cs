namespace NeuroInterfaces
{
    /// <summary>
    /// Interface for represent raw data
    /// </summary>
    public interface IBrainRawData
    {
        /// <summary>
        /// Row count
        /// </summary>
        uint R { get; set; }

        /// <summary>
        /// Columns count
        /// </summary>
        uint C { get; set; }

        /// <summary>
        /// Sampling rate (1/s)
        /// </summary>
        double SamplingRate { get; set; }

        /// <summary>
        /// ADC Bits
        /// </summary>
        byte BitsADC { get; set; }

        /// <summary>
        /// Minimal digital value
        /// </summary>
        ushort MinDigitValue {  get; set; }

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
        /// Samples count
        /// </summary>
        uint SamplesCnt { get; set; }

        /// <summary>
        /// Data GUID
        /// </summary>
        string GUIG {  get; set; }

        /// <summary>
        /// Get average
        /// </summary>
        /// <param name="pos">position</param>
        /// <param name="cnt">elements count</param>
        /// <returns></returns>
        double[] GetAverage(int pos, int cnt);

        /// <summary>
        /// Get raw
        /// </summary>
        /// <param name="r">row</param>
        /// <param name="c">column</param>
        /// <param name="pos">position</param>
        /// <param name="cnt">elements count</param>
        /// <returns>raw array</returns>
        ushort[] GetRaw(int r, int c, int pos, int cnt);

        /// <summary>
        /// Get raw
        /// </summary>
        /// <param name="ch">channel</param>
        /// <param name="pos">position</param>
        /// <param name="cnt">elements count</param>
        /// <returns>raw array</returns>
        ushort[] GetRaw(int ch, int pos, int cnt);

        /// <summary>
        /// Get values
        /// </summary>
        /// <param name="r">row</param>
        /// <param name="c">column</param>
        /// <param name="pos">position</param>
        /// <param name="cnt">elements count</param>
        /// <returns>values array</returns>
        double[] GetValue(int r, int c, int pos, int cnt);

        /// <summary>
        /// Get values
        /// </summary>
        /// <param name="ch">channel</param>
        /// <param name="pos">position</param>
        /// <param name="cnt">elements count</param>
        /// <returns>values array</returns>
        double[] GetValue(int ch, int pos, int cnt);

        /// <summary>
        /// Get Heat Map
        /// </summary>
        /// <param name="pos">position</param>
        /// <returns>Heat map</returns>
        double[,] GetHeatMap(int pos);
    }
}
