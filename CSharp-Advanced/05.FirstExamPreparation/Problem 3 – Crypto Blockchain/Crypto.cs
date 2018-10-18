namespace Problem_3___Crypto_Blockchain
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Crypto
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var chain = new StringBuilder(n * 16);
            string decryptedMessage = string.Empty;

            for (int i = 0; i < n; i++)
            {
                chain.Append(Console.ReadLine());
            }

            string patter = @"{[^\]\[{]+}|\[[^{}\[]+\]";
            var result = Regex.Matches(chain.ToString(), patter);
            string digitsOnly = @"\d{3}";
            var digits = new Dictionary<string,int>();

            foreach (Match match in result)
            {
                var current = Regex.Matches(match.ToString(), digitsOnly);
                digits.Add(current.ToString(),match.Length);
            }


            foreach (string crypto in digits.Keys)
            {
                int lenght = digits[crypto];

                for (int i = 0; i < crypto.Length; i+=3)
                {
                    int currentNumber = int.Parse(crypto.Substring(i, 3));
                    int decryptedChar = currentNumber - lenght;

                    decryptedMessage += (char) decryptedChar;
                }
            }

            Console.WriteLine(decryptedMessage);
        }
    }
}
