namespace Shapes
{
    public class Rectangle : IShape
    {
        private readonly double width;
        private readonly double height;

        public Rectangle(double widthLength, double heightLength)
        {
            width = widthLength;
            height = heightLength;
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
            return "Прямоугольник " + "c длиной " + width + " и шириной " + height;
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
            Rectangle s = (Rectangle)item;

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
