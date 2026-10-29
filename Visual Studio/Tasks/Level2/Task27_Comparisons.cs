using System;
using System.Collections.Generic;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public double AverageGrade { get; set; }

        public Student(string name, double grade)
        {
            Name = name;
            AverageGrade = grade;
        }

        public int CompareTo(Student other)
        {
            if (other == null) return 1;

            return other.AverageGrade.CompareTo(this.AverageGrade);
        }

        public override string ToString()
        {
            return $"{Name} (Балл: {AverageGrade})";
        }
    }

    public class ByNameComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x == null || y == null) return 0;

            return string.Compare(x.Name, y.Name, StringComparison.OrdinalIgnoreCase);
        }
    }

    public class Task27_Comparisons : ITask
    {
        public string Title => "IComparable / IComparer<T> для Student";
        public string Description => "Научить Student сортироваться.";

        public string[] Requirements => new[]
        {
            "Класс Student: Name, AverageGrade.",
            "Реализовать IComparable<Student> — сортировка по среднему баллу (по убыванию).",
            "Реализовать IComparer<Student> ByNameComparer — сортировка по имени.",
            "Продемонстрировать обе сортировки на List<Student>."
        };

        public void Run()
        {
            List<Student> students = new List<Student>
            {
                new Student("Иван", 4.5),
                new Student("Анна", 5.0),
                new Student("Дмитрий", 3.8),
                new Student("Мария", 4.9),
                new Student("Алексей", 4.2)
            };

            Console.WriteLine("--- Исходный список ---");
            PrintList(students);

            students.Sort();

            Console.WriteLine("\n--- Сортировка по среднему баллу (по убыванию) ---");
            PrintList(students);

            students.Sort(new ByNameComparer());

            Console.WriteLine("\n--- Сортировка по имени (по алфавиту) ---");
            PrintList(students);
        }

        private void PrintList(List<Student> list)
        {
            foreach (var student in list)
            {
                Console.WriteLine(student);
            }
        }
    }
}