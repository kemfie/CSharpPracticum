using System;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
    public class Task18_TryParseVsCatch : ITask
    {
        public string Title => "TryParse vs try/catch";
        public string Description => "Сравнить два способа обработки некорректного ввода числа.";

        public string[] Requirements => new[]
        {
            "Способ 1: int.TryParse — вернуть bool + значение через out.",
            "Способ 2: int.Parse внутри try/catch — ловить FormatException.",
            "Оба оформить отдельными методами.",
            "Продемонстрировать на корректном и некорректном вводе."
        };

        public void Run()
        {
            string[] testInputs = { "123", "abc", "45.6", "" };

            foreach (string input in testInputs)
            {
                Console.WriteLine($"\nТестируем ввод: \"{input}\"");

                bool success1 = ParseWithTryParse(input, out int result1);
                Console.WriteLine($"  TryParse:  Успех? {success1}, Результат: {(success1 ? result1.ToString() : "нет")}");

                bool success2 = ParseWithTryCatch(input, out int result2);
                Console.WriteLine($"  try/catch: Успех? {success2}, Результат: {(success2 ? result2.ToString() : "нет")}");
            }

            Console.WriteLine("\nВывод: оба метода справились без падения программы.");
        }

        private bool ParseWithTryParse(string input, out int result)
        {
            return int.TryParse(input, out result);
        }

        private bool ParseWithTryCatch(string input, out int result)
        {
            try
            {
                result = int.Parse(input);
                return true;
            }
            catch (FormatException)
            {
                result = 0;
                return false;
            }
            catch (ArgumentNullException)
            {
                result = 0;
                return false;
            }
        }
    }
}