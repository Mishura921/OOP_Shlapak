using System;

namespace Model
{
    [Serializable]
    /// <summary>
    /// Класс - Круг
    /// </summary>
    public class Circle : FigureBase
    {
        /// <summary>
        /// Радиус круга
        /// </summary>
        private double _radiusOfFigure;

        /// <summary>
        /// Свойство - радиус круга
        /// </summary>
        public double Radius
        {
            get
            {
                return _radiusOfFigure;
            }
            set
            {
                CheckingNumber(value);
                _radiusOfFigure = value;
            }
        }

        /// <summary>
        /// Тип фигуры
        /// </summary>
        public override string FigureType => "Круг";

        /// <summary>
        /// Вычисление площади круга
        /// </summary>
        /// <retutns>Площадь шара</retutns>

        public override double Square
        {
            get
            {
                return  Math.PI * Math.Pow(Radius, 2);
            }
        }
    }
}