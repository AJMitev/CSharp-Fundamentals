namespace Problem_1._Unique_Usernames
{
    using System;
    using System.Collections.Generic;

    public class Usernames
    {
        public static void Main(string[] args)
        {
            int lines = int.Parse(Console.ReadLine());
            var values = new HashSet<string>();

            for (int i = 0; i < lines; i++)
            {
                string input = Console.ReadLine();
                values.Add(input);
            }

            foreach (string item in values)
            {
                Console.WriteLine(item);
            }
        }
    }
}
