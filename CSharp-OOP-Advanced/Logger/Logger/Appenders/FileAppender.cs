namespace Logger.Appenders
{
    using System.IO;
    using Contracts;
    using Layouts.Contracts;
    using Loggers.Contracts;
    using Loggers.Enums;

    public class FileAppender : Appender, IAppender
    {
        
        private readonly ILogFile _logFile;
        private const string Path = "log.txt";

        public FileAppender(ILayout layout, ILogFile logFile) : base(layout)
        {
            this._logFile = logFile;
        }

       
        public override void Append(string dateTime, ReportLevel reportLevel, string message)
        {
            if ((int)reportLevel >= (int)this.ReportLevel)
            {
                this.MessagesCount++;
                string content = string.Format(this.Layout.Format, dateTime, reportLevel, message);
                File.AppendAllText(Path, content);
                this._logFile.Write(content);
            }
        }

        public override string ToString()
        {
            return
                $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, Report level: {this.ReportLevel.ToString()}, Messages appended: {this.MessagesCount}, File size: {this._logFile.Size}";
        }
    }
}