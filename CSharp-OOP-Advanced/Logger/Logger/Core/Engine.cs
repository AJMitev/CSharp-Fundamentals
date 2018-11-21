namespace Logger.Core
{
    using System;
    using System.Collections.Generic;
    using Appenders.Contracts;
    using Contracts;

    public class Engine : IEngine
    {
        private  ICommandInterpreter _commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            _commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] inputArgs = Console.ReadLine().Split();

                this._commandInterpreter.AddAppender(inputArgs);
            }

            string line = Console.ReadLine();
            while (line != "END")
            {
                var args = line.Split('|');

                this._commandInterpreter.AddMessage(args);
                
                line = Console.ReadLine();
            }

            this._commandInterpreter.PrintInfo();
        }
    }
}