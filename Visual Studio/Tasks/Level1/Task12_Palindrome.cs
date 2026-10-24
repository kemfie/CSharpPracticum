using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level1
{
    public class Task12_Palindrome : ITask
    {
        public string Title => "Палиндром (без учёта регистра/пробелов)";
        public string Description => "Проверить, является ли строка палиндромом.";

        public string[] Requirements => new[]
        {
            "Игнорировать регистр (ToLower/ToUpper).",
            "Игнорировать пробелы и знаки пунктуации.",
            "Не использовать LINQ Reverse.",
            "Пустая строка и строка из одного символа — палиндром."
        };

        public void Run()
        {
            string[] testStrings =
            {
                "А роза упала на лапу Азора",
                "hello",
                "12321",
                "A",
                " "
            };

            foreach (string text in testStrings)
            {
                bool result = IsPalindrome(text);
                Console.WriteLine($"\"{text}\" -> {result}");
            }
        }

        private bool IsPalindrome(string text)
        {
            if (string.IsNullOrEmpty(text)) return true;
            StringBuilder cleanStr = new StringBuilder();
            foreach (char c in text)
            {
                if (char.IsLetterOrDigit(c))
                {
                    cleanStr.Append(char.ToLower(c));
                }
            }
            string s = cleanStr.ToString();
            int left = 0;
            int right = s.Length - 1;
            while (left < right)
            {
                if (s[left] != s[right])
                {
                    return false;
                }
                left++;
                right--;
            }
            return true;
        }
    }
}
