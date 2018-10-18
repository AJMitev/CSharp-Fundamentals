using System;

namespace _01.ProblemOne
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int dataSize = 0;

            for (int i = 0; i < n; i++)
            {
                string message = Console.ReadLine(); //Console.ReadLine().Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
                string pattern = "(s:.+;)(r:.+;)(m--\"[A-Za-z\\s]+\")";
                if (Regex.IsMatch(message, pattern))
                {
                    var info = message.Split(";");

                    string sender = string.Empty;
                    string reciver = string.Empty;
                    string text = string.Empty;


                    for (int j = 0; j < 3; j++)
                    {


                        if (j == 0)
                        {
                            var senderInfo = info[0].Split(":");

                            for (int k = 0; k < senderInfo[1].Length; k++)
                            {
                                if (((int)senderInfo[1][k] >= 65 && (int)senderInfo[1][k] <= 90) || ((int)senderInfo[1][k] >= 97 && (int)senderInfo[1][k] <= 122) || senderInfo[1][k] == ' ')
                                {
                                    sender += senderInfo[1][k];
                                }
                                else if ((int)senderInfo[1][k] >= 48 && (int)senderInfo[1][k] <= 57)
                                {
                                    string number = senderInfo[1][k].ToString();
                                    dataSize += int.Parse(number);
                                }
                            }
                        }

                        if (j == 1)
                        {
                            var senderInfo = info[1].Split(":");

                            for (int k = 0; k < senderInfo[1].Length; k++)
                            {
                                if (((int)senderInfo[1][k] >= 65 && (int)senderInfo[1][k] <= 90) || ((int)senderInfo[1][k] >= 97 && (int)senderInfo[1][k] <= 122) || senderInfo[1][k] == ' ')
                                {
                                    reciver += senderInfo[1][k];
                                }
                                else if ((int)senderInfo[1][k] >= 48 && (int)senderInfo[1][k] <= 57)
                                {
                                    string number = senderInfo[1][k].ToString();
                                    dataSize += int.Parse(number);
                                }
                            }
                        }

                        if (j == 2)
                        {
                            var messageinfo = info[2].Split("--");
                            text = messageinfo[1];
                        }

                    }

                    Console.WriteLine($"{sender} says {text} to {reciver}");

                }


            }
            Console.WriteLine($"Total data transferred: {dataSize}MB");

        }
    }
}
