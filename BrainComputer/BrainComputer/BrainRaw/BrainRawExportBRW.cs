using HDF5CSharp;
using NeuroInterfaces;

namespace BrainComputer.BrainRaw
{
    internal class BrainRawExportBRW : IBrainRawData
    {
        #region IBrainRawData

        /// <inheritdoc />
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

        public ushort[] GetRaw(int r, int c, int pos, int cnt)
        {
            throw new NotImplementedException();
        }

        public ushort[] GetRaw(int ch, int pos, int cnt)
        {
            throw new NotImplementedException();
        }

        public double[] GetValue(int r, int c, int pos, int cnt)
        {
            throw new NotImplementedException();
        }

        public double[] GetValue(int ch, int pos, int cnt)
        {
            throw new NotImplementedException();
        }

        public double[,] GetHeatMap(int pos)
        {
            throw new NotImplementedException();
        }
        #endregion

        /// <summary>
        /// Export 
        /// </summary>
        /// <param name="fileName"></param>
        public void Export(string fileName)
        {
            var fileId = Hdf5.OpenFile(fileName);

            var tree = Hdf5.ReadTreeFileStructure(fileName);
            var flat = Hdf5.ReadFlatFileStructure(fileName);

            Hdf5.CloseFile(fileId);
        }
    }
}
