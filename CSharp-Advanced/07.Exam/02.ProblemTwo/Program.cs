using System;

namespace _02.ProblemTwo
{
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            var users = new Dictionary<string, Dictionary<string, int>>();
            while (input != "end")
            {
                if (input.StartsWith("ban"))
                {
                    string[] data = input.Split();

                    users.Remove(data[1]);
                }
                else
                {
                    string[] data = input.Split(" -> ");
                    string username = data[0];
                    string hashtag = data[1];
                    int likes = int.Parse(data[2]);

                    if (!users.ContainsKey(username))
                    {
                        users.Add(username, new Dictionary<string, int>());
                    }

                    if (!users[username].ContainsKey(hashtag))
                    {
                        users[username].Add(hashtag,0);
                    }

                    users[username][hashtag] += likes;
                }



                input = Console.ReadLine();
            }


            foreach (var user in users.Keys.OrderByDescending(k=>users[k].Values.Sum()).ThenBy(h=>users[h].Count))
            {
                Console.WriteLine(user);
                foreach (var data in users[user])
                {
                    Console.WriteLine($"- {data.Key}: {data.Value}");
                }
            }
        }
    }
}
