namespace Logger.Loggers
{
    using Appenders.Contracts;
    using Contracts;
    using Enums;

    public class Logger : ILogger
    {
        private readonly IAppender _consoleAppender;
        private readonly IAppender _fileAppender;

        public Logger(IAppender consoleAppender)
        {
            this._consoleAppender = consoleAppender;
        }
        public Logger(IAppender consoleAppender, IAppender fileAppender) : this(consoleAppender)
        {
            this._fileAppender = fileAppender;
        }

        public void Info(string date, string message)
        {
            AppendMessage(date, ReportLevel.INFO, message);
        }
        public void Warning(string date, string message)
        {
            AppendMessage(date, ReportLevel.WARNING, message);
        }

        public void Error(string date, string message)
        {
            AppendMessage(date, ReportLevel.ERROR, message);
        }

        public void Critical(string date, string message)
        {
            AppendMessage(date, ReportLevel.CRITICAL, message);
        }
        public void Fatal(string date, string message)
        {
            AppendMessage(date, ReportLevel.FATAL, message);
        }

        private void AppendMessage(string date, ReportLevel reportLevel, string message)
        {
            this._consoleAppender?.Append(date, reportLevel, message);
            this._fileAppender?.Append(date, reportLevel, message);
        }


    }
}