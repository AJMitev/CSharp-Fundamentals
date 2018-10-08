namespace Problem_04._Find_Evens_or_Odds
{
    using System;
    using System.Linq;

    public class EvenOrOdd
    {
        public static void Main()
        {
            int[] range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            string type = Console.ReadLine();

            Predicate<int> isEven = x => x % 2 == 0;

            Console.WriteLine(string.Join(" ", Enumerable
                .Range(range[0], range[1] - range[0] + 1)
                .Where(n => type == "even" ? isEven(n) : !isEven(n))
                .ToArray()));

        }
    }
}
