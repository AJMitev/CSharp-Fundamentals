namespace Problem_09._Crossfire
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Crossfire
    {
        public static void Main()
        {
            int[] parameters = Console.ReadLine()?
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[][] matrix = new int[parameters[0]][];
            int number = 1;
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[parameters[1]];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = number++;
                }
            }

            string line = Console.ReadLine();

            while (line != "Nuke it from orbit")
            {
                parameters = line?
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int row = parameters[0];
                int col = parameters[1];
                int radius = parameters[2];

                if (row >= matrix.Length || row < 0 || col < 0)
                {
                    line = Console.ReadLine();
                    continue;
                }

                for (int rw = Math.Max(0, row - radius); rw < Math.Min(matrix.Length, row + radius + 1); rw++)
                {
                    if (matrix[rw].Length > col)
                    {
                        matrix[rw][col] = -1;

                    }
                }

                for (int cl = Math.Max(0, col - radius); cl < Math.Min(matrix[row].Length, row + radius + 1); cl++)
                {
                    if (matrix[row].Length > cl)
                    {
                        matrix[row][cl] = -1;
                    }
                }

                var queue = new Queue<int>();
                for (int rw = 0; rw < matrix.Length; rw++)
                {
                    for (int i = 0; i < matrix[rw].Length; i++)
                    {
                        int currentSymbol = matrix[rw][i];
                        if (!currentSymbol.Equals(-1))
                        {
                            queue.Enqueue(currentSymbol);
                        }
                    }
                    matrix[rw] = new int[queue.Count];

                    for (int i = 0; i < matrix[rw].Length; i++)
                    {
                        matrix[rw][i] = queue.Dequeue();
                    }
                }


                line = Console.ReadLine();
            }

            foreach (int[] lineOfNumbers in matrix)
            {
                Console.WriteLine(string.Join(" ", lineOfNumbers));
            }
        }
    }
}
