using System;
using Byrniee.Serilog4Unity.Internal;
using Byrniee.Serilog4Unity.Sinks;
using Byrniee.UnityConfiguration;
using Byrniee.UnityLogging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.Graylog;
using Serilog.Sinks.Graylog.Core.Transport;

namespace Byrniee.Serilog4Unity
{
    /// <summary>
    /// Serilog logger factory.
    /// </summary>
    public class SerilogLoggerFactory : ILoggerFactory
    {
        private readonly SerilogSettings serilogSettings;

        /// <summary>
        /// Initialises a new nistance of the <see cref="SerilogLoggerFactory"/> class.
        /// </summary>
        public SerilogLoggerFactory(IConfig<SerilogSettings> serilogSettings)
        {
            this.serilogSettings = serilogSettings.Value;

            ConfigureLogging();
        }

        /// <inheritdoc />
        public ILogger<T> Create<T>()
        {
            return new SerilogLogger<T>();
        }

        private void ConfigureLogging()
        {
            LogEventLevel globalMinimumLevel = GetLogLevel(serilogSettings.GlobalMinimumLoggingLevel);
            LoggerConfiguration loggerConfiguration = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .MinimumLevel.Is(globalMinimumLevel);

            ConfigureUnitySink(loggerConfiguration);
            ConfigureFileSink(loggerConfiguration);
            ConfigureGraylogSink(loggerConfiguration);


            Log.Logger = loggerConfiguration
                .CreateLogger();
        }

        private LogEventLevel GetLogLevel(string logLevel)
        {
            if(!Enum.TryParse<LogEventLevel>(logLevel, out LogEventLevel logEventLevel))
            {
                logEventLevel = LogEventLevel.Information;
            }

            return logEventLevel;
        }

        private void ConfigureUnitySink(LoggerConfiguration loggerConfiguration)
        {
            if (serilogSettings.Unity == null)
            {
                return;
            }

            LogEventLevel logEventLevel = GetLogLevel(serilogSettings.Unity.MinimumLoggingLevel);
            string outputTemplate = serilogSettings.Unity.OutputTemplate;

            loggerConfiguration.WriteTo.Unity3D(logEventLevel, outputTemplate);
        }

        private void ConfigureFileSink(LoggerConfiguration loggerConfiguration)
        {
            if (serilogSettings.File == null)
            {
                return;
            }

            LogEventLevel logEventLevel = GetLogLevel(serilogSettings.File.MinimumLoggingLevel);
            string outputTemplate = serilogSettings.File.OutputTemplate;
            string fileName = serilogSettings.File.FileName;

            loggerConfiguration.WriteTo.File(
                fileName,
                logEventLevel,
                outputTemplate,
                rollingInterval: RollingInterval.Day,
                retainedFileCountLimit: serilogSettings.File.FileRetensionDays);
        }

        private void ConfigureGraylogSink(LoggerConfiguration loggerConfiguration)
        {
            if (serilogSettings.Graylog == null)
            {
                return;
            }

            loggerConfiguration.WriteTo.Graylog(
                new GraylogSinkOptions()
                {
                    HostnameOrAddress = serilogSettings.Graylog.BaseUrl,
                    Port = serilogSettings.Graylog.Port,
                    TransportType = TransportType.Http,
                });
        }
    }
}