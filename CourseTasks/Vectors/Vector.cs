using System;
using System.Text;
using System.Linq;

namespace Vectors
{
    public class Vector
    {
        private double[] components;

        public Vector(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Размерность должна быть > 0, сейчас равна " + size.ToString(), "size");
            }

            components = new double[size];
        }

        public Vector(Vector vector)
        {
            components = new double[vector.GetSize()];
            Array.Copy(vector.components, components, components.Length);
        }

        public Vector(double[] components)
        {
            if (components.Length <= 0)
            {
                throw new ArgumentException("Размерность должна быть > 0, сейчас равна " + components.Length.ToString(), "components.Length");

            }

            this.components = new double[components.Length];
            Array.Copy(components, this.components, components.Length);
        }

        public Vector(int size, double[] components)
        {
            if (size <= 0)
            {
                throw new ArgumentException("Размерность должна быть > 0, сейчас равна " + size.ToString(), "size");
            }

            this.components = new double[size];
            Array.Copy(components, this.components, Math.Min(size, components.Length));
        }

        public int GetSize()
        {
            return components.Length;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("{");

            foreach (double value in components)
            {
                sb.Append(value + ", ");
            }

            sb = sb.Remove(sb.Length - 2, 2);
            sb.Append("}");

            return sb.ToString();
        }

        public void Add(Vector vector)
        {
            if (components.Length < vector.GetSize())
            {
                Array.Resize(ref components, vector.GetSize());
            }

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] += vector.components[i];
            }
        }

        public void Subtract(Vector vector)
        {
            if (components.Length < vector.GetSize())
            {
                Array.Resize(ref components, vector.GetSize());
            }

            for (int i = 0; i < vector.components.Length; i++)
            {
                components[i] -= vector.components[i];
            }
        }

        public void MultiplyByScalar(double number)
        {
            for (int i = 0; i < components.Length; i++)
            {
                components[i] *= number;
            }
        }

        public void Reverse()
        {
            MultiplyByScalar(-1);
        }

        public double GetLength()
        {
            double module = 0;

            foreach (double value in components)
            {
                module += Math.Pow(value, 2);
            }

            return Math.Sqrt(module);
        }

        public void SetElement(int index, double value)
        {
            components[index] = value;
        }

        public double GetElement(int index)
        {
            return components[index];
        }

        public override bool Equals(object o)
        {
            if (ReferenceEquals(o, this))
            {
                return true;
            }

            if (ReferenceEquals(o, null) || o.GetType() != GetType())
            {
                return false;
            }

            Vector v = (Vector)o;

            return components.Length == v.components.Length && components.SequenceEqual(v.components);
        }

        public override int GetHashCode()
        {
            int prime = 11;
            int hash = 1;

            foreach (double value in components)
            {
                hash = prime * hash + value.GetHashCode();
            }

            return hash;
        }

        public static Vector GetSum(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1.components);
            resultVector.Add(vector2);

            return resultVector;
        }

        public static Vector GetDifference(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1.components);
            resultVector.Subtract(vector2);

            return resultVector;
        }

        public static double GetScalarMultiplication(Vector vector1, Vector vector2)
        {
            int minSize = Math.Min(vector1.GetSize(), vector2.GetSize());

            double result = 0.0;

            for (int i = 0; i < minSize; i++)
            {
                result += vector1.components[i] * vector2.components[i];
            }

            return result;
        }
    }
}
