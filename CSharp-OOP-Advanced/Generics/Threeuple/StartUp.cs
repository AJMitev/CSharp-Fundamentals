namespace Threeuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {

            string[] personInfo = Console.ReadLine().Split();
            string fullName = personInfo[0] + " " + personInfo[1];
            string address = personInfo[2];
            string town = personInfo[3];

            string[] beerInfo = Console.ReadLine().Split();
            string name = beerInfo[0];
            int liters = int.Parse(beerInfo[1]);
            bool isDrunk = beerInfo[2] == "drunk";

            string[] someInfo = Console.ReadLine().Split();
            string someName =  someInfo[0];
            double someBalance = double.Parse(someInfo[1]);
            string someBank = someInfo[2];

            var personTuple = new Threeuple<string, string, string>(fullName, address, town);
            var beerTuple = new Threeuple<string, int, bool>(name, liters,isDrunk);
            var specialTuple = new Threeuple<string, double,string>(someName, someBalance,someBank);

            Console.WriteLine(personTuple);
            Console.WriteLine(beerTuple);
            Console.WriteLine(specialTuple);
        }
    }
}
