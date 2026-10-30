using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level3
{
    public class Task41_ParallelTasks : ITask
    {
        public string Title => "Task.WhenAll — параллельно 10 задач";
        public string Description => "Запустить 10 задач параллельно и сравнить с последовательным выполнением.";

        public string[] Requirements => new[]
        {
            "Метод Task<int> WorkAsync(int id) — Task.Delay(500), возвращает id.",
            "Последовательный запуск 10 задач в цикле с await.",
            "Параллельный запуск через Task.WhenAll.",
            "Замерить время обоих вариантов через Stopwatch.",
            "Вывести оба времени и объяснить разницу."
        };

        public void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        private async Task RunAsync()
        {
            Stopwatch sw = new Stopwatch();
            const int taskCount = 10;

            Console.WriteLine($"Запускаем {taskCount} задач ПОСЛЕДОВАТЕЛЬНО (каждая по 500 мс)...");
            sw.Start();

            List<int> sequentialResults = new List<int>();
            for (int i = 0; i < taskCount; i++)
            {
                int result = await WorkAsync(i);
                sequentialResults.Add(result);
            }

            sw.Stop();
            long sequentialTime = sw.ElapsedMilliseconds;
            Console.WriteLine($"Последовательное выполнение заняло: {sequentialTime} мс\n");

            Console.WriteLine($"Запускаем {taskCount} задач ПАРАЛЛЕЛЬНО...");
            sw.Restart();

            List<Task<int>> tasks = new List<Task<int>>();
            for (int i = 0; i < taskCount; i++)
            {
                tasks.Add(WorkAsync(i));
            }

            int[] parallelResults = await Task.WhenAll(tasks);

            sw.Stop();
            long parallelTime = sw.ElapsedMilliseconds;
            Console.WriteLine($"Параллельное выполнение заняло: {parallelTime} мс\n");

            Console.WriteLine("--- Результаты ---");
            Console.WriteLine($"Последовательное время: {sequentialTime} мс");
            Console.WriteLine($"Параллельное время:     {parallelTime} мс");
            Console.WriteLine($"Разница:                {sequentialTime - parallelTime} мс (параллельно быстрее)");

            /* 

             * 
             * Последовательный запуск: мы запускаем задачу 1, ждем 500 мс, 
             * запускаем задачу 2, ждем 500 мс... Итого 10 * 500 = 5000 мс (5 секунд).
             * 
             * Параллельный запуск (Task.WhenAll): мы запускаем все 10 задач 
             * практически одновременно. Пока задача 1 спит 500 мс, задача 2 тоже спит, 
             * задача 3 тоже спит и т.д. В итоге мы ждем завершения самой долгой задачи.
             * Так как все задачи занимают по 500 мс, общее время будет ~500-600 мс.
             */
        }

        private async Task<int> WorkAsync(int id)
        {
            await Task.Delay(500);
            return id;
        }
    }
}
