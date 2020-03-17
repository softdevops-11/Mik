using System;
using System.Collections.Generic;
using System.IO;

namespace ArrayListHome
{
    internal class ArrayListHome
    {
        public static List<string> ReadFileToList(string pathFile)
        {
            List<string> stringList = new List<string>();

            if (!File.Exists(pathFile))
            {
                throw new FileNotFoundException("Файл не найден", pathFile);
            }

            FileStream file = new FileStream(pathFile, FileMode.Open);

            using (StreamReader readFile = new StreamReader(file))
            {
                while (!readFile.EndOfStream)
                {
                    stringList.Add(readFile.ReadLine());
                }
            }

            return stringList;
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
            string pathFile = @"..\..\Text.txt";

            List<string> stringList = ReadFileToList(pathFile);

            foreach (string line in stringList)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine();

            List<int> list = new List<int>
            {
                1,
                6,
                5,
                9,
                10,
                12,
                14,
                65,
                33,
                11
            };
            RemoveEvenNumbers(list);

            foreach (int value in list)
            {
                Console.WriteLine(value);
            }

            Console.WriteLine();

            List<int> listWithRepeat = new List<int>
            {
                1,
                5,
                2,
                1,
                3,
                5
            };

            List<int> listWithoutRepeat = GetListWithoutRepeats(listWithRepeat);

            foreach (int value in listWithoutRepeat)
            {
                Console.WriteLine(value);
            }

            Console.ReadLine();
        }
    }
}
