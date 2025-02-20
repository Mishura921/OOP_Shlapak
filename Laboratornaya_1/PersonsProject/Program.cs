using PersonsClassLibrary;
using System;

namespace Lab1
{
    /// <summary>
    /// Класс Program
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Класс Main
        /// </summary>
        private static void Main(string[] args)
        {
            
            
            // 'a' Создаём программно 2 массива - списка персон 
            Console.WriteLine("'a' Нажмите любую клавишу, чтобы создать 2 cписка персон по 3 человека в каждом: \n");
            Console.ReadKey();
            Console.WriteLine();
            PersonList men = new PersonList();
            PersonList women = new PersonList();
            // Массив с актёрами
            Person bale = new Person ("Christian", "Bale", 51, Gender.Male);
            Person gosling = new Person ("Ryan", "Gosling", 44, Gender.Male);
            Person dafoe = new Person ("Willem", "Dafoe", 69, Gender.Male);
            // Массив с актриссами
            Person stone = new Person ("Emma", "Stone", 36, Gender.Female);
            Person aniston = new Person ("Jennifer", "Aniston", 56, Gender.Female);
            Person robbie = new Person ("Margot", "Robbie", 34, Gender.Female);
            // Раскидываем экземпляры по коллекциям
            men.AddElement(bale);
            men.AddElement(gosling);
            men.AddElement(dafoe);
            women.AddElement(stone);
            women.AddElement(aniston);
            women.AddElement(robbie);
            Console.WriteLine("\n\tМассивы созданы! Пункт 'a' выполнен! \n\n");

            // 'b' Выводим содержимое списков
            Console.WriteLine("'b' Нажмите любую клавишу, чтобы вывести содержимое каждого списка на экран с соответствующими подписями списков: \n");
            Console.ReadKey();
            Console.WriteLine("\n\tСписок актёров: ");
            men.PrintList();;
            Console.WriteLine("\n\tСписок актрисс: ");
            women.PrintList();
            Console.WriteLine("\n\tСодержимое списков выведено! Пункт 'b' выполнен! \n\n");

            // 'c' Добавление нового человека в первый список
            Console.WriteLine("'c' Нажмите любую клавишу, чтобы добавить нового человека в первый список: \n");
            Console.ReadKey();
            Person newActor = new Person("Tom", "Cruise", 62, Gender.Male);
            men.AddElement(newActor);
            Console.WriteLine($"\n\tСписок актёров пополняет {newActor.InputName} {newActor.InputSurname}!\n");
            Console.WriteLine("\tОбновлённый список актёров: \n");
            men.PrintList();
            Console.WriteLine("\n\tНовый человек добавлен в первый список! Пункт 'c' выполнен! \n\n");

            // 'd' Копирование второго человека из первого списка в конец второго списка
            Console.WriteLine("'d' Нажмите любую клавишу, чтобы скопировать второго человека из первого списка в конец второго списка: \n");
            Console.ReadKey();
            women.AddElement(men.GetElementByIndex(1));
            Console.WriteLine($"\n\tК актриссам подсел {men.GetElementByIndex(1).InputName} {men.GetElementByIndex(1).InputSurname}!\n");
            Console.WriteLine("\tПрежний список актёров: \n");
            men.PrintList();
            Console.WriteLine("\n\tОбновлённый список актрисс (и актёров)0))): \n");
            women.PrintList();
            Console.WriteLine("\n\tВторой человек из первого списка скопирован в конец второго списка! Пункт 'd' выполнен! \n\n");

            // 'e' Удаление второго человека из первого списка
            Console.WriteLine("'e' Нажмите любую клавишу, чтобы удалить второго человека из первого списка: \n");
            Console.ReadKey();
            men.DeleteElementByIndex(1);
            Console.WriteLine($"\n\t{women.GetElementByIndex(3).InputName} {women.GetElementByIndex(3).InputSurname} покинул парней!\n");
            Console.WriteLine("\tМужская компания: \n");
            men.PrintList();
            Console.WriteLine($"\n\tДевочки + {women.GetElementByIndex(3).InputName} {women.GetElementByIndex(3).InputSurname}: \n");
            women.PrintList();
            Console.WriteLine("\n\tВы потеряли Райана Гослинга, теперь он у актрисс! Второй человек из первого списка удалён! Пункт 'e' выполнен! \n\n");

            // 'f' Очистка второго списка
            Console.WriteLine("'f' Нажмите любую клавишу, чтобы очистить содержимое второго списка: \n");
            Console.ReadKey();
            women.ClearList();
            Console.WriteLine($"\n\t{gosling.InputName} {gosling.InputSurname} ушёл с девочками!\n");
            Console.WriteLine("\n\tМужская компания: \n");
            men.PrintList();
            Console.WriteLine("\n\tЖенская компания: \n");
            women.PrintList();
            Console.WriteLine("\n\tВторой список очищен! Пункт 'f' выполнен! \n\n");

            // Ввод данных с клавиатуры
            Console.WriteLine("Нажмите любую клавишу, ввести данные: \n");
            Console.ReadKey();
            Console.WriteLine("\n\tВведите данные: \n");
            //var inputPerson = Person.ReadPersonFromConsole();
            //Console.WriteLine(inputPerson.ObjectData()); 

            // Проверка работы метода по созданию рандомных персонажей
            Console.WriteLine("Нажмите любую клавишу, чтобы сгенерировать персонажа: \n");
            Console.ReadKey();
            Console.Write("Рандомный персонаж...: \n");
            var randomPerson = Person.GetRandomPerson();
            Console.WriteLine(randomPerson.ObjectData() + "!");
        }
        
        
        /// <summary>
        /// Method which allows to enter information by console.
        /// </summary>
        public static Person InputPersonByConsole()
        {
            var person = new Person();

            var actionList = new List<(Action<string>, string)>
            {
                (
                new Action<string>((string property) =>
                {
                    Console.Write($"Enter student {property}: ");
                    person.InputName = Console.ReadLine();
                }), "name"),

                (new Action<string>((string property) =>
                {
                    Console.Write($"Enter student {property}: ");
                    person.InputSurname = Console.ReadLine();
                }), "surname"),

                (new Action<string>((string property) =>
                {
                    Console.Write($"Enter student {property}: ");
                    _ = int.TryParse(Console.ReadLine(), out int tmpAge);
                    person.InputAge = tmpAge;
                }), "age"),

                (new Action<string>((string property) =>
                {
                    Console.Write
                        ($"Enter student {property} (1 - Male or 2 - Female): ");
                    _ = int.TryParse(Console.ReadLine(), out int tmpGender);
                    if (tmpGender < 1 || tmpGender > 2)
                    {
                        throw new IndexOutOfRangeException
                            ("Number must be in range [1; 2].");
                    }

                    var realGender = tmpGender == 1
                        ? Gender.Male
                        : Gender.Female;
                    person.InputGender = realGender;
                }), "gender")
            };

            foreach (var action in actionList)
            {
                ActionHandler(action.Item1, action.Item2);
            }

            return person;
        }

        /// <summary>
        /// Method which is used for doing actions from the list.
        /// </summary>
        private static void ActionHandler(Action<string> action, string propertyName)
        {
            while (true)
            {
                try
                {
                    action.Invoke(propertyName);
                    break;
                }
                catch (Exception exception)
                {
                    if (exception.GetType()
                        == typeof(IndexOutOfRangeException)
                        || exception.GetType() == typeof(FormatException)
                        || exception.GetType() == typeof(ArgumentException))
                    {
                        Console.WriteLine($"Incorrect {propertyName}." +
                        $" Error: {exception.Message}" +
                        $"Please, enter the {propertyName} again.");
                    }
                    else
                    {
                        throw exception;
                    }
                }
            }
        }
    }
}