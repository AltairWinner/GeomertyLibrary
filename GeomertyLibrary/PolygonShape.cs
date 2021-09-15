using System;
using System.Collections.Generic;

namespace GeometryLibrary
{
    /// <summary>
    /// Представляет собой несамопересекающуюся геометрическую фигуру неопределенного типа, состоящую из множества вершин.
    /// </summary>
    public class PolygonShape : GeometryShape
    {
        public Vertex[] vertices;
        /// <summary>
        /// Создаёт новую геометрическую фигуру из массива координат вершин на двумерной плоскости.
        /// </summary>
        /// <exception cref="ArgumentNullException">Возникает, если переданный массив является null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Возникает, когда количество вершин меньше 3.</exception>
        /// <exception cref="InvalidOperationException">Возникает при попытке создания самопересекающегося полигона.</exception>
        /// <param name="vertices">Массив координат вершин. При этом считается, что каждая вершина соединяется с соседними.</param>
        public PolygonShape(Vertex[] vertices)
        {
            if (vertices.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Для создания фигуры требуется минимум 3 вершины.");
            }
            for(int i = 0; i < vertices.Length; i++)
            {
                if(vertices[i] is null)
                    throw new ArgumentNullException($"Значение вершины [{i}] в массиве было null.");
            }
            if (IntersectionChecker.IsSelfIntersecting(new List<Vertex>(vertices)))
            {
                throw new InvalidOperationException("Невозможно создать самопересекающуюся фигуру.");
            }

            this.vertices = vertices;
        }

        /// <summary>
        /// Создаёт новую геометрическую фигуру из массива координат вершин на двумерной плоскости.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">Возникает, когда количество вершин меньше 3.</exception>
        /// <exception cref="InvalidOperationException">Возникает при попытке создания самопересекающегося полигона.</exception>
        /// <param name="vertices">Пары координат вершин. При этом считается, что каждая вершина соединяется с соседними.</param>
        public PolygonShape((double, double)[] vertices)
        {
            if (vertices.Length < 3)
                throw new ArgumentOutOfRangeException("Для создания фигуры требуется минимум 3 вершины.");

            var vertexList = new List<Vertex>();
            for (int i = 0; i < vertices.Length; i++)
            {
                vertexList.Add(new Vertex(vertices[i].Item1, vertices[i].Item2));
            }

            if (IntersectionChecker.IsSelfIntersecting(vertexList))
                throw new InvalidOperationException("Невозможно создать самопересекающуюся фигуру.");

            this.vertices = vertexList.ToArray();
        }

        /// <summary>
        /// Находит площадь геометрической фигуры.
        /// </summary>
        /// <returns>Площадь данной геометрической фигуры.</returns>
        public override double CountArea()
        {
            double area = 0;
            for (int i = 0; i < vertices.Length - 1; i++)
            {
                area += (vertices[i].x * vertices[i + 1].y) - (vertices[i].y * vertices[i + 1].x);
            }
            area += vertices[vertices.Length - 1].x * vertices[0].y - vertices[vertices.Length - 1].y * vertices[0].x;
            area /= 2;

            return Math.Abs(area);
        }
    }
}
