using System;
using GeometryLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeometryLibraryUnitTests
{
    [TestClass]
    public class CircleTests
    {
        [TestMethod]
        public void TestConstructor()
        {
            Assert.AreEqual(2.5, new Circle(2.5).Radius, "Конструктор по радиусу сработал неверно.");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Circle(-25.2f), "Некорректно обработан отрицательный радиус.");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new Circle(0), "Некорректно обработан радиус, равный нулю.");
        }


        //Тестируем нахождение площади круга
        [TestMethod]
        public void ValidateAreaCountMethod()
        {
            Assert.AreEqual(314.159265359, new Circle(10).CountArea(), 0.000000001, "Площадь круга найдена неверно.");
        }
    }
}

