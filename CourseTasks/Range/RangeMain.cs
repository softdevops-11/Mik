using System;
using System.Text;

namespace Range
{
    internal class RangeMain
    {
        public static string GetRangesString(Range[] ranges)
        {
            StringBuilder sb = new StringBuilder("[");

            foreach (Range range in ranges)
            {
                sb.Append(range);
                sb.Append(", ");
            }

            if (sb.Length > 1)
            {
                sb.Remove(sb.Length - 2, 2);
            }
            sb.Append("]");

            return sb.ToString();
        }

        public static void Main()
        {
            Console.WriteLine("Введите начало первого диапазона: ");
            double from1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец первого диапазона: ");
            double to1 = Convert.ToDouble(Console.ReadLine());

            Range range1 = new Range(from1, to1);
            double rangeLength = range1.GetLength();
            Console.WriteLine("Длина интервала равна {0}. ", rangeLength);
            Console.WriteLine("Введите число:");

            double number = Convert.ToDouble(Console.ReadLine());

            if (range1.IsInside(number))
            {
                Console.WriteLine("Число лежит в интервале. ");
            }
            else
            {
                Console.WriteLine("Число не лежит в интервале. ");
            }

            Console.WriteLine("Введите начало второго диапазона: ");
            double from2 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец второго диапазона: ");
            double to2 = Convert.ToDouble(Console.ReadLine());

            Range range2 = new Range(from2, to2);

            Range intersection = range1.GetIntersection(range2);

            if (intersection != null)
            {
                Console.WriteLine("Интервал пересечения: {0}", intersection);
            }
            else
            {
                Console.WriteLine("Интервал пересечения: null");
            }

            Range[] union = range1.GetUnion(range2);
            Console.WriteLine("Объединение интервалов дает интервал: {0}", GetRangesString(union));

            Range[] difference = range1.GetDifference(range2);
            Console.WriteLine("Разность интервалов дает интервал: {0}", GetRangesString(difference));

            Console.ReadKey();
        }
    }
}