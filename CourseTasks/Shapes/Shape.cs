using System;

namespace Shapes
{
    public interface IShape
    {
        double GetWidth();
        double GetHeight();
        double GetArea();
        double GetPerimeter();
    }

    public class Square : IShape
    {
        private double sideLength;

        public Square(double sideLength)
        {
            this.sideLength = sideLength;
        }

        public double GetWidth()
        {
            return sideLength;
        }

        public double GetHeight()
        {
            return sideLength;
        }

        public double GetArea()
        {
            return sideLength * sideLength;
        }

        public double GetPerimeter()
        {
            return 4.0 * sideLength;
        }

        public override string ToString()
        {
            return "Квадрат";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Square s = (Square)obj;

            return sideLength == s.sideLength;
        }

        public override int GetHashCode()
        {
            int prime = 12;
            int hash = 1;
            hash = prime * hash + sideLength.GetHashCode();

            return hash;
        }
    }

    public class Triangle : IShape
    {
        private double x1, y1, x2, y2, x3, y3;

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
            return Math.Max(x1, Math.Max(x2, x3));
        }

        public double GetHeight()
        {
            return Math.Max(y1, Math.Max(y2, y3));
        }

        public double GetArea()
        {
            return 1.0 / 2.0 * Math.Abs((x1 - x3) * (y2 - y3) - (x2 - x3) * (y1 - y3));
        }

        public double GetPerimeter()
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2)) + Math.Sqrt(Math.Pow((x2 - x3), 2) + Math.Pow((y2 - y3), 2)) + Math.Sqrt(Math.Pow((x3 - x1), 2) + Math.Pow((y3 - y1), 2));
        }

        public override string ToString()
        {
            return "Треугольник";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Triangle s = (Triangle)obj;

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

    public class Rectangle : IShape
    {
        private double widthLength, heightLength;

        public Rectangle(double widthLength, double heightLength)
        {
            this.widthLength = widthLength;
            this.heightLength = heightLength;
        }

        public double GetWidth()
        {
            return widthLength;
        }

        public double GetHeight()
        {
            return heightLength;
        }

        public double GetArea()
        {
            return heightLength * widthLength;
        }

        public double GetPerimeter()
        {
            return 2.0 * (widthLength + heightLength);
        }

        public override string ToString()
        {
            return "Прямоугольник";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Rectangle s = (Rectangle)obj;

            return widthLength == s.widthLength && heightLength == s.heightLength;
        }

        public override int GetHashCode()
        {
            int prime = 32;
            int hash = 3;
            hash = prime * hash + widthLength.GetHashCode();
            hash = prime * hash + heightLength.GetHashCode();
            return hash;
        }
    }

    public class Circle : IShape
    {
        private double radius;

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
            return "Окружность";
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, this))
            {
                return true;
            }

            if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
            {
                return false;
            }

            Circle s = (Circle)obj;
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
