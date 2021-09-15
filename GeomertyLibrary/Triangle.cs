using System;

namespace GeometryLibrary
{
    public class Triangle : GeometryShape
    {
        public double A { get; private set; }
        public double B { get; private set; }
        public double C { get; private set; }

        /// <summary>
        /// Создает объект типа "Треугольник".
        /// </summary>
        /// <param name="a">Первая сторона.</param>
        /// <param name="b">Вторая сторона.</param>
        /// <param name="c">Третья сторона.</param>
        public Triangle(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("Значения длин сторон должны быть больше нуля.");
            }

            if (a + b < c || b + c < a || a + c < b)
            {
                throw new ArgumentException(@"Невозможно создать треугольник, так как длина 
                                            одной из сторон больше, чем сумма двух других.");
            }

            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Создаёт треугольник из полигона при условии, что полигон имеет 3 вершины.
        /// </summary>
        /// <exception cref="InvalidCastException">Возникает, если количество вершин в фигуре не равно 3.</exception>
        /// <exception cref="ArgumentException">Возникает, если </exception>
        /// <param name="polygonShape">Полигон, имеющий 3 вершины.</param>
        public Triangle(PolygonShape polygonShape)
        {
            if (polygonShape.vertices.Length != 3)
                throw new InvalidCastException("Для преобразования в треугольник фигура должна состоять из 3 вершин.");

            var a = Math.Sqrt(
                Math.Pow(polygonShape.vertices[1].x - polygonShape.vertices[0].x, 2) +
                Math.Pow(polygonShape.vertices[1].y - polygonShape.vertices[0].y, 2)
                );
            var b = Math.Sqrt(
                Math.Pow(polygonShape.vertices[2].x - polygonShape.vertices[1].x, 2) +
                Math.Pow(polygonShape.vertices[2].y - polygonShape.vertices[1].y, 2)
                );
            var c = Math.Sqrt(
                Math.Pow(polygonShape.vertices[0].x - polygonShape.vertices[2].x, 2) +
                Math.Pow(polygonShape.vertices[0].y - polygonShape.vertices[2].y, 2)
                );

            A = a;
            B = b;
            C = c;
        }

        /// <summary>
        /// Находит площадь треугольника и возвращает её.
        /// </summary>
        public override double CountArea()
        {
            var p = (A + B + C) / 2; //Полупериметр
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }

        /// <summary>
        /// Проверяет, является ли треугольник прямоугольным.
        /// </summary>
        /// <returns>Возвращает true, если треугольник является прямоугольным, и false, если нет.</returns>
        public bool IsRightTriangle()
        {
            //Если сумма квадратов двух сторон равна квадрату третьей - то это прямоугольный треугольник
            //Не забываем проверить все возможные варианты
            if (A * A + B * B == C * C || A * A + C * C == B * B || B * B + C * C == A * A)
                return true;
            else
                return false;
        }
    }
}
