namespace Problem_4.Basic_Queue_Operations
{
    using System;
    using System.Collections.Generic;

    public class QueueOperations
    {
        public static void Main()
        {
            string[] commands = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string[] numbers = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var queue = new Queue<int>();

            for (int i = 0; i < int.Parse(commands[0]); i++)
            {
                queue.Enqueue(int.Parse(numbers[i]));
            }

            for (int i = 0; i < int.Parse(commands[1]); i++)
            {
                queue.Dequeue();
            }

            int lookingFor = int.Parse(commands[2]);

            if (queue.Contains(lookingFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                int smallest = Int32.MaxValue;
                foreach (int number in queue)
                {
                    if (smallest > number)
                    {
                        smallest = number;
                    }
                }

                if (smallest != Int32.MaxValue)
                {
                    Console.WriteLine(smallest);
                }
                else
                {
                    Console.WriteLine(0);
                }
            }
        }
    }
}
