using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level1
{
    public class Task04_Parity : ITask
    {
        public string Title => "Проверка четности";

        public string Description => " принимать число и выводить, четное ли оно.";
        public string[] Requirements => new[]
        {
            "Способ 1: через % 2 == 0",
            "Способ 2: через тернарный оператор ? :.",
            "Оба способа реализовать отдельными методами.",
            "Вывести результат обоих способов."
        };

        public void Run()
        {
            Console.WriteLine("Введите число:");
            if (int.TryParse(Console.ReadLine(), out int number))
            {
                bool isEven1 = IsEven1(number);
                bool isEven2 = IsEven2(number);

                Console.WriteLine($"Способ 1: {number} {(isEven1 ? "четное" : "нечетное")}");
                Console.WriteLine($"Способ 2: {number} {(isEven2 ? "четное" : "нечетное")}");
            }
            else
            {
                Console.WriteLine("Ошибка: введите целое число.");
            }
        }

        private bool IsEven1(int n)
        {
            return n % 2 == 0;
        }

        private bool IsEven2(int n)
        {
            return n % 2 == 0 ? true : false;
        }
    }
}
