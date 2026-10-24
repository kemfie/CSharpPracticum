using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level1
{
    public class Task14_AgeCalculator : ITask
    {
        public string Title => "Возраст по дате рождения";
        public string Description => "По дате рождения вычислить точный возраст в годах, месяцах и днях.";

        public string[] Requirements => new[]
        {
            "Ввод даты через DateTime.TryParse (или TryParseExact).",
            "Учесть, что день рождения в этом году мог ещё не наступить.",
            "Вывести «X лет, Y месяцев, Z дней».",
            "Некорректная дата — сообщение об ошибке, не падать."
        };

        public void Run()
        {
            Console.WriteLine("Введите дату рождения (например, 15.05.1990 или 1990-05-15):");
            string input = Console.ReadLine();
            if (DateTime.TryParse(input, out DateTime birthDate))
            {
                if (birthDate > DateTime.Today)
                {
                    Console.WriteLine("Ошибка: дата рождения не может быть в будущем!");
                    return;
                }

                CalculateAndPrintAge(birthDate, DateTime.Today);
            }
            else
            {
                Console.WriteLine("Ошибка: некорректный формат даты. Попробуйте еще раз.");
            }
        }

        private void CalculateAndPrintAge(DateTime birthDate, DateTime today)
        {
            int years = today.Year - birthDate.Year;
            int months = 0;
            int days = 0;
            DateTime tempDate = birthDate.AddYears(years);
            if (today < tempDate)
            {
                years--;
                tempDate = birthDate.AddYears(years);
            }
            while (tempDate.AddMonths(1) <= today)
            {
                months++;
                tempDate = tempDate.AddMonths(1);
            }
            days = (today - tempDate).Days;

            Console.WriteLine($"\nВаш точный возраст: {years} лет, {months} месяцев, {days} дней.");
        }
    }
}
