using System;
using GeometryLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GeometryLibraryUnitTests
{
    [TestClass]
    public class PolygonShapeTests
    {
        [TestMethod]
        public void TestVerticesConstructor()
        {
            var shape = new PolygonShape(
                new Vertex[] {
                    new Vertex(0, 0),
                    new Vertex(0, 3),
                    new Vertex(4, 0)
            });
            Assert.AreEqual(0d, shape.vertices[0].x);
            Assert.AreEqual(0d, shape.vertices[0].y);
            Assert.AreEqual(0d, shape.vertices[1].x);
            Assert.AreEqual(3d, shape.vertices[1].y);
            Assert.AreEqual(4d, shape.vertices[2].x);
            Assert.AreEqual(0d, shape.vertices[2].y);
            try
            {
                shape = new PolygonShape(
                    new Vertex[] {
                    new Vertex(0, 0),
                    new Vertex(0, 3),
                    new Vertex(3, 4),
                    new Vertex(3, 2)
                });

                shape = new PolygonShape(
                new Vertex[] {
                    new Vertex(-4, 0),
                    new Vertex(-2, -1),
                    new Vertex(1, -1),
                    new Vertex(2, -2),
                    new Vertex(4, 0),
                    new Vertex(3, 3),
                    new Vertex(-1, 4),
                    new Vertex(-2, 2)});

            }
            catch (Exception e)
            {
                Assert.Fail("При создании корректного полигона возникло исключение: " + e.Message);
            }

            Assert.ThrowsException<InvalidOperationException>(() => new PolygonShape(
                new Vertex[] {
                    new Vertex(0, 0),
                    new Vertex(0, 3),
                    new Vertex(3, 4),
                    new Vertex(1, 5) //Из-за этой вершины полигон получается самопересекающимся
            }), "Создание самопересекающегося полигона обработано некорректно");

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new PolygonShape(
                new Vertex[] {
                    new Vertex(0, 0),
                    new Vertex(1, 5)
            }), "Создание полигона из двух точек обработано некорректно");

            var nullArray = new Vertex[5]; //Массив из null
            Assert.ThrowsException<ArgumentNullException>(() => new PolygonShape(nullArray),
                "Массив со значениями null обработан некорректно");
        }

        [TestMethod]
        public void TestConstructorTuple()
        {
            var shape = new PolygonShape(
                new (double, double)[] {
                    (0, 0),
                    (0, 3),
                    (4, 0)
            });
            Assert.AreEqual(0d, shape.vertices[0].x);
            Assert.AreEqual(0d, shape.vertices[0].y);
            Assert.AreEqual(0d, shape.vertices[1].x);
            Assert.AreEqual(3d, shape.vertices[1].y);
            Assert.AreEqual(4d, shape.vertices[2].x);
            Assert.AreEqual(0d, shape.vertices[2].y);
            try
            {
                shape = new PolygonShape(
                    new (double, double)[] {
                    (0, 0),
                    (0, 3),
                    (3, 4),
                    (3, 2)
                });

                shape = new PolygonShape(
                new (double, double)[] {
                    (-4, 0),
                    (-2, -1),
                    (1, -1),
                    (2, -2),
                    (4, 0),
                    (3, 3),
                    (-1, 4),
                    (-2, 2)});

            }
            catch (Exception e)
            {
                Assert.Fail("При создании корректного полигона возникло исключение: " + e.Message);
            }

            Assert.ThrowsException<InvalidOperationException>(() => new PolygonShape(
                new (double, double)[] {
                    (0, 0),
                    (0, 3),
                    (3, 4),
                    (1, 5) //Из-за этой вершины полигон получается самопересекающимся
            }), "Создание самопересекающегося полигона обработано некорректно");

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new PolygonShape(
                new (double, double)[] {
                    (0, 0),
                    (1, 5)
            }), "Создание полигона из двух точек обработано некорректно");
        }

        [TestMethod]
        public void TestArea()
        {
            Assert.AreEqual(6d, new PolygonShape(
                new Vertex[] {
                    new Vertex(0, 0),
                    new Vertex(0, 3),
                    new Vertex(4, 0)
            }).CountArea());

            Assert.AreEqual(16, new PolygonShape(
               new Vertex[] {
                    new Vertex(-1, -1),
                    new Vertex(-1, 3),
                    new Vertex(3, 3),
                    new Vertex(3, -1)
           }).CountArea());


            Assert.AreEqual(28d, new PolygonShape(
                new Vertex[] {
                    new Vertex(-4, 0),
                    new Vertex(-2, -1),
                    new Vertex(1, -1),
                    new Vertex(2, -2),
                    new Vertex(4, 0),
                    new Vertex(3, 3),
                    new Vertex(-1, 4),
                    new Vertex(-2, 2)
            }).CountArea());
        }
    }
}
