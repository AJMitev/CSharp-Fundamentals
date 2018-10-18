namespace Problem_4___Hit_List
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class HitList
    {
        public static void Main()
        {
            int targetInfo = int.Parse(Console.ReadLine());
            var list = new Dictionary<string, Dictionary<string, string>>();

            var info = Console.ReadLine();
            while (!info.Equals("end transmissions"))
            {
                var commands = info.Split('=');
                string name = commands[0];
                string[] kvp = commands[1].Split(new[] { ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

                if (!list.ContainsKey(name))
                {
                    list.Add(name, new Dictionary<string, string>());
                }

                for (int i = 0; i < kvp.Length - 1; i += 2)
                {
                    if (list[name].ContainsKey(kvp[i]))
                    {
                        list[name][kvp[i]] = kvp[i + 1];
                    }
                    else
                    {
                        list[name].Add(kvp[i], kvp[i + 1]);

                    }
                }

                info = Console.ReadLine();
            }


            string personToKill = Console.ReadLine().Remove(0, 5);
            int personToKillSum = 0;
            Console.WriteLine($"Info on {personToKill}:");
            foreach (var key in list[personToKill].Keys.OrderBy(k => k))
            {
                Console.WriteLine($"---{key}: {list[personToKill][key]}");
                personToKillSum += key.Length + list[personToKill][key].Length;
            }

            Console.WriteLine($"Info index: {personToKillSum}");

            if (targetInfo <= personToKillSum)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                Console.WriteLine($"Need {targetInfo - personToKillSum} more info.");
            }
        }
    }
}