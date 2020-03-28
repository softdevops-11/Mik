using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHome
{
    internal class ArrayListHome
    {
        public static List<string> GetFileLines(string filePath)
        {
            List<string> fileLines = new List<string>();

            try
            {
                using (StreamReader readFile = new StreamReader(new FileStream(filePath, FileMode.Open)))
                {
                    while (!readFile.EndOfStream)
                    {
                        fileLines.Add(readFile.ReadLine());
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Файл не найден");
            }

            return fileLines;
        }

        public static void RemoveEvenNumbers(List<int> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] % 2 == 0)
                {
                    list.RemoveAt(i);
                    i--;
                }
            }
        }

        public static List<int> GetListWithoutRepeats(List<int> list)
        {
            List<int> listWithoutRepeats = new List<int>();

            foreach (int item in list)
            {
                if (!listWithoutRepeats.Contains(item))
                {
                    listWithoutRepeats.Add(item);
                }
            }

            return listWithoutRepeats;
        }

        private static void Main()
        {
            string filePath = @"..\..\Text1.txt";

            List<string> fileLines = GetFileLines(filePath);

            foreach (string line in fileLines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine();

            List<int> list = new List<int> { 1, 6, 5, 9, 10, 12, 14, 65, 33, 11 };

            RemoveEvenNumbers(list);

            foreach (int number in list)
            {
                Console.Write("{0} ", number);
            }

            Console.WriteLine();

            List<int> listWithRepeats = new List<int> { 1, 5, 2, 1, 3, 5 };

            List<int> listWithoutRepeats = GetListWithoutRepeats(listWithRepeats);

            foreach (int number in listWithoutRepeats)
            {
                Console.Write("{0} ", number);
            }

            Console.ReadLine();
        }
    }
}