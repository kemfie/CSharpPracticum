using System;
using Visual_Studio.Common;
using Visual_Studio.DataStructures;

namespace Visual_Studio.Tasks.Level2
{
    public class Task19_MyCollections : ITask
    {
        public string Title => "Свой стек/очередь на массиве";
        public string Description => "Реализовать MyStack<T> и MyQueue<T> на массиве.";

        public string[] Requirements => new[]
        {
            "Стек: Push, Pop, Peek, Count, IsEmpty.",
            "Очередь: Enqueue, Dequeue, Peek, Count, IsEmpty.",
            "При переполнении — расширять внутренний массив (удвоение).",
            "Pop/Dequeue на пустой коллекции — бросать InvalidOperationException."
        };

        public void Run()
        {
            Console.WriteLine("--- Тестирование MyStack<T> ---");
            MyStack<int> stack = new MyStack<int>();

            for (int i = 1; i <= 5; i++)
            {
                stack.Push(i * 10);
                Console.WriteLine($"Push: {i * 10}, Count: {stack.Count}");
            }

            Console.WriteLine($"Peek: {stack.Peek()}");
            Console.WriteLine($"Pop: {stack.Pop()}");  
            Console.WriteLine($"Pop: {stack.Pop()}");  
            Console.WriteLine($"Count: {stack.Count}");


            stack.Pop();
            stack.Pop();
            stack.Pop();
            try
            {
                stack.Pop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Поймано исключение (Stack): {ex.Message}");
            }

            Console.WriteLine("\n--- Тестирование MyQueue<T> ---");
            MyQueue<string> queue = new MyQueue<string>();

            queue.Enqueue("Первый");
            queue.Enqueue("Второй");
            queue.Enqueue("Третий");
            queue.Enqueue("Четвертый");
            queue.Enqueue("Пятый");

            Console.WriteLine($"Peek: {queue.Peek()}");       
            Console.WriteLine($"Dequeue: {queue.Dequeue()}"); 
            Console.WriteLine($"Dequeue: {queue.Dequeue()}");
            Console.WriteLine($"Count: {queue.Count}");


            queue.Dequeue();
            queue.Dequeue();
            queue.Dequeue();
            try
            {
                queue.Dequeue();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Поймано исключение (Queue): {ex.Message}");
            }
        }
    }
}