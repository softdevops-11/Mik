﻿using System;
using Vectors;

namespace Matrix
{
    internal class ProgramMatrix
    {
        private static void Main(string[] args)
        {
            Matrix matrix1 = new Matrix(5, 6);

            double[,] a = { { 1, 2, 3, 4 }, { 5, 6, 7, 8 }, { 9, 10, 11, 12 }, { 13, 14, 15, 16 } };
            double[,] b = { { 1, 2, 1, 1 }, { 2, 1, 3, 1 }, { 3, 1, 1, 4 }, { 4, 7, 1, 5 } };
            double[,] c = { { 1, 0, 0, 0 }, { 0, 2, 0, 0 }, { 0, 0, 3, 0 }, { 0, 0, 0, 4 } };
            double[,] f = { { 0, 2, 0, 0 }, { 1, 0, 0, 0 }, { 0, 0, 3, 0 }, { 0, 0, 0, 4 } };
            double[] vector = { 1, 2, 1, 1 };
            double[] vector1 = { 1, 2 };
            double[] vector2 = { 1, 3, 1, 1 };
            double[] vector3 = { 4, 2, 1 };
            double[] vector4 = { 6, 2, 1, 1 };

            Vector[] vectorArray = new Vector[4];
            vectorArray[0] = new Vector(vector1);
            vectorArray[1] = new Vector(vector2);
            vectorArray[2] = new Vector(vector3);
            vectorArray[3] = new Vector(vector4);

            Matrix matrix7 = new Matrix(vectorArray);
            Matrix matrix2 = new Matrix(a);
            Matrix matrix3 = new Matrix(b);
            Matrix matrix4 = new Matrix(c);
            Matrix matrix5 = new Matrix(f);
            Matrix matrix6 = new Matrix(matrix7);
            Console.WriteLine(matrix2);

            matrix2.SetVector(0, new Vector(vector));
            Console.WriteLine("Первая сторка матрицы : {0}", matrix2.GetRowVector(0));
            Console.WriteLine("Первый столбец матрицы : {0}", matrix2.GetColumnVector(0));

            matrix2.Transpose();
            Console.WriteLine("Транспонирование матрицы: {0}", matrix2);

            matrix3.MultiplyOnScalar(5);
            Console.WriteLine("Произведение матрицы на скаляр: {0}", matrix3);
            Console.WriteLine("Произведение матрицы на вектор: {0}", matrix3.MultiplyOnVector(new Vector(vector)));

            matrix2.Add(matrix4);
            Console.WriteLine("Сумма матриц: {0}", matrix2);

            matrix2.Substract(matrix4);
            Console.WriteLine("Разность матриц: {0}", matrix2);
            Console.WriteLine("Определитель матрицы: {0}", matrix3.GetDeterminant());
            Console.WriteLine("Сумма матриц: {0}", Matrix.GetMatrixSum(matrix2, matrix4));
            Console.WriteLine("Разность матриц: {0}", Matrix.GetMatrixDifference(matrix2, matrix4));
            Console.WriteLine("Произведение матриц: {0}", Matrix.GetMatrixMultiplication(matrix2, matrix4));

            Console.ReadLine();
        }
    }
}
