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
            return "Окружность " + "радиуса " + radius;
        }

        public override bool Equals(object item)
        {
            if (ReferenceEquals(item, this))
            {
                return true;
            }

            if (ReferenceEquals(item, null) || item.GetType() != GetType())
            {
                return false;
            }
            Circle s = (Circle)item;

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
