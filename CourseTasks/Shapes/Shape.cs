using System;
using Shapes.Comparers;
using Shapes.BasicShapes;

namespace Shapes
{
    class Program
    {
        public static IShape GetMaxShapeArea(IShape[] shapes)
        {
            Array.Sort(shapes, new ShapeAreaComparer());
            return shapes[0];
        }

        public static IShape GetSecondShapePerimeter(IShape[] shapes)
        {
            Array.Sort(shapes, new ShapePerimeterComparer());
            return shapes[1];
        }

        static void Main()
        {
            IShape[] shapes = { new Square(5.0), new Square(2.4), new Triangle(1, 1, 2, 1, 4, 4), new Triangle(1, 1, 2, 2, 1.5, 3),
                new Rectangle(2.0, 7.0), new Rectangle(4.0, 3.0), new Circle(4.0), new Circle(1.0) };

            IShape maxAreaShape = GetMaxShapeArea(shapes);
            IShape secondPerimeterShape = GetSecondShapePerimeter(shapes);

            Console.WriteLine("Фигура с максимальой площадью это - {0}, с высотой {1:0.##}, шириной {2:0.##}, площадью {3:0.##} и периметром {4:0.##}",
                maxAreaShape, maxAreaShape.GetHeight(), maxAreaShape.GetWidth(), maxAreaShape.GetArea(), maxAreaShape.GetPerimeter());

            Console.WriteLine("Фигура с вторым по величине периметром это - {0}, с высотой {1:0.##}, шириной {2:0.##}, площадью {3:0.##} и периметром {4:0.##}",
                secondPerimeterShape, secondPerimeterShape.GetHeight(), secondPerimeterShape.GetWidth(), secondPerimeterShape.GetArea(), secondPerimeterShape.GetPerimeter());

            Console.ReadLine();
        }
    }
}
