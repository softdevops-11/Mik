using System;

namespace Vector
{
    internal class ProgramVector
    {
        private static void Main()
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

            Console.WriteLine("Размерность вектора vector2 {0}", vector2.GetSize());

            vector1.SetVectorValue(1, 10);
            Console.WriteLine("Значение вектора на 2 позиции {0}", vector1.GetVectorValue(1));

            vector2.AddVector(vector1);
            Console.WriteLine("Суммирование к вектору vector2 вектора vector1: {0}", vector2);

            vector2.SubtractVector(vector1);
            Console.WriteLine("Вычитание от вектора vector2 вектора vector1: {0}", vector2);

            vector2.MultiplicateVector(3);
            Console.WriteLine("Умножение вектора vector2 на скаляр: {0}", vector2);

            vector2.ReverseVector();
            Console.WriteLine("Обращение вектора vector2: {0}", vector2);
            Console.WriteLine("Длина вектора vector2: {0}", vector2.GetLengthVector());
            Console.WriteLine("Сравнение на равенство векторов vector1 и vector2{0}", vector1.Equals(vector2));
            Console.WriteLine(vector1);
            Console.WriteLine(vector2);
            Console.WriteLine("Суммирование вектора vector2 и вектора vector1: {0}", Vector.AddVector(vector1, vector2));
            Console.WriteLine("Вычитание вектора vector1 и вектора vector2: {0}", Vector.SubtractVector(vector1, vector2));
            Console.WriteLine("Умножение вектора vector2 и вектора vector1: {0}", Vector.MultiplicateVector(vector1, vector2));

            Console.ReadLine();
        }
    }
}
