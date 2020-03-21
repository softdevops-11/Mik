using System;
using System.Collections;
using System.Collections.Generic;

namespace ArrayList
{
    public class ArrayList<T> : IList<T>
    {
        private T[] items;
        public int Count { get; private set; }
        private int modCount;

        public bool IsReadOnly => false;

        public int Capacity
        {
            get => items.Length;
            set
            {
                if (value < 0)
                {
                    throw new OverflowException("Размерность массива должна быть > 0 , сейчас равна: " + value);
                }

                Array.Resize(ref items, value);

                if (value < Count)
                {
                    Count = value;
                }
            }
        }

        public T this[int index]
        {
            get
            {
                CheckIndex(index, items.Length);

                return items[index];
            }
            set
            {
                CheckIndex(index, items.Length);

                items[index] = value;
            }

        }

        public ArrayList()
        {
            items = new T[0];
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new OverflowException("Размерность массива должна быть > 0 , сейчас равна: " + capacity);
            }

            items = new T[capacity];
        }

        private static void CheckIndex(int index, int length)
        {
            if (index >= length || index < 0)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах от 0 до " + length
                    + " , сейчас он равен: " + index);
            }
        }

        public int IndexOf(T o)
        {
            for (int i = 0; i < Count; i++)
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
            CheckIndex(index, items.Length);

            if (Count >= items.Length)
            {
                Capacity = Count * 2;
            }

            if (index < Count)
            {
                Array.Copy(items, index, items, index + 1, Count - index);
                items[index] = o;
            }
            else
            {
                items[Count] = o;
            }

            Count++;
            modCount++;
        }

        public void RemoveAt(int index)
        {
            CheckIndex(index, items.Length);

            if (index < Count - 1)
            {
                Array.Copy(items, index + 1, items, index, Count - index - 1);
            }

            Count--;
            items[Count] = default;
            modCount++;
        }

        public void Add(T o)
        {
            if (Count >= items.Length)
            {
                Capacity = items.Length * 2 + 1;
            }

            items[Count] = o;
            Count++;
            modCount++;
        }

        public void Clear()
        {
            for (int i = 0; i < Count; i++)
            {
                items[i] = default;
            }

            Count = 0;
        }

        public bool Contains(T o)
        {
            if (IndexOf(o) != -1)
            {
                return true;
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            CheckIndex(arrayIndex, array.Length);

            if (array == null)
            {
                throw new NullReferenceException("Массив null");
            }

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("Размер копируемого списка составляет " + Count
                    + ", что превышает размер остатка массива равного: " + (array.Length - arrayIndex), nameof(arrayIndex));
            }

            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public bool Remove(T o)
        {
            if (IndexOf(o) != -1)
            {
                RemoveAt(IndexOf(o));
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            int tempModCount = modCount;

            for (int i = 0; i < Count; i++)
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
            const double epsilon = 0.9;

            if (Count / (double)items.Length <= epsilon)
            {
                Capacity = Count;
            }
        }
    }
}
