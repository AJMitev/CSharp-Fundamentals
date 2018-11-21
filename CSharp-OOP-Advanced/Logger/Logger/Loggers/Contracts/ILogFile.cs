namespace Logger.Loggers.Contracts
{
    using System;

    public interface ILogFile
    {
        int Size { get; }
        void Write(string message);
    }
}