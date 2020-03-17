using System;
using System.Text;
using Vectors;

namespace Matrix
{
    public class Matrix
    {
        private Vector[] rows;

        public Matrix(int columnsNumber, int rowsNumber)
        {
            if (columnsNumber <= 0)
            {
                throw new ArgumentException("Количество столбцов в матрице должно быть > 0, сейчас равно: " + columnsNumber, nameof(columnsNumber));
            }

            if (rowsNumber <= 0)
            {
                throw new ArgumentException("Количество строк в матрице должно быть > 0, сейчас равно: " + rowsNumber, nameof(rowsNumber));
            }

            rows = new Vector[columnsNumber];

            for (int i = 0; i < columnsNumber; i++)
            {
                rows[i] = new Vector(rowsNumber);
            }
        }

        public Matrix(Matrix matrix)
        {
            rows = new Vector[matrix.GetColumnsNumber()];

            for (int i = 0; i < matrix.GetColumnsNumber(); i++)
            {
                rows[i] = new Vector(matrix.rows[i]);
            }
        }

        public Matrix(double[,] array)
        {
            if (array.GetLength(0) <= 0)
            {
                throw new ArgumentException("Количество столбцов в матрице должно быть > 0, сейчас равно: "
                    + array.GetLength(0), nameof(array));
            }

            if (array.GetLength(1) <= 0)
            {
                throw new ArgumentException("Количество строк в матрице должно быть > 0, сейчас равно: "
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

            if (vectors.Length <= 0)
            {
                throw new ArgumentException("Количество столбцов в векторе должно быть > 0, сейчас равно: "
                    + vectors.Length, nameof(vectors));
            }

            rows = new Vector[vectors.Length];

            for (int i = 0; i < vectors.Length; i++)
            {
                rows[i] = new Vector(maxSize);
                rows[i].Add(vectors[i]);
            }
        }

        public int GetColumnsNumber()
        {
            return rows.Length;
        }

        public int GetRowsNumber()
        {
            return rows[0].GetSize();
        }

        public void SetVector(int index, Vector vector)
        {
            if (index < 0 || index >= rows.Length)
            {
                throw new IndexOutOfRangeException("Индекс вне размеров матрицы, должен быть в пределах от 0 до " 
                    + rows.Length + " , сейчас он равен: " + index);
            }

            rows[index] = new Vector(vector);
        }

        public Vector GetRowVector(int index)
        {
            if (index < 0 || index >= rows.Length)
            {
                throw new IndexOutOfRangeException("Индекс вне размеров матрицы, должен быть в пределах от 0 до "
                    + rows.Length + " , сейчас он равен: " + index);
            }

            return new Vector(rows[index]);
        }

        public Vector GetColumnVector(int index)
        {
            if (index < 0 || index >= rows.Length)
            {
                throw new IndexOutOfRangeException("Индекс вне размеров матрицы, должен быть в пределах от 0 до "
                    + rows.Length + " , сейчас он равен: " + index);
            }

            Vector columnVector = new Vector(GetColumnsNumber());

            for (int i = 0; i < GetColumnsNumber(); i++)
            {
                for (int j = 0; j < GetRowsNumber(); j++)
                {
                    if (j == index)
                    {
                        columnVector.SetElement(i, rows[i].GetElement(j));
                        break;
                    }
                }
            }

            return columnVector;
        }

        public void Transpose()
        {
            Vector[] vectors = new Vector[GetRowsNumber()];

            for (int i = 0; i < vectors.Length; i++)
            {
                vectors[i] = new Vector(GetColumnsNumber());
            }

            for (int i = 0; i < GetRowsNumber(); i++)
            {
                for (int j = 0; j < GetColumnsNumber(); j++)
                {
                    vectors[i].SetElement(j, rows[j].GetElement(i));
                }
            }

            rows = new Vector[GetRowsNumber()];

            for (int i = 0; i < vectors.Length; i++)
            {
                rows[i] = new Vector(vectors[i]);
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
            if (vector.GetSize() != GetRowsNumber())
            {
                throw new ArgumentException("Умножение невозможно, размерность вектора не равна размерности строк матрицы, сейчас равна: " 
                    + vector.GetSize(), nameof(vector));
            }

            Vector result = new Vector(GetColumnsNumber());

            for (int i = 0; i < GetColumnsNumber(); i++)
            {
                result.SetElement(i, Vector.GetScalarMultiplication(rows[i], vector));
            }

            return result;
        }

        public void Add(Matrix matrix)
        {
            if (GetColumnsNumber() != matrix.GetColumnsNumber())
            {
                throw new ArgumentException("Сложение невозможно, количество столбцов матриц не совпадает, сейчас размерность равно: " 
                    + matrix.GetColumnsNumber(), nameof(matrix));
            }

            if (GetRowsNumber() != matrix.GetRowsNumber())
            {
                throw new ArgumentException("Сложение невозможно, количество строк матриц не совпадает, сейчас размерность равно: "
                    + matrix.GetRowsNumber(), nameof(matrix));
            }

            for (int i = 0; i < GetColumnsNumber(); i++)
            {
                rows[i].Add(matrix.rows[i]);
            }
        }

        public void Substract(Matrix matrix)
        {
            if (GetColumnsNumber() != matrix.GetColumnsNumber())
            {
                throw new ArgumentException("Вычитание невозможно, количество столбцов матриц не совпадает, сейчас размерность равно: "
                    + matrix.GetColumnsNumber(), nameof(matrix));
            }

            if (GetRowsNumber() != matrix.GetRowsNumber())
            {
                throw new ArgumentException("Вычитание невозможно, количество строк матриц не совпадает, сейчас размерность равно: "
                    + matrix.GetRowsNumber(), nameof(matrix));
            }

            for (int i = 0; i < GetColumnsNumber(); i++)
            {
                rows[i].Substract(matrix.rows[i]);
            }
        }

        public double GetDeterminant()
        {
            if (GetColumnsNumber() != GetRowsNumber())
            {
                throw new ArgumentException("Вычислить определитель невожможно, матрица не квадратная, сейчас строк: "
                    + GetRowsNumber() + " столбцов: " + GetColumnsNumber());
            }

            double epsilon = 1E-9;
            Matrix determinantMatrix = new Matrix(rows);

            for (int k = 1; k < GetColumnsNumber(); k++)
            {
                if (Math.Abs(determinantMatrix.rows[k - 1].GetElement(k - 1)) < epsilon)
                {
                    for (int i = k - 1; i < GetColumnsNumber(); i++)
                    {
                        if (Math.Abs(determinantMatrix.rows[i].GetElement(k - 1)) > epsilon)
                        {
                            for (int j = k - 1; j < GetColumnsNumber(); j++)
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
                    for (int j = k; j < GetColumnsNumber(); j++)
                    {
                        for (int i = k; i < GetColumnsNumber(); i++)
                        {
                            double temp = determinantMatrix.rows[j].GetElement(i) - determinantMatrix.rows[k - 1].GetElement(i)
                                * determinantMatrix.rows[j].GetElement(k - 1) / determinantMatrix.rows[k - 1].GetElement(k - 1);
                            determinantMatrix.rows[j].SetElement(i, temp);
                        }
                    }
                }
            }

            double determinant = 1;

            for (int i = 0; i < GetColumnsNumber(); i++)
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

        public static Matrix GetMatrixSum(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsNumber() != matrix2.GetColumnsNumber())
            {
                throw new ArgumentException("Сложение невозможно, количество столбцов матриц не совпадает, сейчас количетво столбцов первой матрицы равно: "
                    + matrix1.GetColumnsNumber() + " второй: " + matrix2.GetColumnsNumber(), nameof(matrix1));
            }

            if (matrix1.GetRowsNumber() != matrix2.GetRowsNumber())
            {
                throw new ArgumentException("Сложение невозможно, количество строк матриц не совпадает, сейчас количетво строк первой матрицы равно: "
                    + matrix1.GetRowsNumber() + " второй: " + matrix2.GetRowsNumber(), nameof(matrix1));
            }

            Matrix resultMatrix = new Matrix(matrix1);
            resultMatrix.Add(matrix2);

            return resultMatrix;
        }

        public static Matrix GetMatrixDifference(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetColumnsNumber() != matrix2.GetColumnsNumber())
            {
                throw new ArgumentException("Вычитание невозможно, количество столбцов матриц не совпадает, сейчас количетво столбцов первой матрицы равно: "
                    + matrix1.GetColumnsNumber() + " второй: " + matrix2.GetColumnsNumber(), nameof(matrix1));
            }

            if (matrix1.GetRowsNumber() != matrix2.GetRowsNumber())
            {
                throw new ArgumentException("Вычитание невозможно, количество строк матриц не совпадает, сейчас количетво строк первой матрицы равно: "
                    + matrix1.GetRowsNumber() + " второй: " + matrix2.GetRowsNumber(), nameof(matrix1));
            }

            Matrix resultMatrix = new Matrix(matrix1);
            resultMatrix.Substract(matrix2);

            return resultMatrix;
        }

        public static Matrix GetMatrixMultiplication(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.GetRowsNumber() != matrix2.GetColumnsNumber())
            {
                throw new ArgumentException("Умножение невозможно, количество строк матрицы 1 не равно количеству столбцов матрицы 2, сейчас количество строк матрицы 1 равно: "
                    + matrix1.GetRowsNumber() + " сейчас количество столбцов матрицы 2 равно:" + matrix2.GetColumnsNumber(), nameof(matrix1));
            }

            Matrix resultMatrix = new Matrix(matrix1.GetColumnsNumber(), matrix2.GetRowsNumber());

            for (int i = 0; i < matrix1.GetColumnsNumber(); i++)
            {
                for (int j = 0; j < matrix2.GetRowsNumber(); j++)
                {
                    double temp = 0;

                    for (int k = 0; k < matrix1.GetRowsNumber(); k++)
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
