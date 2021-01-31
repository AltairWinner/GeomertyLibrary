using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryLibrary;

namespace GeometryLibraryUnitTests
{
    [TestClass]
    public class TriangleTests
    {
        [TestMethod]
        public void ValidateAreaCountMethod()
        {
            double a = 14;
            double b = 16;
            double c = 22;
            double expected = 111.71392035015153;
            Triangle circle = new Triangle(a,b,c);

            double actual = circle.CountArea();
            Assert.AreEqual(expected, actual, 0.000000001, "Площадь треугольника найдена неверно.");
        }

        [TestMethod]
        public void ValidateAreaCountMethod_Static()
        {
            double a = 14;
            double b = 16;
            double c = 22;
            double expected = 111.71392035015153;

            double actual = Triangle.CountArea(a,b,c);
            Assert.AreEqual(expected, actual, 0.000000001, "Площадь треугольника в статическом методе найдена неверно.");
        }

       
        [TestMethod]
        public void Validate_IsRightTriangle_Right_StandartOrder()
        {
            Triangle triangle = new Triangle(3, 4, 5);
            bool expected = true;
            bool actual = triangle.IsRightTriangle();

            Assert.AreEqual(expected, actual, "Прямоугольный треугольник был отмечен, как не прямоугольный.");
        }

        //Проверка метода при условии, что данные о сторонах треугольника передаются в смешанном порядке.
        [TestMethod]
        public void Validate_IsRightTriangle_Right_AnyOrder()
        {
            Triangle triangle = new Triangle(3, 5, 4);
            bool expected = true;
            bool actual = triangle.IsRightTriangle();

            Assert.AreEqual(expected, actual, "Прямоугольный треугольник был отмечен, как не прямоугольный, когда параметры о сторонах передаются в случайном порядке.");
        }

        [TestMethod]
        public void Validate_IsRightTriangle_NotRight()
        {
            Triangle triangle = new Triangle(23, 14, 15);
            bool expected = false;
            bool actual = triangle.IsRightTriangle();

            Assert.AreEqual(expected, actual, "Не прямоугольный треугольник был отмечен, как прямоугольный");
        }
    }
}
