using System;

namespace List
{
    internal class ProgramList
    {
        private static void Main()
        {
            SingleLinkedList<int> list = new SingleLinkedList<int>();

            list.Add(1);
            list.Add(5);
            list.Add(17);
            list.Add(42);
            list.Add(-69);
            list.Add(5, -33);

            SingleLinkedList<int> newList = new SingleLinkedList<int>();
            list.Copy(newList);

            for (ListNode<int> p = newList.GetHead(); p != null; p = p.Next)
            {
                Console.WriteLine(p.Data);
            }

            newList.DeleteFirstItem();
            Console.WriteLine();

            for (ListNode<int> p = list.GetHead(); p != null; p = p.Next)
            {
                Console.WriteLine(p.Data);
            }

            Console.WriteLine();

            list.Inverse();

            for (ListNode<int> p = list.GetHead(); p != null; p = p.Next)
            {
                Console.WriteLine(p.Data);
            }

            Console.WriteLine();
            Console.WriteLine(list.GetHeadData());
            Console.WriteLine(list.DeleteFirstItem());
            Console.WriteLine(list.DeleteOnIndex(2));
            Console.WriteLine(list.SetData(2, 111));
            Console.WriteLine(list.DeleteOnData(-33));
            Console.WriteLine(list.GetData(2));
            Console.WriteLine();

            for (ListNode<int> p = newList.GetHead(); p != null; p = p.Next)
            {
                Console.WriteLine(p.Data);
            }

            Console.WriteLine();

            for (ListNode<int> p = list.GetHead(); p != null; p = p.Next)
            {
                Console.WriteLine(p.Data);
            }

            Console.ReadLine();
        }
    }
}
