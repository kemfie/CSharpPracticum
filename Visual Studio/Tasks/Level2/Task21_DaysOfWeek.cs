using System;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
    

    public class Task21_DaysOfWeek : ITask
    {
        public string Title => "enum дни недели";
        public string Description => "Описать дни недели через enum и определить тип дня.";

        public string[] Requirements => new[]
        {
            "enum DayOfWeek { Monday, ..., Sunday }.",
            "Метод IsWeekend(DayOfWeek day) — true для субботы и воскресенья.",
            "Метод GetRussianName(DayOfWeek day) — возвращает название на русском.",
            "Продемонстрировать на всех 7 днях."
        };

        public void Run()
        {
            Console.WriteLine("--- Дни недели ---");

            DayOfWeek[] allDays = (DayOfWeek[])Enum.GetValues(typeof(DayOfWeek));

            foreach (DayOfWeek day in allDays)
            {
                string name = GetName(day);
                bool weekend = IsWeekend(day);
                string status = weekend ? "Выходной" : "Рабочий";

                Console.WriteLine($"{name,-12} - {status}");
            }
        }

        private bool IsWeekend(DayOfWeek day)
        {
            return day == DayOfWeek.Saturday || day == DayOfWeek.Sunday;
        }

        private string GetName(DayOfWeek day)
        {
            switch (day)
            {
                case DayOfWeek.Monday: return "Понедельник";
                case DayOfWeek.Tuesday: return "Вторник";
                case DayOfWeek.Wednesday: return "Среда";
                case DayOfWeek.Thursday: return "Четверг";
                case DayOfWeek.Friday: return "Пятница";
                case DayOfWeek.Saturday: return "Суббота";
                case DayOfWeek.Sunday: return "Воскресенье";
                default: return "Неизвестный день";
            }
        }
        public enum DayOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }
    }
}