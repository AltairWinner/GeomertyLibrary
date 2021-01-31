using Microsoft.VisualStudio.TestTools.UnitTesting;
using GeometryLibrary;

namespace GeometryLibraryUnitTests
{
    [TestClass]
    public class CircleTests
    {
        //��������� ���������� ������� ����� (�������)
        [TestMethod]
        public void ValidateAreaCountMethod()
        {
            double radius = 10;
            double expected = 314.159265359;
            Circle circle = new Circle(radius);

            double actual = circle.CountArea();
            Assert.AreEqual(expected, actual, 0.000000001, "������� ����� ������� �������.");
        }

        //��������� ���������� ������� ����� � ������������ ��������
        [TestMethod]
        public void ValidateAreaCountMethod_Static()
        {
            double radius = 10;
            double expected = 314.159265359;

            double actual = Circle.CountArea(radius);
            Assert.AreEqual(expected, actual, 0.000000001, "������� ����� � ����������� ������ ������� �������.");
        }
    }
}
