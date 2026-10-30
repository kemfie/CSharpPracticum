using System;
using System.Collections.Generic;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level3
{
    public class Task39_YieldEvenNumbers : ITask
    {
        public string Title => "yield return — генератор чётных чисел";
        public string Description => "Реализовать генератор чётных чисел через yield return.";

        public string[] Requirements => new[]
        {
            "Метод IEnumerable<int> GetEvenNumbers(int max) — возвращает чётные числа до max.",
            "Реализовать именно через yield return, без промежуточного списка.",
            "Продемонстрировать работу в foreach.",
            "Дополнительно: показать ленивость — вывести сообщение внутри генератора и убедиться, что оно печатается по одному."
        };

        public void Run()
        {
            Console.WriteLine("--- Запуск генератора (ленивость) ---");

            IEnumerable<int> evens = GetEvenNumbers(10);

            Console.WriteLine("Метод вызван, но числа еще не сгенерированы (ленивость!).\n");

            foreach (int number in evens)
            {
                Console.WriteLine($"Получено число из foreach: {number}");

            }

            Console.WriteLine("\n--- Генератор завершил работу ---");
        }

        private IEnumerable<int> GetEvenNumbers(int max)
        {
            Console.WriteLine("[Генератор]: Начал работу.");

            for (int i = 0; i <= max; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"[Генератор]: Готовлю число {i}...");
                    Console.WriteLine($"[Генератор]: Готовлю число {i}...");
                    yield return i;
                }
            }

            Console.WriteLine("[Генератор]: Закончил работу.");
        }
    }
}
