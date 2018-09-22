namespace Problem_3.Maximum_Element
{
    using System;
    using System.Collections.Generic;

    public class MaximumElement
    {
        public static void Main()
        {
            var sequence = int.Parse(Console.ReadLine());
            var stack = new Stack<int>();

            for (int i = 0; i < sequence; i++)
            {
                var line = Console.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int command = int.Parse(line[0]);

                switch (command)
                {
                    case 1:
                        stack.Push(int.Parse(line[1]));
                        break;
                    case 2:
                        stack.Pop();
                        break;
                    case 3:
                        var maximumNumber = int.MinValue;
                        foreach (int n in stack)
                        {
                            if (maximumNumber < n)
                            {
                                maximumNumber = n;
                            }
                        }
                        Console.WriteLine(maximumNumber);
                        break;
                }
            }
        }
    }
}
