namespace Problem_07._Lego_Blocks
{
    using System;
    using System.Linq;

    public class Lego
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            int[][] firstJagged = new int[n][];
            int[][] secondJagged = new int[n][];

            for (int i = 0; i < n; i++)
            {
                firstJagged[i] = Console.ReadLine()?
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            for (int i = 0; i < n; i++)
            {
                secondJagged[i] = Console.ReadLine()?
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            Console.WriteLine();

            foreach (int[] numbers in secondJagged)
            {
                Array.Reverse(numbers);
            }

            var matrix = new int[n][];
            var length = 0;
            var isMatrix = true;
            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = firstJagged[i].Concat(secondJagged[i]).ToArray();
                if (i == 0)
                {
                    length = matrix[i].Length;
                }
                else if (matrix[i].Length != length)
                {
                    isMatrix = false;
                }

            }

            if (isMatrix)
            {
                foreach (var arr in matrix)
                {
                    var result = "[" + string.Join(", ", arr) + "]";
                    Console.WriteLine(result);
                }
            }
            else
            {
                int cels = 0;
                foreach (var arr in matrix)
                {
                    cels += arr.Length;
                }
                Console.WriteLine($"The total number of cells is: {cels}");
            }
        }
    }
}
