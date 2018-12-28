namespace ListyIterator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] data = Console.ReadLine()
                .Split()
                .Skip(1)
                .ToArray();

            var listy = new ListyIterator<string>(data);


            try
            {
                var input = Console.ReadLine();
                while (input != "END")
                {
                    switch (input)
                    {
                        case "Move":
                            Console.WriteLine(listy.Move());
                            break;
                        case "HasNext":
                            Console.WriteLine(listy.HasNext());
                            break;
                        case "Print":
                            Console.WriteLine(listy.Print());
                            break;
                        case "PrintAll":
                            Console.WriteLine(listy.PrintAll());
                            ;break;
                    }

                    input = Console.ReadLine();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
    }
}
