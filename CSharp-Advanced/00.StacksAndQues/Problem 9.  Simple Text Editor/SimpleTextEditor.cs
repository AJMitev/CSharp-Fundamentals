namespace Problem_9.Simple_Text_Editor
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SimpleTextEditor
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var actions = new Stack<string>();
            var removedString = new Stack<string>();
            var text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();
                actions.Push(line);

                var commands = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int action = int.Parse(commands[0]);

                switch (action)
                {
                    case 1:
                        text.Append(commands[1]);
                        break;
                    case 2:
                        string removed = String.Empty;
                        for (int k = 0; k < int.Parse(commands[1]); k++)
                        {
                            removed += text[text.Length - int.Parse(commands[1]) + k];
                        }
                        removedString.Push(removed);
                        text.Remove(text.Length - int.Parse(commands[1]), int.Parse(commands[1]));
                        break;
                    case 3:
                        int index = int.Parse(commands[1]);
                        Console.WriteLine(text[--index]);
                        break;
                    case 4:
                        UndoLastAction(actions, text, removedString);
                        break;
                }
            }
        }

        public static void UndoLastAction(Stack<string> actions, StringBuilder text, Stack<string> removed)
        {
            string lastAction = actions.Pop();

            while (lastAction[0] != '1' && lastAction[0] != '2')
            {
                    lastAction = actions.Pop();
            }

            var commands = lastAction.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            int action = int.Parse(commands[0]);

            switch (action)
            {
                case 1:
                    text.Remove(text.Length - (commands[1].Length), commands[1].Length);
                    break;
                case 2:
                    text.Append(removed.Pop());
                    break;
            }
        }
    }
}
