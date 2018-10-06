namespace Problem_01._Odd_Lines
{
    using System;
    using System.IO;

    public class OddLines
    {
        public static void Main()
        {
            string filePath = "../../../text.txt";
            int line = 0;

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (sr.Peek() >= 0)
                {
                    var textLine = sr.ReadLine();
                    if (line % 2 == 1)
                    {
                        Console.WriteLine(textLine);
                    }

                    ++line;
                }
            }

        }
    }
}
