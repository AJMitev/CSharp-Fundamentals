namespace Problem_4._Even_Times
{
    using System;
    using System.Collections.Generic;

    public class Times
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var numbers = new Dictionary<string,int>();

            for (int i = 0; i < n; i++)
            {
                string line = Console.ReadLine();

                if (!numbers.ContainsKey(line))
                {
                    numbers.Add(line, 0);
                }

                int count = numbers[line];

                numbers[line] = ++count;
            }

            foreach (var key in numbers.Keys)
            {
                if (numbers[key] % 2 == 0)
                {
                    Console.WriteLine(key);
                }
            }
        }
    }
}
