using System;

namespace Lettercount
{
    static class Program
    {
        public const int MinNumber = 1;
        public const int MaxNumber = 1000;
        private static readonly string[] SingleDigitMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
        private static readonly string[] TensMap = new[] { "zero", "ten", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety" };
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");
            int totalLetters = 0;
            for (int i = MinNumber; i <= MaxNumber; i++)
            {
                var words = NumberToWords(i);
                var wordLength = GetLength(words);
                totalLetters = totalLetters + wordLength;
                Console.WriteLine($"{i} = {words}, Length : {wordLength}");
            }
            Console.WriteLine($"Total Letters : {totalLetters}");
            Console.WriteLine("Press any key to exit...");
            Console.ReadLine();
        }

        private static int GetLength(string word)
        {
            word = word.Replace(" ", "");
            return word.Replace("-", "").Length;
        }

        public static string NumberToWords(int number)
        {
            string words = "";


            if ((number / 1000) > 0)
            {
                words += NumberToWords(number / 1000) + " thousand ";
                number %= 1000;
            }

            if ((number / 100) > 0)
            {
                words += NumberToWords(number / 100) + " hundred ";
                number %= 100;
            }

            if (number > 0)
            {
                if (words != "")
                    words += "and ";



                if (number < 20)
                    words += SingleDigitMap[number];
                else
                {
                    words += TensMap[number / 10];
                    if ((number % 10) > 0)
                        words += "-" + SingleDigitMap[number % 10];
                }
            }

            return words.Trim();
        }
    }
}