using System;
using System.Text;

namespace Range
{
    class RangeMain
    {
        public static string GetStringRanges(Range[] ranges)
        {
            StringBuilder sb = new StringBuilder();

            foreach (Range range in ranges)
            {
                sb.Append(range);
                sb.Append(", ");
            }

            sb.Remove(sb.Length - 2, 2);
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
            StringBuilder unionString = new StringBuilder("Объединение интервалов дает интервал: [");
            unionString.Append(GetStringRanges(union));
            Console.WriteLine(unionString.ToString());

            Range[] difference = range1.GetDifference(range2);
            StringBuilder differenceString = new StringBuilder("Разность интервалов дает интервал: [");
            differenceString.Append(GetStringRanges(difference));
            Console.WriteLine(differenceString.ToString());

            Console.ReadKey();
        }
    }
}
