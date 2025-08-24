using Microsoft.Extensions.Logging;

namespace BrainComputer.Logging
{
    /// <summary>
    /// Logger class
    /// </summary>
    internal class Logging
    {
        ILogger _logger = null;
        private static Logging _instance = null;
        private static object _lock = new object();
        private Logging()
        {
            using ILoggerFactory factory = LoggerFactory.Create(builder => builder.AddConsole());
            _logger = factory.CreateLogger("BC_Program");
        }

        /// <summary>
        /// Instance
        /// </summary>
        public static Logging Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new Logging();
                    }
                }
                return _instance;
            }
        }

        /// <summary>
        /// Trace
        /// </summary>
        /// <param name="trace">trace</param>
        public void LogTrace(string trace)
        {
            string str = String.Format("[{0}][{1}]", DateTime.Now, trace);
            _logger.LogTrace(str);
        }

        /// <summary>
        /// Info
        /// </summary>
        /// <param name="info">info</param>
        public void LogInfo(string info)
        {
            string str = String.Format("[{0}][{1}]", DateTime.Now, info);
            _logger.LogInformation(str);
        }

        /// <summary>
        /// Warning
        /// </summary>
        /// <param name="warn">Warning</param>
        public void LogWarning(string warn)
        {
            string str = String.Format("[{0}][{1}]", DateTime.Now, warn);
            _logger.LogWarning(str);
        }

        /// <summary>
        /// Error
        /// </summary>
        /// <param name="error">error</param>
        public void LogError(string error)
        {
            string str = String.Format("[{0}][{1}]", DateTime.Now, error);
            _logger.LogError(str);
        }
    }
}
