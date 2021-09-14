namespace GeometryLibrary
{
    /// <summary>
    /// Представляет собой абстракцию над любой геометрической фигурой.
    /// </summary>
    public abstract class GeometryShape
    {
        /// <summary>
        /// Метод возвращает площадь данной фигуры.
        /// </summary>
        public abstract double CountArea();
    }
}