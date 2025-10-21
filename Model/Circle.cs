using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Круг
    /// </summary>
    public class Circle : FigureBase
    {

        /// <summary>
        /// Радиус круга
        /// </summary>
        private double _radiusCircle;

        /// <summary>
        /// Свойство для доступа к радиусу круга
        /// </summary>
        public double Radius
        {
            get
            {
                return _radiusCircle;
            }
            set
            {
                CheckNumber(value);
                _radiusCircle = value;
            }
        }

        /// <summary>
        /// Свойство для вычисления площади круга
        /// </summary>
        /// <retutns>Площадь круга</retutns>

        public override double Square
        {
            get
            {
                return Math.Round(Math.PI * Math.Pow(Radius, 2), 4);
            }
        }
    }
}