using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle : FigureBase
    {
        /// <summary>
        /// Длина стороны, к которой проведена высота
        /// </summary>
        private double _edgeLenght;

        /// <summary>
        /// Длина высоты, проведённой к стороне
        /// </summary>
        private double _height;

        /// <summary>
        /// Свойство для доступа к длине стороны треугольника
        /// </summary>
        public double EdgeLenght
        {
            get
            {
                return _edgeLenght;
            }
            set
            {
                CheckNumber(value);
                _edgeLenght = value;
            }
        }

        /// <summary>
        /// Свойство для доступа к длине высоты треугольника
        /// </summary>
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                CheckNumber(value);
                _height = value;
            }
        }

        /// <summary>
        /// Свойство для вычисления площади треугольника
        /// </summary>
        /// <retutns>Площадь треугольника</retutns>

        public override double Square
        {
            get
            {
                return EdgeLenght * Height * 1 / 2;
            }
        }
    }
}