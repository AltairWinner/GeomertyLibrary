using GeometryLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeometryLibraryUnitTests
{
    [TestClass]
    public class AreaFinderTests
    {
        [TestMethod]
        public void Validate_CountAreaGuess_IfCircle()
        {
            double a = 12;
            double expected = 452.389342117;
            double actual = AreaFinder.CountArea(a);

            Assert.AreEqual(expected, actual, 0.000000001, "Площадь была найдена неверно. Целевая фигура - круг.");
        }

        [TestMethod]
        public void Validate_CountAreaGuess_IfRectangle()
        {
            double a = 12;
            double b = 14;
            double expected = 168;
            double actual = AreaFinder.CountArea(a,b);

            Assert.AreEqual(expected, actual, 0.000000001, "Площадь была найдена неверно. Целевая фигура - прямоугольник.");
        }

        [TestMethod]
        public void Validate_CountAreaGuess_IfParallelogram()
        {
            double a = 8;
            double b = 26;
            double expected = 208;
            double actual = AreaFinder.CountArea(a, b);

            Assert.AreEqual(expected, actual, 0.000000001, "Площадь была найдена неверно. Целевая фигура - параллелограмм. Исходные данные - основание и высота");
        }

        [TestMethod]
        public void Validate_CountAreaGuess_IfTriangle()
        {
            double a = 15;
            double b = 12;
            double c = 9;
            double expected = 54;
            double actual = AreaFinder.CountArea(a, b, c);

            Assert.AreEqual(expected, actual, 0.000000001, "Площадь была найдена неверно. Целевая фигура - треугольник.");
        }
    }
}
