using System;

namespace RangeMain
{
    internal class RangeMain
    {
        public static void Main()
        {
            Console.WriteLine("Введите концы диапазона: ");
            double from = Convert.ToDouble(Console.ReadLine());
            double to = Convert.ToDouble(Console.ReadLine());
            Range interval = new Range(from, to);

            double intervalLength = interval.GetLength();
            Console.WriteLine("Длина интервала равна {0}. ", intervalLength);
            Console.WriteLine("Введите число:");

            double number = Convert.ToDouble(Console.ReadLine());

            if (interval.IsInside(number))
            {
                Console.WriteLine("Число лежит в интервале. ");
            }
            else
            {
                Console.WriteLine("Число не лежит в интервале. ");
            }

            Console.WriteLine("Введите концы первого диапазона: ");
            double fromOne = Convert.ToDouble(Console.ReadLine());
            double toOne = Convert.ToDouble(Console.ReadLine());
            Range intervalOne = new Range(fromOne, toOne);

            Console.WriteLine("Введите концы второго диапазона: ");
            double fromTwo = Convert.ToDouble(Console.ReadLine());
            double toTwo = Convert.ToDouble(Console.ReadLine());
            Range intervalTwo = new Range(fromTwo, toTwo);

            Range intervalIntersection = Range.RangesIntersection(intervalOne, intervalTwo);

            if (intervalIntersection != null)
            {
                Console.WriteLine("Интервал пересечения [{0},{1}]. ", intervalIntersection.From, intervalIntersection.To);
            }
            else
            {
                Console.WriteLine("Интервал пересечения null.");
            }

            Range[] intervalUnion = Range.RangesUnion(intervalOne, intervalTwo);
            Console.Write("Объединение интервалов дает интервал: ");

            for (int i = 0; i < 2; i++)
            {
                if (intervalUnion[i] != null)
                {
                    Console.Write(" [{0},{1}] ", intervalUnion[i].From, intervalUnion[i].To);
                }
            }

            Console.WriteLine();
            Range[] intervalDifference = Range.RangesDifference(intervalOne, intervalTwo);
            Console.Write("Разность интервалов дает интервал: ");

            for (int i = 0; i < 2; i++)
            {
                if (intervalDifference[i] != null)
                {
                    Console.Write(" [{0},{1}] ", intervalDifference[i].From, intervalDifference[i].To);
                }
            }

            Console.ReadKey();
        }
    }
}
