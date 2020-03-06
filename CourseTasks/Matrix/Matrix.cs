using System;
using System.Text;
using Vectors;

namespace Matrix
{
    public class Matrix
    {
        private Vector[] rows;

        public Matrix(int columnCount, int rowCount)
        {
            if (columnCount <= 0)
            {
                throw new ArgumentException("Количество столбцов в матрице должно быть > 0, сейчас равна " + columnCount, "columnCount");
            }

            if (rowCount <= 0)
            {
                throw new ArgumentException("Количество строк в матрице должно быть > 0, сейчас равна " + rowCount, "rowCount");
            }

            rows = new Vector[columnCount];

            for (int i = 0; i < columnCount; i++)
            {
                rows[i] = new Vector(rowCount);
            }
        }

        public Matrix(Matrix matrix)
        {
            rows = new Vector[matrix.GetColumnCount()];

            for (int i = 0; i < matrix.GetColumnCount(); i++)
            {
                rows[i] = new Vector(matrix.rows[i]);
            }
        }

        public Matrix(double[,] array)
        {
            if (array.GetLength(0) <= 0)
            {
                throw new ArgumentException("Количество столбцов в матрице должно быть > 0, сейчас равна " + array.GetLength(0), "array.Columns");
            }

            if (array.GetLength(1) <= 0)
            {
                throw new ArgumentException("Количество строк в матрице должно быть > 0, сейчас равна " + array.GetLength(1), "array.Rows");
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
                throw new ArgumentException("Количество столбцов в матрице должно быть > 0, сейчас равна " + vectors.Length, "vectors.Length");
            }

            if (vectors.Length <= 0)
            {
                throw new ArgumentException("Количество строк в матрице должно быть > 0, сейчас равна " + maxSize, "maxSize");
            }

            rows = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                rows[i] = new Vector(maxSize);
                rows[i].Add(vectors[i]);
            }
        }

        public int GetColumnCount()
        {
            return rows.Length;
        }

        public int GetRowCount()
        {
            return rows[0].GetSize();
        }

        public void SetVector(int index, Vector vector)
        {
            if (index < 0 || index >= rows.Length)
            {
                throw new ArgumentOutOfRangeException("index", "Индекс вне размеров матрицы, должен быть в пределах от 0 до "
                + rows.Length + " , сейчас он равен" + index);
            }

            rows[index] = new Vector(vector);
        }

        public Vector GetVector(int index)
        {
            if (index < 0 || index >= rows.GetLength(0))
            {
                throw new ArgumentOutOfRangeException("index", "Индекс вне размеров матрицы, должен быть в пределах от 0 до "
                + rows.GetLength(0) + " , сейчас он равен" + index);
            }

            return new Vector(rows[index]);
        }

        public void Transpose()
        {
            double[,] array = new double[GetRowCount(), GetColumnCount()];

            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = rows[j].GetElement(i);
                }
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

        public void MultiplyOnScalar(double scalar)
        {
            foreach (Vector vector in rows)
            {
                vector.MultiplyByScalar(scalar);
            }
        }

        public Vector MultiplyOnVector(Vector vector)
        {
            if (vector.GetSize() != GetRowCount())
            {
                throw new ArgumentException("Умножение невозможно, размерность вектора не равна размерности строк матрицы, сейчас равна " 
                + vector.GetSize(), "vector.Size");
            }

            Vector result = new Vector(GetColumnCount());

            for (int i = 0; i < GetColumnCount(); i++)
            {
                result.SetElement(i, Vector.GetScalarMultiplication(rows[i], vector));
            }

            return result;
        }

        public void Add(Matrix matrix)
        {
            if (GetColumnCount() != matrix.GetColumnCount())
            {
                throw new ArgumentException("Сложение невозможно, количество столбцов матриц не совпадает, сейчас размерность равна " 
                + matrix.GetColumnCount(), "matrix.Columns");
            }

            if (GetRowCount() != matrix.GetRowCount())
            {
                throw new ArgumentException("Сложение невозможно, количество строк матриц не совпадает, сейчас размерность равна " 
                + matrix.GetRowCount(), "matrix.Rows");
            }

            for (int i = 0; i < GetColumnCount(); i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Subtract(Matrix matrix)
        {
            if (GetColumnCount() != matrix.GetColumnCount())
            {
                throw new ArgumentException("Вычитание невозможно, количество столбцов матриц не совпадает, сейчас размерность равна "
                + matrix.GetColumnCount(), "matrix.Columns");
            }

            if (GetRowCount() != matrix.GetRowCount())
            {
                throw new ArgumentException("Вычитание невозможно, количество строк матриц не совпадает, сейчас размерность равна "
                + matrix.GetRowCount(), "matrix.Rows");
            }

            for (int i = 0; i < GetColumnCount(); i++)
            {
                rows[i].Subtract(matrix.rows[i]);
            }
        }

        public double GetDeterminant()
        {
            if (GetColumnCount() != GetRowCount())
            {
                throw new ArgumentException("Вычислить определитель невожможно, матрица не квадратная, сейчас строк "
                + GetRowCount() + " столбцов " + GetColumnCount(), "Columns/Rows");
            }

            double epsilon = 1E-9;
            Matrix determinantMatrix = new Matrix(rows);

            for (int k = 1; k < GetColumnCount(); k++)
            {
                if (Math.Abs(determinantMatrix.rows[k - 1].GetElement(k - 1)) < epsilon)
                {
                    for (int i = k - 1; i < GetColumnCount(); i++)
                    {
                        if (Math.Abs(determinantMatrix.rows[i].GetElement(k - 1)) > epsilon)
                        {
                            for (int j = k - 1; j < GetColumnCount(); j++)
                            {
                                double temp = determinantMatrix.rows[k - 1].GetElement(j);
                                determinantMatrix.rows[k - 1].SetElement(j, determinantMatrix.rows[i].GetElement(j));
                                determinantMatrix.rows[i].SetElement(j, temp);
                            }

                            break;
                        }
                    }
                }

                if (Math.Abs(determinantMatrix.rows[k].GetElement(k)) > epsilon)
                {
                    for (int j = k; j < GetColumnCount(); j++)
                    {
                        for (int i = k; i < GetColumnCount(); i++)
                        {
                            double temp = determinantMatrix.rows[j].GetElement(i) - determinantMatrix.rows[k - 1].GetElement(i) 
                            * determinantMatrix.rows[j].GetElement(k - 1) / determinantMatrix.rows[k - 1].GetElement(k - 1);
                            determinantMatrix.rows[j].SetElement(i, temp);
                        }
                    }
                }
            }

            double determinant = 1;

            for (int i = 0; i < GetColumnCount(); i++)
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
                sb.Append(vector + ", ");
            }

            sb = sb.Remove(sb.Length - 2, 2);
            sb.Append("}");

            return sb.ToString();
        }

        public static Matrix GetMatrixSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnCount() != matrix2.GetColumnCount())
            {
                throw new ArgumentException("Сложение невозможно, количество столбцов матриц не совпадает, сейчас количетво столбцов первой матрицы равно " 
                + matrix1.GetColumnCount() + " второй " + matrix2.GetColumnCount(), "Columns");
            }

            if (matrix1.GetRowCount() != matrix2.GetRowCount())
            {
                throw new ArgumentException("Сложение невозможно, количество строк матриц не совпадает, сейчас количетво строк первой матрицы равно "
                + matrix1.GetRowCount() + " второй " + matrix2.GetRowCount(), "Rows");
            }

            Matrix resultMatrix = new Matrix(matrix1.GetColumnCount(), matrix1.GetRowCount());

            resultMatrix.Add(matrix1);
            resultMatrix.Add(matrix2);

            return resultMatrix;
        }

        public static Matrix GetMatrixDifference(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnCount() != matrix2.GetColumnCount())
            {
                throw new ArgumentException("Вычитание невозможно, количество столбцов матриц не совпадает, сейчас количетво столбцов первой матрицы равно "
                + matrix1.GetColumnCount() + " второй " + matrix2.GetColumnCount(), "Columns");
            }

            if (matrix1.GetRowCount() != matrix2.GetRowCount())
            {
                throw new ArgumentException("Вычитание невозможно, количество строк матриц не совпадает, сейчас количетво строк первой матрицы равно " 
                + matrix1.GetRowCount() + " второй " + matrix2.GetRowCount(), "Rows");
            }

            Matrix resultMatrix = new Matrix(matrix1.GetColumnCount(), matrix1.GetRowCount());

            resultMatrix.Add(matrix1);
            resultMatrix.Subtract(matrix2);

            return resultMatrix;
        }

        public static Matrix GetMatrixMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetRowCount() != matrix2.GetColumnCount())
            {
                throw new ArgumentException("Умножение невозможно, количество строк матрицы 1 не равно количеству столбцов матрицы 2, сейчас количество строк матрицы 1 равно " 
                + matrix1.GetRowCount() + " сейчас количество столбцов матрицы 2 равно" + matrix2.GetColumnCount(), "matrix1.Rows/matrix2.Columns");
            }

            Matrix resultMatrix = new Matrix(matrix1.GetColumnCount(), matrix2.GetRowCount());

            for (int i = 0; i < matrix1.GetColumnCount(); i++)
            {
                for (int j = 0; j < matrix2.GetRowCount(); j++)
                {
                    double temp = 0;

                    for (int k = 0; k < matrix1.GetRowCount(); k++)
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
