using HDF5CSharp;
using NeuroInterfaces;

namespace BrainComputer.BrainRaw
{
    /// <summary>
    /// Class for import BRW file
    /// </summary>
    internal class BrainRawImportBRW : IBrainRawData
    {
        /// <summary>
        /// Import progress delegate
        /// </summary>
        /// <param name="sender">sender</param>
        /// <param name="progress">progress</param>
        public delegate void Progress(object sender, int progress);

        /// <summary>
        /// Import progress event
        /// </summary>
        public event Progress OnProgress;

        private double _coff = 1;
        #region IBrainRawData
        public uint R { get; set; }

        /// <inheritdoc />
        public uint C { get; set; }

        /// <inheritdoc />
        public double SamplingRate { get; set; }

        /// <inheritdoc />
        public byte BitsADC { get; set; }

        /// <inheritdoc />
        public ushort MinDigitValue { get; set; }

        /// <inheritdoc />
        public ushort MaxDigitValue { get; set; }

        /// <inheritdoc />
        public double MinAnalogValue { get; set; }

        /// <inheritdoc />
        public double MaxAnalogValue { get; set; }

        /// <inheritdoc />
        public uint SamplesCnt { get; set; }

        /// <inheritdoc />
        public string GUIG { get; set; } = "";

        /// <inheritdoc />
        public double[] GetAverage(int pos, int cnt)
        {
            return null;
        }

        /// <inheritdoc />
        public ushort[] GetRaw(int r, int c, int pos, int cnt)
        {
            if (pos + cnt > SamplesCnt) { return null; }
            ushort[] result = new ushort[cnt];
            Array.Copy(_raw[r * C + c], pos, result, 0, cnt);
            return result;
        }

        /// <inheritdoc />
        public ushort[] GetRaw(int ch, int pos, int cnt)
        {
            if (pos + cnt > SamplesCnt) { return null; }
            ushort[] result = new ushort[cnt];
            Array.Copy(_raw[ch], pos, result, 0, cnt);
            return result;
        }

        /// <inheritdoc />
        public double[] GetValue(int r, int c, int pos, int cnt)
        {
            if (pos + cnt > SamplesCnt) { return null; }

            double[] result = new double[cnt];
            Array.Copy(_raw[r * C + c], pos, result, 0, cnt);
            return result.Select(x => (MinAnalogValue + x * _coff)).ToArray<double>();
        }

        /// <inheritdoc />
        public double[] GetValue(int ch, int pos, int cnt)
        {
            if (pos + cnt > SamplesCnt) { return null; }
            double[] result = new double[cnt];
            Array.Copy(_raw[ch], pos, result, 0, cnt);
            return result.Select(x => (MinAnalogValue + x * _coff)).ToArray<double>();
        }

        public double[,] GetHeatMap(int pos)
        {
            double[,] result = new double[R, C];
            if (_raw != null)
            {
                for (int i = 0; i < SZ; ++i)
                {
                    result[i / C, i % C] = (MinAnalogValue + (_raw[i][pos] * _coff));
                }
            }
            return result;
        }
        #endregion

        uint SZ;
        int _progress = 0;

        ushort[][]? _raw = null;
        string _fileName = "";

        /// <summary>
        /// Import BRW raw file
        /// </summary>
        /// <param name="fileName">brw file name</param>
        public void Import(string fileName)
        {
            _progress = 0;
            _fileName = fileName;
            Task t = Task.Factory.StartNew(ImportTask);
        }

        private void ImportTask()
        {
            _progress = 0;
            var fileId = Hdf5.OpenFile(_fileName);

            var maxV = Hdf5.ReadDatasetToArray<double>(fileId, "/3BRecInfo/3BRecVars/MaxVolt");
            if (maxV.Item1)
            {
                MaxAnalogValue = ((double[])(maxV.Item2))[0];
            }
            var minV = Hdf5.ReadDatasetToArray<double>(fileId, "/3BRecInfo/3BRecVars/MinVolt");
            if (minV.Item1)
            {
                MinAnalogValue = ((double[])(minV.Item2))[0];
            }
            var sr = Hdf5.ReadDatasetToArray<double>(fileId, "/3BRecInfo/3BRecVars/SamplingRate");
            if (sr.Item1)
            {
                SamplingRate = ((double[])(sr.Item2))[0];
            }

            var bc = Hdf5.ReadDatasetToArray<byte>(fileId, "/3BRecInfo/3BRecVars/BitDepth");
            if (bc.Item1)
            {
                BitsADC = ((byte[])(bc.Item2))[0];
            }
            else
            {
                BitsADC = 14;
            }

            MinDigitValue = 0;
            MaxDigitValue = (ushort)(1 << BitsADC);
            _coff = (MaxAnalogValue - MinAnalogValue) / (MaxDigitValue - MinDigitValue);
            var r = Hdf5.ReadDatasetToArray<UInt32>(fileId, "/3BRecInfo/3BMeaChip/NRows");
            if (r.Item1)
            {
                R = ((UInt32[])(r.Item2))[0];
            }

            var c = Hdf5.ReadDatasetToArray<UInt32>(fileId, "/3BRecInfo/3BMeaChip/NCols");
            if (c.Item1)
            {
                C = ((UInt32[])(c.Item2))[0];
            }
            SZ = R * C;

            var raw_ds = Hdf5.ReadDatasetToArray<ushort>(fileId, "/3BData/Raw");
            ushort[] raw = (ushort[])(raw_ds.Item2);
            _raw = new ushort[SZ][];

            SamplesCnt = (uint)(raw.Length / SZ);
            for (int i = 0; i < SZ; ++i)
            {
                _raw[i] = new ushort[SamplesCnt];
            }

            int progress_step = (int)((raw.Length / SZ) / 100);
            progress_step = Math.Max(progress_step, 1);
            int pos = 0;
            uint pos_cur = 0;
            int ch = 0;
            for (int progress = 0; progress < 100; ++progress)
            {

                uint pos_next = (uint)Math.Min(raw.Length, pos_cur + (SZ * progress_step));

                for (; pos_cur < pos_next;)
                {
                    for (ch = 0; ch < SZ; ch++)
                    {
                        _raw[ch][pos] = raw[pos_cur];
                        pos_cur++;
                    }
                    pos++;
                }

                if (OnProgress != null)
                {
                    OnProgress(this, progress);
                }
                Console.WriteLine(string.Format("{0} {1}", progress, pos_cur, pos_next));
            }

            _progress = 100;
            if (OnProgress != null)
            {
                OnProgress(this, _progress);
            }
            Hdf5.CloseFile(fileId);
        }
    }
}
