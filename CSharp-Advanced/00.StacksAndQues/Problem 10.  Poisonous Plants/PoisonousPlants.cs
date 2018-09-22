namespace Problem_10.Poisonous_Plants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PoisonousPlants
    {
        public static void Main()
        {
            // Input
            int n = int.Parse(Console.ReadLine());
            var plants = Console.ReadLine()?.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse)
                .ToList();
            int days = 0;

            var queue = new Queue<int>();

            while (true)
            {

                for (int i = 0; i < plants.Count - 1; i++)
                {
                    if (plants[i] < plants[i + 1])
                    {
                        queue.Enqueue(i + 1);
                    }
                }

                if (queue.Count.Equals(0))
                {
                    break;
                }

                ++days;

                foreach (int index in queue.OrderByDescending(index => index))
                {
                    plants.RemoveAt(index);
                }

                queue.Clear();
            }

            Console.WriteLine(days);
        }
    }
}