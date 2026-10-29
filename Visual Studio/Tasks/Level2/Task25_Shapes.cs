using System;
using System.Collections.Generic;
using System.Linq;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
    public interface IShape
    {
        double Area();
        double Perimeter();
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }
        public Circle(double r) => Radius = r;

        public double Area() => Math.PI * Radius * Radius;
        public double Perimeter() => 2 * Math.PI * Radius;

        public override string ToString() => $"Круг (R={Radius})";
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }
        public Rectangle(double w, double h) { Width = w; Height = h; }

        public double Area() => Width * Height;
        public double Perimeter() => 2 * (Width + Height);

        public override string ToString() => $"Прямоугольник ({Width}x{Height})";
    }

    public class Triangle : IShape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle(double a, double b, double c) { A = a; B = b; C = c; }

        public double Area()
        {
            double p = Perimeter() / 2;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        public double Perimeter() => A + B + C;

        public override string ToString() => $"Треугольник ({A}, {B}, {C})";
    }

    public class Task25_Shapes : ITask
    {
        public string Title => "Интерфейс IShape + сортировка фигур";
        public string Description => "Реализовать интерфейс фигур и отсортировать их.";

        public string[] Requirements => new[]
        {
            "IShape с методами Area() и Perimeter().",
            "Классы Circle, Rectangle, Triangle — реализуют IShape.",
            "Создать List<IShape> из 5+ фигур.",
            "Отсортировать по площади (через List.Sort с лямбдой или OrderBy).",
            "Вывести фигуры с площадями до и после сортировки."
        };

        public void Run()
        {
            List<IShape> shapes = new List<IShape>
            {
                new Circle(5),
                new Rectangle(4, 6),
                new Triangle(3, 4, 5),
                new Circle(1.5),
                new Rectangle(10, 2),
                new Triangle(5, 5, 5)
            };

            Console.WriteLine("--- До сортировки ---");
            PrintShapes(shapes);

            shapes.Sort((x, y) => x.Area().CompareTo(y.Area()));

            Console.WriteLine("\n--- После сортировки (List.Sort) ---");
            PrintShapes(shapes);

            var orderedShapes = shapes.OrderBy(s => s.Area()).ToList();
            Console.WriteLine("\n--- После сортировки (OrderBy) ---");
            PrintShapes(orderedShapes);
        }

        private void PrintShapes(List<IShape> list)
        {
            foreach (var shape in list)
            {
                Console.WriteLine($"{shape} -> Площадь: {shape.Area():F2}, Периметр: {shape.Perimeter():F2}");
            }
        }
    }
}