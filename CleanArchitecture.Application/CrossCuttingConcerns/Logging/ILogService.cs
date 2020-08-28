using System;

namespace CleanArchitecture.Application.CrossCuttingConcerns.Logging
{
    public interface ILogService
    {
        void Log(LogEntry entry);

        void Debug(string message, Exception exception = null);

        void Info(string message, Exception exception = null);

        void Warn(string message, Exception exception = null);

        void Error(string message, Exception exception = null);

        void Fatal(string message, Exception exception = null);
    }
}