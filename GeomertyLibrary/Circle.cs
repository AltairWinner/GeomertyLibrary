﻿using System;

namespace GeometryLibrary
{
    public class Circle : GeometryShape
    {
        private double radius;


        public Circle(double radius)
        {
            this.radius = radius;
        }

        /// <summary>
        /// Находит площадь круга и возвращает её.
        /// </summary>
        public override double CountArea()
        {
            return CountArea(radius);
        }

        /// <summary>
        /// Находит площадь круга с радиусом radius и возвращает её.
        /// </summary>
        public static double CountArea(double radius)
        {
            return (Math.PI * radius* radius);
        }
    }
}
