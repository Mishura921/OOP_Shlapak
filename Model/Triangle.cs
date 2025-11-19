using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Serializable]
    /// <summary>
    /// Класс - Треугольник
    /// </summary>
    public class Triangle : FigureBase
    {
        /// <summary>
        /// Длина
        /// </summary>
        private double _length;

        /// <summary>
        /// Высота
        /// </summary>
        private double _height;

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
        /// Свойство - высота
        /// </summary>
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                CheckingNumber(value);
                _height = value;
            }
        }

        /// <summary>
        /// Тип фигуры
        /// </summary>
        public override string FigureType => "Треугольник";


        /// <summary>
        /// Вычисление площади треугольника
        /// </summary>
        /// <retutns>Площадь пирамиды</retutns>

        public override double Square
        {
            get
            {
                return Length * Height * 1 / 2;
            }
        }
    }
}