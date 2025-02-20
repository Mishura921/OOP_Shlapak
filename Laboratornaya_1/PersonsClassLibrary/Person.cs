using System.Globalization;
using System.Text.RegularExpressions;

namespace PersonsClassLibrary
{
    //TODO: XML
    public class Person
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

        //TODO: rename Input
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
                    //TODO: {}
                    if (value <= MinAge || value >= MaxAge)
                        //TODO: RSDN
                        throw new IndexOutOfRangeException($"Возраст должен быть в диапазоне: [{MinAge} - {MaxAge}].");

                    _age = value;
                }
                catch (IndexOutOfRangeException ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}");
                }
            }
        }

        //TODO: autoproperty
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
        public Person(string name, string surname, int age, Gender gender)
        {
            InputName = name; 
            InputSurname = surname;
            InputAge = age;
            InputGender = gender;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        public Person()
        { }

        /// <summary>
        /// Валидация языка. Функция оределяет, какому языку соответствует переданная строка name.
        /// </summary>
        private static Language LanguageValidation(string name)
        {
            name = name.Trim();
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

                throw new ArgumentException("Некорректный ввод!");
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
            if (!string.IsNullOrEmpty(InputName)
                && !string.IsNullOrEmpty(InputSurname))
            {
                var nameLanguage = LanguageValidation(InputName);
                var surnameLanguage = LanguageValidation(InputSurname);

                if (nameLanguage != surnameLanguage)
                {
                    throw new FormatException("Имя и фамилия должны быть на одном языке!");
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

        //TODO: rename
        /// <summary>
        /// Функция выводит информацию об экземпляре класса в соответствующем формате.
        /// </summary>
        public string ObjectData()
        {
            //TODO: RSDN
            return $"{InputName} {InputSurname}; Возраст - {InputAge}; Пол - {InputGender}";
        }
        /// <summary>
        /// Функция генерирует человека со случайными параметрами имени, фамилии, возраста и пола.
        /// </summary>
        public static Person GetRandomPerson()
        {
            //TODO: RSDN
            string[] maleNames = { "Gaius", "Winston", "Benito", "Vlad", "Pierre", "Clyde"};
            string[] femaleNames = { "Cleopatra", "Elizabeth", "Mary", "Anne", "Marie ", "Bonnie"};
            string[] surnames = { "Caesar", "Churchill", "Mussolini", "Drakula", "Curie", "Parker"};

            Random random = new Random();

            //TODO: refactor ?:
            // Генерация пола
            Gender tmpGender;
            if (random.Next(2) == 0)
            {
                tmpGender = Gender.Male;
            }
            else
            {
                tmpGender = Gender.Female;
            }

            //TODO: refactor ?:
            // Выбор имени осуществлять будем в зависимости от пола, а также фамилии и возраста
            string tmpName;
            if (tmpGender == Gender.Male)
            {
                tmpName = maleNames[random.Next(maleNames.Length)];
            }
            else
            {
                tmpName = femaleNames[random.Next(femaleNames.Length)];
            }
            // Здесь фамилия и возраст
            string tmpSurname = surnames[random.Next(surnames.Length)];
            int tmpAge = random.Next(MinAge, MaxAge);
            
            return new Person(tmpName, tmpSurname, tmpAge, tmpGender);
        }
    }
} 

