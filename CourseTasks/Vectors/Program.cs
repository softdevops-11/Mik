using System;

namespace Vectors
{
    class ProgramVector
    {
        static void Main()
        {
            double[] a = { 1.1, 2.1, 4, 7.5 };
            Vector vector1 = new Vector(a);

            double[] b = { 3, 4, 5, 6, 7 };
            Vector vector2 = new Vector(b);

            double[] c = { 1, 1, 1 };
            Vector vector3 = new Vector(c);

            Console.WriteLine(new Vector(6));
            Console.WriteLine(new Vector(vector2));
            Console.WriteLine(new Vector(a));
            Console.WriteLine(vector1);
            Console.WriteLine(new Vector(6, b));

            Console.WriteLine("Размерность вектора vector2: {0}", vector2.GetSize());

            vector1.SetElement(1, 10);
            Console.WriteLine("Значение вектора на 2 позиции: {0}", vector1.GetElement(1));

            vector2.Add(vector1);
            Console.WriteLine("Суммирование к вектору vector2 вектора vector1: {0}", vector2);

            vector2.Substract(vector1);
            Console.WriteLine("Вычитание от вектора vector2 вектора vector1: {0}", vector2);

            vector2.MultiplyByScalar(3);
            Console.WriteLine("Умножение вектора vector2 на скаляр: {0}", vector2);

            vector2.Reverse();
            Console.WriteLine("Обращение вектора vector2: {0}", vector2);
            Console.WriteLine("Длина вектора vector2: {0}", vector2.GetLength());
            Console.WriteLine("Сравнение на равенство векторов vector1 и vector2: {0}", vector1.Equals(vector2));
            Console.WriteLine("Хэш код вектора vector1: {0}", vector1.GetHashCode());
            Console.WriteLine(vector1);
            Console.WriteLine(vector2);
            Console.WriteLine("Суммирование вектора vector2 и вектора vector1: {0}", Vector.GetSum(vector1, vector2));
            Console.WriteLine("Вычитание вектора vector1 и вектора vector2: {0}", Vector.GetDifference(vector1, vector2));
            Console.WriteLine("Умножение вектора vector2 и вектора vector1: {0}", Vector.GetScalarMultiplication(vector1, vector2));

            Console.ReadLine();
        }
    }
}