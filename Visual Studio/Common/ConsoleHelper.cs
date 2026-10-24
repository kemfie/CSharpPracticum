using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual_Studio.Common
{
    public static class ConsoleHelper
    {
        public static void Pause()
        {
            Console.WriteLine("\nНажмите Enter для возврата в меню...");
            Console.ReadLine();
        }

        public static void PrintTaskInfo(ITask task)
        {
            Console.WriteLine($"Задание: {task.Title}");
            Console.WriteLine("Описание:");
            Console.WriteLine($"  {task.Description}");
            Console.WriteLine("\nТребования:");
            foreach (var req in task.Requirements)
            {
                Console.WriteLine($"  - {req}");
            }
            Console.WriteLine("[запуск решения...]\n");
        }
    }
}
