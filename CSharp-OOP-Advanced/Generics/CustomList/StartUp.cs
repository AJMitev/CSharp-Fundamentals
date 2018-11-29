namespace CustomList
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            var list = new CustomList<string>();

            while (input != "END")
            {
                //{
                //    •	Add <element> - Adds the given element to the end of the list
                //        •	Remove <index> - Removes the element at the given index
                //        •	Contains <element> - Prints if the list contains the given element (True or False)
                //    •	Swap <index> <index> - Swaps the elements at the given indexes
                //        •	Greater <element> - Counts the elements that are greater than the given element and prints their count
                //        •	Max - Prints the maximum element in the list
                //        •	Min - Prints the minimum element in the list
                //        •	Print


                var commands = input.Split();

                switch (commands[0])
                {
                    case "Add":
                        list.Add(commands[1]);
                        break;
                    case "Remove":
                        list.Remove(int.Parse(commands[1]));
                        break;
                    case "Contains":
                        Console.WriteLine(list.Contains(commands[1]));
                        break;
                    case "Swap":
                        list.Swap(int.Parse(commands[1]), int.Parse(commands[2]));
                        break;
                    case "Greater":
                        Console.WriteLine(list.CountGreaterThan(commands[1]));
                        break;
                    case "Max":
                        Console.WriteLine(list.Max());
                        break;
                    case "Min":
                        Console.WriteLine(list.Min());
                        break;
                    case "Sort":
                        list.Sort();
                        break;
                    case "Print":
                        Console.WriteLine(list);
                        break;
                }


                input = Console.ReadLine();
            }
        }
    }
}
