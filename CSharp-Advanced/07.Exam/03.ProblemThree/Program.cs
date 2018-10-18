using System;

namespace _03.ProblemThree
{
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] commands = Console.ReadLine().Split();

            char[][] filed = new char[size][];
            for (int i = 0; i < size; i++)
            {
                filed[i] = new char[size];
                filed[i] = Console.ReadLine().Split(" ").Select(char.Parse).ToArray();
            }

            int coals = FindAllCoals(filed);
            bool isEscaped = false;
            int[] playerPosition = FindPlayerStartPosition(filed);
            for (int j = 0; j < commands.Length; j++)
            {

                isEscaped = MovePlayer(filed, commands[j], coals, playerPosition);
                playerPosition = FindPlayerStartPosition(filed);
                coals = FindAllCoals(filed);

                if (isEscaped)
                {
                    Console.WriteLine($"Game over! ({playerPosition[0]}, {playerPosition[1]})");
                    break;
                }

                if (coals <= 0)
                {
                    Console.WriteLine($"You collected all coals! ({playerPosition[0]}, {playerPosition[1]})");
                    break;
                }

            }


            if (!isEscaped && coals > 0 )
            {
                Console.WriteLine($"{coals} coals left. ({playerPosition[0]}, {playerPosition[1]})");
            }
        }


        private static int[] FindPlayerStartPosition(char[][] filed)
        {
            for (int row = 0; row < filed.Length; row++)
            {
                for (int col = 0; col < filed[row].Length; col++)
                {
                    if (filed[row][col].Equals('s'))
                    {
                        return new[] { row, col };
                    }
                }
            }

            return new[] { -1, -1 };
        }

        private static bool MovePlayer(char[][] filed, string command, int coals, int[] player)
        {

            int playerRow = player[0];
            int playerCol = player[1];
            char nextIndex = 'l';
            switch (command)
            {
                case "up":
                    if (playerRow - 1 < 0)
                    {
                        return false;
                    }

                     nextIndex = filed[playerRow - 1][playerCol];


                    if (nextIndex.Equals('e'))
                    {
                        filed[playerRow][playerCol] = '*';
                        filed[playerRow - 1][playerCol] = 's';
                        return true;
                    }

                    if (nextIndex.Equals('*'))
                    {
                        filed[playerRow][playerCol] = '*';
                        filed[playerRow - 1][playerCol] = 's';
                        return false;
                    }

                    if (nextIndex.Equals('c'))
                    {
                        filed[playerRow][playerCol] = '*';
                        filed[playerRow - 1][playerCol] = 's';
                        --coals;
                        return false;
                    }

                    break;
                case "down":
                    if (playerRow + 1 >= filed.Length)
                    {
                        return false;
                    }

                     nextIndex = filed[playerRow + 1][playerCol];


                    if (nextIndex.Equals('e'))
                    {
                        filed[playerRow][playerCol] = '*';
                        filed[playerRow + 1][playerCol] = 's';
                        return true;
                    }

                    if (nextIndex.Equals('*'))
                    {
                        filed[playerRow][playerCol] = '*';
                        filed[playerRow + 1][playerCol] = 's';
                        return false;
                    }

                    if (nextIndex.Equals('c'))
                    {
                        filed[playerRow][playerCol] = '*';
                        filed[playerRow + 1][playerCol] = 's';
                        --coals;
                        return false;
                    }

                    break;
                case "left": 
                    if (playerCol - 1 < 0)
                    {
                        return false;
                    }

                    nextIndex = filed[playerRow][playerCol-1];


                    if (nextIndex.Equals('e'))
                    {
                        filed[playerRow][playerCol] = '*';
                        filed[playerRow][playerCol+1] = 's';
                        return true;
                    }

                    if (nextIndex.Equals('*'))
                    {
                        filed[playerRow][playerCol] = '*';
                        filed[playerRow][playerCol-1] = 's';
                        return false;
                    }

                    if (nextIndex.Equals('c'))
                    {
                        filed[playerRow][playerCol] = '*';
                        filed[playerRow][playerCol-1] = 's';
                        --coals;
                        return false;
                    }

                    break;
                case "right": 
                    if (playerCol + 1 >= filed.Length)
                    {
                        return false;
                    }

                    nextIndex = filed[playerRow][playerCol+1];


                    if (nextIndex.Equals('e'))
                    {
                        filed[playerRow][playerCol] = '*';
                        filed[playerRow][playerCol+1] = 's';
                        return true;
                    }

                    if (nextIndex.Equals('*'))
                    {
                        filed[playerRow][playerCol] = '*';
                        filed[playerRow][playerCol + 1] = 's';
                        return false;
                    }

                    if (nextIndex.Equals('c'))
                    {
                        filed[playerRow][playerCol] = '*';
                        filed[playerRow][playerCol+1] = 's';
                        --coals;
                        return false;
                    }
                    break;
            }


            return false;
        }

        private static int FindAllCoals(char[][] filed)
        {
            int counter = 0;
            for (int row = 0; row < filed.Length; row++)
            {
                for (int col = 0; col < filed[row].Length; col++)
                {
                    if (filed[row][col].Equals('c'))
                    {
                        ++counter;
                    }
                }
            }

            return counter;
        }
    }
}
