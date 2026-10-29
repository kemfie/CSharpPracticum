using System;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
    public class Temperature
    {
        private double _celsius;

        public double Celsius
        {
            get { return _celsius; }
            set
            {
                if (value < -273.15)
                {
                    throw new ArgumentOutOfRangeException(nameof(value),
                        "Температура не может быть ниже абсолютного нуля (-273.15°C).");
                }
                _celsius = value;
            }
        }

        public double Fahrenheit
        {
            get { return (_celsius * 9 / 5) + 32; }
        }

        public Temperature(double initialCelsius)
        {
            Celsius = initialCelsius;
        }
    }


    public class Task32_Temperature : ITask
    {
        public string Title => "Свойства с валидацией (Temperature)";
        public string Description => "Класс Temperature с валидацией в set.";

        public string[] Requirements => new[]
        {
            "Свойство Celsius с проверкой в set: не ниже −273.15.",
            "При некорректном значении — бросать ArgumentOutOfRangeException.",
            "Вычисляемое свойство Fahrenheit (только get).",
            "Продемонстрировать корректное и некорректное присваивание."
        };

        public void Run()
        {
            Console.WriteLine("--- Корректные значения ---");
            Temperature temp = new Temperature(25);
            Console.WriteLine($"Температура: {temp.Celsius}°C = {temp.Fahrenheit:F1}°F");

            temp.Celsius = 0;
            Console.WriteLine($"Изменено на: {temp.Celsius}°C = {temp.Fahrenheit:F1}°F");

            temp.Celsius = -273.15;
            Console.WriteLine($"Абсолютный ноль: {temp.Celsius}°C = {temp.Fahrenheit:F1}°F");

            Console.WriteLine("\n--- Некорректное значение ---");
            try
            {
                temp.Celsius = -300;
                Console.WriteLine("Этого не произойдет.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Температура осталась прежней: {temp.Celsius}°C");
            }
        }
    }
}