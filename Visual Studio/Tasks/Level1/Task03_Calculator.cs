using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level1
{
    public class Task03_Calculator : ITask
    {
        public string Title => "Калькулятор";

        public string Description => " принимать два числа и оператор (+ - * /), выводить результат.";

        public string[] Requirements => new[]
        {
            "Оператор обрабатывать через switch",
            "При делении на ноль — вывести сообщение об ошибке, не ронять приложение.",
            "Некорректный оператор — вывести «Неизвестная операция».",
            "Ввод чисел — через double.Parse или TryParse."
        };

        public void Run()
        {
            Console.WriteLine("Введите первое число:");
            Double.TryParse(Console.ReadLine(), out double num1);
            Console.WriteLine("Введите второе число:");
            Double.TryParse(Console.ReadLine(), out double num2);
            Console.WriteLine("Введите оператор (+, -, *, /):");
            string op = Console.ReadLine();
            switch (op)
            {
                case "+":
                    Console.WriteLine($"Результат: {num1 + num2}");
                    break;
                case "-":
                    Console.WriteLine($"Результат: {num1 - num2}");
                    break;
                case "*":
                    Console.WriteLine($"Результат: {num1 * num2}");
                    break;
                case "/":
                    if (num2 == 0)
                    {
                        Console.WriteLine("Ошибка: деление на ноль.");
                    }
                    else
                    {
                        Console.WriteLine($"Результат: {num1 / num2}");
                    }
                    break;
                default:
                    Console.WriteLine("Неизвестная операция.");
                    break;
            }
        }
    }
}
