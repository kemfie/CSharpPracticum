using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level1
{
    internal class Task10_BubIns : ITask
    {
        public string Title => "Сортировка пузырьком + вставками";
        public string Description => "Отсортировать массив двумя алгоритмами.";

        public string[] Requirements => new[]
        {
            "Реализовать BubbleSort и InsertionSort отдельными методами.",
            "Оба — без LINQ и Array.Sort.",
            "Пустой массив — обработать (не падать)."
        };

        public void Run()
        {
            int[] originalArray = { 5, 2, 9, 1, 5, 6 };
            int[] arrayForBubble = originalArray;
            int[] arrayForInsertion = originalArray;
            Console.WriteLine("Исходный массив: " + string.Join(", ", originalArray));
            BubbleSort(arrayForBubble);
            Console.WriteLine("Пузырьком:       " + string.Join(", ", arrayForBubble));

            InsertionSort(arrayForInsertion);
            Console.WriteLine("Вставками:       " + string.Join(", ", arrayForInsertion));
        }



        private void BubbleSort(int[] arr)
        {
            if (arr == null || arr.Length == 0) return; 
            for (int i = 0; i < arr.Length - 1; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }
            }
        }
        private void InsertionSort(int[] arr)
        {
            if (arr == null || arr.Length == 0) return;

            for (int i = 1; i < arr.Length; i++)
            {
                int current = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > current)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = current;
            }
        }
    }
}
