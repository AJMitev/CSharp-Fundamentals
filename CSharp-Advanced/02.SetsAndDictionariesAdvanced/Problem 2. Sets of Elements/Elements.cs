namespace Problem_2._Sets_of_Elements
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Elements
    {
        public static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine()?
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();
            var firstArray = new HashSet<int>();
            var secondArray = new HashSet<int>();
            var result = new HashSet<int>();

            for (int i = 0; i < sizes[0]; i++)
            {
                firstArray.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < sizes[1]; i++)
            {
                secondArray.Add(int.Parse(Console.ReadLine()));
            }

            foreach (int number in firstArray)
            {
                if (secondArray.Contains(number))
                {
                    result.Add(number);
                }
            }

            Console.WriteLine(string.Join(" ",result));
        }
    }
}
