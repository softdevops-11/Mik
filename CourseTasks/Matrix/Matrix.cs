using System;
using System.Text;
using Vectors;

namespace Matrix
{
    public class Matrix
    {
        private Vector[] rows;

        public Matrix(int rowsCount, int columnsCount)
        {
            if (columnsCount <= 0)
            {
                throw new ArgumentException("Количество столбцов в матрице должно быть > 0, сейчас равно: "
                    + columnsCount, nameof(columnsCount));
            }

            if (rowsCount <= 0)
            {
                throw new ArgumentException("Количество строк в матрице должно быть > 0, сейчас равно: "
                    + rowsCount, nameof(rowsCount));
            }

            rows = new Vector[rowsCount];

            for (int i = 0; i < rowsCount; i++)
            {
                rows[i] = new Vector(columnsCount);
            }
        }

        public Matrix(Matrix matrix)
        {
            rows = new Vector[matrix.GetRowsCount()];

            for (int i = 0; i < matrix.GetRowsCount(); i++)
            {
                rows[i] = new Vector(matrix.rows[i]);
            }
        }

        public Matrix(double[,] array)
        {
            if (array.GetLength(0) <= 0)
            {
                throw new ArgumentException("Количество строк в матрице должно быть > 0, сейчас равно: "
                    + array.GetLength(0), nameof(array));
            }

            if (array.GetLength(1) <= 0)
            {
                throw new ArgumentException("Количество столбцов в матрице должно быть > 0, сейчас равно: "
                    + array.GetLength(1), nameof(array));
            }

            rows = new Vector[array.GetLength(0)];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                rows[i] = new Vector(array.GetLength(1));

                for (int j = 0; j < array.GetLength(1); j++)
                {
                    rows[i].SetElement(j, array[i, j]);
                }
            }
        }

        public Matrix(Vector[] vectors)
        {
            if (vectors.Length <= 0)
            {
                throw new ArgumentException("Количество строк в векторе должно быть > 0, сейчас равно: "
                    + vectors.Length, nameof(vectors));
            }

            int maxSize = 0;

            foreach (Vector vector in vectors)
            {
                if (maxSize < vector.GetSize())
                {
                    maxSize = vector.GetSize();
                }
            }

            if (maxSize <= 0)
            {
                throw new ArgumentException("Количество строк в векторе должно быть > 0, сейчас равно: "
                    + maxSize, nameof(vectors));
            }

            rows = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                rows[i] = new Vector(maxSize);
                rows[i].Add(vectors[i]);
            }
        }

        internal void Substract(Matrix matrix4)
        {
            throw new NotImplementedException();
        }

        public int GetRowsCount()
        {
            return rows.Length;
        }

        public int GetColumnsCount()
        {
            return rows[0].GetSize();
        }

        public void SetRow(int index, Vector vector)
        {
            if (index < 0 || index >= rows.Length)
            {
                throw new IndexOutOfRangeException("Индекс строки вне размеров матрицы, должен быть в пределах: [0, "
                    + (rows.Length - 1) + "], сейчас он равен: " + index);
            }

            rows[index] = new Vector(vector);
        }

        public Vector GetRow(int index)
        {
            if (index < 0 || index >= rows.Length)
            {
                throw new IndexOutOfRangeException("Индекс строки вне размеров матрицы, должен быть в пределах: [0, "
                    + (rows.Length - 1) + "], сейчас он равен: " + index);
            }

            return new Vector(rows[index]);
        }

        public Vector GetColumn(int index)
        {
            if (index < 0 || index >= GetColumnsCount())
            {
                throw new IndexOutOfRangeException("Индекс столбца вне размеров матрицы, должен быть в пределах: [0, "
                    + (GetColumnsCount() - 1) + "], сейчас он равен: " + index);
            }

            Vector columnVector = new Vector(GetRowsCount());

            for (int i = 0; i < GetRowsCount(); i++)
            {
                columnVector.SetElement(i, rows[i].GetElement(index));
            }

            return columnVector;
        }

        public void Transpose()
        {
            Vector[] vectors = new Vector[GetColumnsCount()];

            for (int i = 0; i < vectors.Length; i++)
            {
                vectors[i] = GetColumn(i);
            }

            rows = vectors;
        }

        public void MultiplyByScalar(double scalar)
        {
            foreach (Vector vector in rows)
            {
                vector.MultiplyByScalar(scalar);
            }
        }

        public Vector MultiplyByVector(Vector vector)
        {
            if (vector.GetSize() != GetColumnsCount())
            {
                throw new ArgumentException("Умножение невозможно, размерность вектора не равна количеству столбцов матрицы, сейчас равна: "
                    + vector.GetSize() + ", а количество столбцов матрицы равно: " + GetColumnsCount(), nameof(vector));
            }

            Vector result = new Vector(GetRowsCount());

            for (int i = 0; i < GetRowsCount(); i++)
            {
                result.SetElement(i, Vector.GetScalarMultiplication(rows[i], vector));
            }

            return result;
        }

        public void Add(Matrix matrix)
        {
            if (GetColumnsCount() != matrix.GetColumnsCount())
            {
                throw new ArgumentException("Сложение невозможно, количество столбцов матриц не совпадает, сейчас количество равно: "
                    + matrix.GetColumnsCount() + ", а количество столбцов исходной матрицы равно: " + GetColumnsCount(), nameof(matrix));
            }

            if (GetRowsCount() != matrix.GetRowsCount())
            {
                throw new ArgumentException("Сложение невозможно, количество строк матриц не совпадает, сейчас количество равно: "
                    + matrix.GetRowsCount() + ", а количество строк исходной матрицы равно: " + GetRowsCount(), nameof(matrix));
            }

            for (int i = 0; i < GetRowsCount(); i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtsract(Matrix matrix)
        {
            if (GetColumnsCount() != matrix.GetColumnsCount())
            {
                throw new ArgumentException("Вычитание невозможно, количество столбцов матриц не совпадает, сейчас количество равно: "
                    + matrix.GetColumnsCount() + ", а количество столбцов исходной матрицы равно: " + GetColumnsCount(), nameof(matrix));
            }

            if (GetRowsCount() != matrix.GetRowsCount())
            {
                throw new ArgumentException("Вычитание невозможно, количество строк матриц не совпадает, сейчас количество равно: "
                    + matrix.GetRowsCount() + ", а количество строк исходной матрицы равно: " + GetRowsCount(), nameof(matrix));
            }

            for (int i = 0; i < GetRowsCount(); i++)
            {
                rows[i].Substract(matrix.rows[i]);
            }
        }

        public double GetDeterminant()
        {
            if (GetColumnsCount() != GetRowsCount())
            {
                throw new ArgumentException("Вычислить определитель невожможно, матрица не квадратная, сейчас строк: "
                    + GetRowsCount() + " столбцов: " + GetColumnsCount());
            }

            double epsilon = 1E-9;
            Matrix determinantMatrix = new Matrix(rows);

            for (int i = 1; i < GetRowsCount(); i++)
            {
                int countZero = 0;

                if (Math.Abs(determinantMatrix.rows[i - 1].GetElement(i - 1)) < epsilon)
                {
                    for (int j = i; j < GetRowsCount(); j++)
                    {
                        if (Math.Abs(determinantMatrix.rows[j].GetElement(i - 1)) > epsilon)
                        {
                            for (int k = i - 1; k < GetRowsCount(); k++)
                            {
                                double temp = determinantMatrix.rows[i - 1].GetElement(k);
                                determinantMatrix.rows[i - 1].SetElement(k, determinantMatrix.rows[j].GetElement(k));
                                determinantMatrix.rows[j].SetElement(k, temp);
                            }

                            break;
                        }

                        countZero++;
                    }
                }

                if (countZero != GetRowsCount() - i)
                {
                    for (int j = i; j < GetRowsCount(); j++)
                    {
                        for (int k = i; k < GetRowsCount(); k++)
                        {
                            double temp = determinantMatrix.rows[j].GetElement(k) - determinantMatrix.rows[i - 1].GetElement(k)
                                * determinantMatrix.rows[j].GetElement(i - 1) / determinantMatrix.rows[i - 1].GetElement(i - 1);
                            determinantMatrix.rows[j].SetElement(k, temp);
                        }
                    }
                }
            }

            double determinant = 1;

            for (int i = 0; i < GetRowsCount(); i++)
            {
                determinant *= determinantMatrix.rows[i].GetElement(i);
            }

            return determinant;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("{");

            foreach (Vector vector in rows)
            {
                sb.Append(vector);
                sb.Append(", ");
            }

            sb = sb.Remove(sb.Length - 2, 2);
            sb.Append("}");

            return sb.ToString();
        }

        public static Matrix GetSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsCount() != matrix2.GetColumnsCount())
            {
                throw new ArgumentException("Сложение невозможно, количество столбцов матриц не совпадает, сейчас количество столбцов первой матрицы равно: "
                    + matrix1.GetColumnsCount() + " второй: " + matrix2.GetColumnsCount(), nameof(matrix1));
            }

            if (matrix1.GetRowsCount() != matrix2.GetRowsCount())
            {
                throw new ArgumentException("Сложение невозможно, количество строк матриц не совпадает, сейчас количество строк первой матрицы равно: "
                    + matrix1.GetRowsCount() + " второй: " + matrix2.GetRowsCount(), nameof(matrix1));
            }

            Matrix resultMatrix = new Matrix(matrix1);
            resultMatrix.Add(matrix2);

            return resultMatrix;
        }

        public static Matrix GetDifference(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsCount() != matrix2.GetColumnsCount())
            {
                throw new ArgumentException("Вычитание невозможно, количество столбцов матриц не совпадает, сейчас количество столбцов первой матрицы равно: "
                    + matrix1.GetColumnsCount() + " второй: " + matrix2.GetColumnsCount(), nameof(matrix1));
            }

            if (matrix1.GetRowsCount() != matrix2.GetRowsCount())
            {
                throw new ArgumentException("Вычитание невозможно, количество строк матриц не совпадает, сейчас количество строк первой матрицы равно: "
                    + matrix1.GetRowsCount() + " второй: " + matrix2.GetRowsCount(), nameof(matrix1));
            }

            Matrix resultMatrix = new Matrix(matrix1);
            resultMatrix.Substract(matrix2);

            return resultMatrix;
        }

        public static Matrix GetMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsCount() != matrix2.GetRowsCount())
            {
                throw new ArgumentException("Умножение невозможно, количество столбцов матрицы 1 не равно количеству строк матрицы 2, сейчас количество столбцов матрицы 1 равно: "
                    + matrix1.GetColumnsCount() + " сейчас количество строк матрицы 2 равно:" + matrix2.GetRowsCount(), nameof(matrix1));
            }

            Matrix resultMatrix = new Matrix(matrix1.GetRowsCount(), matrix2.GetColumnsCount());

            for (int i = 0; i < matrix1.GetRowsCount(); i++)
            {
                for (int j = 0; j < matrix2.GetColumnsCount(); j++)
                {
                    double temp = 0;

                    for (int k = 0; k < matrix1.GetColumnsCount(); k++)
                    {
                        temp += matrix1.rows[i].GetElement(k) * matrix2.rows[k].GetElement(j);
                    }

                    resultMatrix.rows[i].SetElement(j, temp);
                }
            }
            return resultMatrix;
        }
    }
}