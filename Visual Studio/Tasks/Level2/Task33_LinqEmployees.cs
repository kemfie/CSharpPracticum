using System;
using System.Collections.Generic;
using System.Linq;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string Department { get; set; }

        public Employee(string name, int age, decimal salary, string department)
        {
            Name = name;
            Age = age;
            Salary = salary;
            Department = department;
        }

        public override string ToString() => $"{Name} ({Age} лет, {Department}, {Salary} руб.)";
    }


    public class Task33_LinqEmployees : ITask
    {
        public string Title => "LINQ: сотрудники (top-3, avg по отделу, фильтр)";
        public string Description => "LINQ-запросы по списку сотрудников.";

        public string[] Requirements => new[]
        {
            "Класс Employee: Name, Age, Salary, Department.",
            "Список из 10+ сотрудников.",
            "Запросы через LINQ: топ-3 по зарплате (убывание), средняя зарплата по каждому отделу (GroupBy + Average), сотрудники старше 30 (Where).",
            "Вывести результаты."
        };

        public void Run()
        {
            List<Employee> employees = new List<Employee>
            {
                new Employee("Иван", 25, 50000, "IT"),
                new Employee("Мария", 32, 80000, "HR"),
                new Employee("Алексей", 45, 120000, "IT"),
                new Employee("Ольга", 28, 60000, "Sales"),
                new Employee("Дмитрий", 35, 90000, "IT"),
                new Employee("Елена", 40, 75000, "HR"),
                new Employee("Сергей", 22, 40000, "Sales"),
                new Employee("Анна", 38, 110000, "IT"),
                new Employee("Павел", 29, 55000, "Sales"),
                new Employee("Наталья", 31, 70000, "HR"),
                new Employee("Виктор", 50, 150000, "Sales"),
                new Employee("Татьяна", 27, 65000, "IT")
            };

            Console.WriteLine("--- Топ-3 сотрудников по зарплате ---");

            var top3 = employees
                .OrderByDescending(e => e.Salary) 
                .Take(3)                          
                .ToList();

            foreach (var emp in top3)
            {
                Console.WriteLine(emp);
            }

            Console.WriteLine("\n--- Средняя зарплата по отделам ---");

            var avgByDept = employees
                .GroupBy(e => e.Department)
                .Select(g => new
                {
                    Department = g.Key,
                    AverageSalary = g.Average(e => e.Salary)
                })
                .ToList();

            foreach (var item in avgByDept)
            {
                Console.WriteLine($"Отдел: {item.Department}, Средняя зарплата: {item.AverageSalary:F2} руб.");
            }


            Console.WriteLine("\n--- Сотрудники старше 30 лет ---");

            var olderThan30 = employees
                .Where(e => e.Age > 30) 
                .OrderBy(e => e.Age)    
                .ToList();

            foreach (var emp in olderThan30)
            {
                Console.WriteLine(emp);
            }
        }
    }
}