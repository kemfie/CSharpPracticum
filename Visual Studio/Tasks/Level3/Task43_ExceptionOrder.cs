using System;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level3
{
    // 1. Свое кастомное исключение
    public class CustomException : Exception
    {
        public CustomException(string message) : base(message) { }
    }

    public class Task43_ExceptionOrder : ITask
    {
        public string Title => "Множественные типы исключений, порядок catch";
        public string Description => "Продемонстрировать порядок обработки исключений.";

        public string[] Requirements => new[]
        {
            "Метод, который может бросить FormatException, DivideByZeroException или свой CustomException.",
            "Несколько catch-блоков в правильном порядке (от частного к общему).",
            "Продемонстрировать все три сценария.",
            "В конце — finally с выводом «завершено».",
            "Объяснить в комментарии, почему порядок catch важен."
        };

        public void Run()
        {
            Console.WriteLine("--- Сценарий 1: FormatException ---");
            TestScenario("abc");

            Console.WriteLine("\n--- Сценарий 2: DivideByZeroException ---");
            TestScenario("10_0");

            Console.WriteLine("\n--- Сценарий 3: CustomException ---");
            TestScenario("custom"); 

            Console.WriteLine("\n--- Сценарий 4: Без ошибок ---");
            TestScenario("42"); 
        }

        private void TestScenario(string input)
        {
            try
            {
                ProcessInput(input);
                Console.WriteLine("Успешно обработано!");
            }

            catch (CustomException ex)
            {
                Console.WriteLine($"Поймано CustomException: {ex.Message}");
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Поймано FormatException: {ex.Message}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Поймано DivideByZeroException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Поймано какое-то другое исключение: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("  [finally]: завершено.");
            }
        }

        private void ProcessInput(string input)
        {
            if (input == "custom")
            {
                throw new CustomException("Сработало кастомное исключение!");
            }

            if (input == "10_0")
            {
                int zero = 0;
                int result = 10 / zero;
            }

            int number = int.Parse(input);
            Console.WriteLine($"  Число успешно распарсено: {number}");
        }

        /*
         * 
         * Все исключения в C# наследуются от базового класса Exception. 
         * Если бы мы поставили catch (Exception ex) самым первым, 
         * он бы перехватывал ВСЁ ПОДРЯД (и FormatException, и CustomException), 
         * и до специфичных блоков catch дело бы просто не дошло.
         * 
         * Поэтому мы всегда идем от "самого конкретного" (CustomException) 
         * к "самому общему" (Exception).
         * 
         * Если попытаться написать наоборот (сначала Exception, потом FormatException), 
         * компилятор C# выдаст ошибку: 
         * "Предыдущий блок catch уже обрабатывает все исключения этого типа".
         */
    }
}
