using System;

namespace GeometryLibrary
{
    public class Circle : GeometryShape
    {
        private double _radius;

        /// <summary>
        /// Создаёт объект типа "круг".
        /// </summary>
        /// <param name="radius">Радиус круга.</param>
        public Circle(double radius)
        {
            _radius = radius;
        }

        /// <summary>
        /// Находит площадь круга и возвращает её.
        /// </summary>
        public override double CountArea()
        {
            return CountArea(_radius);
        }

        /// <summary>
        /// Находит площадь круга с радиусом radius и возвращает её.
        /// </summary>
        public static double CountArea(double radius)
        {
            return (Math.PI * radius * radius);
        }
    }
}