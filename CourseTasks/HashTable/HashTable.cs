using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTable
{
    internal class HashTable<T> : ICollection<T>
    {
        private List<T>[] items;
        public int Count { get; private set; }
        private int modCount;
        private readonly int defaultCapacity = 10;

        public bool IsReadOnly => false;

        public HashTable()
        {
            items = new List<T>[defaultCapacity];
            Count = 0;
        }

        public HashTable(int capacity)
        {
            if (capacity < 0)
            {
                throw new OverflowException("Размерность массива должна быть > 0 , сейчас равна: " + capacity);
            }

            items = new List<T>[capacity];
            Count = 0;
        }

        public void Add(T o)
        {
            int index = Math.Abs(o.GetHashCode() % items.Length);

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
            for (int i = 0; i < items.Length; i++)
            {
                items[i] = default;
            }

            Count = 0;
        }

        public bool Contains(T o)
        {
            int index = Math.Abs(o.GetHashCode() % items.Length);

            if (items[index] != null)
            {
                if (items[index].Contains(o))
                {
                    return true;
                }
            }

            return false;
        }

        public bool Remove(T o)
        {
            int index = Math.Abs(o.GetHashCode() % items.Length);

            if (items[index] != null)
            {
                if (items[index].Contains(o))
                {
                    items[index].Remove(o);
                    modCount++;
                    Count--;
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex >= array.Length || arrayIndex < 0)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах от 0 до " + array.Length
                    + " , сейчас он равен: " + arrayIndex);
            }

            if (array == null)
            {
                throw new NullReferenceException("Массив null");
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("Размер копируемого списка составляет " + Count
                    + ", что превышает размер остатка массива равного: " + (array.Length - arrayIndex), nameof(arrayIndex));
            }

            foreach (T item in this)
            {
                array[arrayIndex] = item;
                arrayIndex++;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            int tempModCount = modCount;

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    for (int j = 0; j < items[i].Count; j++)
                    {
                        if (tempModCount != modCount)
                        {
                            throw new InvalidOperationException("Массив был изменен");
                        }

                        yield return items[i][j];
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
