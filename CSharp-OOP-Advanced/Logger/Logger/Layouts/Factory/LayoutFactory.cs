namespace Logger.Layouts.Factory
{
    using System;
    using Contracts;
    using Layouts.Contracts;

    public class LayoutFactory : ILayoutFactory
    {
        public ILayout CreateLayout(string type)
        {
            var typeInsensitive = type.ToLower();

            switch (typeInsensitive)
            {
                    case "simplelayout": return new SimpleLayout();
                    case "xmllayout": return new XmlLayout();
                    default:throw new ArgumentException("Invalid Layout type!");
            }
        }
    }
}