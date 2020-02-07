using System;

namespace Shapes
{
    class Shape
    {
        public static IShape SortAreaShape(IShape[] shape)
        {
            Array.Sort(shape, new ShapeAreaComparer());

            return shape[0];
        }

        public static IShape SortPerimeterShape(IShape[] shape)
        {
            Array.Sort(shape, new ShapePerimeterComparer());

            return shape[1];
        }

        static void Main()
        {
            IShape[] Shape = { new Square(5.0), new Square(2.4), new Triangle(1, 1, 2, 1, 4, 4), new Triangle(1, 1, 2, 2, 1.5, 3), new Rectangle(2.0, 7.0), new Rectangle(4.0, 3.0), new Circle(4.0), new Circle(1.0) };

            IShape maxAreaShape = SortAreaShape(Shape);
            IShape secondPerimeterShape = SortPerimeterShape(Shape);
            Console.WriteLine("Фигура с максимальной площадью это {0} с высотой {1:0.##}, шириной {2:0.##}, площадью {3:0.##} и периметром {4:0.##}", maxAreaShape.ToString(), maxAreaShape.GetHeight(), maxAreaShape.GetWidth(), maxAreaShape.GetArea(), maxAreaShape.GetPerimeter());
            Console.WriteLine("Фигура со вторым по величине периметром это {0} с высотой {1:0.##}, шириной {2:0.##}, площадью {3:0.##} и периметром {4:0.##}", secondPerimeterShape.ToString(), secondPerimeterShape.GetHeight(), secondPerimeterShape.GetWidth(), secondPerimeterShape.GetArea(), secondPerimeterShape.GetPerimeter());

            Console.ReadLine();
        }
    }
}
