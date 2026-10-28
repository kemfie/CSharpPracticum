using System;
using System.Diagnostics;
using System.Text;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level2
{
    public class Task17_StringPerformance : ITask
    {
        public string Title => "StringBuilder vs конкатенация (замер)";
        public string Description => "Сравнить производительность конкатенации через + и StringBuilder.";

        public string[] Requirements => new[]
        {
            "Собрать строку из 10 000 чисел двумя способами.",
            "Замерить время каждого через Stopwatch.",
            "Вывести оба времени и разницу.",
            "Объяснить в комментарии, почему StringBuilder быстрее."
        };

        public void Run()
        {
            const int count = 10000; 
            Stopwatch sw = new Stopwatch();

            Console.WriteLine($"Генерация строки из {count} чисел...");


            sw.Start();
            string result1 = "";
            for (int i = 0; i < count; i++)
            {
                result1 += i.ToString();
            }
            sw.Stop();
            long time1 = sw.ElapsedMilliseconds;


            sw.Restart(); 
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(i);
            }
            string result2 = sb.ToString();
            sw.Stop();
            long time2 = sw.ElapsedMilliseconds;

            Console.WriteLine("\n--- Результаты ---");
            Console.WriteLine($"Конкатенация (+):    {time1} мс");
            Console.WriteLine($"StringBuilder:      {time2} мс");
            Console.WriteLine($"Разница:            {time1 - time2} мс");
        }
        /*
        * 
        * Строки в C# (string) являются неизменяемыми (immutable). 
        * Когда мы используем оператор "+" в цикле, каждый раз создается НОВЫЙ объект строки в памяти, 
        * в который копируется предыдущая строка и добавляется новая часть. 
        * На 10 000 итераций создается 10 000 временных строк, что вызывает огромную нагрузку на память 
        * и сборщик мусора (Garbage Collector).
        * 
        * StringBuilder же использует внутренний изменяемый массив символов (буфер). 
        * При добавлении текста (Append) он просто дописывает символы в свободное место массива, 
        * расширяя его только при необходимости. Это избавляет от бесконечного копирования строк.
        */
    }
}