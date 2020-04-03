using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTable
{
    internal class HashTable<T> : ICollection<T>
    {
        private readonly List<T>[] items;
        private int modCount;
        private const int DefaultCapacity = 10;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public HashTable()
        {
            items = new List<T>[DefaultCapacity];
        }

        public HashTable(int capacity)
        {
            if (capacity <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Размерность массива должна быть > 0 ," +
                    " сейчас равна: " + capacity);
            }

            items = new List<T>[capacity];
        }

        private int GetIndex(T o)
        {
            if (o == null)
            {
                return 0;
            }

            return Math.Abs(o.GetHashCode() % items.Length);
        }

        public void Add(T o)
        {
            int index = GetIndex(o);

            if (items[index] == null)
            {
                items[index] = new List<T>();
            }

            items[index].Add(o);
            Count++;
            modCount++;
        }

        public void Clear()
        {
            Array.Clear(items, 0, items.Length);
            Count = 0;
            modCount++;
        }

        public bool Contains(T o)
        {
            int index = GetIndex(o);

            return items[index] != null && items[index].Contains(o);
        }

        public bool Remove(T o)
        {
            int index = GetIndex(o);

            if (items[index] != null && items[index].Remove(o))
            {
                modCount++;
                Count--;
                return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new NullReferenceException("Массив null");
            }

            if (arrayIndex >= array.Length || arrayIndex < 0)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах от 0 до "
                    + array.Length + " , сейчас он равен: " + arrayIndex);
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("Размер копируемого списка составляет " + Count + "," +
                    " что превышает размер остатка массива равного: " + (array.Length - arrayIndex), nameof(arrayIndex));
            }

            int index = arrayIndex;

            foreach (T item in this)
            {
                array[index] = item;
                index++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int tempModCount = modCount;

            foreach (List<T> hashTableItem in items)
            {
                if (hashTableItem != null)
                {
                    foreach (T item in hashTableItem)
                    {
                        if (tempModCount != modCount)
                        {
                            throw new InvalidOperationException("Массив был изменен");
                        }

                        yield return item;
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}


