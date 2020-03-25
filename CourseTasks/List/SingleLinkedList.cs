using System;

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
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах: [0, " + (Count - 1) + "], "
                    + "сейчас он равен: " + index);
            }

            return FindNodeByIndex(index).Data;
        }

        public T SetData(int index, T data)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах: [0, " + (Count - 1) + "],"
                    + " сейчас он равен: " + index);
            }

            ListNode<T> node = FindNodeByIndex(index);
            T temp = node.Data;
            node.Data = data;

            return temp;
        }

        public T DeleteByIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах: [0, " + (Count - 1) + "], "
                    + "сейчас он равен: " + index);
            }

            T temp;

            if (index == 0)
            {
                return DeleteFirstItem();
            }

            ListNode<T> node = FindNodeByIndex(index - 1);
            temp = node.Next.Data;
            node.Next = node.Next.Next;
            Count--;

            return temp;
        }

        public void AddToHead(T data)
        {
            ListNode<T> item = new ListNode<T>(data)
            {
                Next = head
            };
            head = item;
            Count++;
        }

        public void Insert(int index, T data)
        {
            if (index > Count || index < 0)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах: [0, " + (Count - 1) + "],"
                    + " сейчас он равен: " + index);
            }

            if (index == 0)
            {
                AddToHead(data);
                return;
            }

            ListNode<T> item = new ListNode<T>(data);
            ListNode<T> node = FindNodeByIndex(index - 1);
            item.Next = node.Next;
            node.Next = item;
            Count++;
        }

        public bool DeleteByValue(T data)
        {
            if (head != null)
            {
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
            }

            return false;
        }

        public T DeleteFirstItem()
        {
            if (head == null)
            {
                throw new InvalidOperationException("Список пуст");
            }

            T temp = head.Data;
            head = head.Next;
            Count--;

            return temp;
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

        public void Inverse()
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
    }
}

