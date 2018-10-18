namespace Problem_1___Key_Revolver
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class KeyRevolver
    {
        public static void Main()
        {
            int bulletPrice = int.Parse(Console.ReadLine());
            int sizeOfTheBarrel = int.Parse(Console.ReadLine());
            int[] bulletsArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] locksArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());


            var bullets = new Stack<int>();
            var locks = new Queue<int>();

            foreach (int bullet in bulletsArray)
            {
                bullets.Push(bullet);
            }

            foreach (int @lock in locksArray)
            {
                locks.Enqueue(@lock);
            }


            for (int i = 0; i < sizeOfTheBarrel; i++)
            {
                int currentBullet = bullets.Pop();
                int currentLock = locks.Peek();

                if (currentBullet <= currentLock)
                {
                    locks.Dequeue();
                    Console.WriteLine("Bang!");
                }
                else
                {
                    Console.WriteLine("Ping!");
                }

                if (i == sizeOfTheBarrel -1 && bullets.Count != 0)
                {
                    Console.WriteLine("Reloading!");
                    i = -1;
                }

                if (bullets.Count.Equals(0) && locks.Count > 0)
                {
                    Console.WriteLine($"Couldn't get through. Locks left: {locks.Count}");
                    break;
                }

                if (locks.Count.Equals(0))
                {
                    Console.WriteLine($"{bullets.Count} bullets left. Earned ${intelligenceValue - ((bulletsArray.Length - bullets.Count) * bulletPrice)}");
                    break;
                }
            }
        }
    }
}
