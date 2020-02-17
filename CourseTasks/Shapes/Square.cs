namespace Shapes
{
    public class Square : IShape
    {
        private readonly double sideLength;

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
            return "Квадрат " + "со стороной " + sideLength;
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
            Square s = (Square)item;

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
}
