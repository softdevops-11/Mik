using ArrayList;
using System;
using System.Collections;
using System.Collections.Generic;

namespace HashTable
{
    internal class HashTable<T> : ICollection<T>
    {
        private ArrayList<T>[] items;
        private int length;
        private int modCount = 0;

        public int Count => length;

        public int Capacity
        {
            get => items.Length;
            set
            {
                ArrayList<T>[] old = items;
                items = new ArrayList<T>[value];
                length = 0;

                for (int i = 0; i < old.Length; i++)
                {
                    if (old[i] != null)
                    {
                        for (int j = 0; j < old[i].Count; j++)
                        {
                            Add(old[i][j]);
                        }
                    }
                }
            }
        }

        public bool IsReadOnly => false;

        public HashTable(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentNullException("size", "Размерность массива должна быть > 0");
            }

            items = new ArrayList<T>[size];
            length = 0;
        }

        public void Add(T o)
        {
            if (items.Length == 0)
            {
                throw new ArgumentNullException("items.Length", "Размерность массива должна быть > 0");
            }

            int index = Math.Abs(o.GetHashCode() % items.Length);

            for (int i = 0; i < items.Length; i++)
            {
                if (index == i)
                {
                    if (items[i] == null)
                    {
                        items[i] = new ArrayList<T>(10);
                    }

                    items[i].Add(o);
                }
            }

            length++;
            modCount++;
        }

        public void Clear()
        {
            length = 0;
        }

        public bool Contains(T o)
        {
            if (items.Length == 0)
            {
                throw new ArgumentNullException("items.Length", "Размерность массива должна быть > 0");
            }

            int index = Math.Abs(o.GetHashCode() % items.Length);

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    for (int j = 0; j < items[i].Count; j++)
                    {
                        if (Equals(o, items[i][j]))
                        {
                            return true;
                        }

                    }
                }
            }

            return false;
        }

        public bool Remove(T o)
        {
            if (items.Length == 0)
            {
                throw new ArgumentNullException("items.Length", "Размерность массива должна быть > 0");
            }

            int index = Math.Abs(o.GetHashCode() % items.Length);

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    for (int j = 0; j < items[i].Count; j++)
                    {
                        if (Equals(o, items[i][j]))
                        {
                            items[i].RemoveAt(j);
                            modCount++;
                            length--;
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex <= 0 && arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException("arrayIndex", "Индекс вне пределов массива");
            }

            if (array == null)
            {
                throw new ArgumentNullException("array", "Массив null");
            }

            if (length > array.Length - arrayIndex)
            {
                throw new ArgumentException("Размер копируемого списка превышает размер остатка массива", "arrayIndex");
            }

            int index = arrayIndex;

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] != null)
                {
                    for (int j = 0; j < items[i].Count; j++)
                    {
                        array[index] = items[i][j];
                        index++;
                    }
                }
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
