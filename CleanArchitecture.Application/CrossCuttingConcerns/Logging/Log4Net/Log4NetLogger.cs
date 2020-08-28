using System;
using System.Reflection;
using log4net;
using log4net.Core;

namespace CleanArchitecture.Application.CrossCuttingConcerns.Logging.Log4Net
{
    public class Log4NetLogger : ILogService
    {
        public const string LOGGER_NAME = "CleanArchitecture.Logger";

        private readonly ILog _logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public void Debug(string message, Exception exception = null)
        {
            _logger.Debug(message, exception);
        }

        public void Error(string message, Exception exception = null)
        {
            _logger.Error(message, exception);
        }

        public void Fatal(string message, Exception exception = null)
        {
            _logger.Fatal(message, exception);
        }

        public void Info(string message, Exception exception = null)
        {
            _logger.Info(message, exception);
        }

        public void Log(LogEntry entry)
        {
            if (entry == null) throw new ArgumentNullException(nameof(entry));

            Level logLevel = GetLogLevel(entry.Severity);
            _logger.Logger.Log(MethodBase.GetCurrentMethod().DeclaringType, logLevel, entry.Message, entry.Exception);
        }

        public void Warn(string message, Exception exception = null)
        {
            _logger.Warn(message, exception);
        }

        private Level GetLogLevel(LoggingEventType severity)
        {
            switch (severity)
            {
                case LoggingEventType.Debug:
                    return Level.Debug;
                case LoggingEventType.Information:
                    return Level.Info;
                case LoggingEventType.Warning:
                    return Level.Warn;
                case LoggingEventType.Error:
                    return Level.Error;
                case LoggingEventType.Fatal:
                    return Level.Fatal;
                default:
                    return Level.Error;
            }
        }
    }
}