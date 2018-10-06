namespace Problem_04._Copy_Binary_File
{
    using System.IO;

    public class BinaryCopy
    {
        public static void Main()
        {
            string filePath = "../../../copyMe.png";
            string newFilePath = "../../../copyMe_new.png";

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite))
            {
                using (FileStream newFileStream = new FileStream(newFilePath,FileMode.CreateNew,FileAccess.ReadWrite))
                {
                    byte[] buffer = new byte[fs.Length];

                    fs.Read(buffer, 0, buffer.Length);

                    newFileStream.Write(buffer,0,buffer.Length);
                }
            }
        }
    }
}
