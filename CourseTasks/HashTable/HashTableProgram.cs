using System;

namespace HashTable
{
    class HashTableProgram
    {
        static void Main()
        {
            HashTable<int> hashTable = new HashTable<int>(10);
            int[] array = new int[10];

            hashTable.Add(5);
            hashTable.Add(2);
            hashTable.Add(13);
            hashTable.Add(522);
            hashTable.Add(125);
            hashTable.Add(9);
            hashTable.Add(55);

            foreach (int value in hashTable)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();
            Console.WriteLine(hashTable.Contains(9));
            Console.WriteLine(hashTable.Remove(13));

            Console.WriteLine();

            foreach (int value in hashTable)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();
            hashTable.Capacity = 20;

            foreach (int value in hashTable)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();
            hashTable.CopyTo(array, 1);

            foreach (int value in array)
            {
                Console.WriteLine(value);
            }

            Console.ReadLine();
        }
    }
}
