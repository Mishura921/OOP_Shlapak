namespace ClassLibrary
{
    public abstract class PersonBase
    {
        /// <summary>
        /// Поле имени человека
        /// </summary>
        private string _firstName = string.Empty;

        /// <summary>
        /// Поле фамилии человека
        /// </summary> 
        private string _lastName = string.Empty;

        /// <summary>
        /// Поле возраста человека
        /// </summary>
        private int _age;

        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
            }
        }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
            }
        }

        /// <summary>
        /// Возраст
        /// </summary>
        public int Age
        {
            get => _age;
            set
            {
                if (value < _minAge || value > _maxAge)
                {
                    throw new ArgumentException($"Возраст должен быть больше {_minAge} и меньше {_maxAge}.");
                }
                _age = value;
            }
        }

        protected int _minAge = 0;

        protected int _maxAge = 125;


        public PersonBase(string firstName, string lastName, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
        }

        public abstract string DoSomeWork();
        


        public string ToString()
        {
            return $"Я {FirstName} {LastName}, мне {Age} лет. ";
        }
    }
}
