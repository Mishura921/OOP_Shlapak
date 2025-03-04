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
        public string Surname
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
        public int Age
        {
            get => _age;
            set
            {
                try
                {
                    if (value <= MinAge || value >= MaxAge)
                    {
                        throw new IndexOutOfRangeException(
                            $"Возраст должен быть в диапазоне: " +
                            $"[{MinAge} - {MaxAge}]."
                        );
                    }

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

        /// <summary>
        /// Функция определяет, какому языку соответствует переданная строка name.
        /// </summary>
        /// <param name="name">String.</param>
        private static Language LanguageValidation(string name)
        {
            name = name.Trim();
            var engLetters = new Regex(@"^[A-z]+(-[A-z])?[A-z]*$");
            var ruLetters = new Regex(@"^[А-я]+(-[А-я])?[А-я]*$");

            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    throw new ArgumentException(
                        "Имя не может являться " +
                        "null или быть пустым!");
                }

                if (engLetters.IsMatch(name))
                {
                    return Language.English;
                }

                if (ruLetters.IsMatch(name))
                {
                    return Language.Russian;
                }

                throw new ArgumentException("Некорректный ввод!");
            }
            catch (ArgumentException ex)
            {
                //TODO: Remove
                Console.WriteLine($"Ошибка: {ex.Message}");
                return Language.Other;
            }
        }

        /// <summary>
        /// Сравнение языка в фамилии и имени
        /// </summary>
        /// <exception cref="FormatException">
        /// Фамилия и имя - на одном языке!
        /// </exception>
        private void NameSurnameValidation()
        {
            if (!string.IsNullOrEmpty(Name)
                && !string.IsNullOrEmpty(Surname))
            {
                var nameLanguage = LanguageValidation(Name);
                var surnameLanguage = LanguageValidation(Surname);

                if (nameLanguage != surnameLanguage)
                {
                    throw new FormatException(
                        "Имя и фамилия должны " +
                        "быть на одном языке!"
                    );
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
        /// Генерирует объект человека со случайными параметрами: имени, фамилии, возраста
        /// и пола.
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

            // Генерация пола
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
    }
} 

