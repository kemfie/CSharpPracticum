using System;
using System.Collections.Generic;
using Visual_Studio.Common;
using Visual_Studio.Tasks.Level1;
// using Visual_Studio.Tasks.Level2; 

namespace Visual_Studio.Menu
{
    public class MenuRunner
    {
        private List<ITask> level1Tasks = new List<ITask>();
        private List<ITask> level2Tasks = new List<ITask>();

        public MenuRunner()
        {
            level1Tasks.Add(new Task01_HelloWorld());
            level1Tasks.Add(new Task02_Primitives());
            level1Tasks.Add(new Task03_Calculator());
            level1Tasks.Add(new Task04_Parity());
            level1Tasks.Add(new Task05_Multiplication());
            level1Tasks.Add(new Task06_Sum_Dig_Num());
            level1Tasks.Add(new Task07_Reverse());
            level1Tasks.Add(new Task08_FizzBuzz());
            level1Tasks.Add(new Task09_Array());
            level1Tasks.Add(new Task10_BubIns());
            level1Tasks.Add(new Task11_MatrixDiagonal());
            level1Tasks.Add(new Task12_Palindrome());
            level1Tasks.Add(new Task13_Dictionary());
            level1Tasks.Add(new Task14_AgeCalculator());

        }
        public void Start()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== Практикум по C# ===");
                Console.WriteLine("1. Уровень 1 — Базовый");
                Console.WriteLine("2. Уровень 2 — Средний");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите уровень: ");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    ShowLevelMenu(level1Tasks, "Уровень 1: Базовый");
                }
                else if (choice == "2")
                {
                    ShowLevelMenu(level2Tasks, "Уровень 2: Средний");
                }
                else if (choice == "0" || choice == "q")
                {
                    isRunning = false;
                }
            }
        }
        private void ShowLevelMenu(List<ITask> tasks, string levelTitle)
        {
            bool inLevel = true;

            while (inLevel)
            {
                Console.Clear();
                Console.WriteLine($"--- {levelTitle} ---");

                if (tasks.Count == 0)
                {
                    Console.WriteLine("В этом уровне пока нет заданий.");
                }
                else
                {
                    for (int i = 0; i < tasks.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {tasks[i].Title}");
                    }
                }

                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите задание: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    inLevel = false;
                }
                else if (int.TryParse(choice, out int index))
                {
                    index--;
                    if (index >= 0 && index < tasks.Count)
                    {
                        Console.Clear();
                        ConsoleHelper.PrintTaskInfo(tasks[index]);
                        tasks[index].Run();                        
                        ConsoleHelper.Pause();                     
                    }
                }
            }
        }
    }
}