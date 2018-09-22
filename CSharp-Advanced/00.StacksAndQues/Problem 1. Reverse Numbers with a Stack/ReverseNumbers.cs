namespace Problem_1.Reverse_Numbers_with_a_Stack
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ReverseNumbers
    {
       public static void Main()
       {
           string[] numbers = Console.ReadLine()?.Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries).ToArray();

           var stack = new Stack<int>();

           foreach (var number in numbers)
           {
               stack.Push(int.Parse(number));
           }

           int rounds = stack.Count;

           for (int i = 0; i < rounds; i++)
           {
               Console.Write($"{stack.Pop()} ");
           }

           Console.WriteLine();
       }
    }
}
