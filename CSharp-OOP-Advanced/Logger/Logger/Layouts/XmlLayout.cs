namespace Logger.Layouts
{
    using System;
    using Contracts;

    public class XmlLayout : ILayout
    {
        public string Format => "<log>\r\n   <date>{0}</date>\r\n   <level>{1}</level>\r\n   <message>{2}</message>\r\n<log>\r\n";
    }
}