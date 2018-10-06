namespace Problem_5._Count_Symbols
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Symbols
    {
        public static void Main()
        {
            var counting = new Dictionary<char,int>();
            string line = Console.ReadLine();

            for (int i = 0; i < line.Length; i++)
            {
                if (!counting.ContainsKey(line[i]))
                {
                    counting.Add(line[i], 0);
                }

                int count = counting[line[i]];

                counting[line[i]] = ++count;
            }

            foreach (var key in counting.Keys.OrderBy(a=>a))
            {
                Console.WriteLine($"{key}: {counting[key]} time/s");
            }
        }
    }
}
