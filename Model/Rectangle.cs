using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Прямоугольник
    /// </summary>
    public class Rectangle : FigureBase
    {
        /// <summary>
        /// Длина прямоугольника
        /// </summary>
        private double _length;

        /// <summary>
        /// Ширина прямоугольника
        /// </summary>
        private double _width;

        /// <summary>
        /// Свойство для доступа к длине прямоугольника
        /// </summary>
        public double Length
        {
            get
            {
                return _length;
            }
            set
            {
                CheckNumber(value);
                _length = value;
            }
        }

        /// <summary>
        /// Свойство для доступа к ширине прямоугольника
        /// </summary>
        public double Width
        {
            get
            {
                return _width;
            }
            set
            {
                CheckNumber(value);
                _width = value;
            }
        }

        /// <summary>
        /// Свойство для вычисления площади прямоугольника
        /// </summary>
        /// <retutns>Площадь прямоугольника</retutns>
        public override double Square
        {
            get
            {
                return Length * Width;
            }
        }
    }
}