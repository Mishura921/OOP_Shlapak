using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace Model
{
    /// <summary>
    /// Базовый класс для всех фигур
    /// </summary>
    [Serializable]
    [XmlInclude(typeof(Rectangle))]
    [XmlInclude(typeof(Triangle))]
    [XmlInclude(typeof(Circle))]

    public abstract class FigureBase
    {
        /// <summary>
        /// Тип фигуры
        /// </summary>
        public abstract string FigureType { get; }

        /// <summary>
        /// Расчёт площади
        /// </summary>
        public abstract double Square { get; }

        /// <summary>
        /// Проверка числа
        /// </summary>
        /// <param name="number">Число для проверки</param>
        /// <returns>Корректное число</returns>
        public static double CheckingNumber(double number)
        {
            if (number <= 0)
            {
                throw new ArgumentOutOfRangeException("Величина должна " +
                    "быть положительным числом!");
            }
            else if (double.IsNaN(number))
            {
                throw new Exception("Нечисловое значение!");
            }
            else
            {
                return number;
            }
        }
    }
}
