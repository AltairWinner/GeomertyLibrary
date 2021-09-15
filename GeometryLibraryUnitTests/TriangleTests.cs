using System;
using GeometryLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeometryLibraryUnitTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void TestConstructorWithSides()
        {
            Assert.ThrowsException<ArgumentException>(() => new Triangle(2, 5, 105),
                "При попытке создать невозможный треугольник не возникло исключение.");

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(-3, 3, 3),
                "При некорректной стороне 'a' треугольника не возникло исключение.");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(3, -3, 3),
                "При некорректной стороне 'b' треугольника не возникло исключение.");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(3, 3, -3),
                "При некорректной стороне 'c' треугольника не возникло исключение.");

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(0, 3, 3),
                "При некорректной стороне 'a' треугольника не возникло исключение.");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(3, 0, 3),
                "При некорректной стороне 'b' треугольника не возникло исключение.");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Triangle(3, 3, 0),
                "При некорректной стороне 'c' треугольника не возникло исключение.");
        }

        [TestMethod]
        public void TestConstructorFromPolygon()
        {
            var shape = new PolygonShape(
                new Vertex[] {
                    new Vertex(0, 0),
                    new Vertex(0, 3),
                    new Vertex(4, 0)
            });

            Assert.AreEqual(3, new Triangle(shape).A);
            Assert.AreEqual(5, new Triangle(shape).B);
            Assert.AreEqual(4, new Triangle(shape).C);
        }

        [TestMethod]
        public void ValidateAreaCountMethod()
        {
            Assert.AreEqual(111.71392035015153, new Triangle(14, 16, 22).CountArea(),
                0.000000001, "Площадь треугольника найдена неверно.");
        }


        [TestMethod]
        public void Validate_IsRightTriangle()
        {
            Assert.AreEqual(true, new Triangle(3, 4, 5).IsRightTriangle(), "Прямоугольный треугольник был отмечен, как не прямоугольный.");
            Assert.AreEqual(true, new Triangle(3, 5, 4).IsRightTriangle(), "Прямоугольный треугольник был отмечен, как не прямоугольный, когда параметры о сторонах передаются в случайном порядке.");
            Assert.AreEqual(false, new Triangle(23, 14, 15).IsRightTriangle(), "Не прямоугольный треугольник был отмечен, как прямоугольный");
        }
    }
}
