using System;
using System.Text;

namespace Range
{
    class RangeMain
    {
        public static void Main()
        {
            {
            }
            Console.WriteLine("Введите начало диапазона: ");
            double from = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец диапазона: ");
            double to = Convert.ToDouble(Console.ReadLine());

            Range range3 = new Range(from, to);
            double rangeLength = range3.GetLength();
            Console.WriteLine("Длина интервала равна {0}. ", rangeLength);
            Console.WriteLine("Введите число:");

            double number = Convert.ToDouble(Console.ReadLine());

            if (range3.IsInside(number))
            {
                Console.WriteLine("Число лежит в интервале. ");
            }
            else
            {
                Console.WriteLine("Число не лежит в интервале. ");
            }

            Console.WriteLine("Введите начало первого диапазона: ");
            double from1 = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Введите конец первого диапазона: ");
            double to1 = Convert.ToDouble(Console.ReadLine());

            Range range1 = new Range(from1, to1);

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
                Console.WriteLine("Интервал пересечения: ");
            }

            Range[] union = range1.GetUnion(range2);
            StringBuilder unionString = new StringBuilder("Объединение интервалов дает интервал: [");

            foreach (Range range in union)
            {
                unionString.AppendFormat("{0}, ", range);
            }

            unionString = unionString.Remove(unionString.Length - 2, 2);
            unionString.Append("]");
            Console.WriteLine(unionString.ToString());

            Range[] difference = range1.GetSubtraction(range2);
            StringBuilder differenceString = new StringBuilder("Разность интервалов дает интервал: [");

            foreach (Range range in difference)
            {
                differenceString.AppendFormat("{0}, ", range);
            }

            if (difference.Length != 0)
            {
                differenceString = differenceString.Remove(differenceString.Length - 2, 2);
            }
            differenceString.Append("]");
            Console.WriteLine(differenceString.ToString());

            Console.ReadKey();
        }
    }
}
