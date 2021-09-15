using System;

namespace GeometryLibrary
{
    public class Circle : GeometryShape
    {
        public double Radius { get; private set; }

        /// <summary>
        /// Создаёт объект типа "круг".
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Возникает при попытке создания круга с радиусом, 
        /// равным или меньше нуля.</exception>
        /// <param name="radius">Радиус круга.</param>
        public Circle(double radius)
        {
            if (radius <= 0)
            {
                throw new ArgumentOutOfRangeException("Радиус круга должен быть больше нуля.");
            }

            Radius = radius;
        }

        /// <summary>
        /// Возвращает площадь данного круга.
        /// </summary>
        public override double CountArea() => Math.PI * Radius * Radius;
    }
}
