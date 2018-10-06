namespace Problem_02._Line_Numbers
{
    using System.IO;

    public class LineNumbers
    {
        public static void Main()
        {
            string filePath = "../../../text.txt";
            string pathToNewFile = "../../../text_new.txt";
            int line = 1;

            using (StreamReader reader = new StreamReader(filePath))
            {
                while (reader.Peek() >= 0)
                {
                    using (StreamWriter writer = new StreamWriter(pathToNewFile,true))
                    {
                        writer.WriteLine($"Line {line}:{reader.ReadLine()}");   
                    }

                    ++line;
                }
            }
        }
    }
}
