namespace Problem_3._Periodic_Table
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PeriodicTable
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var elements = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elementsToAdd = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                foreach (var element in elementsToAdd)
                {
                    elements.Add(element);
                }
            }

            Console.WriteLine(string.Join(" ",elements.OrderBy(e=>e)));
        }
    }
}
