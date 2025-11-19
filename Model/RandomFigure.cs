using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Model
{
    /// <summary>
    /// Класс для генерации случайной фигуры
    /// </summary>
    public static class RandomFigure
    {
        /// <summary>
        /// Рандом
        /// </summary>
        private static Random _random = new Random();

        /// <summary>
        /// Максимальное значение параметра
        /// </summary>
        private const int MAXVALUE = 10000;

        /// <summary>
        /// Минимальное значение параметра
        /// </summary>
        private const int MINVALUE = 1;

        /// <summary>
        /// Значение делителя 
        /// </summary>
        private const double DIVIDER = 10000.0;

        /// <summary>
        /// Генерация случайного числа double через int
        /// </summary>
        /// <param name="minValue">Минимальное значение</param>
        /// <param name="maxValue">Максимальное значение</param>
        /// <param name="divider">Делитель</param>
        public static double GetRandomDouble(int minValue, int maxValue,
            double divider)
        {
            var randomValue = Convert.ToDouble(_random.Next(minValue, maxValue));
            return randomValue / divider;
        }

        /// <summary>
        /// Генерация случайной фигуры
        /// </summary>
        /// <returns>Сгенерированный объект класса FigureBase</returns>
        public static FigureBase GetRandomFigure()
        {
            var figureType = _random.Next(0, 3);

            switch (figureType)
            {
                case 0:
                    {
                        return GetRandomRectangle();
                    }
                case 1:
                    {
                        return GetRandomTriangle();
                    }
                case 2:
                    {
                        return GetRandomCircle();
                    }
                default:
                    {
                        throw new ArgumentException("Тип фигуры отсутствует.");
                    }
            }
        }

        /// <summary>
        /// Генерация случайного прямоугольника
        /// </summary>
        /// <returns>Случайный прямоугольник</returns>
        public static FigureBase GetRandomRectangle()
        {
            var rectangle = new Rectangle
            {
                Length = GetRandomDouble(MINVALUE, MAXVALUE, DIVIDER),
                Width = GetRandomDouble(MINVALUE, MAXVALUE, DIVIDER),
            };
            return rectangle;
        }

        /// <summary>
        /// Генерация случайного треугольника
        /// </summary>
        /// <returns>Случайный треугольник</returns>
        public static FigureBase GetRandomTriangle()
        {
            var triangle = new Triangle
            {
                Length = GetRandomDouble(MINVALUE, MAXVALUE, DIVIDER),
                Height = GetRandomDouble(MINVALUE, MAXVALUE, DIVIDER)
            };
            return triangle;
        }

        /// <summary>
        /// Генерация случайного круга
        /// </summary>
        /// <returns>Случайный круг</returns>
        public static FigureBase GetRandomCircle()
        {
            var circle = new Circle
            {
                Radius = GetRandomDouble(MINVALUE, MAXVALUE, DIVIDER),
            };
            return circle;
        }
    }
}
