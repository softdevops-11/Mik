using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ArrayList
{
    public class ArrayList<T> : IList<T>
    {
        private T[] items;
        private int modCount;
        private const int DefaultCapacity = 10;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public int Capacity
        {
            get => items.Length;
            set
            {
                if (value < Count)
                {
                    throw new ArgumentOutOfRangeException(nameof(value), "Размерность массива должна быть >= "
                        + Count + ", сейчас равна: " + value);
                }

                Array.Resize(ref items, value);
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
            items = new T[DefaultCapacity];
        }

        public ArrayList(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(capacity), "Размерность массива должна быть >= 0 ," +
                    " сейчас равна: " + capacity);
            }

            items = new T[capacity];
        }

        private static void CheckIndex(int index, int length)
        {
            if (index < 0 || index >= length)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, индекс должен быть в пределах: " +
                    "[0, " + (length - 1) + "] , сейчас он равен: " + index);
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

        private void IncreaseCapacity()
        {
            if (Count >= items.Length)
            {
                if (items.Length == 0)
                {
                    Capacity = 1;
                }
                else
                {
                    Capacity = items.Length * 2;
                }
            }
        }

        public void Insert(int index, T o)
        {
            CheckIndex(index, Count + 1);
            IncreaseCapacity();

            if (index < Count)
            {
                Array.Copy(items, index, items, index + 1, Count - index);
            }

            items[index] = o;
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
            IncreaseCapacity();
            items[Count] = o;
            Count++;
            modCount++;
        }

        public void Clear()
        {
            Array.Clear(items, 0, Count);
            Count = 0;
            modCount++;
        }

        public bool Contains(T o)
        {
            return IndexOf(o) != -1;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array), "Массив null");
            }

            CheckIndex(arrayIndex, array.Length);

            if (Count > array.Length - arrayIndex)
            {
                throw new ArgumentException("Размер копируемого списка составляет " + Count + ", что превышает размер остатка массива равного: " + (array.Length - arrayIndex)
                    + ". Длина массива равна: " + array.Length + ". Индекс копирования равен: " + arrayIndex, nameof(arrayIndex));
            }

            Array.Copy(items, 0, array, arrayIndex, Count);
        }

        public bool Remove(T o)
        {
            int index = IndexOf(o);

            if (index != -1)
            {
                RemoveAt(index);
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");

            for (int i = 0; i < Count; i++)
            {
                if (items[i] == null)
                {
                    sb.Append("null");
                }
                else
                {
                    sb.Append(items[i]);
                }

                sb.Append(", ");
            }

            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 2, 2);
            }

            sb.Append("]");

            return sb.ToString();
        }
    }
}
