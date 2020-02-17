using System;

using System.Text;

namespace Matrix
{
    internal class Matrix
    {
        private Vector[] vector;

        public Matrix(int dimension1, int dimension2)
        {
            if (dimension1 <= 0 || dimension2 <= 0)
            {
                throw new ArgumentException("Размерность должна быть > 0");
            }

            Array.Resize(ref vector, dimension1);

            for (int i = 0; i < dimension1; i++)
            {
                vector[i] = new Vector(dimension2);
            }
        }

        public Matrix(Matrix matrix)
        {
            Array.Resize(ref vector, matrix.vector.Length);
            Array.Copy(matrix.vector, vector, vector.Length);
        }

        public Matrix(double[,] massive)
        {
            if (massive.GetLength(0) <= 0 || massive.GetLength(1) <= 0)
            {
                throw new ArgumentException("Размерность должна быть > 0");
            }

            Array.Resize(ref vector, massive.GetLength(0));

            for (int i = 0; i < massive.GetLength(0); i++)
            {
                vector[i] = new Vector(massive.GetLength(1));

                for (int j = 0; j < massive.GetLength(1); j++)
                {
                    vector[i].SetElement(j, massive[i, j]);
                }
            }
        }

        public Matrix(Vector[] vector)
        {
            int maxSize = 0;

            for (int i = 0; i < vector.Length; i++)
            {

                if (maxSize < vector[i].GetSize())
                {
                    maxSize = vector[i].GetSize();
                }
            }

            if (maxSize <= 0 || vector.Length <= 0)
            {
                throw new ArgumentException("Размерность должна быть >0");
            }

            Array.Resize(ref this.vector, vector.Length);

            for (int i = 0; i < vector.Length; i++)
            {

                this.vector[i] = new Vector(maxSize);

                for (int j = 0; j < vector[i].GetSize(); j++)
                {
                    this.vector[i].SetElement(j, vector[i].GetElement(j));
                }
            }
        }

        public int[] GetSize()
        {
            int[] matrixDimension = new int[2];
            matrixDimension[0] = vector.Length;
            matrixDimension[1] = vector[0].GetSize();

            return matrixDimension;
        }

        public void SetVector(int index, Vector vector)
        {
            if (index < 0 || index >= this.vector.Length)
            {
                throw new ArgumentException("Индекс вне размеров матрицы");
            }

            this.vector[index] = new Vector(vector);
        }

        public Vector GetVector(int index)
        {
            if (index < 0 || index >= vector.GetLength(0))
            {
                throw new ArgumentException("Индекс вне размеров матрицы");
            }

            return vector[index];
        }

        public void Transpose()
        {
            int[] matrixSize = GetSize();

            Matrix transposeMatrix = new Matrix(matrixSize[1], matrixSize[0]);

            for (int i = 0; i < matrixSize[0]; i++)
            {
                for (int j = 0; j < matrixSize[1]; j++)
                {
                    transposeMatrix.vector[j].SetElement(i, vector[i].GetElement(j));
                }
            }

            vector = transposeMatrix.vector;
        }

        public void MultiplyOnScalar(double scalar)
        {
            int[] matrixSize = GetSize();

            for (int i = 0; i < matrixSize[0]; i++)
            {
                vector[i].MultiplyOnScalar(scalar);
            }
        }

        public Vector MultiplyOnVector(Vector vector)
        {
            int[] matrixSize = GetSize();
            int vectorSize = vector.GetSize();

            if (vectorSize != matrixSize[1])
            {
                throw new ArgumentException("Умножение невозможно");
            }

            Vector result = new Vector(matrixSize[0]);
            double temp = 0;

            for (int i = 0; i < matrixSize[0]; i++)
            {
                temp = 0;

                for (int j = 0; j < matrixSize[1]; j++)
                {
                    temp += this.vector[i].GetElement(j) * vector.GetElement(j);
                }

                result.SetElement(i, temp);
            }

            return result;
        }

        public void Add(Matrix matrix)
        {
            int[] matrixSize1 = GetSize();
            int[] matrixSize2 = matrix.GetSize();

            if (matrixSize1[0] != matrixSize2[0] || matrixSize1[1] != matrixSize2[1])
            {
                throw new ArgumentException("Сложение невозможно");
            }

            for (int i = 0; i < matrixSize1[0]; i++)
            {
                for (int j = 0; j < matrixSize1[1]; j++)
                {
                    vector[i].SetElement(j, vector[i].GetElement(j) + matrix.vector[i].GetElement(j));
                }
            }
        }

        public void Subtract(Matrix matrix)
        {
            int[] matrixSize1 = GetSize();
            int[] matrixSize2 = matrix.GetSize();

            if (matrixSize1[0] != matrixSize2[0] || matrixSize1[1] != matrixSize2[1])
            {
                throw new ArgumentException("Вычитание невозможно");
            }

            for (int i = 0; i < matrixSize1[0]; i++)
            {
                for (int j = 0; j < matrixSize1[1]; j++)
                {
                    vector[i].SetElement(j, vector[i].GetElement(j) - matrix.vector[i].GetElement(j));
                }
            }
        }

        public double GetDeterminant()
        {
            int[] matrixSize = GetSize();

            if (matrixSize[0] != matrixSize[1])
            {
                throw new ArgumentException("Вычислить определитель невожможно");
            }

            double epsilon = 1E-9;
            double temp;
            Matrix determinantMatrix = new Matrix(vector);

            for (int k = 1; k < matrixSize[0]; k++)
            {
                if (Math.Abs(determinantMatrix.vector[k - 1].GetElement(k - 1) - 0.0) < epsilon)
                {
                    for (int i = k - 1; i < matrixSize[0]; i++)
                    {
                        if (Math.Abs(determinantMatrix.vector[i].GetElement(k - 1) - 0.0) > epsilon)
                        {
                            for (int j = k - 1; j < matrixSize[0]; j++)
                            {
                                temp = determinantMatrix.vector[k - 1].GetElement(j);
                                determinantMatrix.vector[k - 1].SetElement(j, determinantMatrix.vector[i].GetElement(j));
                                determinantMatrix.vector[i].SetElement(j, temp);
                            }

                            break;
                        }
                    }
                }

                if (Math.Abs(determinantMatrix.vector[k].GetElement(k) - 0.0) > epsilon)
                {
                    for (int j = k; j < matrixSize[0]; j++)
                    {
                        for (int i = k; i < matrixSize[0]; i++)
                        {
                            temp = determinantMatrix.vector[j].GetElement(i) - determinantMatrix.vector[k - 1].GetElement(i)
                            * determinantMatrix.vector[j].GetElement(k - 1) / determinantMatrix.vector[k - 1].GetElement(k - 1);
                            determinantMatrix.vector[j].SetElement(i, temp);
                        }
                    }
                }
            }

            double determinant = 1;

            for (int i = 0; i < matrixSize[0]; i++)
            {
                determinant *= determinantMatrix.vector[i].GetElement(i);
            }

            return determinant;
        }

        public override string ToString()
        {

            int[] matrixSize = GetSize();
            StringBuilder matrixString = new StringBuilder("{");

            for (int i = 0; i < matrixSize[0]; i++)
            {
                matrixString.Append("{");

                for (int j = 0; j < matrixSize[1]; j++)
                {
                    matrixString.AppendFormat("{0}, ", vector[i].GetElement(j).ToString());
                }

                matrixString = matrixString.Remove(matrixString.Length - 2, 2);
                matrixString.Append("}, ");
            }

            matrixString = matrixString.Remove(matrixString.Length - 2, 2);
            matrixString.Append("}");

            return matrixString.ToString();
        }

        public static Matrix GetSumMatrix(Matrix matrix1, Matrix matrix2)
        {
            int[] matrixSize1 = matrix1.GetSize();
            int[] matrixSize2 = matrix2.GetSize();

            if (matrixSize1[0] != matrixSize2[0] || matrixSize1[1] != matrixSize2[1])
            {
                throw new ArgumentException("Сложение невозможно");
            }

            Matrix resultMatrix = new Matrix(matrixSize1[0], matrixSize1[1]);

            resultMatrix.Add(matrix1);
            resultMatrix.Add(matrix2);

            return resultMatrix;
        }

        public static Matrix GetDifferenceMatrix(Matrix matrix1, Matrix matrix2)
        {
            int[] matrixSize1 = matrix1.GetSize();
            int[] matrixSize2 = matrix2.GetSize();

            if (matrixSize1[0] != matrixSize2[0] || matrixSize1[1] != matrixSize2[1])
            {
                throw new ArgumentException("Вычитание невозможно");
            }

            Matrix resultMatrix = new Matrix(matrixSize1[0], matrixSize1[1]);

            resultMatrix.Subtract(matrix1);
            resultMatrix.Subtract(matrix2);

            return resultMatrix;
        }

        public static Matrix GetMultiplicatioMatrix(Matrix matrix1, Matrix matrix2)
        {
            int[] matrixSize1 = matrix1.GetSize();
            int[] matrixSize2 = matrix2.GetSize();

            if (matrixSize1[1] != matrixSize2[0])
            {
                throw new ArgumentException("Умножение невозможно");
            }

            Matrix resultMatrix = new Matrix(matrixSize1[1], matrixSize2[0]);

            double temp = 0;

            for (int i = 0; i < matrixSize1[0]; i++)
            {
                for (int j = 0; j < matrixSize2[1]; j++)
                {
                    temp = 0;

                    for (int k = 0; k < matrixSize1[1]; k++)
                    {
                        temp = temp + matrix1.vector[i].GetElement(k) * matrix2.vector[k].GetElement(j);
                    }

                    resultMatrix.vector[i].SetElement(j, temp);
                }
            }

            return resultMatrix;
        }
    }
}
