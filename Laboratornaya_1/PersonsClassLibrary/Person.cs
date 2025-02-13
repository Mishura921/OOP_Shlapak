using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsClassLibrary
{
    class Person
    {
        /// <summary>
        /// Имя
        /// </summary>
        private string _name;
        /// <summary>
        /// Фамилия
        /// </summary>
        private string _surname;
        /// <summary>
        /// Возраст
        /// </summary>
        private int _age;
        /// <summary>
        /// Минимальный предусматриваемый возраст
        /// </summary>
        private const int MinAge = 0;
        /// <summary>
        /// Максимальный предусматриваемый возраст
        /// </summary>
        private const int MaxAge = 120;
        /// <summary>
        /// Гендер
        /// </summary>
        private Gender _gender;
    }
}
