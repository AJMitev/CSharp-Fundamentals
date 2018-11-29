namespace CustomTuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] personInfo = Console.ReadLine().Split();
            string fullName = personInfo[0] + " " + personInfo[1];
            string town = personInfo[2];

            string[] beerInfo = Console.ReadLine().Split();
            string name = beerInfo[0];
            int liters = int.Parse(beerInfo[1]);

            string[] specialNumbers = Console.ReadLine().Split();
            int specialInt = int.Parse(specialNumbers[0]);
            double specialDouble = double.Parse(specialNumbers[1]);

            var personTuple = new CustomTuple<string, string>(fullName, town);
            var beerTuple = new CustomTuple<string, int>(name, liters);
            var specialTuple = new CustomTuple<int, double>(specialInt, specialDouble);

            Console.WriteLine(personTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(specialTuple);
        }
    }
}
