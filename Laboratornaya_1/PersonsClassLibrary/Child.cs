using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsClassLibrary
{
    public class Child : PersonBase
    {
        /// <summary>
        /// Отец ребенка.
        /// </summary>
        private Adult _father;

        /// <summary>
        /// Мать ребенка.
        /// </summary>
        private Adult _mother;

        /// <summary>
        /// Название учебного заведения (детский сад/школа)
        /// </summary>
        private string _school;

        /// <summary>
        /// Minimum age value.
        /// </summary>
        private const int MinAge = 0;

        /// <summary>
        /// Maximum age of a child.
        /// </summary>
        private const int MaxAge = 16;
    }
}
