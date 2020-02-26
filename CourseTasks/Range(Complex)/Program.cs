using System;
using System.Text;

namespace ComplexRange
{
    class RangeMain
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

            Range rangeIntersection = range1.Intersect(range2);

            if (rangeIntersection != null)
            {
                Console.WriteLine("Интервал пересечения: [{0}]", rangeIntersection);
            }
            else
            {
                Console.WriteLine("Интервал пересечения: []");
            }

            Range range3 = new Range(1, 2);
            Range range4 = new Range(3, 5);

            Range[] rangeUnion = range3.Unite(range4);
            StringBuilder unionString = new StringBuilder("Объединение интервалов дает интервал: ");

            for (int i = 0; i < rangeUnion.Length; i++)
            {
                unionString.AppendFormat("[{0}], ", rangeUnion[i]);
            }

            unionString = unionString.Remove(unionString.Length - 2, 2);
            Console.WriteLine(unionString.ToString());

            Range range5 = new Range(2, 7);
            Range range6 = new Range(1, 8);

            Range[] rangeDifference = range5.Subtract(range6);
            StringBuilder differenceString = new StringBuilder("Разность интервалов дает интервал: ");

            if (rangeDifference != null)
            {
                for (int i = 0; i < rangeDifference.Length; i++)
                {
                    differenceString.AppendFormat("[{0}], ", rangeDifference[i]);
                }

                differenceString = differenceString.Remove(differenceString.Length - 2, 2);
                Console.WriteLine(differenceString.ToString());
            }
            else
            {
                Console.WriteLine("Разность интервалов дает интервал: []");
            }

            Console.ReadKey();
        }
    }
}
