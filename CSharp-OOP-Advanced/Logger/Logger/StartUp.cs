namespace Logger
{
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            ICommandInterpreter commandInterpreter = new CommandInterpreter();
            IEngine app = new Engine(commandInterpreter);
            app.Run();
        }
    }
}
