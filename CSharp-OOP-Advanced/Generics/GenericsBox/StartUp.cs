namespace GenericBox
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var items = new List<double>(n);

            for (int i = 0; i < n; i++)
            {
                double message = double.Parse(Console.ReadLine());
                items.Add(message);
            }

            double element = double.Parse(Console.ReadLine());

            var box = new Box<double>(items);
            double result = box.ItemsGreaterThan(element);
            Console.WriteLine(result);
        }
    }
}
