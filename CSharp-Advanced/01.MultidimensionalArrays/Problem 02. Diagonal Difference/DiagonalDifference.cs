namespace Problem_02._Diagonal_Difference
{
    using System;
    using System.Linq;

    public class DiagonalDifference
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size,size];

            for (int i = 0; i < size; i++)
            {
                int[] numbers = Console.ReadLine()
                    .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }

            int primaryDiagonalSum = 0;
            int secondaryDiagonalSum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                 primaryDiagonalSum += matrix[row, row];
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                secondaryDiagonalSum += matrix[matrix.GetLength(0) - 1 - row, row];
            }

            int result = Math.Abs(primaryDiagonalSum - secondaryDiagonalSum);
            Console.WriteLine(result);

        }
    }
}
