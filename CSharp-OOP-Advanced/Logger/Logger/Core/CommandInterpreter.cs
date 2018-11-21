namespace Logger.Core
{
    using System;
    using System.Collections.Generic;
    using Appenders.Contracts;
    using Appenders.Factory;
    using Appenders.Factory.Contracts;
    using Contracts;
    using Layouts.Contracts;
    using Layouts.Factory;
    using Layouts.Factory.Contracts;
    using Loggers.Enums;

    public class CommandInterpreter : ICommandInterpreter
    {
        private ICollection<IAppender> _appenders;
        private IAppenderFactory _appenderFactory;
        private ILayoutFactory _layoutFactory;

        public CommandInterpreter()
        {
            this._appenders = new List<IAppender>();
            this._appenderFactory = new AppenderFactory();
            this._layoutFactory = new LayoutFactory();
        }

        public void AddAppender(string[] args)
        {
            string appenderType = args[0];
            string layoutType = args[1];
            ReportLevel reportLevel = ReportLevel.INFO;

            if (args.Length == 3)
            {
                reportLevel = Enum.Parse<ReportLevel>(args[2],true);
            }

            ILayout layout = this._layoutFactory.CreateLayout(layoutType);
            IAppender appender = this._appenderFactory.CreateAppender(appenderType, layout);
            appender.ReportLevel = reportLevel;
            this._appenders.Add(appender);
        }

        public void AddMessage(string[] args)
        {
            ReportLevel reportLevel = Enum.Parse<ReportLevel>(args[0],true);
            string date = args[1];
            string message = args[2];


            foreach (IAppender appender in this._appenders)
            {
                appender.Append(date, reportLevel, message);
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Logger info");
            foreach (IAppender appender in _appenders)
            {
                Console.WriteLine(appender);
            }
        }
    }
}