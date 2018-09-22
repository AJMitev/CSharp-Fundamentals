namespace Problem_5.Calculate_Sequence_with_Queue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Numerics;

    public class CalculateSequence
    {
        public static void Main()
        {
            BigInteger number = BigInteger.Parse(Console.ReadLine());
            var queue = new Queue<BigInteger>();
            var result = new List<BigInteger>();
            result.Add(number);
            while (result.Count < 50)
            {
                queue.Enqueue(number + 1);
                result.Add(number + 1);
                queue.Enqueue(number * 2 + 1);
                result.Add(number * 2 + 1);
                queue.Enqueue(number + 2);
                result.Add(number + 2);

                number = queue.Dequeue();
            }

            Console.WriteLine(string.Join(" ", result.Take(50)));
        }
    }
}
