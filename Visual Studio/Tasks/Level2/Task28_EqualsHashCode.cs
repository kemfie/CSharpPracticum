using System;
using System.Collections.Generic;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
    public class Point : IEquatable<Point>
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public bool Equals(Point other)
        {
            if (other == null) return false;

            if (ReferenceEquals(this, other)) return true;

            return X == other.X && Y == other.Y;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Point);
        }


        public override int GetHashCode()
        {
            unchecked 
            {
                int hash = 17;
                hash = hash * 23 + X.GetHashCode();
                hash = hash * 23 + Y.GetHashCode();
                return hash;
            }
        }

        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }

    public class Task28_EqualsHashCode : ITask
    {
        public string Title => "Equals / GetHashCode для Point";
        public string Description => "Переопределить Equals и GetHashCode для класса Point(x, y).";

        public string[] Requirements => new[]
        {
            "Переопределить Equals(object) и GetHashCode().",
            "Реализовать IEquatable<Point>.",
            "Проверить: две точки с одинаковыми координатами равны.",
            "Проверить в HashSet<Point>: добавление дубликата не увеличивает Count."
        };

        public void Run()
        {
            Point p1 = new Point(5, 10);
            Point p2 = new Point(5, 10);
            Point p3 = new Point(3, 7);

            Console.WriteLine("--- Проверка Equals ---");
            Console.WriteLine($"p1 = {p1}, p2 = {p2}, p3 = {p3}");
            Console.WriteLine($"p1.Equals(p2): {p1.Equals(p2)} (должно быть True)");
            Console.WriteLine($"p1.Equals(p3): {p1.Equals(p3)} (должно быть False)");
            Console.WriteLine($"p1 == p2:      {p1 == p2} (должно быть False, так как == не переопределен)");

            Console.WriteLine("\n--- Проверка HashSet ---");
            HashSet<Point> pointsSet = new HashSet<Point>();

            pointsSet.Add(p1);
            Console.WriteLine($"Добавили p1. Count = {pointsSet.Count}");

            pointsSet.Add(p2); 
            Console.WriteLine($"Добавили p2 (дубликат). Count = {pointsSet.Count} (должно остаться 1)");

            pointsSet.Add(p3);
            Console.WriteLine($"Добавили p3. Count = {pointsSet.Count} (должно стать 2)");
        }
    }
}