using System;

namespace List
{
    class SingleLinkedList<T>
    {
        private int Length { get; set; }
        private ListNode<T> head;

        public ListNode<T> Head
        {
            get
            {
                return head;
            }
        }

        public T GetHeadData()
        {
            if (head == null)
            {
                throw new ArgumentNullException("head", "Список пуст");
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
                throw new ArgumentOutOfRangeException("index", "Неверное значение индекса, должен быть в пределах от 0 до " 
                + Length + " , сейчас он равен" + index);
            }

            ListNode<T> node = this.FindNodeByIndex(index);

            return node.Data;
        }

        public T SetData(int index, T data)
        {
            if (index >= Length || index < 0)
            {
                throw new ArgumentOutOfRangeException("index", "Неверное значение индекса, должен быть в пределах от 0 до "
                + Length + " , сейчас он равен" + index);
            }

            ListNode<T> node = this.FindNodeByIndex(index);
            T temp = node.Data;
            node.Data = data;

            return temp;
        }

        public T DeleteByIndex(int index)
        {
            if (index >= Length || index < 0)
            {
                throw new ArgumentOutOfRangeException("index", "Неверное значение индекса, должен быть в пределах от 0 до "
                + Length + " , сейчас он равен" + index);
            }

            if (index == 0)
            {
                T temp = head.Data;
                head = head.Next;
                Length--;

                return temp;
            }

            int count = 0;

            for (ListNode<T> current = head, previous = null; current != null; previous = current, current = current.Next)
            {
                if (count == index)
                {
                    T temp = current.Data;
                    previous.Next = current.Next;
                    Length--;

                    return temp;
                }

                count++;
            }

            return default;
        }

        public void AddToHead(T data)
        {
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

            Length++;
        }

        public void Insert(int index, T data)
        {
            if (index > Length || index < 0)
            {
                throw new ArgumentOutOfRangeException("index", "Неверное значение индекса, должен быть в пределах от 0 до "
                + Length + " , сейчас он равен" + index);
            }

            ListNode<T> item = new ListNode<T>(data);

            if (index == 0)
            {
                item.Next = head;
                head = item;
                Length++;
            }

            int count = 0;

            for (ListNode<T> current = head, previous = null; ; previous = current, current = current.Next)
            {
                if (count == index)
                {
                    item.Next = current;
                    previous.Next = item;
                    Length++;
                    break;
                }

                count++;
            }
        }

        public bool DeleteByValue(T data)
        {
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
                throw new ArgumentNullException("head", "Список пуст");
            }

            T temp = head.Data;
            head = head.Next;
            Length--;

            return temp;
        }

        public SingleLinkedList<T> Copy()
        {
            SingleLinkedList<T> newList = new SingleLinkedList<T>();

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
                newList.Length++;
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

