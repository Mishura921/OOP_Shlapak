using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsClassLibrary
{
    /// <summary>
    /// Класс, описывающий взрослого. Наследуется от класса PersonBase.
    /// </summary>
    public class Adult : PersonBase
    {
        /// <summary>
        /// Серия и номер паспорта взрослого. Указывается единым 10-значным числом.
        /// </summary>
        private int _passportNumber;
        /// <summary>
        /// Место работы взрослого.
        /// </summary>
        private string _employer;

        /// <summary>
        /// Статус в браке: муж/жена.
        /// </summary>
        private Adult _marriageStatus;

        /// <summary>
        /// Минимальный возраст возрослого.
        /// </summary>
        private const int MinAge = 18;

        /// <summary>
        /// Максимальный возраст взрослого.
        /// </summary>
        private const int MaxAge = 120;
    }
}
