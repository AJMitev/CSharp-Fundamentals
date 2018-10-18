namespace Problem_2___Knight_Game
{
    using System;

    public class KnightGame
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());
            char[][] board = new char[size][];

            int removed = 0;

            for (int i = 0; i < size; i++)
            {
                board[i] = new char[size];
                board[i] = Console.ReadLine().ToCharArray();
            }

            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (board[row][col].Equals('K'))
                    {
                        
                    }
                }
            }

        }
    }
}
