using System;
using System.Text;
using Vectors;

namespace Matrix
{
    public class Matrix
    {
        private Vector[] strings;

        public Matrix(int dimensionColumn, int dimensionRow)
        {
            if (dimensionColumn <= 0 || dimensionRow <= 0)
            {
                throw new ArgumentException("Размерность должна быть > 0");
            }

            strings = new Vector[dimensionColumn];

            for (int i = 0; i < dimensionColumn; i++)
            {
                strings[i] = new Vector(dimensionRow);
            }
        }

        public Matrix(Matrix matrix)
        {
            int matrixDimensionColumn = matrix.GetDimensionColumn();
            strings = new Vector[matrix.strings.Length];

            for (int i = 0; i < matrixDimensionColumn; i++)
            {
                strings[i] = new Vector(matrix.strings[i]);
            }
        }

        public Matrix(double[,] array)
        {
            if (array.GetLength(0) <= 0 || array.GetLength(1) <= 0)
            {
                throw new ArgumentException("Размерность должна быть > 0");
            }

            strings = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                strings[i] = new Vector(array.GetLength(1));

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    strings[i].SetElement(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] vectors)
        {
            int maxSize = 0;

            foreach (Vector vector in vectors)
            {
                if (maxSize < vector.GetSize())
                {
                    maxSize = vector.GetSize();
                }
            }

            if (maxSize <= 0 || vectors.Length <= 0)
            {
                throw new ArgumentException("Размерность должна быть > 0");
            }

            strings = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                strings[i] = new Vector(maxSize);
                strings[i].Add(vectors[i]);
            }
        }

        public int GetDimensionColumn()
        {
            return strings.Length;
        }

        public int GetDimensionRow()
        {
            return strings[0].GetSize();
        }

        public void SetVector(int index, Vector vector)
        {
            if (index < 0 || index >= this.strings.Length)
            {
                throw new ArgumentException("Индекс вне размеров матрицы");
            }

            this.strings[index] = new Vector(vector);
        }

        public Vector GetVector(int index)
        {
            if (index < 0 || index >= this.strings.GetLength(0))
            {
                throw new ArgumentException("Индекс вне размеров матрицы");
            }

            return new Vector(strings[index]);
        }

        public void Transpose()
        {
            int matrixDimensionColumn = GetDimensionColumn();
            int matrixDimensionRow = GetDimensionRow();

            for (int i = 0; i < matrixDimensionColumn; i++)
            {
                for (int j = i; j < matrixDimensionRow; j++)
                {
                    double temp = this.strings[j].GetElement(i);
                    this.strings[j].SetElement(i, this.strings[i].GetElement(j));
                    this.strings[i].SetElement(j, temp);
                }
            }
        }

        public void MultiplyOnScalar(double scalar)
        {
            foreach (Vector vector in strings)
            {
                vector.MultiplyOnScalar(scalar);
            }
        }

        public Vector MultiplyOnVector(Vector vector)
        {
            int matrixDimensionColumn = GetDimensionColumn();
            int matrixDimensionRow = GetDimensionRow();

            int vectorSize = vector.GetSize();

            if (vectorSize != matrixDimensionRow)
            {
                throw new ArgumentException("Умножение невозможно");
            }

            Vector result = new Vector(matrixDimensionColumn);

            for (int i = 0; i < matrixDimensionColumn; i++)
            {
                result.SetElement(i, Vector.GetScalarMultiplication(strings[i], vector));
            }

            return result;
        }

        public void Add(Matrix matrix)
        {
            int matrixDimensionColumn1 = GetDimensionColumn();
            int matrixDimensionRow1 = GetDimensionRow();
            int matrixDimensionColumn2 = matrix.GetDimensionColumn();
            int matrixDimensionRow2 = matrix.GetDimensionRow();

            if (matrixDimensionColumn1 != matrixDimensionColumn2 || matrixDimensionRow1 != matrixDimensionRow2)
            {
                throw new ArgumentException("Сложение невозможно");
            }

            for (int i = 0; i < matrixDimensionColumn1; i++)
            {
                strings[i].Add(matrix.strings[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            int matrixDimensionColumn1 = GetDimensionColumn();
            int matrixDimensionRow1 = GetDimensionRow();
            int matrixDimensionColumn2 = matrix.GetDimensionColumn();
            int matrixDimensionRow2 = matrix.GetDimensionRow();


            if (matrixDimensionColumn1 != matrixDimensionColumn2 || matrixDimensionRow1 != matrixDimensionRow2)
            {
                throw new ArgumentException("Вычитание невозможно");
            }

            for (int i = 0; i < matrixDimensionColumn1; i++)
            {
                strings[i].Subtract(matrix.strings[i]);
            }
        }

        public double GetDeterminant()
        {
            int matrixDimensionColumn1 = GetDimensionColumn();
            int matrixDimensionRow1 = GetDimensionRow();

            if (matrixDimensionColumn1 != matrixDimensionRow1)
            {
                throw new ArgumentException("Вычислить определитель невожможно");
            }

            double epsilon = 1E-9;
            double temp;
            Matrix determinantMatrix = new Matrix(this.strings);

            for (int k = 1; k < matrixDimensionColumn1; k++)
            {
                if (Math.Abs(determinantMatrix.strings[k - 1].GetElement(k - 1) - 0.0) < epsilon)
                {
                    for (int i = k - 1; i < matrixDimensionColumn1; i++)
                    {
                        if (Math.Abs(determinantMatrix.strings[i].GetElement(k - 1) - 0.0) > epsilon)
                        {
                            for (int j = k - 1; j < matrixDimensionColumn1; j++)
                            {
                                temp = determinantMatrix.strings[k - 1].GetElement(j);
                                determinantMatrix.strings[k - 1].SetElement(j, determinantMatrix.strings[i].GetElement(j));
                                determinantMatrix.strings[i].SetElement(j, temp);
                            }

                            break;
                        }
                    }
                }

                if (Math.Abs(determinantMatrix.strings[k].GetElement(k) - 0.0) > epsilon)
                {
                    for (int j = k; j < matrixDimensionColumn1; j++)
                    {
                        for (int i = k; i < matrixDimensionColumn1; i++)
                        {
                            temp = determinantMatrix.strings[j].GetElement(i) - determinantMatrix.strings[k - 1].GetElement(i)
                            * determinantMatrix.strings[j].GetElement(k - 1) / determinantMatrix.strings[k - 1].GetElement(k - 1);
                            determinantMatrix.strings[j].SetElement(i, temp);
                        }
                    }
                }
            }

            double determinant = 1;

            for (int i = 0; i < matrixDimensionColumn1; i++)
            {
                determinant *= determinantMatrix.strings[i].GetElement(i);
            }

            return determinant;
        }

        public override string ToString()
        {
            StringBuilder matrixString = new StringBuilder("{");

            foreach (Vector vector in strings)
            {
                matrixString.AppendFormat("{0}, ", vector.ToString());
            }

            matrixString = matrixString.Remove(matrixString.Length - 2, 2);
            matrixString.Append("}");

            return matrixString.ToString();
        }

        public static Matrix GetMatrixSum(Matrix matrix1, Matrix matrix2)
        {
            int matrixDimensionColumn1 = matrix1.GetDimensionColumn();
            int matrixDimensionRow1 = matrix1.GetDimensionRow();
            int matrixDimensionColumn2 = matrix2.GetDimensionColumn();
            int matrixDimensionRow2 = matrix2.GetDimensionRow();

            if (matrixDimensionColumn1 != matrixDimensionColumn2 || matrixDimensionRow1 != matrixDimensionRow2)
            {
                throw new ArgumentException("Сложение невозможно");
            }

            Matrix resultMatrix = new Matrix(matrixDimensionColumn1, matrixDimensionRow1);

            resultMatrix.Add(matrix1);
            resultMatrix.Add(matrix2);

            return resultMatrix;
        }

        public static Matrix GetMatrixDifference(Matrix matrix1, Matrix matrix2)
        {
            int matrixDimensionColumn1 = matrix1.GetDimensionColumn();
            int matrixDimensionRow1 = matrix1.GetDimensionRow();
            int matrixDimensionColumn2 = matrix2.GetDimensionColumn();
            int matrixDimensionRow2 = matrix2.GetDimensionRow();

            if (matrixDimensionColumn1 != matrixDimensionColumn2 || matrixDimensionRow1 != matrixDimensionRow2)
            {
                throw new ArgumentException("Вычитание невозможно");
            }

            Matrix resultMatrix = new Matrix(matrixDimensionColumn1, matrixDimensionRow1);

            resultMatrix.Add(matrix1);
            resultMatrix.Subtract(matrix2);

            return resultMatrix;
        }

        public static Matrix GetMatrixMultiplication(Matrix matrix1, Matrix matrix2)
        {
            int matrixDimensionColumn1 = matrix1.GetDimensionColumn();
            int matrixDimensionRow1 = matrix1.GetDimensionRow();
            int matrixDimensionColumn2 = matrix2.GetDimensionColumn();
            int matrixDimensionRow2 = matrix2.GetDimensionRow();

            if (matrixDimensionRow1 != matrixDimensionColumn2)
            {
                throw new ArgumentException("Умножение невозможно");
            }

            Matrix resultMatrix = new Matrix(matrixDimensionRow1, matrixDimensionColumn2);

            for (int i = 0; i < matrixDimensionColumn1; i++)
            {
                for (int j = 0; j < matrixDimensionRow2; j++)
                {
                    double temp = 0;

                    for (int k = 0; k < matrixDimensionRow1; k++)
                    {
                        temp += matrix1.strings[i].GetElement(k) * matrix2.strings[k].GetElement(j);
                    }

                    resultMatrix.strings[i].SetElement(j, temp);
                }
            }

            return resultMatrix;
        }
    }
}
