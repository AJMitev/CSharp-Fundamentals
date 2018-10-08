namespace Problem_03._Custom_Min_Function
{
    using System;
    using System.Linq;

    public class MinFunction
    {
        public static void Main()
        {
            Console.WriteLine(findSmallest(Console.ReadLine()?.Split().Select(int.Parse).ToArray()));
        }

        public static Func<int[], int> findSmallest = numbers => numbers.Min();
    }
}
