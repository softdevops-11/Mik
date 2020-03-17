using System;

namespace List
{
    internal class SingleLinkedList<T>
    {
        public int Length { get; set; }
        private ListNode<T> head;

        public T GetHeadData()
        {
            if (head == null)
            {
                throw new NullReferenceException("Список пуст");
            }

            return head.Data;
        }

        private ListNode<T> FindNodeByIndex(int index)
        {
            int count = 0;

            for (ListNode<T> p = head; p != null; p = p.Next)
            {
                if (count == index)
                {
                    return p;
                }

                count++;
            }

            return null;
        }

        public T GetData(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах от 0 до "
                    + Length + " , сейчас он равен: " + index);
            }

            ListNode<T> node = FindNodeByIndex(index);

            return node.Data;
        }

        public T SetData(int index, T data)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах от 0 до "
                    + Length + " , сейчас он равен: " + index);
            }

            ListNode<T> node = FindNodeByIndex(index);
            T temp = node.Data;
            node.Data = data;

            return temp;
        }

        public T DeleteByIndex(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах от 0 до "
                    + Length + " , сейчас он равен: " + index);
            }

            T temp;

            if (index == 0)
            {
                temp = head.Data;
                head = head.Next;
                Length--;

                return temp;
            }

            ListNode<T> node = FindNodeByIndex(index - 1);
            temp = node.Next.Data;
            node.Next = node.Next.Next;
            Length--;

            return temp;
        }

        public void AddToHead(T data)
        {
            ListNode<T> item = new ListNode<T>(data);

            item.Next = head;
            head = item;
            Length++;
        }

        public void Insert(int index, T data)
        {
            if (index > Length || index < 0)
            {
                throw new IndexOutOfRangeException("Неверное значение индекса, должен быть в пределах от 0 до "
                    + Length + " , сейчас он равен: " + index);
            }

            ListNode<T> item = new ListNode<T>(data);

            if (index == 0)
            {
                item.Next = head;
                head = item;
                Length++;

                return;
            }

            ListNode<T> node = FindNodeByIndex(index - 1);
            item.Next = node.Next;
            node.Next = item;
            Length++;
        }

        public bool DeleteByValue(T data)
        {
            if (head == null)
            {
                throw new NullReferenceException("Список пуст");
            }

            if (Equals(head.Data, data))
            {
                head = head.Next;
                Length--;

                return true;
            }

            for (ListNode<T> current = head, previous = null; current != null; previous = current, current = current.Next)
            {
                if (Equals(current.Data, data))
                {
                    previous.Next = current.Next;
                    Length--;

                    return true;
                }
            }

            return false;
        }

        public T DeleteFirstItem()
        {
            if (head == null)
            {
                throw new NullReferenceException("Список пуст");
            }

            T temp = head.Data;
            head = head.Next;
            Length--;

            return temp;
        }

        public SingleLinkedList<T> Copy()
        {
            SingleLinkedList<T> newList = new SingleLinkedList<T>();
            newList.Length = Length;

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
