namespace Byrniee.Serilog4Unity
{
    /// <summary>
    /// Serilog settings class.
    /// </summary>
    public class SerilogSettings
    {
        /// <summary>
        /// Gets or sets the global minimum logging level.
        /// </summary>
        public string GlobalMinimumLoggingLevel { get; set; }

        /// <summary>
        /// Gets or sets the unity console sink settings.
        /// </summary>
        public UnityConsoleSinkSettings Unity { get; set; }

        /// <summary>
        /// Gets or sets the File sink settings.
        /// </summary>
        public FileSinkSettings File { get; set; }

        /// <summary>
        /// Gets or sets the Graylog sink settings.
        /// </summary>
        public GraylogSinkSettings Graylog { get; set; }

        public class UnityConsoleSinkSettings
        {
            /// <summary>
            /// Gets or sets the minimum logging level.
            /// </summary>
            public string MinimumLoggingLevel { get; set; }

            /// <summary>
            /// Gets or sets the output template.
            /// </summary>
            public string OutputTemplate { get; set; }
        }

        public class FileSinkSettings
        {
            /// <summary>
            /// Gets or sets the minimum logging level.
            /// </summary>
            public string MinimumLoggingLevel { get; set; }

            /// <summary>
            /// Gets or sets the output template.
            /// </summary>
            public string OutputTemplate { get; set; }

            /// <summary>
            /// Gets or sets the filename.
            /// </summary>
            public string FileName { get; set; }

            /// <summary>
            /// Gets or sets the file retension in days.
            /// </summary>
            public int FileRetensionDays { get; set; }
        }

        public class GraylogSinkSettings
        {
            /// <summary>
            /// Gets or sets the minimum logging level.
            /// </summary>
            public string MinimumLoggingLevel { get; set; }
            
            /// <summary>
            /// Gets or sets the base URL.
            /// </summary>
            public string BaseUrl { get; set; }

            /// <summary>
            /// Gets or sets the port number.
            /// </summary>
            public int Port { get; set; }
        }
    }
}
