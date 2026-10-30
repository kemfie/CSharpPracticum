using System;
using System.Collections.Generic;
using System.Linq;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level3
{
    public class Task36_DubList : ITask
    {
        public string Title => "Дубликаты в List (HashSet + GroupBy)";
        public string Description => "Найти дубликаты в списке чисел двумя способами.";

        public string[] Requirements => new[]
        {
            "Способ 1: через HashSet<int> — при добавлении проверять Contains.",
            "Способ 2: через LINQ GroupBy(x => x).Where(g => g.Count() > 1).",
            "Оба способа оформить отдельными методами.",
            "Продемонстрировать на списке с повторяющимися значениями."
        };

        public void Run()
        {
            List<int> numbers = new List<int> { 1, 2, 3, 2, 4, 5, 1, 6, 7, 3, 8, 9, 9 };

            Console.WriteLine("Исходный список: " + string.Join(", ", numbers) + "\n");

            var duplicates1 = FindDuplicatesWithHashSet(numbers);
            Console.WriteLine("Способ 1 (HashSet): " + string.Join(", ", duplicates1));

            var duplicates2 = FindDuplicatesWithLinq(numbers);
            Console.WriteLine("Способ 2 (LINQ):    " + string.Join(", ", duplicates2));

            bool isEqual = duplicates1.OrderBy(x => x).SequenceEqual(duplicates2.OrderBy(x => x));
            Console.WriteLine($"\nРезультаты совпадают? {isEqual}");
        }


        private List<int> FindDuplicatesWithHashSet(List<int> list)
        {
            HashSet<int> seen = new HashSet<int>();    
            HashSet<int> duplicates = new HashSet<int>();

            foreach (int num in list)
            {
                if (seen.Contains(num))
                {
                    duplicates.Add(num);
                }
                else
                {
                    seen.Add(num);
                }
            }

            return duplicates.ToList();
        }


        private List<int> FindDuplicatesWithLinq(List<int> list)
        {
            return list
                .GroupBy(x => x)              
                .Where(g => g.Count() > 1)    
                .Select(g => g.Key)           
                .ToList();
        }
    }
}
