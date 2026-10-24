using System;
using System.Collections.Generic;
using Visual_Studio.Common;
using Visual_Studio.Tasks.Level1;

namespace Visual_Studio.Menu
{
    public class MenuRunner
    {
        private List<ITask> level1Tasks = new List<ITask>();

        public MenuRunner()
        {
            level1Tasks.Add(new Task01_HelloWorld());
            level1Tasks.Add(new Task02_Primitives());
        }
        public void Start()
        {
            bool isRunning = true;
            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("=== Практикум по C# ===");
                Console.WriteLine("1. Уровень 1 — Базовый");
                Console.WriteLine("0. Выход");
                Console.Write("\nВыберите уровень: ");

                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    Level1Menu();
                }
                else if (choice == "0" || choice == "q")
                {
                    isRunning = false;
                }
            }
        }
        private void Level1Menu()
        {
            bool inLevel1 = true;
            while (inLevel1)
            {
                Console.Clear();
                Console.WriteLine("--- Уровень 1 ---");
                for (int i = 0; i < level1Tasks.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {level1Tasks[i].Title}");
                }
                Console.WriteLine("0. Назад");
                Console.Write("\nВыберите задание: ");

                string choice = Console.ReadLine();

                if (choice == "0")
                {
                    inLevel1 = false;
                }
                else
                {
                    int index = int.Parse(choice) - 1;

                    if (index >= 0 && index < level1Tasks.Count)
                    {
                        Console.Clear();
                        ConsoleHelper.PrintTaskInfo(level1Tasks[index]);
                        level1Tasks[index].Run();
                        ConsoleHelper.Pause();
                    }
                }
            }
        }
    }
}