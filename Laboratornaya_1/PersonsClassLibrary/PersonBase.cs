using System.Globalization;
using System.Text.RegularExpressions;

namespace PersonsClassLibrary
{
    /// <summary>
    /// Абстрактный класс, описывающий персонажей.
    /// </summary> 
    public abstract class PersonBase
    {
        /// <summary>
        /// Имя персонажа.
        /// </summary>
        private string _name;

        /// <summary>
        /// Фамилия персонажа.
        /// </summary>
        private string _surname;

        /// <summary>
        /// Возраст персонажа.
        /// </summary>
        private int _age;

        /// <summary>
        /// Минимальный возраст персонажа.
        /// </summary>
        protected const int MinAge = 0;

        /// <summary>
        /// Максимальный возраст персонажа.
        /// </summary>
        protected const int MaxAge = 125;


        /// <summary>
        /// Свойство для получения или ввода имени.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                NameVerification(value, "Имя");
                _name = EditRegister(value);
                LanguageVerification();
            }
        }

        /// <summary>
        /// Свойство для получения или ввода фамилии.
        /// </summary>
        public string Surname
        {
            get => _surname;
            set
            {

                NameVerification(value, "Фамилия");
                _surname = EditRegister(value);
                LanguageVerification();
            }
        }

        /// <summary>
        /// Свойство для получения или ввода возраста персонажа.
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {

                CheckAge(value);
                _age = value;
            }
        }

        /// <summary>
        /// Свойство для получения или ввода пола персонажа.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Конструктор персонажа (класса PersonBase)
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="surname">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        protected PersonBase(string name, string surname, int age, Gender gender)
        {
            Name = name; 
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Конструктор базового класса по умолчанию
        /// </summary>
        protected PersonBase()
        { }

        /// <summary>
        /// Регулярное выражение для проверки строки, содержащей только английские буквы.
        /// </summary>
        /// <remarks>
        /// Допускаются только буквы латинского алфавита (A-Z, a-z).
        /// </remarks>
        private const string _engLetters = "^[A-Za-z]+(-[A-Za-z]+)*$";

        /// <summary>
        /// Регулярное выражение для проверки строки, содержащей только русские буквы.
        /// </summary>
        /// <remarks>
        /// Допускаются только буквы русского алфавита (А-Я, а-я, Ё, ё).
        /// </remarks>
        private const string _ruLetters = "^[А-ЯЁа-яё]+(-[А-ЯЁа-яё]+)*$";

        /// <summary>
        /// Метод для определения языка на основе имени
        /// </summary>
        /// <param name="name">Имя для анализа.</param>
        /// <returns>Код языка (Engish, Russian or Other).</returns>
        public static Language CheckLanguage(string Name)
        {

            if (string.IsNullOrEmpty(Name) == false)
            {
                if (Regex.IsMatch(Name, _engLetters))
                {
                    return Language.English;
                }
                else if (Regex.IsMatch(Name, _ruLetters))
                {
                    return Language.Russian;
                }
            }
            else
            {
                throw new ArgumentException($"Все симоволы имени " +
                    $"и фамилии должын быть на одном языке");
            }
            
            return Language.Other;
        }

        /// <summary>
        /// Метод проверки на соответствие языку
        /// </summary>
        /// <exception cref="FormatException"></exception>
        private void LanguageVerification()
        {
            if (!string.IsNullOrEmpty(_name)
                && !string.IsNullOrEmpty(_surname))
            {
                Language firstNameLanguage = CheckLanguage(_name);
                Language lastNameLanguage = CheckLanguage(_surname);

                if (firstNameLanguage != Language.Other
                    && lastNameLanguage != Language.Other
                    && firstNameLanguage != lastNameLanguage)
                {
                    throw new FormatException("Имя и фамилия " +
                        "должны быть на одном языке.");
                }
            }
        }

        /// <summary>
        /// Преобразует первую букву слова в заглавную, а остальные — в строчные.
        /// </summary>
        /// <param name="word">Имя или фамилия человека.</param>
        /// <returns>Изменённое имя или фамилия.</returns>
        private static string EditRegister(string word)
        {
            return CultureInfo.CurrentCulture.TextInfo.
                ToTitleCase(word.ToLower());
        }

        /// <summary>
        /// Метод выводит поля класса Person.
        /// </summary>
        public string GetPersonInfo()
        {
            return $"{Name} {Surname}; Возраст - {Age}; " +
                   $"Пол - {Gender}";
        }

        /// <summary>
        /// Преобразует имя и фамилию в строковый формат.
        /// </summary>
        /// <returns>Имя и фамилия человека.</returns>
        public string GetPersonNameSurname()
        {
            return $"{Name} {Surname}";
        }

        /// <summary>
        /// Абстрактный метод для получения информации о персонаже.
        /// </summary>
        /// <returns>Возвращает информацию о персонаже</returns>
        public abstract string GetInfo();

        /// <summary>
        /// Метод проверки имени и фамилии на соответствие заданным критериям.
        /// </summary>
        private void NameVerification(string GetName, string GetValueName)
        {
            if (string.IsNullOrWhiteSpace(GetName))
            {
                throw new ArgumentException($"Возможно, Вы " +
                    $"не ввели {GetValueName.ToLower()}," +
                    $" также не должно быть пробелов " +
                    $"или null.");
            }
            if (!Regex.IsMatch(GetName, _engLetters) && !Regex.IsMatch(GetName, _ruLetters))
            {
                throw new ArgumentException($"{GetValueName} должно содержать" +
                    $" только буквы русского или английского алфавита. " +
                    $"Двойные имена/фамилии содержат один символ тире.");
            }
        }

        /// <summary>
        /// Проверка возраста персоны.
        /// </summary>
        /// <param name="age">Возраст персоны.</param>
        protected void CheckAge(int age, int minAge = MinAge, int maxAge = MaxAge)
        {
            if (age < minAge || age > maxAge)
            {
                throw new IndexOutOfRangeException($"Возраст " +
                    $"должен быть в диапазоне [{minAge};{maxAge}].");
            }
        }
    }
} 

