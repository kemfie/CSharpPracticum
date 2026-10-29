using System;
using System.Collections.Generic;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
    
    public abstract class Animal
    {
        public string Name { get; set; }

        public Animal(string name)
        {
            Name = name;
        }

        public abstract void MakeSound();

        public override string ToString()
        {
            return $"Животное: {GetType().Name}, Имя: {Name}";
        }
    }

    public class Dog : Animal
    {
        public Dog(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} говорит: Гав-гав!");
        }
    }

    public class Cat : Animal
    {
        public Cat(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} говорит: Мяу!");
        }
    }

    public class Bird : Animal
    {
        public Bird(string name) : base(name) { }

        public override void MakeSound()
        {
            Console.WriteLine($"{Name} говорит: Чирик-чирик!");
        }

        public void Fly()
        {
            Console.WriteLine($"{Name} летит в небесах!");
        }
    }

    public class Task24_Animals : ITask
    {
        public string Title => "ООП: Animal → Dog/Cat/Bird";
        public string Description => "Построить иерархию животных.";

        public string[] Requirements => new[]
        {
            "Абстрактный класс Animal: свойство Name, абстрактный метод MakeSound(), переопределённый ToString().",
            "Классы Dog, Cat, Bird — наследники, реализуют MakeSound().",
            "Bird дополнительно имеет метод Fly().",
            "Продемонстрировать полиморфизм: List<Animal> с разными животными, вызов MakeSound() в цикле."
        };

        public void Run()
        {
            List<Animal> animals = new List<Animal>
            {
                new Dog("Шарик"),
                new Cat("Мурка"),
                new Bird("Кеша")
            };

            Console.WriteLine("--- Полиморфизм в цикле ---");
            foreach (Animal animal in animals)
            {
                Console.WriteLine(animal.ToString());

                animal.MakeSound();
                Console.WriteLine();
            }

            Console.WriteLine("--- Специфичный метод Bird ---");
            Bird myBird = new Bird("Гоша");
            myBird.Fly();
        }
    }
}