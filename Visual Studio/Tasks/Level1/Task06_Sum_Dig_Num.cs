using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level1
{
    internal class Task06_Sum_Dig_Num : ITask
    {
        public string Title => "Сумма цифр числа (строка + арифметика)";
        public string Description => " найти сумму цифр введённого числа (например, 1234 → 10).";
        public string[] Requirements => new[]
        {"Способ 1 (строка): число → ToString() → пройти по символам → int.Parse каждой цифры.",
            "Способ 2 (арифметика): цикл while (n > 0) { sum += n % 10; n /= 10; }..",
            "Оба способа оформить отдельными методами",
            "Отрицательные числа — брать модуль"
        };

        public void Run()
        {
            Console.WriteLine("Введите число:");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                int sum1 = SumDigitsString(Math.Abs(number));
                int sum2 = SumDigitsArithmetic(Math.Abs(number));
                Console.WriteLine($"Способ 1 (строка): сумма цифр числа {number} = {sum1}");
                Console.WriteLine($"Способ 2 (арифметика): сумма цифр числа {number} = {sum2}");
            }
            else
            {
                Console.WriteLine("Ошибка: введите целое число.");
            }



        }
        private int SumDigitsString(int n)
        {
            int sum = 0;
            string numberStr = n.ToString();
            foreach (char c in numberStr)
            {
                sum += c - '0';
            }

            return sum;
        }
        private int SumDigitsArithmetic(int n)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;       
            }
            return sum;
        }

    }
}
