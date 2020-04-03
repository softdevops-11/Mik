using System;
using System.Text;

namespace List
{
    internal class SingleLinkedList<T>
    {
        private ListNode<T> head;

        public int Count { get; private set; }

        public T GetHeadData()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Список пуст");
            }

            return head.Data;
        }

        private ListNode<T> FindNodeByIndex(int index)
        {
            int i = 0;

            for (ListNode<T> p = head; p != null; p = p.Next)
            {
                if (i == index)
                {
                    return p;
                }

                i++;
            }

            return null;
        }

        public T GetData(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах: [0, " + (Count - 1) + "]," +
                    " сейчас он равен: " + index);
            }

            return FindNodeByIndex(index).Data;
        }

        public T SetData(int index, T data)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах: [0, " + (Count - 1) + "], " +
                    "сейчас он равен: " + index);
            }

            ListNode<T> current = FindNodeByIndex(index);
            T temporaryData = current.Data;
            current.Data = data;

            return temporaryData;
        }

        public T DeleteByIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах: [0, " + (Count - 1) + "]," +
                    " сейчас он равен: " + index);
            }

            if (index == 0)
            {
                return DeleteFirstItem();
            }

            ListNode<T> previous = FindNodeByIndex(index - 1);
            T data = previous.Next.Data;
            previous.Next = previous.Next.Next;
            Count--;

            return data;
        }

        public void AddToHead(T data)
        {
            ListNode<T> item = new ListNode<T>(data, head);

            head = item;
            Count++;
        }

        public void Insert(int index, T data)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах: [0, " + (Count - 1) + "], " +
                    "сейчас он равен: " + index);
            }

            if (index == 0)
            {
                AddToHead(data);
                return;
            }

            ListNode<T> item = new ListNode<T>(data);
            ListNode<T> previous = FindNodeByIndex(index - 1);
            item.Next = previous.Next;
            previous.Next = item;
            Count++;
        }

        public bool DeleteByValue(T data)
        {
            if (head == null)
            {
                return false;
            }

            if (Equals(head.Data, data))
            {
                head = head.Next;
                Count--;

                return true;
            }

            for (ListNode<T> current = head.Next, previous = head; current != null; previous = current, current = current.Next)
            {
                if (Equals(current.Data, data))
                {
                    previous.Next = current.Next;
                    Count--;

                    return true;
                }
            }

            return false;
        }

        public T DeleteFirstItem()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Список пуст");
            }

            T data = head.Data;
            head = head.Next;
            Count--;

            return data;
        }

        public SingleLinkedList<T> Copy()
        {
            SingleLinkedList<T> newList = new SingleLinkedList<T>
            {
                Count = Count
            };

            int count = 0;
            ListNode<T> tail = null;

            for (ListNode<T> current = head; current != null; current = current.Next)
            {
                ListNode<T> item = new ListNode<T>(current.Data);

                if (count == 0)
                {
                    newList.head = item;
                }
                else
                {
                    tail.Next = item;
                }

                tail = item;
                count++;
            }

            return newList;
        }

        public void Reverse()
        {
            ListNode<T> current = head;
            ListNode<T> previous = null;

            while (current != null)
            {
                ListNode<T> next = current.Next;
                current.Next = previous;
                previous = current;
                current = next;
            }

            head = previous;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (ListNode<T> current = head; current != null; current = current.Next)
            {
                sb.Append(current.Data);
                sb.Append("-> ");
            }

            return sb.ToString();
        }
    }
}
