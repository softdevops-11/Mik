using System;

namespace List
{
    internal class SingleLinkedList<T>
    {
        private int length;
        private ListNode<T> head;

        public SingleLinkedList()
        {
        }

        public int GetLength()
        {
            return length;
        }

        public ListNode<T> GetHead()
        {
            return head;
        }

        public T GetHeadData()
        {
            if (head.Data == null)
            {
                throw new ArgumentNullException("Значение пусто");
            }

            return head.Data;
        }

        public T GetData(int index)
        {
            if (index >= length || index < 0)
            {
                throw new ArgumentException("Неверное значение индекса");
            }

            int count = 0;

            for (ListNode<T> p = head; p != null; p = p.Next)
            {
                if (count == index)
                {
                    return p.Data;
                }

                count++;
            }

            return default(T);
        }

        public T SetData(int index, T data)
        {
            if (index >= length || index < 0)
            {
                throw new ArgumentException("Неверное значение индекса");
            }

            if (data == null)
            {
                throw new ArgumentNullException("Значение пусто");
            }

            int count = 0;

            for (ListNode<T> current = head, previous = null; current != null; previous = current, current = current.Next)
            {
                if (count == index)
                {
                    T temp = current.Data;
                    current.Data = data;

                    return temp;
                }

                count++;
            }

            return default(T);
        }

        public T DeleteOnIndex(int index)
        {
            if (index >= length || index < 0)
            {
                throw new ArgumentException("Неверное значение индекса");
            }

            int count = 0;

            for (ListNode<T> current = head, previous = null; current != null; previous = current, current = current.Next)
            {
                if (count == index)
                {
                    T temp = current.Data;
                    previous.Next = current.Next;
                    length--;

                    return temp;
                }

                count++;
            }

            return default(T);
        }

        public void Add(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Значение пусто");
            }

            ListNode<T> item = new ListNode<T>(data);

            if (head == null)
            {
                head = item;
            }
            else
            {
                item.Next = head;
                head = item;
            }

            length++;
        }

        public void Add(int index, T data)
        {
            if (index > length || index < 0)
            {
                throw new ArgumentException("Неверное значение индекса");
            }

            if (data == null)
            {
                throw new ArgumentNullException("Значение пусто");
            }

            ListNode<T> item = new ListNode<T>(data);
            int count = 0;

            for (ListNode<T> current = head, previous = null; current != null; previous = current, current = current.Next)
            {
                if (index == 0)
                {
                    item.Next = head;
                    head = item;
                    length++;
                    break;
                }

                if (count == index)
                {
                    item.Next = current;
                    previous.Next = item;
                    length++;
                    break;
                }

                count++;

                if (count == index)
                {
                    previous = current;
                    current = current.Next;
                    current = item;
                    previous.Next = current;
                    length++;
                    break;
                }
            }
        }

        public bool DeleteOnData(T data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("Значение пусто");
            }

            int count = 0;

            for (ListNode<T> current = head, previous = null; current != null; previous = current, current = current.Next)
            {
                if (current.Data.Equals(data))
                {
                    previous.Next = current.Next;
                    length--;

                    return true;
                }

                count++;
            }

            return false;
        }

        public T DeleteFirstItem()
        {
            if (head != null)
            {
                T temp = head.Data;
                head = head.Next;
                length--;

                return temp;
            }

            return default(T);
        }

        public void Copy(SingleLinkedList<T> newList)
        {
            int count = 0;

            for (ListNode<T> current = head; current != null; current = current.Next)
            {
                if (count == 0)
                {
                    newList.Add(current.Data);
                }
                else
                {
                    newList.Add(count, current.Data);
                }

                count++;
            }
        }

        public void Inverse()
        {
            SingleLinkedList<T> tempList = new SingleLinkedList<T>();

            for (ListNode<T> current = head; current != null; current = current.Next)
            {
                tempList.Add(current.Data);
            }

            int count = 0;
            ListNode<T> tempListCurrent = tempList.head;

            for (ListNode<T> current = tempList.head; current != null; current = current.Next)
            {
                SetData(count, current.Data);
                count++;
            }
        }
    }
}
