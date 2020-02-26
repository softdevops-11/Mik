using System;

namespace Shapes
{
    public class Rectangle : IShape
    {
        private readonly double width;
        private readonly double height;

        public Rectangle(double widthLength, double heightLength)
        {
            this.width = widthLength;
            this.height = heightLength;
        }

        public double GetWidth()
        {
            return width;
        }

        public double GetHeight()
        {
            return height;
        }

        public double GetArea()
        {
            return height * width;
        }

        public double GetPerimeter()
        {
            return 2.0 * (width + height);
        }

        public override string ToString()
        {
            return string.Format("Прямоугольник c длиной {0} и шириной {1}", width, height);
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

            Rectangle s = (Rectangle)o;

            return width == s.width && height == s.height;
        }

        public override int GetHashCode()
        {
            int prime = 32;
            int hash = 3;
            hash = prime * hash + width.GetHashCode();
            hash = prime * hash + height.GetHashCode();

            return hash;
        }
    }
}
