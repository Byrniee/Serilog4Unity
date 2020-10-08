using System;
using Byrniee.UnityLogging;
using Serilog;

namespace Byrniee.Serilog4Unity.Internal
{
    /// <summary>
    /// Serilog logger implementation.
    /// </summary>
    /// <typeparam name="T">Logger type.</typeparam>
    public class SerilogLogger<T> : ILogger<T>
    {
        /// <inheritdoc />
        public void LogCritical(string message, params object[] args)
        {
            Log.ForContext<T>().Fatal(message, args);
        }

        /// <inheritdoc />
        public void LogDebug(string message, params object[] args)
        {
            Log.ForContext<T>().Debug(message, args);
        }

        /// <inheritdoc />
        public void LogError(string message, params object[] args)
        {
            Log.ForContext<T>().Error(message, args);
        }

        /// <inheritdoc />
        public void LogInformation(string message, params object[] args)
        {
            Log.ForContext<T>().Information(message, args);
        }

        /// <inheritdoc />
        public void LogTrace(string message, params object[] args)
        {
            Log.ForContext<T>().Verbose(message, args);
        }

        /// <inheritdoc />
        public void LogWarning(string message, params object[] args)
        {
            Log.ForContext<T>().Warning(message, args);
        }
    }
}
