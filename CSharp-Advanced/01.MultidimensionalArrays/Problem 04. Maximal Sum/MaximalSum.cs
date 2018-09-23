namespace Problem_04._Maximal_Sum
{
    using System;
    using System.Linq;

    public class MaximalSum
    {
        public static void Main()
        {
            int[] sizes = Console.ReadLine()?
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[sizes[0], sizes[1]];
            for (int row = 0; row < sizes[0]; row++)
            {
                int[] numbers = Console.ReadLine()?
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] = numbers[col];
                }
            }

            int maxSum = int.MinValue;
            int firstNumber = int.MinValue;
            int secondNumber = int.MinValue;
            int thirdNumber = int.MinValue;
            int fourthNumber = int.MinValue;
            int fifthNumber = int.MinValue;
            int sixthNumber = int.MinValue;
            int seventhNumber = int.MinValue;
            int eightNumber = int.MinValue;
            int ninthNumber = int.MinValue;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2] +
                                     matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2] +
                                     matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        firstNumber = matrix[row, col];
                        secondNumber = matrix[row, col + 1];
                        thirdNumber = matrix[row, col + 2];

                        fourthNumber = matrix[row + 1, col];
                        fifthNumber = matrix[row + 1, col + 1];
                        sixthNumber = matrix[row + 1, col + 2];

                        seventhNumber = matrix[row + 2, col];
                        eightNumber = matrix[row + 2, col + 1];
                        ninthNumber = matrix[row + 2, col + 2];
                    }
                }
            }

            Console.WriteLine($"Sum = {maxSum}");
            Console.WriteLine($"{firstNumber} {secondNumber} {thirdNumber}");
            Console.WriteLine($"{fourthNumber} {fifthNumber} {sixthNumber}");
            Console.WriteLine($"{seventhNumber} {eightNumber} {ninthNumber}");
        }
    }
}
