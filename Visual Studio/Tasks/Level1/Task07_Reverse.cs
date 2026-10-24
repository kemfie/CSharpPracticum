using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level1
{
    public class Task07_Reverse : ITask
    {
        public string Title => "Реверс строки без LINQ";

        public string Description => "  перевернуть введённую строку.";
        public string[] Requirements => new[]
        {
            "Не использовать Array.Reverse и LINQ.",
            "Реализовать через цикл for от конца к началу (или через char[] и swap)",
            "Пустая строка и строка из одного символа — обрабатываются корректно."
        };

        public void Run()
        {
            Console.WriteLine("Введите строку для реверса:");
            string input = Console.ReadLine();
            char[] reversed = new char[input.Length];
            for (int i = 0; i < input.Length; i++)
            {
                reversed[i] = input[input.Length - 1 - i];
            }
            string result = new string(reversed);
            Console.WriteLine($"Реверс строки: {result}");
        }
    }
}
