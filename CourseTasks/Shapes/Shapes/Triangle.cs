using System;

namespace Shapes
{
    public class Triangle : IShape
    {
        private readonly double x1;
        private readonly double y1;
        private readonly double x2;
        private readonly double y2;
        private readonly double x3;
        private readonly double y3;

        public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
        {
            this.x1 = x1;
            this.y1 = y1;
            this.x2 = x2;
            this.y2 = y2;
            this.x3 = x3;
            this.y3 = y3;
        }

        public double GetWidth()
        {
            return Math.Max(x1, Math.Max(x2, x3)) - Math.Min(x1, Math.Min(x2, x3));
        }

        public double GetHeight()
        {
            return Math.Max(y1, Math.Max(y2, y3)) - Math.Min(y1, Math.Min(y2, y3));
        }

        public double GetArea()
        {
            return 0.5 * Math.Abs((x1 - x3) * (y2 - y3) - (x2 - x3) * (y1 - y3));
        }

        private static double GetSideLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        public double GetPerimeter()
        {
            return GetSideLength(x1, y1, x2, y2) + GetSideLength(x2, y2, x3, y3) + GetSideLength(x1, y1, x3, y3);
        }

        public override string ToString()
        {
            return string.Format("Треугольник с вершинами в точках: ({0}, {1}), ({2}, {3}), ({4}, {5})", x1, y1, x2, y2, x3, y3);
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

            Triangle s = (Triangle)o;

            return x1 == s.x1 && x2 == s.x2 && x3 == s.x3 && y1 == s.y1 && y2 == s.y2 && y3 == s.y3;
        }

        public override int GetHashCode()
        {
            int prime = 22;
            int hash = 2;
            hash = prime * hash + x1.GetHashCode();
            hash = prime * hash + x2.GetHashCode();
            hash = prime * hash + x3.GetHashCode();
            hash = prime * hash + y1.GetHashCode();
            hash = prime * hash + y2.GetHashCode();
            hash = prime * hash + y3.GetHashCode();

            return hash;
        }
    }
}
