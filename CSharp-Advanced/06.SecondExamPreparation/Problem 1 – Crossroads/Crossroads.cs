namespace Problem_1___Crossroads
{
    using System;
    using System.Collections.Generic;

    public class Crossroads
    {
        public static void Main()
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            var queue = new Queue<string>();
            int carsPassed = 0;
            int greenLight = greenLightDuration;

            string line = Console.ReadLine();
            while (line != "END")
            {

                while (line != "green")
                {
                    queue.Enqueue(line);
                    line = Console.ReadLine();
                }
                

                var loop = queue.Count;
                for (int i = 0; i < loop; i++)
                {
                    var currentCar = queue.Dequeue();


                    if (currentCar.Length > (greenLightDuration + freeWindowDuration))
                    {
                        Console.WriteLine("A crash happened!");
                        Console.WriteLine($"{currentCar} was hit at {currentCar[greenLightDuration + freeWindowDuration]}.");
                        return;
                    }

                    greenLightDuration -= currentCar.Length;
                    ++carsPassed;

                    if (greenLightDuration <= 0)
                    {
                     break;   
                    }
                }

                greenLightDuration = greenLight;
                line = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{carsPassed} total cars passed the crossroads.");

        }
    }
}
