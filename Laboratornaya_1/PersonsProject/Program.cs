using PersonsClassLibrary;
using System;

namespace Lab1
{
    /// <summary>
    /// Класс Program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Класс Main.
        /// </summary>
        private static void Main(string[] args)
        {
            Console.WriteLine(
                "'a' Нажмите любую клавишу, чтобы создать 2 " +
                "списка персон по 3 человека в каждом: \n");
            Console.ReadKey();
            Console.WriteLine();
            PersonList men = new PersonList();
            PersonList women = new PersonList();

            Person bale = new Person(
                "Christian", "Bale", 51, Gender.Male);
            Person gosling = new Person(
                "Ryan", "Gosling", 44, Gender.Male);
            Person dafoe = new Person(
                "Willem", "Dafoe", 69, Gender.Male);

            Person stone = new Person(
                "Emma", "Stone", 36, Gender.Female);
            Person aniston = new Person(
                "Jennifer", "Aniston", 56, Gender.Female);
            Person robbie = new Person(
                "Margot", "Robbie", 34, Gender.Female);

            men.AddElement(bale);
            men.AddElement(gosling);
            men.AddElement(dafoe);
            women.AddElement(stone);
            women.AddElement(aniston);
            women.AddElement(robbie);
            Console.WriteLine("\n\tМассивы созданы! Пункт 'a' " +
                "выполнен! \n\n");

            Console.WriteLine("'b' Нажмите любую клавишу, чтобы " +
                "вывести содержимое каждого списка на экран с " +
                "соответствующими подписями списков: \n");
            Console.ReadKey();
            Console.WriteLine("\n\tСписок актёров: ");
            PrintList(men);
            Console.WriteLine("\n\tСписок актрисс: ");
            PrintList(women);
            Console.WriteLine("\n\tСодержимое списков выведено! " +
                "Пункт 'b' выполнен! \n\n");

            Console.WriteLine(
                "'c' Нажмите любую клавишу, чтобы добавить нового " +
                "человека в первый список: \n");
            Console.ReadKey();
            Person newActor = new Person("Tom", "Cruise", 62, Gender.Male);
            men.AddElement(newActor);
            Console.WriteLine(
                $"\n\tСписок актёров пополняет {newActor.Name} " +
                $"{newActor.Surname}!\n");

            Console.WriteLine("\tОбновлённый список актёров: \n");
            PrintList(men);
            Console.WriteLine(
                "\n\tНовый человек добавлен в первый список! " +
                "Пункт 'c' выполнен! \n\n");

            Console.WriteLine(
                "'d' Нажмите любую клавишу, чтобы скопировать второго " +
                "человека из первого списка в конец второго списка: \n");
            Console.ReadKey();
            women.AddElement(men.GetElementByIndex(1));
            Console.WriteLine(
                $"\n\tК актриссам подсел " +
                $"{men.GetElementByIndex(1).Name} " +
                $"{men.GetElementByIndex(1).Surname}!\n");
            Console.WriteLine("\tПрежний список актёров: \n");
            PrintList(men);
            Console.WriteLine("\n\tОбновлённый список актрисс " +
                "(и актёров)0))): \n");
            PrintList(women);
            Console.WriteLine("\n\tВторой человек из первого списка " +
                "скопирован в конец второго списка! Пункт 'd' выполнен! \n\n");

            Console.WriteLine( "'e' Нажмите любую клавишу, чтобы удалить " +
                "второго человека из первого списка: \n");
            Console.ReadKey();
            men.DeleteElementByIndex(1);
            Console.WriteLine(
                $"\n\t{women.GetElementByIndex(3).Name} " +
                $"{women.GetElementByIndex(3).Surname} покинул парней!\n");
            Console.WriteLine("\tМужская компания: \n");
            PrintList(men);
            Console.WriteLine(
                $"\n\tДевочки + {women.GetElementByIndex(3).Name}" +
                $" {women.GetElementByIndex(3).Surname}: \n");
            PrintList(women);
            Console.WriteLine(
                "\n\tВы потеряли Райана Гослинга, теперь " +
                "он у актрисс! Второй человек из первого списка удалён! " +
                "Пункт 'e' выполнен! \n\n");

            Console.WriteLine("'f' Нажмите любую клавишу, чтобы очистить " +
                "содержимое второго списка: \n");
            Console.ReadKey();
            women.ClearList();
            Console.WriteLine($"\n\t{gosling.Name} {gosling.Surname} " +
                $"ушёл с девочками!\n");
            Console.WriteLine("\n\tМужская компания: \n");
            PrintList(men);
            Console.WriteLine("\n\tЖенская компания: \n");
            PrintList(women);
            Console.WriteLine("\n\tВторой список очищен! Пункт 'f' " +
                "выполнен! \n\n");

            Console.WriteLine("Нажмите любую клавишу, ввести данные: \n");
            Console.ReadKey();
            Console.WriteLine("\n\tВведите данные: \n");
            var inputPerson = InputPersonByConsole();
            Console.WriteLine(inputPerson.Info()); 

            Console.WriteLine("Нажмите любую клавишу, чтобы сгенерировать " +
                "персонажа: \n");
            Console.ReadKey();
            Console.Write("\nРандомный персонаж...: \n");
            var randomPerson = Person.GetRandomPerson();
            Console.WriteLine(randomPerson.Info() + "!");
        }
        
        /// <summary>
        /// Метод для ввода с клавиатуры в консоль
        /// </summary>
        public static Person InputPersonByConsole()
        {
            var person = new Person();

            var actionList = new List<(Action<string>, string)>
            {
                (
                new Action<string>((string property) =>
                {
                    Console.Write($"Enter person's {property}: ");
                    person.Name = Console.ReadLine();
                }), "name"),

                (new Action<string>((string property) =>
                {
                    Console.Write($"Enter person's {property}: ");
                    person.Surname = Console.ReadLine();
                }), "surname"),

                (new Action<string>((string property) =>
                {
                    Console.Write($"Enter person's {property}: ");
                    _ = int.TryParse(Console.ReadLine(), out int tmpAge);
                    person.Age = tmpAge;
                }), "age"),

                (new Action<string>((string property) =>
                {
                    Console.Write
                        ($"Enter person's {property} (1 - Male or 2 - Female): ");
                    _ = int.TryParse(Console.ReadLine(), out int tmpGender);
                    if (tmpGender < 1 || tmpGender > 2)
                    {
                        throw new IndexOutOfRangeException
                            ("Должно быть в диапазоне [1; 2].");
                    }

                    var realGender = tmpGender == 1
                        ? Gender.Male
                        : Gender.Female;
                    person.Gender = realGender;
                }), "gender")
            };

            foreach (var action in actionList)
            {
                ActionHandler(action.Item1, action.Item2);
            }

            return person;
        }

        /// <summary>
        /// Метод воспроизводящий действия из списка действий
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

        /// <summary>
        /// Возвращает элементы коллекции.
        /// </summary>
        public static void PrintList(PersonList personList)
        {
            if (personList.Count == 0)
            {
                Console.WriteLine("Список пуст!");
                return;
            }
            for (int i = 0; i < personList.Count; i++)
            {
                Person person = personList.GetElementByIndex(i);
                Console.WriteLine(person.Info());
            }
        }
    }
}