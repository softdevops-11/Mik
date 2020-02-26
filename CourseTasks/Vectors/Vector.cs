using System;
using System.Text;
using System.Linq;

namespace Vectors
{
    public class Vector
    {
        private double[] value;

        public Vector(int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("Размерность должна быть > 0");
            }

            Array.Resize(ref value, dimension);
        }

        public Vector(Vector vector)
        {
            Array.Resize(ref value, vector.GetSize());
            Array.Copy(vector.value, value, value.Length);
        }

        public Vector(double[] value)
        {
            if (value.Length <= 0)
            {
                throw new ArgumentException("Размерность должна быть > 0");
            }

            Array.Resize(ref this.value, value.Length);
            Array.Copy(value, this.value, value.Length);
        }

        public Vector(int dimension, double[] value)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("Размерность должна быть > 0");
            }

            Array.Resize(ref this.value, dimension);
            Array.Copy(value, this.value, Math.Min(dimension, value.Length));
        }

        public int GetSize()
        {
            return value.Length;
        }

        public override string ToString()
        {
            StringBuilder vectorString = new StringBuilder("{");

            foreach (double value in this.value)
            {
                vectorString.AppendFormat("{0}, ", value);
            }

            vectorString = vectorString.Remove(vectorString.Length - 2, 2);
            vectorString.Append("}");

            return vectorString.ToString();
        }

        public void Add(Vector vector)
        {
            if (value.Length < vector.GetSize())
            {
                Array.Resize(ref value, vector.GetSize());
            }

            for (int i = 0; i < vector.value.Length; i++)
            {
                value[i] += vector.value[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (value.Length < vector.GetSize())
            {
                Array.Resize(ref value, vector.GetSize());
            }

            for (int i = 0; i < vector.value.Length; i++)
            {
                value[i] -= vector.value[i];
            }
        }

        public void MultiplyOnScalar(double scalar)
        {
            for (int i = 0; i < value.Length; i++)
            {
                value[i] *= scalar;
            }
        }

        public void Reverse()
        {
            for (int i = 0; i < value.Length; i++)
            {
                value[i] *= (-1);
            }
        }

        public double GetLength()
        {
            double vectorLength = 0;

            for (int i = 0; i < value.Length; i++)
            {
                vectorLength += Math.Pow(value[i], 2);
            }

            return Math.Sqrt(vectorLength);
        }

        public void SetElement(int index, double value)
        {
            this.value[index] = value;
        }

        public double GetElement(int index)
        {
            return value[index];
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }

            if (ReferenceEquals(o, null) || o.GetType() != this.GetType())
            {
                return false;
            }

            Vector v = (Vector)o;

            return value.SequenceEqual(v.value) && value.Length == v.value.Length;
        }

        public override int GetHashCode()
        {
            int prime = 11;
            int hash = 1;

            foreach (double value in this.value)
            {
                hash = prime * hash + value.GetHashCode();
            }

            return hash;
        }

        public static Vector GetSumVector(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1.value);
            resultVector.Add(vector2);

            return resultVector;
        }

        public static Vector GetDifferenceVector(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1.value);
            resultVector.Subtract(vector2);

            return resultVector;
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            int minResultSizeVector = Math.Min(vector1.GetSize(), vector2.GetSize());

            double result = 0.0;

            for (int i = 0; i < minResultSizeVector; i++)
            {
                result += vector1.value[i] * vector2.value[i];
            }

            return result;
        }
    }
}
