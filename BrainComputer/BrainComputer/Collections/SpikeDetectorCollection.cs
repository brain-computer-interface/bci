using System.Collections;
using System.Reflection;
using NeuroInterfaces;

namespace BrainComputer.Collections
{
    internal class SpikeDetectorCollection : CollectionBase
    {
        private Hashtable tableIAdaptee = null;

        public void Add(IDetectedSpikes spikeDetector)
        {
            InnerList.Add(spikeDetector);
        }

        public void Remove(IDetectedSpikes camera)
        {
            InnerList.Remove(camera);
        }

        public IDetectedSpikes GetSpikeDetector(string name)
        {
            // find the camera
            foreach (IDetectedSpikes spikeDetector in InnerList)
            {
                if (spikeDetector.MethodName == name)
                    return spikeDetector;
            }
            return null;
        }

        public IDetectedSpikes this[int index]
        {
            get
            {
                return InnerList[index] as IDetectedSpikes;
            }
        }

        public void Load(string path, ref Hashtable tableIAdaptee)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(path);
                this.tableIAdaptee = tableIAdaptee;
                FileInfo[] files = dir.GetFiles("*.dll");

                foreach (FileInfo f in files)
                {
                    LoadAssembly(Path.Combine(path, f.Name));
                }

                InnerList.Sort();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Logging.Logging.Instance.LogWarning(ex.Message);
            }
        }

        private void LoadAssembly(string fileName)
        {
            Type typeSpikeDetector = typeof(IDetectedSpikes);

            try
            {
                Assembly asm = Assembly.LoadFrom(fileName);
                Type[] types = asm.GetTypes();

                foreach (Type type in types)
                {
                    Type[] interfaces = type.GetInterfaces();

                    if (Array.IndexOf(interfaces, typeSpikeDetector) != -1)
                    {
                        try
                        {
                            IDetectedSpikes? desc = Activator.CreateInstance(type) as IDetectedSpikes;

                            if (desc != null)
                            {
                                tableIAdaptee.Add(desc.MethodName, desc);
                                InnerList.Add(desc);
                            }
                        }
                        catch (Exception ex)
                        {
                            Logging.Logging.Instance.LogWarning(ex.Message);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Logging.Logging.Instance.LogWarning(ex.Message);
            }
        }
    }
}
