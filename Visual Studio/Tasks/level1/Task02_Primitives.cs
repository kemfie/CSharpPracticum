using System;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level1
{
    public class Task02_Primitives : ITask
    {
        public string Title => "Переменные примитивных типов";

        public string Description => "Объявить переменные разных типов и вывести их значения в консоль.";

        public string[] Requirements => new[]
        {
            "Использовать типы int, double, bool, string, char",
            "Вывести каждую переменную на экран"
        };

        public void Run()
        {
            int age = 19;
            double weight = 86.9;
            bool isStudent = true;
            string name = "Василий";
            char grade = '5';

            Console.WriteLine($"Имя: {name}, Возраст: {age}");
            Console.WriteLine($"Вес: {weight}, Оценка: {grade}");
            Console.WriteLine($"Студент: {isStudent}");
        }
    }
}