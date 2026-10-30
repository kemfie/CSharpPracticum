using System;
using System.Threading.Tasks;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level3
{
    public class Task40_AsyncAwait : ITask
    {
        public string Title => "async/await + обработка исключений";
        public string Description => "Асинхронный метод с эмуляцией «скачивания».";

        public string[] Requirements => new[]
        {
            "async Task<string> DownloadAsync(string url) — внутри Task.Delay(1000).",
            "Имитировать ошибку: если url пустой — бросить ArgumentException.",
            "В Main вызвать через await внутри try/catch.",
            "Продемонстрировать успешный и ошибочный вызов."
        };

        public void Run()
        {
            RunAsync().GetAwaiter().GetResult();
        }

        private async Task RunAsync()
        {
            Console.WriteLine("--- 1. Успешный вызов ---");
            try
            {

                string result = await DownloadAsync("https://example.com/data");
                Console.WriteLine($"Успех! Результат: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка (этого не должно быть): {ex.Message}");
            }

            Console.WriteLine("\n--- 2. Ошибочный вызов (пустой URL) ---");
            try
            {

                string result = await DownloadAsync("");
                Console.WriteLine("Этого текста не будет, так как вылетит исключение.");
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine($"Поймано исключение: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Какая-то другая ошибка: {ex.Message}");
            }

            Console.WriteLine("\nПриложение продолжает работу без падений!");
        }


        private async Task<string> DownloadAsync(string url)
        {

            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentException("URL не может быть пустым!");
            }

            Console.WriteLine($"[Скачивание] Начинаем загрузку: {url}...");


            await Task.Delay(1000);

            Console.WriteLine($"[Скачивание] Загрузка {url} завершена.");

            return $"Данные с {url}";
        }
    }
}
