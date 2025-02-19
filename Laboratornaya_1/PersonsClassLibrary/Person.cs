using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PersonsClassLibrary
{
    class Person
    {
        // Поля класса Person: определяем их как приватные, доступ к ним будем осуществлять с помощью методов
        /// <summary>
        /// Имя.
        /// </summary>
        private string _name;
        /// <summary>
        /// Фамилия.
        /// </summary>
        private string _surname;
        /// <summary>
        /// Возраст.
        /// </summary>
        private int _age;
        /// <summary>
        /// Минимальный предусматриваемый возраст.
        /// </summary>
        private const int MinAge = 0;
        /// <summary>
        /// Максимальный предусматриваемый возраст.
        /// </summary>
        private const int MaxAge = 120;
        /// <summary>
        /// Гендер.
        /// </summary>
        private Gender _gender;

        // Методы класса Person. Позволяютт получить доступ к приватным полям. Так реализуем инкапсуляцию. Безопасность
        /// <summary>
        /// Вводимое имя.
        /// </summary>
        public string InputName
        {
            get => _name;

            set
            {
                LanguageValidation(value);
                _name = EditRegister(value);

                if (_surname != null)
                {
                    NameSurnameValidation();
                }
            }
        }
        /// <summary>
        /// Вводимая фамилия.
        /// </summary>
        public string InputSurname
        {
            get => _surname;

            set
            {
                LanguageValidation(value);
                _surname = EditRegister(value);

                if (_surname != null)
                {
                    NameSurnameValidation();
                }
            }
        }
        /// <summary>
        /// Передаваемое значение возраста.
        /// </summary>
        public int InputAge
        {
            get => _age;
            set
            {
                try
                {
                    if (value <= MinAge || value >= MaxAge)
                        throw new IndexOutOfRangeException($"Возраст должен быть в диапазоне: [{MinAge} - {MaxAge}].");

                    _age = value;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Передаваемое значение пола.
        /// </summary>
        public Gender InputGender
        {
            get => _gender;
            set => _gender = value;
        }
        /// <summary>
        /// Конструктор класса Person.
        /// </summary>
        public Person
            (string name, string surname, int age, Gender gender)
        {
            InputName = name; // this.name = name ???
            InputSurname = surname;
            InputAge = age;
            InputGender = gender;
        }

        /// <summary>
        /// Валидация языка. Функция оределяет, какому языку соответствует переданная строка name.
        /// </summary>
        private static Language LanguageValidation(string name)
        {
            var engLetters = new Regex(@"^[A-z]+(-[A-z])?[A-z]*$");
            var ruLetters = new Regex(@"^[А-я]+(-[А-я])?[А-я]*$");

            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException("Имя не может являться null или быть пустым!");
                }

                if (engLetters.IsMatch(name))
                {
                    return Language.English;
                }

                if (ruLetters.IsMatch(name))
                {
                    return Language.Russian;
                }

                throw new ArgumentException("Некорректный ввод, повторите!");
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                return Language.Other;
            }
        }
        /// <summary>
        /// Функция сравнивает, на одном ли языке введены имя и фамилия.
        /// </summary>
        private void NameSurnameValidation()
        {
            if ((string.IsNullOrEmpty(InputName) == false)
                && (string.IsNullOrEmpty(InputSurname) == false))
            {
                var nameLanguage = LanguageValidation(InputName);
                var surnameLanguage = LanguageValidation(InputSurname);

                if (nameLanguage != surnameLanguage)
                {
                    throw new FormatException("Имя и фамилия должны быть на одном языке");
                }
            }
        }
        /// <summary>
        /// Функция меняет первую букву на заглавную, оставляя остальные строчными. Прим.: иЛьЯ - > Илья.
        /// </summary>
        private static string EditRegister(string word)
        {
            return CultureInfo.CurrentCulture.TextInfo.
                ToTitleCase(word.ToLower());
        }
        public string ObjectData()
        {
            return $"{InputName} {InputSurname}; Возраст - {InputAge}; Пол - {InputGender}";
        }
    }
} 

