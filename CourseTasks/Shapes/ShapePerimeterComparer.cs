using System.Collections.Generic;

namespace Shapes
{
    internal class ShapePerimeterComparer : IComparer<IShape>
    {
        public int Compare(IShape shape1, IShape shape2)
        {
            if ((ReferenceEquals(shape1, null)))
            {
                return 1;
            }

            if ((ReferenceEquals(shape2, null)))
            {
                return -1;
            }

            return shape2.GetPerimeter().CompareTo(shape1.GetPerimeter());
        }
    }
}
