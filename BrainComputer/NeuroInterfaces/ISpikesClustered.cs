using System;
namespace NeuroInterfaces
{
    /// <summary>
    /// Interface for clustered spikes
    /// </summary>
    public interface ISpikesClustered
    {
        /// <summary>
        /// Spikes groups
        /// </summary>
        byte[] SpikesGroup { get; set; }

        /// <summary>
        /// Spikes groups names
        /// </summary>
        string[] SpikesGroupsNames { get; set; }

        /// <summary>
        /// Clustering algorithm info
        /// </summary>
        string AlgorithmInfo { get; set; }
    }
}
