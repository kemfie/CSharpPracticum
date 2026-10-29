using System;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
    public class Task20_Generalizations : ITask
    {
        public string Title => "Обобщения: Swap<T>, Max<T> с IComparable<T>";
        public string Description => "Написать обобщённые методы Swap и Max.";

        public string[] Requirements => new[]
        {
            "Swap<T>(ref T a, ref T b) — меняет значения местами.",
            "Max<T>(T a, T b) where T : IComparable<T> — возвращает большее.",
            "Продемонстрировать на int, string, double.",
            "Swap — без ограничений, Max — с ограничением."
        };

        public void Run()
        {
            Console.WriteLine("Тестирование Swap<T>");

            int x = 5, y = 10;
            Console.WriteLine($"До Swap: x = {x}, y = {y}");
            GenericsHelper.Swap(ref x, ref y);
            Console.WriteLine($"После Swap: x = {x}, y = {y}\n");

            string s1 = "Яблоко", s2 = "Апельсин";
            Console.WriteLine($"До Swap: s1 = {s1}, s2 = {s2}");
            GenericsHelper.Swap(ref s1, ref s2);
            Console.WriteLine($"После Swap: s1 = {s1}, s2 = {s2}\n");


            Console.WriteLine("Тестирование Max<T>");

            int maxInt = GenericsHelper.Max(15, 42);
            Console.WriteLine($"Max(15, 42) = {maxInt}");

            double maxDouble = GenericsHelper.Max(3.14, 2.71);
            Console.WriteLine($"Max(3.14, 2.71) = {maxDouble}");

            string maxString = GenericsHelper.Max("Бананы", "Ананасы");
            Console.WriteLine($"Max(\"Бананы\", \"Ананасы\") = {maxString}");
        }
    }
}