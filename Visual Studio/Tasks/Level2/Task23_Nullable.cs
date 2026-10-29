using System;
using System.Collections.Generic;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
    public class Task23_Nullable : ITask
    {
        public string Title => "Nullable-типы, ??, ?.";
        public string Description => "Продемонстрировать работу с nullable.";

        public string[] Requirements => new[]
        {
            "Метод int? FindValue(string key) — возвращает null, если ключа нет.",
            "Использовать ?? для значения по умолчанию.",
            "Использовать ?. для безопасного доступа к свойству объекта, который может быть null.",
            "Использовать HasValue / Value с проверкой.",
            "Продемонстрировать на примере с найденным и ненайденным ключом."
        };


        private class User
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }

        private Dictionary<string, int> _database = new Dictionary<string, int>
        {
            { "apple", 10 },
            { "banana", 20 }
        };

        public void Run()
        {
            int? foundValue = FindValue("apple");
            int? notFoundValue = FindValue("orange");

            Console.WriteLine("--- 1. Метод FindValue ---");
            Console.WriteLine($"Поиск 'apple': {foundValue}");
            Console.WriteLine($"Поиск 'orange': {notFoundValue}");

            Console.WriteLine("\n--- 2. Оператор ?? ---");
            int result1 = notFoundValue ?? 0;
            Console.WriteLine($"notFoundValue ?? 0 = {result1}");

            int result2 = foundValue ?? 0;
            Console.WriteLine($"foundValue ?? 0 = {result2}");

            Console.WriteLine("\n--- 3. HasValue / Value ---");
            if (foundValue.HasValue)
            {
                Console.WriteLine($"Ключ найден. Значение: {foundValue.Value}");
            }

            if (!notFoundValue.HasValue)
            {
                Console.WriteLine("Ключ 'orange' не найден (HasValue == false).");
            }

            Console.WriteLine("\n--- 4. Оператор ?. ---");

            User user1 = new User { Name = "Иван", Email = "ivan@mail.com" };
            User user2 = null; 

            string name1 = user1?.Name;
            string name2 = user2?.Name;

            Console.WriteLine($"Имя user1: {name1 ?? "Не указано"}");
            Console.WriteLine($"Имя user2: {name2 ?? "Пользователь не найден"}");

            int nameLength = user2?.Name?.Length ?? 0;
            Console.WriteLine($"Длина имени user2: {nameLength}");
        }

        private int? FindValue(string key)
        {
            if (_database.TryGetValue(key, out int value))
            {
                return value;
            }
            return null; 
        }
    }
}