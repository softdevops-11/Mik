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
            newList.DeleteFirstItem();

            list.Inverse();
            Console.WriteLine(list.GetHeadData());
            Console.WriteLine(list.DeleteFirstItem());
            Console.WriteLine(list.DeleteByIndex(2));
            Console.WriteLine(list.SetData(2, 111));
            Console.WriteLine(list.DeleteByValue(-33));
            Console.WriteLine(list.GetData(2));
            Console.WriteLine();

            Console.ReadLine();
        }
    }
}