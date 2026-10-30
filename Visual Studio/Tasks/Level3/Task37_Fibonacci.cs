using System;
using System.Collections.Generic;
using System.Diagnostics;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level3
{
    public class Task37_Fibonacci : ITask
    {
        public string Title => "Мемоизация Фибоначчи через Dictionary";
        public string Description => "Реализовать мемоизированную функцию Фибоначчи.";

        public string[] Requirements => new[]
        {
            "Обычная рекурсивная версия (для сравнения на маленьком N).",
            "Мемоизированная версия с Dictionary<int, long>.",
            "Замерить время обеих на N = 30–35 через Stopwatch.",
            "Вывести оба времени и разницу."
        };

        public void Run()
        {
            int n = 35;
            Console.WriteLine($"Вычисляем число Фибоначчи для N = {n}\n");

            Stopwatch sw = new Stopwatch();

            sw.Start();
            long result1 = FibRecursive(n);
            sw.Stop();
            long time1 = sw.ElapsedMilliseconds;

            Console.WriteLine($"Обычная рекурсия:    {result1} (время: {time1} мс)");


            Dictionary<int, long> cache = new Dictionary<int, long>();

            sw.Restart();
            long result2 = FibMemoized(n, cache);
            sw.Stop();
            long time2 = sw.ElapsedMilliseconds;

            Console.WriteLine($"Мемоизация (кэш):    {result2} (время: {time2} мс)");

            Console.WriteLine($"\nРазница во времени:  {time1 - time2} мс");
            Console.WriteLine($"Результаты равны?    {result1 == result2}");
        }

        private long FibRecursive(int n)
        {
            if (n <= 1) return n;
            return FibRecursive(n - 1) + FibRecursive(n - 2);
        }

        private long FibMemoized(int n, Dictionary<int, long> cache)
        {
            if (n <= 1) return n;

            if (cache.ContainsKey(n))
            {
                return cache[n];
            }

            long result = FibMemoized(n - 1, cache) + FibMemoized(n - 2, cache);
            cache[n] = result;

            return result;
        }
    }
}
