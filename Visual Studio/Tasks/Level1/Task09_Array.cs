using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level1
{
    internal class Task09_Array : ITask
    {
        public string Title => " Массивы: min/max/sum/avg";

        public string Description => " для массива чисел найти минимум, максимум, сумму и среднее.";
        public string[] Requirements => new[]
        {
            "Заполнить массив (например, случайными числами 1–100, размер 20).",
            "Реализовать без LINQ (Min/Max/Sum/Average запрещены).",
            "Оформить 4 отдельных метода.",
            "Пустой массив — обработать (вернуть ошибку или 0, но не падать).",
        };
        public void Run()
        {
            int[] numbers = new int[20];
            Random rnd = new Random();

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(1, 101);
            }
            Console.WriteLine("Массив: " + string.Join(", ", numbers));
            Console.WriteLine();
            Console.WriteLine($"Минимум: {GetMin(numbers)}");
            Console.WriteLine($"Максимум: {GetMax(numbers)}");
            Console.WriteLine($"Сумма: {GetSum(numbers)}");
            Console.WriteLine($"Среднее: {GetAverage(numbers):F2}");
            Console.WriteLine("\nПроверка пустого массива");
            int[] emptyArray = new int[0];
            Console.WriteLine($"Сумма пустого: {GetSum(emptyArray)}"); 
            Console.WriteLine($"Среднее пустого: {GetAverage(emptyArray)}"); 
        }
        private int GetMin(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0; 
            int min = arr[0];
            foreach (int num in arr)
            {
                if (num < min) min = num;
            }
            return min;
        }

        private int GetMax(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0; 
            int max = arr[0];
            foreach (int num in arr)
            {
                if (num > max) max = num;
            }
            return max;
        }
        private int GetSum(int[] arr)
        {
            if (arr == null) return 0; 

            int sum = 0;
            foreach (int num in arr)
            {
                sum += num;
            }
            return sum;
        }
        private double GetAverage(int[] arr)
        {
            if (arr == null || arr.Length == 0) return 0;
            int sum = GetSum(arr);
            return (double)sum / arr.Length;
        }
    }
}