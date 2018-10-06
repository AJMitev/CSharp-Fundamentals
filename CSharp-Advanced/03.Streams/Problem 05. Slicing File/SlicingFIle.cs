namespace Problem_05._Slicing_File
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;

    public class SlicingFIle
    {
        public static void Main()
        {
            Console.WriteLine("Enter the source file path:");
            string sourceFilePath = Console.ReadLine();
            Console.WriteLine("How many parts you wanna slice it? (Enter an integer)");
            int.TryParse(Console.ReadLine(), NumberStyles.Integer, null, out int parts);
            string destinationDirectory = "../../../";
            //Slice(sourceFilePath, parts, destinationDirectory);

            var items = new List<string>
            {
                "E:\\Programming\\Software University\\CSharp-Fundamentals\\CSharp-Advanced\\03.Streams\\Problem 05. Slicing File\\Part-0.avi",
                "E:\\Programming\\Software University\\CSharp-Fundamentals\\CSharp-Advanced\\03.Streams\\Problem 05. Slicing File\\Part-1.avi",
                "E:\\Programming\\Software University\\CSharp-Fundamentals\\CSharp-Advanced\\03.Streams\\Problem 05. Slicing File\\Part-2.avi",
                "E:\\Programming\\Software University\\CSharp-Fundamentals\\CSharp-Advanced\\03.Streams\\Problem 05. Slicing File\\Part-3.avi",
                "E:\\Programming\\Software University\\CSharp-Fundamentals\\CSharp-Advanced\\03.Streams\\Problem 05. Slicing File\\Part-4.avi"
            };

            Assemble(items,destinationDirectory);


        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            byte[][] jaggedBuffer = new byte[files.Count][];
            int count = 0;

            foreach (string file in files)
            {
                using (FileStream fs = new FileStream(file, FileMode.Open, FileAccess.Read))
                {
                    jaggedBuffer[count] = new byte[fs.Length];

                    fs.Read(jaggedBuffer[count], 0, jaggedBuffer[count].Length);
                }
                ++count;
            }


            using (FileStream fs = new FileStream($"{destinationDirectory}/Assembled.avi", FileMode.Append, FileAccess.Write))
            {
                for (int i = 0; i < jaggedBuffer.Length; i++)
                {
                    fs.Write(jaggedBuffer[i], 0, jaggedBuffer[i].Length);
                }

            }
        }

        private static void Slice(string sourceFilePath, int parts, string destinationDirectory)
        {
            int partCount = 0;

            using (FileStream fs = new FileStream(sourceFilePath, FileMode.Open, FileAccess.ReadWrite))
            {
                byte[] buffer = new byte[fs.Length / parts];

                for (int i = 0; i < parts; i++)
                {
                    fs.Read(buffer, 0, buffer.Length);

                    using (FileStream writer = new FileStream(string.Concat(destinationDirectory, $"Part-{partCount}.avi"), FileMode.CreateNew, FileAccess.ReadWrite))
                    {
                        writer.Write(buffer, 0, buffer.Length);
                    }

                    ++partCount;
                }
            }
        }
    }
}
