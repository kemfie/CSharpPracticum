using System;
using System.Collections.Generic;
using System.Linq; 
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level1
{
    public class Task13_Dictionary : ITask
    {
        public string Title => "Счётчик вхождений слов в тексте (Dictionary)";
        public string Description => "Посчитать, сколько раз каждое слово встречается в тексте.";

        public string[] Requirements => new[]
        {
            "Использовать Dictionary<string, int>.",
            "Разбить текст на слова (по пробелам и знакам пунктуации).",
            "Привести слова к нижнему регистру.",
            "Вывести пары «слово → количество», отсортированные по убыванию количества."
        };

        public void Run()
        {
            string text = "Вот дом, Который построил Джек. А это пшеница, Которая в темном чулане хранится В доме, Который построил Джек.";

            Console.WriteLine("Исходный текст:");
            Console.WriteLine(text);
            Console.WriteLine("\nРезультат:");
            char[] separators = text.Where(c => !char.IsLetterOrDigit(c)).ToArray();
            string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            foreach (string word in words)
            {
                string lowerWord = word.ToLower();
                if (wordCounts.ContainsKey(lowerWord))
                {
                    wordCounts[lowerWord]++;
                }
                else
                {
                    wordCounts[lowerWord] = 1;
                }
            }
            var sortedWords = wordCounts.OrderByDescending(pair => pair.Value);

            foreach (var pair in sortedWords)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}