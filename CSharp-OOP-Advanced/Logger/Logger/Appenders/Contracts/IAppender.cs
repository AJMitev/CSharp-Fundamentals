namespace Logger.Appenders.Contracts
{
    using Loggers.Enums;

    public interface IAppender
    {
        int MessagesCount { get; }
        ReportLevel ReportLevel { get; set; }
        void Append(string dateTime, ReportLevel reportLevel, string message);
    }
}