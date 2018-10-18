namespace Problem_2___Sneaking
{
    using System;

    public class Sneaking
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] room = new char[n][];
            int[] playersPosition = {-1, -1};

            for (int i = 0; i < n; i++)
            {
                string row = Console.ReadLine();
                room[i] = new char[row.Length];

                for (int j = 0; j < row.Length; j++)
                {
                    room[i][j] = row[j];
                }

            }

            string directions = Console.ReadLine();

            for (int i = 0; i < directions.Length; i++)
            {
                EnemyMoves(room);
                bool isDead = CheckIfSamIsDead(room, playersPosition);
                if (isDead)
                {
                    Console.WriteLine($"Sam died at {playersPosition[0]}, {playersPosition[1]}");

                    foreach (char[] row in room)
                    {
                        Console.WriteLine(string.Join("", row));
                    }

                    return;
                }

                SamMoves(room, directions[i]);
                bool isSamWin = CheckIfSamWin(room, playersPosition);

                if (isSamWin)
                {
                    Console.WriteLine("Nikoladze killed!");

                    foreach (char[] row in room)
                    {
                        Console.WriteLine(string.Join("", row));
                    }

                    return;
                }
            }
        }

        private static bool CheckIfSamWin(char[][] room, int[] player)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col].Equals('S'))
                    {
                        player[0] = row;
                        player[1] = col;

                        for (int i = 0; i < room[row].Length; i++)
                        {
                            if (room[row][i].Equals('N'))
                            {
                                room[row][i] = 'X';
                                return true;
                            }
                        }
                    }
                }

            }

            return false;
        }

        private static void SamMoves(char[][] room, char move)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col].Equals('S'))
                    {
                        switch (move)
                        {
                            case 'U':
                                room[row][col] = '.';
                                room[row - 1][col] = 'S';
                                break;
                            case 'D':
                                room[row][col] = '.';
                                room[row + 1][col] = 'S';
                                break;
                            case 'L':
                                room[row][col] = '.';
                                room[row][col - 1] = 'S';
                                break;
                            case 'R':
                                room[row][col] = '.';
                                room[row][col + 1] = 'S';
                                break;
                            default:
                                break;
                        }

                        return;
                    }
                }

            }
        }

        private static bool CheckIfSamIsDead(char[][] room, int[] player)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    if (room[row][col].Equals('S'))
                    {
                        player[0] = row;
                        player[1] = col;

                        for (int i = 0; i < col; i++)
                        {
                            if (room[row][i].Equals('b'))
                            {
                                room[row][col] = 'X';
                                return true;
                            }
                        }

                        for (int i = col + 1; i < room[row].Length; i++)
                        {
                            if (room[row][i].Equals('d'))
                            {
                                room[row][col] = 'X';
                                return true;
                            }
                        }
                    }
                }

            }

            return false;
        }

        private static void EnemyMoves(char[][] room)
        {
            for (int row = 0; row < room.Length; row++)
            {
                for (int col = 0; col < room[row].Length; col++)
                {
                    // Moves Left to Right
                    if (room[row][col].Equals('b'))
                    {
                        if (col == room[row].Length - 1)
                        {
                            room[row][col] = 'd';
                        }
                        else
                        {
                            room[row][col] = '.';
                            room[row][col + 1] = 'b';
                            ++col;
                        }
                    }

                    // Moves Right to Left
                    if (room[row][col].Equals('d'))
                    {
                        if (col == 0)
                        {
                            room[row][col] = 'b';
                        }
                        else
                        {
                            room[row][col] = '.';
                            room[row][col - 1] = 'd';
                        }
                    }
                }

            }
        }
    }
}