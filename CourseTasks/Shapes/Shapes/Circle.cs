using System;

namespace Shapes
{
    public class Circle : IShape
    {
        private readonly double radius;

        public Circle(double radius)
        {
            this.radius = radius;
        }

        public double GetWidth()
        {
            return 2.0 * radius;
        }

        public double GetHeight()
        {
            return 2.0 * radius;
        }

        public double GetArea()
        {
            return Math.PI * Math.Pow(radius, 2);
        }

        public double GetPerimeter()
        {
            return 2.0 * radius * Math.PI;
        }

        public override string ToString()
        {
            return string.Format("Окружность радиуса {0}", radius);
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

            Circle s = (Circle)o;

            return radius == s.radius;
        }

        public override int GetHashCode()
        {
            int prime = 42;
            int hash = 4;
            hash = prime * hash + radius.GetHashCode();

            return hash;
        }
    }
}
