using System;
using System.Collections.Generic;
using System.Linq;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
    public class Task34_GroupWords : ITask
    {
        public string Title => "LINQ: группировка слов по первой букве";
        public string Description => "Сгруппировать слова по первой букве.";

        public string[] Requirements => new[]
        {
            "Взять список слов (10+).",
            "Сгруппировать через LINQ GroupBy(w => w[0]).",
            "Отсортировать группы по первой букве.",
            "Внутри группы — отсортировать слова.",
            "Вывести «Буква: слово1, слово2, ...»."
        };

        public void Run()
        {
            List<string> words = new List<string>
            {
                "Яблоко", "Арбуз", "Банан", "Апельсин", "Брусника",
                "ягода", "Ананас", "Барбарис", "Груша", "Голубика",
                "Вишня", "Виноград"
            };

            Console.WriteLine("Исходный список: " + string.Join(", ", words) + "\n");
            var groupedWords = words
                .GroupBy(w => char.ToUpper(w[0])) 
                .OrderBy(g => g.Key)              
                .Select(g => new
                {
                    Letter = g.Key,
                    Words = g.OrderBy(w => w, StringComparer.OrdinalIgnoreCase).ToList()
                });

            Console.WriteLine("--- Результат группировки ---");
            foreach (var group in groupedWords)
            {
                Console.WriteLine($"{group.Letter}: {string.Join(", ", group.Words)}");
            }
        }
    }
}