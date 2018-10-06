namespace Problem_03._Word_Count
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class WordCount
    {
        public static void Main()
        {
            string filePath = "../../../text.txt";
            string pathToWords = "../../../words.txt";
            string pathToResult = "../../../result.txt";
            var kvp = new Dictionary<string, int>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string[] line = reader.ReadToEnd()
                    .ToLower()
                    .Split(new[] { ' ', '.', '?', '!', ',', '-','\r','\n' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < line.Length; i++)
                {
                    if (!kvp.Keys.Contains(line[i]))
                    {
                        kvp.Add(line[i], 0);
                    }

                    kvp[line[i]]++;
                }

                
            }


            using (StreamWriter wordsWriter = new StreamWriter(pathToWords, true))
            {
                foreach (string i in kvp.Keys)
                {
                    wordsWriter.WriteLine(i);
                }

                using (StreamWriter resultWriter = new StreamWriter(pathToResult, true))
                {
                    foreach (var item in kvp.OrderByDescending(i=>i.Value))
                    {
                            
                           resultWriter.WriteLine($"{item.Key} - {item.Value}");
                    }
                }
            }
        }
    }
}
