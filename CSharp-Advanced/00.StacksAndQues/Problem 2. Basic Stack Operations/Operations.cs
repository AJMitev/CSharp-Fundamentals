namespace Problem_2.Basic_Stack_Operations
{
    using System;
    using System.Collections.Generic;

    public class Operations
    {
        public static void Main()
        {
            string[] commands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var stack = new Stack<int>();

            for (int i = 0; i < int.Parse(commands[0]); i++)
            {
                stack.Push(int.Parse(numbers[i]));
            }

            for (int i = 0; i < int.Parse(commands[1]); i++)
            {
                stack.Pop();
            }

            int lookingFor = int.Parse(commands[2]);

            if (stack.Contains(lookingFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                int smallest = Int32.MaxValue;
                foreach (int number in stack)
                {
                    if (smallest > number)
                    {
                        smallest = number;
                    }
                }

                if (smallest != Int32.MaxValue)
                {
                    Console.WriteLine(smallest);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
