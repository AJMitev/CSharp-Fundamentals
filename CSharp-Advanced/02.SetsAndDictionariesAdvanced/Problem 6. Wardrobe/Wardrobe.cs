namespace Problem_6._Wardrobe
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Wardrobe
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var wardrobe = new Dictionary<string, Dictionary<string, int>>();
            

            for (int i = 0; i < n; i++)
            {
                string[] line = Console.ReadLine()?
                    .Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();
                string color = line[0];
                string[] clothes = line[1]
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                if (!wardrobe.ContainsKey(color))
                {
                    wardrobe.Add(color, new Dictionary<string, int>());
                }

                for (int k = 0; k < clothes.Length; k++)
                {
                    if (!wardrobe[color].ContainsKey(clothes[k]))
                    {
                        wardrobe[color].Add(clothes[k], 0);
                    }

                    wardrobe[color][clothes[k]]++;
                }
            }

            string[] lookingFor = Console.ReadLine()?
                .Split();

            foreach (var color in wardrobe.Keys)
            {
                Console.WriteLine($"{color} clothes:");
                foreach (var cloth in wardrobe[color].Keys)
                {
                    int count = wardrobe[color][cloth];
                    if (color == lookingFor[0] && cloth == lookingFor[1])
                    {
                        Console.WriteLine($"* {cloth} - {count} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth} - {count}");
                    }
                }
            }
        }
    }
}
