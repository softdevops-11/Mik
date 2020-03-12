using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    public class ArrayList<T> : IList<T>
    {
        private T[] items;
        private int length;
        private int modCount = 0;

        public int Count => length;

        public bool IsReadOnly => false;

        public int Capacity
        {
            get => items.Length;
            private set
            {
                T[] old = items;
                items = new T[value];

                if (value > old.Length)
                {
                    Array.Copy(old, 0, items, 0, old.Length);
                }
                else
                {
                    Array.Copy(old, 0, items, 0, value);
                }
            }
        }

        public T this[int index]
        {
            get
            {
                if (index <= 0 && index > items.Length)
                {
                    throw new ArgumentOutOfRangeException("index", "Индекс вне пределов массива");
                }

                return items[index];
            }
            set
            {
                if (index <= 0 && index > items.Length)
                {
                    throw new ArgumentOutOfRangeException("index", "Индекс вне пределов массива");
                }

                items[index] = value;
            }

        }

        public ArrayList(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentNullException("size", "Размерность массива должна быть > 0");
            }

            items = new T[size];
        }

        public int IndexOf(T o)
        {
            for (int i = 0; i < length; i++)
            {
                if (Equals(o, items[i]))
                {
                    return i;
                }
            }

            return -1;
        }

        public void Insert(int index, T o)
        {
            if (index <= 0 && index > items.Length)
            {
                throw new ArgumentOutOfRangeException("index", "Индекс вне пределов массива");
            }

            if (length >= items.Length)
            {
                Capacity = length * 2;
            }

            Array.Copy(items, index, items, index + 1, length - index - 1);
            items[index] = o;
            length++;
            modCount++;
        }

        public void RemoveAt(int index)
        {
            if (index <= 0 && index > items.Length)
            {
                throw new ArgumentOutOfRangeException("index", "Индекс вне пределов массива");
            }

            if (index < length - 1)
            {
                Array.Copy(items, index + 1, items, index, length - index - 1);
            }

            length--;
            modCount++;
        }

        public void Add(T o)
        {
            if (length >= items.Length)
            {
                Capacity = items.Length * 2;
            }

            items[length] = o;
            length++;
            modCount++;
        }

        public void Clear()
        {
            length = 0;
        }

        public bool Contains(T o)
        {
            for (int i = 0; i < length; i++)
            {
                if (Equals(o, items[i]))
                {
                    return true;
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

            Array.Copy(items, 0, array, arrayIndex, length);
        }

        public bool Remove(T o)
        {
            for (int i = 0; i < length; i++)
            {
                if (Equals(o, items[i]))
                {
                    RemoveAt(i);
                    modCount++;
                    return true;
                }
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int tempModCount = modCount;

            for (int i = 0; i < length; i++)
            {
                if (tempModCount != modCount)
                {
                    throw new InvalidOperationException("Массив был изменен");
                }

                yield return items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void TrimExcess()
        {
            const double epsilon = 0.1;

            if (length / (double)items.Length <= epsilon)
            {
                Capacity = length;
            }
        }
    }
}
