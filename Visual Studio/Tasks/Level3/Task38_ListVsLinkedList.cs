using System;
using System.Collections.Generic;
using System.Diagnostics;
using Visual_Studio.Common;

namespace Visual_Studio.Tasks.Level3
{
    public class Task38_ListVsLinkedList : ITask
    {
        public string Title => "List<T> vs LinkedList<T> (бенчмарк)";
        public string Description => "Сравнить вставку в середину List<T> и LinkedList<T>.";

        public string[] Requirements => new[]
        {
            "Создать List<int> и LinkedList<int> по 100 000 элементов.",
            "Вставить 1000 элементов в середину каждой коллекции.",
            "Замерить время через Stopwatch.",
            "Вывести оба времени и объяснить результат в комментарии."
        };

        public void Run()
        {
            const int initialSize = 100000; 
            const int insertCount = 1000;   

            Console.WriteLine($"Готовим коллекции по {initialSize} элементов...\n");

            List<int> list = new List<int>();
            for (int i = 0; i < initialSize; i++) list.Add(i);

            LinkedList<int> linkedList = new LinkedList<int>();
            for (int i = 0; i < initialSize; i++) linkedList.AddLast(i);

            Stopwatch sw = new Stopwatch();

            sw.Start();
            for (int i = 0; i < insertCount; i++)
            {
                int middle = list.Count / 2;
                list.Insert(middle, -1);
            }
            sw.Stop();
            long timeList = sw.ElapsedMilliseconds;
            Console.WriteLine($"List<T> вставка 1000 раз в середину:       {timeList} мс");

            sw.Restart();

            LinkedListNode<int> middleNode = linkedList.First;
            for (int i = 0; i < initialSize / 2; i++)
            {
                middleNode = middleNode.Next;
            }

            for (int i = 0; i < insertCount; i++)
            {

                linkedList.AddBefore(middleNode, -1);
            }
            sw.Stop();
            long timeLinkedList = sw.ElapsedMilliseconds;
            Console.WriteLine($"LinkedList<T> вставка 1000 раз в середину: {timeLinkedList} мс");
            Console.WriteLine($"\nРазница: List медленнее на {timeList - timeLinkedList} мс");

            /* 

             * 
             * List<T> внутри использует обычный массив. 
             * Когда мы вставляем элемент в середину (list.Insert(middle, -1)), 
             * List вынужден сдвинуть ВСЕ элементы справа от середины на одну позицию вправо.
             * На 100 000 элементах это означает копирование ~50 000 элементов при каждой вставке.
             * 1000 вставок = 50 000 000 операций копирования. Это медленно (O(n)).
             * 
             * LinkedList<T> — это двусвязный список. Он состоит из узлов, каждый из которых 
             * хранит ссылку на следующий и предыдущий. 
             * Если у нас уже есть ссылка на нужный узел (в нашем случае middleNode), 
             * вставка перед ним занимает ВСЕГО 2 операции: 
             * переставить указатели у соседних узлов. 
             * Это делается мгновенно (O(1)), независимо от размера списка!
             * 
             * НО: LinkedList медленнее при поиске по индексу. 
             * Если ты напишешь linkedList.ElementAt(50000), ему придется 
             * пробежать 50 000 узлов с начала, чтобы найти нужный. 
             * В List доступ по индексу мгновенный (arr[50000]), так как массив лежит в памяти подряд.
             */
        }
    }
}
