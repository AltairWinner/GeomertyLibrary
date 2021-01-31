﻿/*
 * По заданию требуется сделать нахождение площади фигуры без знания её типа. 
 * Если не разрабатывать более полноценную библиотеку - то проще всего просто принять количество
 * параметров функции за какой-то тип фигуры.
 * Иначе требуется создавать, к примеру, нахождение площади полигона, и получать на вход
 * список всех сторон и углов. Либо координаты вершин. И то - это решение не найдёт площадь эллипса или круга, так как там иные исходные данные.
 */
namespace GeometryLibrary
{
    public class AreaFinder
    {
        //Если передается одно значение - считаем, что это круг, а нам передают радиус. Другие фигуры из одного значения создать невозможно.
        public static double CountArea(double radius)
        {
            return Circle.CountArea(radius);
        }

        //Если передается 2 значения - представим, что это параллелограмм. 
        //Другие подтипы фигур, которые может обработать этот метод: прямоугольник, квадрат
        public static double CountArea(double a, double h)
        {
            return a * h;
        }

        //3 значения - считаем, что это треугольник.
        public static double CountArea(double a, double b, double c)
        {
            return Triangle.CountArea(a, b, c);
        }
    }
}