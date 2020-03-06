using System;

namespace List
{
    internal class ProgramList
    {
        private static void Main()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();

            list.AddToHead(1);
            list.AddToHead(5);
            list.AddToHead(17);
            list.AddToHead(42);
            list.AddToHead(-69);
            list.Insert(5, -33);

            SingleLinkedList<int> newList = list.Copy();

            for (ListNode<int> p = newList.Head; p != null; p = p.Next)
            {
                Console.WriteLine(p.Data);
            }

            newList.DeleteFirstItem();
            Console.WriteLine();

            for (ListNode<int> p = list.Head; p != null; p = p.Next)
            {
                Console.WriteLine(p.Data);
            }

            Console.WriteLine();

            list.Inverse();

            for (ListNode<int> p = list.Head; p != null; p = p.Next)
            {
                Console.WriteLine(p.Data);
            }

            Console.WriteLine();
            Console.WriteLine(list.GetHeadData());
            Console.WriteLine(list.DeleteFirstItem());
            Console.WriteLine(list.DeleteByIndex(2));
            Console.WriteLine(list.SetData(2, 111));
            Console.WriteLine(list.DeleteByValue(-33));
            Console.WriteLine(list.GetData(2));
            Console.WriteLine();

            for (ListNode<int> p = newList.Head; p != null; p = p.Next)
            {
                Console.WriteLine(p.Data);
            }

            Console.WriteLine();

            for (ListNode<int> p = list.Head; p != null; p = p.Next)
            {
                Console.WriteLine(p.Data);
            }

            Console.ReadLine();
        }
    }
}
