using System;
using System.Text.RegularExpressions;

namespace Model
{
    /// <summary>
    /// Базовый класс для всех фигур
    /// </summary>
    public abstract class FigureBase
    {
        /// <summary>
        /// Свойство для расчёта площади
        /// </summary>
        public abstract double Square { get; }

        /// <summary>
        /// Метод проверки числа
        /// </summary>
        /// <param name="number">Число для проверки</param>
        /// <returns>Корректное число</returns>
        public static double CheckNumber(double number)
        {
            if (number < 0)
            {
                throw new ArgumentOutOfRangeException("Величина должна " +
                    "быть положительным числом!");
            }
            else
            {
                return number;
            }
        }
    }
}