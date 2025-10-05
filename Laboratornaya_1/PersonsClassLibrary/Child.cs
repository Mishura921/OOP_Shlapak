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
        /// Название учебного заведения (детский сад/школа).
        /// </summary>
        private string _institution;

        /// <summary>
        /// Максимальный возраст ребёнка.
        /// </summary>
        private const int MaxAge = 17;

        /// <summary>
        /// Свойство, позволяющее получить информацию об отце ребёнка
        /// и установить его имя.
        /// </summary>
        public Adult Father
        {
            get => _father;
            set
            {
                CheckParentGender(value, Gender.Female);
                _father = value;
            }
        }

        /// <summary>
        /// Свойство, позволяющее получить информацию о матери ребёнка
        /// и установить её имя.
        /// </summary>
        public Adult Mother
        {
            get => _mother;
            set
            {
                CheckParentGender(value, Gender.Male);
                _mother = value;
            }
        }

        /// <summary>
        /// Автосвойство, позволяющее получить информацию об учебном
        /// зведении ребёнка.
        /// </summary>
        public string Institution { get; set; }








        /// <summary>
        /// Проверяет пол родителя.
        /// </summary>
        /// <param name="parent">Указанный взрослый родитель.</param>
        /// <param name="gender">Пол, который должен отличаться от пола родителя.</param>
        /// <exception cref="ArgumentException">
        /// Вызывает исключение, если пол родителя не совпадает с указанным.
        /// </exception>

        private static void CheckParentGender
            (Adult parent, Gender gender)
        {
            if (parent != null && parent.Gender == gender)
            {
                throw new ArgumentException
                    ("Parent gender must be another");
            }
        }
    }
}
