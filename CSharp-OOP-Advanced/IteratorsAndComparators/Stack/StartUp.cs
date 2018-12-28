namespace Stack
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] data = Console.ReadLine()
                .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .Skip(1)
                .ToArray();

            var stack = new Stack<string>();

            foreach (string s in data)
            {
                stack.Push(s);
            }


            string input = Console.ReadLine();

            while (input != "END")
            {
                try
                {
                    switch (input)
                    {
                        case "Pop":
                            stack.Pop();
                            break;
                        default:
                            string value = input.Split()[1];
                            stack.Push(value);
                            break;
                    }
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(string.Join(Environment.NewLine, stack));
            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }
    }
}
