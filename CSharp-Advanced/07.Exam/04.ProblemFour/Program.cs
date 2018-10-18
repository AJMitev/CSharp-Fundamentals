using System;

namespace _04.ProblemFour
{
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var bottles = new Stack<int>();
            var cups = new Queue<int>();

            int[] cupsCapacity = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] bottleSizes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int wastedWater = 0;

            for (int i = 0; i < cupsCapacity.Length; i++)
            {
                cups.Enqueue(cupsCapacity[i]);
            }

            for (int i = 0; i < bottleSizes.Length; i++)
            {
                bottles.Push(bottleSizes[i]);
            }

            while (cups.Count != 0 && bottles.Count != 0)
            {
                var currentBottleSize = bottles.Pop();
                var currentCupSize = cups.Peek();



                int result = currentCupSize - currentBottleSize;

                if (result <= 0)
                {
                    cups.Dequeue();

                    if (result < 0)
                    {
                        wastedWater += result;
                    }
                }
                else
                {
                    while (result > 0 && bottles.Count > 0)
                    {

                        var newBottle = bottles.Pop();
                        result -= newBottle;

                        if (result < 0)
                        {
                            wastedWater += result;
                        }

                    }

                    cups.Dequeue();
                }
            }


            if (cups.Count != 0)
            {
                Console.WriteLine($"Cups: {string.Join(" ", cups)}");

            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(" ", bottles)}");
            }

            Console.WriteLine($"Wasted litters of water: {Math.Abs(wastedWater)}");

        }
    }
}
