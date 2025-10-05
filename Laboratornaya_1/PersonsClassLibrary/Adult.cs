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
        /// Минимальное значение серии паспорта.
        /// </summary>
        private const int PassportSeriesLowBound = 100;

        /// <summary>
        /// Максимальное значение серии паспорта.
        /// </summary>
        private const int PassportSeriesHighBound = 9999;

        /// <summary>
        /// Минимальное значение номера паспорта.
        /// </summary>
        private const int PassportNumberLowBound = 0;

        /// <summary>
        /// Максимальное значение номера паспорта.
        /// </summary>
        private const int PassportNumberHighBound = 999999;

        /// <summary>
        /// Серия паспорта.
        /// </summary>
        private int _passportSeries;

        /// <summary>
        /// Номер паспорта.
        /// </summary>
        private int _passportNumber;

        /// <summary>
        /// Свойство для доступа к серии паспорта.
        /// </summary>
        public int PassportSeries
        {
            get => _passportSeries;
            set
            {
                CheckPassportData(value, _passportNumber);
                _passportSeries = value;
            }
        }

        /// <summary>
        /// Свойство для досутпа к номеру паспорта.
        /// </summary>
        public int PassportNumber
        {
            get => _passportNumber;
            set
            {
                CheckPassportData(_passportSeries, value);
                _passportNumber = value;
            }
        }
        /// <summary>
        /// Место работы взрослого.
        /// </summary>
        public string Employer
        {
            get => _employer;
            set
            {
                _employer = string.IsNullOrWhiteSpace(value) ? "Безработный" : value.Trim();
            }
        }


        /// <summary>
        /// Свйоство для указания статуса в браке
        /// </summary>
        public Adult MarriageStatus
        {
            get => _marriageStatus;
            set
            {
                _marriageStatus = value;
            }
        }


        /// <summary>
        /// Конструктор класса Adult.
        /// </summary>
        /// <param name="name">Name of the person.</param>
        /// <param name="surname">Surname of the person.</param>
        /// <param name="age">Age of the person.</param>
        /// <param name="gender">Gender of the person.</param>
        /// <param name="passportNumber">Adult's passport number.</param>
        /// <param name="spouse">Adult's spouse.</param>
        /// <param name="_employer">Adult's employer.</param>
        public Adult(string name, string surname, int age,
            Gender gender, int passportNumber, Adult marraigeStatus,
            string _employer) : base(name, surname, age, gender)
        {
            PassportNumber = passportNumber;
            Employer = _employer;
            MarriageStatus = _marriageStatus;
        }

        /// <summary>
        /// Create an instance of class Adult without parameters.
        /// </summary>
        public Adult() : this("Unknown", "Unknown", 17,
            Gender.Male, 100000, null, null)
        { }





        /// <summary>
        /// Проверяет корректность серии и номера паспорта.
        /// </summary>
        /// <param name="series">Серия паспорта.</param>
        /// <param name="number">Номер паспорта.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Вызывается, если серия или номер вне допустимого диапазона.
        /// </exception>
        private static void CheckPassportData(int series, int number)
        {
            if (series < PassportSeriesLowBound || series > PassportSeriesHighBound)
            {
                throw new ArgumentOutOfRangeException(nameof(series),
                    $"Серия паспорта должна быть в диапазоне [{PassportSeriesLowBound}:{PassportSeriesHighBound}].");
            }

            if (number < PassportNumberLowBound || number > PassportNumberHighBound)
            {
                throw new ArgumentOutOfRangeException(nameof(number),
                    $"Номер паспорта должен быть в диапазоне [{PassportNumberLowBound}:{PassportNumberHighBound}].");
            }
        }

    }
}
