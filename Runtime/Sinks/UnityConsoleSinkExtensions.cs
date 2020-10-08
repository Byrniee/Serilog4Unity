using System;
using Serilog;
using Serilog.Configuration;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using Serilog.Formatting.Display;

namespace Byrniee.Serilog4Unity.Sinks
{
    /// <summary>
    /// Unity console sink extensions.
    /// </summary>
    public static class UnityConsoleSinkExtensions
    {
        private const string DefaultDebugOutputTemplate = "[{Timestamp:HH:mm:ss.fff} [{Level}] {SourceContext}] {Message:lj}{NewLine}{Exception}";

        /// <summary>
        /// Writes log events to the Unity3d Console.
        /// </summary>
        /// <param name="loggerSinkConfiguration">Logger sink configuration.</param>
        /// <param name="logEventLevel">The minimum level for
        /// events passed through the sink. Ignored when <paramref name="loggingLevelSwitch"/> is specified.</param>
        /// <param name="outputTemplate">A message template describing the format used to write to the sink.
        /// the default is <code>"[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj}{NewLine}{Exception}"</code>.</param>
        /// <param name="formatProvider">Supplies culture-specific formatting information, or null.</param>
        /// <param name="loggingLevelSwitch">A switch allowing the pass-through minimum level
        /// to be changed at runtime.</param>
        /// <returns>Configuration object allowing method chaining.</returns>
        public static LoggerConfiguration Unity3D(
            this LoggerSinkConfiguration loggerSinkConfiguration,
            LogEventLevel logEventLevel = LevelAlias.Minimum,
            string outputTemplate = DefaultDebugOutputTemplate,
            IFormatProvider formatProvider = null,
            LoggingLevelSwitch loggingLevelSwitch = null)
        {
            if (string.IsNullOrEmpty(outputTemplate))
            {
                outputTemplate = DefaultDebugOutputTemplate;
            }
            
            ITextFormatter formatter = new MessageTemplateTextFormatter(outputTemplate, formatProvider);
            return loggerSinkConfiguration.Sink(new UnityConsoleSink(formatter), logEventLevel, loggingLevelSwitch);
        }
    }
}
