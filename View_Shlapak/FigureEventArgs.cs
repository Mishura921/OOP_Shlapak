using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace View
{
    /// <summary>
    /// Класс аргумента для передачи событий о фигурах
    /// </summary>
    public class FigureEventArgs : EventArgs
    {
        /// <summary>
        /// Фигура для передачи
        /// </summary>
        public FigureBase SendingFigure { get; }

        /// <summary>
        /// Конструктор для передачи фигуры
        /// </summary>
        /// <param name="sendingFigure">Передача</param>
        public FigureEventArgs(FigureBase sendingFigure)
        {
            SendingFigure = sendingFigure;
        }
    }
}
