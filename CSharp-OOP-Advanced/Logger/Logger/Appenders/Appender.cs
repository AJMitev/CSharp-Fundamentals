namespace Logger.Appenders
{
    using Contracts;
    using Layouts.Contracts;
    using Loggers.Enums;

    public abstract class Appender : IAppender
    {
        protected Appender(ILayout layout)
        {
            Layout = layout;
        }

        public int MessagesCount { get; protected set; }
        public ILayout Layout { get; }

        public ReportLevel ReportLevel { get; set; }
        public abstract void Append(string dateTime, ReportLevel reportLevel, string message);

       }
}