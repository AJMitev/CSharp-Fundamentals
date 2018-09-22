namespace Problem_8.Stack_Fibonacci
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public class Fibbonacci
    {
        public static void Main()
        {
            var stack = new Stack<BigInteger>();
            stack.Push(0);
            stack.Push(1);

            int numberOfFibbunacci = int.Parse(Console.ReadLine());

            for (int num = 0; num < numberOfFibbunacci-1; num++)
            {
                BigInteger f2 = stack.Pop();
                BigInteger f1 = stack.Pop();
                BigInteger f3 = f1 + f2;
                stack.Push(f2);
                stack.Push(f3);
            }

            Console.WriteLine(stack.Peek());

        }
    }
}
