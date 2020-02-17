using System;
using System.Text;

namespace RangeComplex
{
    internal class RangeMain
    {
        public static void Main()
        {
            Console.WriteLine("Введите концы диапазона: ");
            double from = Convert.ToDouble(Console.ReadLine());
            double to = Convert.ToDouble(Console.ReadLine());
            Range range = new Range(from, to);

            double rangeLength = range.GetLength();
            Console.WriteLine("Длина интервала равна {0}. ", rangeLength);
            Console.WriteLine("Введите число:");

            double number = Convert.ToDouble(Console.ReadLine());

            if (range.IsInside(number))
            {
                Console.WriteLine("Число лежит в интервале. ");
            }
            else
            {
                Console.WriteLine("Число не лежит в интервале. ");
            }

            Console.WriteLine("Введите концы первого диапазона: ");
            double from1 = Convert.ToDouble(Console.ReadLine());
            double to1 = Convert.ToDouble(Console.ReadLine());
            Range range1 = new Range(from1, to1);

            Console.WriteLine("Введите концы второго диапазона: ");
            double from2 = Convert.ToDouble(Console.ReadLine());
            double to2 = Convert.ToDouble(Console.ReadLine());
            Range range2 = new Range(from2, to2);

            range1.Intersection(range2);
            double epsilon = 1E-9;

            if (Math.Abs(range1.To - range1.From) > epsilon)
            {
                Console.WriteLine("Интервал пересечения: [{0}]", range1);
            }
            else
            {
                Console.WriteLine("Интервал пересечения: []");
            }

            Range range3 = new Range(1, 2);
            Range range4 = new Range(3, 5);

            range3.Union(range4);
            StringBuilder unionString = new StringBuilder("Объединение интервалов дает интервал: [");

            if (Math.Abs(range3.From - range4.From) <= epsilon && Math.Abs(range3.To - range4.To) <= epsilon)
            {
                unionString.AppendFormat("{0}]", range3);
            }
            else
            {
                unionString.AppendFormat("{0}, {1}]", range3, range4);
            }

            Console.WriteLine(unionString.ToString());

            Range range5 = new Range(2, 5);
            Range range6 = new Range(3, 4);

            range5.Difference(range6);
            StringBuilder differenceString = new StringBuilder("Разность интервалов дает интервал: [");

            if (Math.Abs(range5.From - range6.From) <= epsilon && Math.Abs(range5.To - range6.To) <= epsilon)
            {
                if (Math.Abs(range5.To - range5.From) > epsilon)
                {
                    differenceString.AppendFormat("{0}]", range5);
                }
                else
                {
                    differenceString.Append("]");
                }
            }
            else
            {
                differenceString.AppendFormat("{0}, {1}]", range5, range6);
            }

            Console.Write(differenceString.ToString());

            Console.ReadKey();
        }
    }
}
