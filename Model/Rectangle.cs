using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    /// <summary>
    /// Класс - Прямоугольник
    /// </summary>
    public class Rectangle : FigureBase
    {
        /// <summary>
        /// Длина
        /// </summary>
        private double _length;

        /// <summary>
        /// Ширина
        /// </summary>
        private double _width;

        /// <summary>
        /// Свойство - длина
        /// </summary>
        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                CheckingNumber(value);
                _length = value;
            }
        }

        /// <summary>
        /// Свойство - ширина
        /// </summary>
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                CheckingNumber(value);
                _width = value;
            }
        }

        /// <summary>
        /// Тип фигуры
        /// </summary>
        public override string FigureType => "Прямоугольник";

        /// <summary>
        /// Вычисление площади прямоугольника
        /// </summary>
        /// <retutns>Площадь</retutns>
        public override double Square
        {
            get
            {
                return Length * Width;
            }
        }
    }
}