using System;
using System.Threading;
using System.Threading.Tasks;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level3
{
    public class Task42_Cancellation : ITask
    {
        public string Title => "CancellationToken — отмена через 2 сек";
        public string Description => "Реализовать долгую операцию с поддержкой отмены.";

        public string[] Requirements => new[]
        {
            "async Task LongOperationAsync(CancellationToken token) — цикл с Task.Delay(500, token) 10 раз.",
            "В Main создать CancellationTokenSource, запустить операцию, отменить через 2 секунды.",
            "Обработать OperationCanceledException.",
            "Вывести «операция отменена»."
        };

        public void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        private async Task RunAsync()
        {

            using (CancellationTokenSource cts = new CancellationTokenSource())
            {

                CancellationToken token = cts.Token;

                Console.WriteLine("Запуск долгой операции...");


                Task operationTask = LongOperationAsync(token);

                Console.WriteLine("Таймер отмены установлен на 2 секунды...");
                await Task.Delay(2000);

                Console.WriteLine("\n>>> Время вышло! Посылаем сигнал отмены (Cancel)...");
                cts.Cancel(); 

                try
                {
                    await operationTask;
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Операция отменена.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Произошла другая ошибка: {ex.Message}");
                }
            }
        }

        private async Task LongOperationAsync(CancellationToken token)
        {
            try
            {
                for (int i = 1; i <= 10; i++)
                {
                    token.ThrowIfCancellationRequested();

                    Console.WriteLine($"Шаг {i} из 10 выполнен...");
                    await Task.Delay(500, token);
                }
                Console.WriteLine("Операция успешно завершена!");
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("[Внутри метода]: Получен сигнал отмены!");
                throw; 
            }
        }
    }
}
