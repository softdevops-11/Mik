using System;

namespace ArrayList
{
    internal class ArrayListProgram
    {
        private static void Main()
        {
            ArrayList<int> list = new ArrayList<int>(10);
            int[] array = new int[10];

            list.Add(5);
            list.Add(2);
            list.Add(13);
            list.Add(522);
            list.Add(125);
            list.Add(9);
            list.RemoveAt(2);

            foreach (int value in list)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine(list.Remove(125));
            Console.WriteLine(list.IndexOf(9));
            Console.WriteLine();
            list.Insert(1, 100);

            foreach (int value in list)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();
            Console.WriteLine(list.Contains(100));
            Console.WriteLine();

            list.Clear();
            list.Add(5);
            list.Add(2);
            list.Add(13);
            list.Add(522);
            list.Add(125);
            list.Add(9);
            list.CopyTo(array, 3);

            foreach (int value in array)
            {
                Console.WriteLine(value);
            }

            ArrayList<int> listNew = new ArrayList<int>(10)
            {
                2,
            };

            listNew.TrimExcess();

            Console.ReadLine();
        }
    }
}
