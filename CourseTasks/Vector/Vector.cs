using System;

namespace Vector
{
    class Vector
    {
        private double[] vector;

        public Vector(int n)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность должна быть > 0");
            }

            this.vector = new double[n];

            for (int i = 0; i < n; i++)
            {
                this.vector[i] = 0.0;
            }
        }

        public Vector(Vector vector)
        {
            this.vector = vector.vector;
        }

        public Vector(double[] vector)
        {
            this.vector = vector;
        }

        public Vector(int n, double[] vector)
        {
            if (n <= 0)
            {
                throw new ArgumentException("Размерность должна быть > 0");
            }

            this.vector = new double[n];

            for (int i = 0; i < n; i++)
            {
                if (i <= vector.Length - 1)
                {
                    this.vector[i] = vector[i];
                }
                else
                {
                    this.vector[i] = 0.0;
                }
            }
        }

        public int GetSize()
        {
            return vector.Length;
        }

        public override string ToString()
        {
            string stringVector = "{";

            for (int i = 0; i < GetSize(); i++)
            {
                stringVector += GetVectorValue(i) + ", ";
            }
            stringVector = stringVector.Remove(stringVector.Length - 2, 2);
            stringVector += "}";

            return stringVector;
        }

        public double[] AddVector(Vector vector)
        {
            if (this.vector.Length < vector.GetSize())
            {
                Array.Resize(ref this.vector, vector.GetSize());
            }

            for (int i = 0; i < vector.vector.Length; i++)
            {
                this.vector[i] = this.vector[i] + vector.vector[i];
            }

            return this.vector;
        }

        public double[] SubtractVector(Vector vector)
        {
            if (this.vector.Length < vector.GetSize())
            {
                Array.Resize(ref this.vector, vector.GetSize());
            }

            for (int i = 0; i < vector.vector.Length; i++)
            {
                this.vector[i] = this.vector[i] - vector.vector[i];
            }

            return this.vector;
        }

        public double[] MultiplicateVector(double scalar)
        {
            for (int i = 0; i < this.vector.Length; i++)
            {
                this.vector[i] = this.vector[i] * scalar;
            }

            return this.vector;
        }

        public double[] ReverseVector()
        {
            for (int i = 0; i < this.vector.Length; i++)
            {
                this.vector[i] = this.vector[i] * (-1);
            }

            return this.vector;
        }

        public double GetLengthVector()
        {
            double lenghtVector = 0;

            for (int i = 0; i < this.vector.Length; i++)
            {
                lenghtVector = lenghtVector + Math.Pow(this.vector[i], 2);
            }

            return Math.Sqrt(lenghtVector);
        }

        public void SetVectorValue(int index, double value)
        {
            this.vector[index] = value;
        }

        public double GetVectorValue(int index)
        {
            return this.vector[index];
        }

        public override bool Equals(object component)
        {
            if (ReferenceEquals(component, this))
            {
                return true;
            }

            if (ReferenceEquals(component, null) || component.GetType() != this.GetType())
            {
                return false;
            }
            Vector v = (Vector)component;

            return this.vector == v.vector && this.vector.Length == v.vector.Length;
        }

        public override int GetHashCode()
        {
            int prime = 11;
            int hash = 1;
            for (int i = 0; i < this.vector.Length; i++)
            hash = prime * hash + this.vector[i].GetHashCode();

            return hash;
        }

        public static Vector AddVector(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1.GetSize(), vector1.vector);
            resultVector.AddVector(vector2);

            return resultVector;
        }

        public static Vector SubtractVector(Vector vector1, Vector vector2)
        {
            Vector resultVector = new Vector(vector1.GetSize(), vector1.vector);
            resultVector.SubtractVector(vector2);

            return resultVector;
        }

        public static double MultiplicateVector(Vector vector1, Vector vector2)
        {
            int resultSize = 0;

            if (vector1.GetSize() > vector2.GetSize())
            {
                resultSize = vector2.GetSize();
            }
            else
            {
                resultSize = vector1.GetSize();
            }

            double result = 0.0;

            for (int i = 0; i < resultSize; i++)
            {
                result = result + vector1.vector[i] * vector2.vector[i];
            }

            return result;
        }
    }
}
