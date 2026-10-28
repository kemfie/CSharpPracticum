using System;

namespace Visual_Studio.DataStructures
{
    public class MyStack<T>
    {
        private T[] _items;
        private int _count;

        public int Count => _count;
        public bool IsEmpty => _count == 0;

        public MyStack()
        {
            _items = new T[4];
            _count = 0;
        }

        public void Push(T item)
        {
            if (_count == _items.Length)
            {
                Resize();
            }
            _items[_count] = item;
            _count++;
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст. Нельзя извлечь элемент.");

            _count--;
            T item = _items[_count];
            _items[_count] = default(T);
            return item;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст. Нельзя посмотреть верхний элемент.");

            return _items[_count - 1];
        }

        private void Resize()
        {
            T[] newArray = new T[_items.Length * 2];
            Array.Copy(_items, newArray, _items.Length);
            _items = newArray;
        }
    }
}