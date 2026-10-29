using System;
using System.Collections.Generic;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
    public class Task22_ParamsAndOverload : ITask
    {
        public string Title => "params-метод + перегрузка";
        public string Description => "Написать метод суммы с params и его перегрузку.";

        public string[] Requirements => new[]
        {
            "Sum(params int[] numbers) — сумма произвольного числа чисел.",
            "Перегрузка Sum(int[] numbers) — та же логика для массива.",
            "Продемонстрировать: Sum(1, 2, 3), Sum(new[] {1, 2, 3}), Sum().",
            "Пустой вызов — вернуть 0."
        };

        public void Run()
        {
            Console.WriteLine("--- Тестирование Sum ---");

            int result1 = Sum(1, 2, 3);
            Console.WriteLine($"Sum(1, 2, 3) = {result1}");

            int result2 = Sum(new[] { 1, 2, 3 });
            Console.WriteLine($"Sum(new[] {{1, 2, 3}}) = {result2}");

            int result3 = Sum();
            Console.WriteLine($"Sum() = {result3}");

            List<int> list = new List<int> { 1, 2, 3 };
            int result4 = Sum(list);
            Console.WriteLine($"Sum(List<int> {{1, 2, 3}}) = {result4}");
        }

        private int Sum(params int[] numbers)
        {
            if (numbers == null || numbers.Length == 0) return 0;

            int total = 0;
            foreach (int num in numbers)
            {
                total += num;
            }
            return total;
        }

        private int Sum(List<int> numbers)
        {
            if (numbers == null || numbers.Count == 0) return 0;

            int total = 0;
            foreach (int num in numbers)
            {
                total += num;
            }
            return total;
        }
    }
}