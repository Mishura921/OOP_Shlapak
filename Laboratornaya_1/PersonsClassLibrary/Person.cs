using System.Globalization;
using System.Text.RegularExpressions;

namespace PersonsClassLibrary
{
    /// <summary>
    /// Класс, описывающий персонажей.
    /// </summary>
    public class Person
    {
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
        /// Вводимое имя.
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
        /// Вводимая фамилия.
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
        /// Передаваемое значение возраста.
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {
                
                if (value >= MinAge && value <= MaxAge)
                {
                    _age = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Возраст " +
                        $"должен быть в диапазоне [{MinAge}:{MaxAge}].");
                }
            }
        }

        /// <summary>
        /// Передаваемое значение пола.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Конструктор персонажа
        /// </summary>
        /// <param name="name">Имя.</param>
        /// <param name="surname">Фамилия.</param>
        /// <param name="age">Возраст.</param>
        /// <param name="gender">Пол.</param>
        public Person(string name, string surname, int age, Gender gender)
        {
            Name = name; 
            Surname = surname;
            Age = age;
            Gender = gender;
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Person"/>.
        /// </summary>
        public Person()
        { }

        //TODO: XML+
        //TODO: RSDN+
        /// <summary>
        /// Регулярное выражение для проверки строки, содержащей только английские буквы.
        /// </summary>
        /// <remarks>
        /// Допускаются только буквы латинского алфавита (A-Z, a-z).
        /// </remarks>
        private const string _EngLetters = 
            "^[A-Za-z]+(-[A-Za-z]+)*$";

        //TODO: XML+
        //TODO: RSDN+
        /// <summary>
        /// Регулярное выражение для проверки строки, содержащей только русские буквы.
        /// </summary>
        /// <remarks>
        /// Допускаются только буквы русского алфавита (А-Я, а-я, Ё, ё).
        /// </remarks>
        private const string _RuLetters = 
            "^[А-ЯЁа-яё]+(-[А-ЯЁа-яё]+)*$";

        /// <summary>
        /// Метод для определения языка на основе имени
        /// </summary>
        /// <param name="name">Имя для анализа.</param>
        /// <returns>Код языка (Engish, Russian or Other).</returns>
        public static Language CheckLanguage(string Name)
        {

            if (string.IsNullOrEmpty(Name) == false)
            {
                if (Regex.IsMatch(Name, _EngLetters))
                {
                    return Language.English;
                }
                else if (Regex.IsMatch(Name, _RuLetters))
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
        /// Функция выводит информацию об экземпляре класса в соответствующем формате.
        /// </summary>
        public string Info()
        {
            return $"{Name} {Surname}; Возраст - {Age}; " +
                   $"Пол - {Gender}";
        }

        /// <summary>
        /// Генерирует объект человека со случайными параметрами: имени, фамилии,
        /// возраста и пола.
        /// </summary>
        /// <returns>Случайно сгенерированный человек.</returns>
        public static Person GetRandomPerson()
        {
            string[] maleNames =
            {
                "Gaius", "Winston", "Benito", 
                "Vlad", "Pierre", "Clyde"
            };

            string[] femaleNames =
            {
                "Cleopatra", "Elizabeth", "Mary", 
                "Anne", "Marie", "Bonnie"
            };

            string[] surnames =
            {
                "Caesar", "Churchill", "Mussolini", 
                "Drakula", "Curie", "Parker"
            };

            Random random = new Random();

            // Здесь происходит генерация пола
            Gender tmpGender = random.Next(2) == 0 
                ? Gender.Male 
                : Gender.Female;

            string tmpName = tmpGender == Gender.Male 
                ? maleNames[random.Next(maleNames.Length)] 
                : femaleNames[random.Next(femaleNames.Length)];
            string tmpSurname = surnames[random.Next(surnames.Length)];
            int tmpAge = random.Next(MinAge, MaxAge);
            
            return new Person(tmpName, tmpSurname, tmpAge, tmpGender);
        }

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
            if (!Regex.IsMatch(GetName, _EngLetters) && !Regex.IsMatch(GetName, _RuLetters))
            {
                throw new ArgumentException($"{GetValueName} должно содержать" +
                    $" только буквы русского или английского алфавита. " +
                    $"Двойные имена/фамилии содержат один символ тире.");
            }
        }
    }
} 

