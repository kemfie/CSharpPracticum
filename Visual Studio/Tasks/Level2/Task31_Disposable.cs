using System;
using System.IO;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
    public class FileWriter : IDisposable
    {
        private StreamWriter _writer;
        private bool _disposed = false;

        public FileWriter(string filePath)
        {

            _writer = new StreamWriter(filePath, false);
        }

        public void WriteLine(string text)
        {

            if (_disposed)
                throw new ObjectDisposedException(nameof(FileWriter));

            _writer.WriteLine(text);
        }


        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;

            if (disposing)
            {

                if (_writer != null)
                {
                    _writer.Dispose();
                    _writer = null;
                }
            }


            _disposed = true;
        }
    }


    public class Task31_Disposable : ITask
    {
        public string Title => "IDisposable + using";
        public string Description => "Реализовать IDisposable для класса, работающего с файлом.";

        public string[] Requirements => new[]
        {
            "Класс FileWriter с полем StreamWriter.",
            "Реализовать Dispose() (закрыть StreamWriter).",
            "Продемонстрировать использование через using.",
            "Дополнительно: продемонстрировать using-декларацию (C# 8+, using var)."
        };

                public void Run()
        {
            string filePath = "test_disposable.txt";


            Console.WriteLine("--- Классический using ---");
            using (FileWriter writer = new FileWriter(filePath))
            {
                writer.WriteLine("Строка 1: Записано через using-блок.");
                writer.WriteLine("Строка 2: Файл закроется автоматически.");
            }

            Console.WriteLine("Файл записан и закрыт.\n");

            Console.WriteLine("--- Второй using ---");
            using (var writer2 = new FileWriter("test_disposable2.txt"))
            {
                writer2.WriteLine("Строка 1: Записано через второй using.");
                writer2.WriteLine("Строка 2: Файл закроется в конце блока.");
            }
            
            Console.WriteLine("Запись завершена.");

            Console.WriteLine("\n--- Проверка доступа к файлу ---");
            try
            {
                string content = File.ReadAllText(filePath);
                Console.WriteLine("Содержимое файла:");
                Console.WriteLine(content);
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Ошибка доступа к файлу (файл занят!): {ex.Message}");
            }
        }
    }
}