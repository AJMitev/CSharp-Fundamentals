namespace Problem_02._Knights_of_Honor
{
    using System;
    using System.Collections;
    using System.Linq;

    public class KnightsOfHonor
    {
        public static void Main()
        {
            string[] names = Console.ReadLine()?.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries).ToArray();


            

            printNames(names);


        }

        public static Action<ICollection> printNames = namesToPrint =>
        {
            foreach (string s in namesToPrint)
            {
                Console.WriteLine($"Sir {s}");
            }

        };
    }

}
