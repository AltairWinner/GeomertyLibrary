/*
 Часть данного кода была взята из интернета. Данная реализация не оптимальна:
 было бы лучше использовать алгоритм заметающей прямой, чтобы библиотека могла работать
 с большим количеством вершин. 
 */

using System;
using System.Collections.Generic;

namespace GeometryLibrary
{
    internal class IntersectionChecker
    {
        // Given three collinear points p, q, r, the function checks if
        // point q lies on line segment 'pr'
        private static bool OnSegment(Vertex p, Vertex q, Vertex r)
        {
            if (q.x <= Math.Max(p.x, r.x) && q.x >= Math.Min(p.x, r.x) &&
                q.y <= Math.Max(p.y, r.y) && q.y >= Math.Min(p.y, r.y))
                return true;

            return false;
        }

        // To find orientation of ordered triplet (p, q, r).
        // The function returns following values
        // 0 --> p, q and r are collinear
        // 1 --> Clockwise
        // 2 --> Counterclockwise
        private static int Orientation(Vertex p, Vertex q, Vertex r)
        {
            int val = (int)((q.y - p.y) * (r.x - q.x) -
                    (q.x - p.x) * (r.y - q.y));

            if (val == 0)
                return 0; // collinear

            return (val > 0) ? 1 : 2; // clock or counterclock wise
        }

        // The main function that returns true if line segment 'p1q1'
        // and 'p2q2' intersect.
        internal static bool DoIntersect(Vertex p1, Vertex q1, Vertex p2, Vertex q2)
        {
            // Find the four orientations needed for general and
            // special cases
            int o1 = Orientation(p1, q1, p2);
            int o2 = Orientation(p1, q1, q2);
            int o3 = Orientation(p2, q2, p1);
            int o4 = Orientation(p2, q2, q1);

            // General case
            if (o1 != o2 && o3 != o4)
                return true;

            // Special Cases
            // p1, q1 and p2 are collinear and p2 lies on segment p1q1
            if (o1 == 0 && OnSegment(p1, p2, q1))
                return true;

            // p1, q1 and q2 are collinear and q2 lies on segment p1q1
            if (o2 == 0 && OnSegment(p1, q2, q1))
                return true;

            // p2, q2 and p1 are collinear and p1 lies on segment p2q2
            if (o3 == 0 && OnSegment(p2, p1, q2))
                return true;

            // p2, q2 and q1 are collinear and q1 lies on segment p2q2
            if (o4 == 0 && OnSegment(p2, q1, q2))
                return true;

            return false; // Doesn't fall in any of the above cases
        }

        /// <summary>
        /// Метод проверяет, является ли фигура самопересекающейся.
        /// </summary>
        /// <param name="vertices">Массив вершин.</param>
        /// <returns>Является ли фигура самопересекающейся.</returns>
        public static bool IsSelfIntersecting(List<Vertex> vertices)
        {
            //Сравниваем каждую сторону с последующими, начиная со стороны через одну (так как
            //с соседней стороной мы всегда имеем общую точку)
            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = i + 2; j < vertices.Count; j++)
                {
                    //Последняя сторона состоит из первой и последней вершин в массиве, поэтому обрабатываем отдельно. 
                    if (j == vertices.Count - 1)
                    {
                        if (i != 0) //Сторона 0,1 и последняя-0 всегда имеют общую точку. 
                            if (DoIntersect(vertices[i], vertices[i + 1], vertices[j], vertices[0]))
                                return true;
                    }
                    else
                    {
                        if (DoIntersect(vertices[i], vertices[i + 1], vertices[j], vertices[j + 1]))
                            return true;
                    }
                }
            }
            return false;
        }
    }
}
