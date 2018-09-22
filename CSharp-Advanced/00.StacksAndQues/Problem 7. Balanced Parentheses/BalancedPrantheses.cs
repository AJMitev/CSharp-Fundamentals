namespace Problem_7.Balanced_Parentheses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BalancedPrantheses
    {
        public static void Main()
        {
            string prantheses = Console.ReadLine();

            var stack = new Stack<char>();
            char[] openingPrantheses = new[]
            {
                '(',
                '[',
                '{'
            };

            bool isValid = true;


            for (int i = 0; i < prantheses.Length; i++)
            {
                char currentBracket = prantheses[i];

                if (openingPrantheses.Contains(currentBracket))
                {
                    stack.Push(currentBracket);
                    continue;

                }

                if (stack.Count == 0)
                {
                    isValid = false;
                    break;
                }

                if (stack.Peek().Equals('(') && currentBracket.Equals(')'))
                {
                    stack.Pop();
                    continue;
                }

                if (stack.Peek().Equals('{') && currentBracket.Equals('}'))
                {
                    stack.Pop();
                    continue;
                }

                if (stack.Peek().Equals('[') && currentBracket.Equals(']'))
                {
                    stack.Pop();
                    continue;
                }
            }


            if (isValid && stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }

        }
    }
}
