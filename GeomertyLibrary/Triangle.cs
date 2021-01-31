using System;

namespace GeometryLibrary
{
    public class Triangle : GeometryShape
    {
        private double a, b, c;

        /// <summary>
        /// Создает объект типа "Треугольник"
        /// </summary>
        /// <param name="a">Первая сторона</param>
        /// <param name="b">Вторая сторона</param>
        /// <param name="c">Третья сторона</param>
        public Triangle(double a, double b, double c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        /// <summary>
        /// Находит площадь треугольника и возвращает её.
        /// </summary>
        public override double CountArea()
        {
            return CountArea(a, b, c);
        }

        /// <summary>
        /// Проверяет, является ли треугольник прямоугольным.
        /// </summary>
        /// <returns>Возвращает true, если треугольник является прямоугольным, и false, если нет.</returns>
        public bool IsRightTriangle()
        {
            //Если сумма квадратов двух сторон равна квадрату третьей - то это прямоугольный треугольник
            //Не забываем проверить все возможные варианты
            if (a * a + b * b == c * c || a * a + c * c == b * b || b * b + c * c == a * a)
                return true;
            else
                return false;

        }

        /// <summary>
        /// Находит площадь треугольника и возвращает её.
        /// </summary>
        /// <param name="a">Первая сторона</param>
        /// <param name="b">Вторая сторона</param>
        /// <param name="c">Третья сторона</param>
        public static double CountArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2; //Полупериметр
            return Math.Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
