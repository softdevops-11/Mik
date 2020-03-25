namespace List
{
    internal class ListNode<T>
    {
        public T Data { get; set; }

        public ListNode<T> Next { get; set; }

        public ListNode(T data)
        {
            Data = data;
        }

        public ListNode(T data, ListNode<T> next)
        {
            Data = data;
            Next = next;
        }

        public override string ToString()
        {
            return string.Format("[Узел: {0}] -> {1}", Data, Next);
        }
    }
}


