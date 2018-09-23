namespace Problem_03._2x2_Squares_in_Matrix
{
    using System;
    using System.Linq;

    public class SquaresInTheMatrix
    {
        public static void Main()
        {
            int[] sizes = Console.ReadLine()?
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            char[,] matrix = new char[sizes[0], sizes[1]];
            for (int row = 0; row < sizes[0]; row++)
            {
                char[] chars = Console.ReadLine()
                    .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();

                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            int squares = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    bool areTheyMatching = matrix[row, col] == matrix[row, col + 1] && 
                                           matrix[row, col] == matrix[row + 1, col] && 
                                           matrix[row, col] == matrix[row + 1, col + 1];

                    if (areTheyMatching)
                    {
                        ++squares;
                    }

                }
            }

            Console.WriteLine(squares);
        }
    }
}
