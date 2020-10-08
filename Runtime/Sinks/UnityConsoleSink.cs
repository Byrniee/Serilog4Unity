using System;
using System.IO;
using Serilog.Core;
using Serilog.Events;
using Serilog.Formatting;
using UnityEngine;

namespace Byrniee.Serilog4Unity.Sinks
{
    /// <summary>
    /// Serilog sink for Unity3d Console.
    /// </summary>
    public class UnityConsoleSink : ILogEventSink
    {
        private readonly ITextFormatter textFormatter;

        /// <summary>
        /// Initialises a new instance of the <see cref="UnityConsoleSink"/> class.
        /// </summary>
        /// <param name="textFormatter">The text formatter.</param>
        public UnityConsoleSink(ITextFormatter textFormatter)
        {
            this.textFormatter = textFormatter;
        }
        
        /// <inheritdoc />
        public void Emit(LogEvent logEvent)
        {
            using (StringWriter buffer = new StringWriter())
            {
                textFormatter.Format(logEvent, buffer);

                switch (logEvent.Level)
                {
                    case LogEventLevel.Verbose:
                    case LogEventLevel.Debug:
                    case LogEventLevel.Information:
                        Debug.Log(buffer.ToString().Trim());
                        break;

                    case LogEventLevel.Warning:
                        Debug.LogWarning(buffer.ToString().Trim());
                        break;

                    case LogEventLevel.Error:
                    case LogEventLevel.Fatal:
                        Debug.LogError(buffer.ToString().Trim());
                        break;

                    default:
                        throw new ArgumentOutOfRangeException("Unknown log level");
                }
            }
        }
    }
}
