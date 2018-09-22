namespace Problem_6.Truck_Tour
{
    using System;
    using System.Linq;

    public class TruckTour
    {
        public static void Main()
        {
            int numberOfPumps = int.Parse(Console.ReadLine());
            int petrolCapacity = 0;
            int index = -1;
            bool isFuelEmpty = false;
            int[] petrolAtEachPump = new int[numberOfPumps];
            int[] distanceToNextPump = new int[numberOfPumps];

            for (int i = 0; i < numberOfPumps; i++)
            {
                var line = Console.ReadLine()?.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                petrolAtEachPump[i] = int.Parse(line[0]);
                distanceToNextPump[i] = int.Parse(line[1]);
            }

            for (int startingIndex = 0; startingIndex < numberOfPumps; startingIndex++)
            {

                for (int j = startingIndex; j < numberOfPumps; j++)
                {
                    petrolCapacity += petrolAtEachPump[j];
                    petrolCapacity -= distanceToNextPump[j];
                
                    if (petrolCapacity < 0)
                    {
                        isFuelEmpty = true;
                        index = -1;
                        petrolCapacity = 0;
                        break;
                    }

                    isFuelEmpty = false;
                }

                if (!isFuelEmpty)
                {
                    index = startingIndex;
                    break;
                }
            }

            Console.WriteLine(index);
        }
    }
}
