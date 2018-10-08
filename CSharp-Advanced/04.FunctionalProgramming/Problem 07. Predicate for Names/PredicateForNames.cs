namespace Problem_07._Predicate_for_Names
{
    using System;
    using System.Linq;

    public class PredicateForNames
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Predicate<string> isValid = x => x.Length <= size;

            Console.WriteLine(string.Join("\n", names.Where(x => isValid(x))));
        }
    }
}
