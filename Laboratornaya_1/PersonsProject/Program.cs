using ClassPerson;
using ClassesPersons;
using PersonsClassLibrary;

namespace Persons
{
    /// <summary>
    /// Основной класс программы.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// Главный метод программы.
        /// </summary>
        public static void Main(string[] args)
        {
            Console.WriteLine("Нажмите любую клавишу для " +
                "создания списка и добавления 7 человек.");
            Console.WriteLine();
            var listOfPeople = new PersonList();
            var rnd = new Random();

            for (var i = 0; i < 7; i++)
            {
                PersonBase rndPerson = rnd.Next(2) == 0
                    ? Adult.GetRandomPerson()
                    : Child.GetRandomPerson();
                listOfPeople.Add(rndPerson);
            }

            _ = Console.ReadKey();

            Console.WriteLine("Люди из списка.");
            Console.WriteLine();
            PrintList(listOfPeople);

            Console.WriteLine("Нажмите любую клавишу " +
                "для определения типа 4-ого человека.");
            _ = Console.ReadKey();
            Console.WriteLine();
            var person = listOfPeople.GetElement(3);
            switch (person)
            {
                //TODO: RSDN
                case Adult personAdult:
                    Console.WriteLine($"Тип: Взрослый");
                    Console.WriteLine(personAdult.GetCar());
                    break;
                case Child personChild:
                    Console.WriteLine($"Тип: Ребёнок");
                    Console.WriteLine(personChild.GetHobby());
                    break;
                default:
                    Console.WriteLine($"Тип: Неизвестный");
                    break;
            }

            _ = Console.ReadKey();

        }

        /// <summary>
        /// Метод, который позволяет вывести список людей.
        /// </summary>
        /// <param name="personList">Экземпляр класса PersonList.</param>
        private static void PrintList(PersonList personList)
        {
            if (personList == null)
            {
                throw new NullReferenceException("Список не существует.");
            }

            if (personList.Count != 0)
            {
                for (int i = 0; i < personList.Count; i++)
                {
                    var tmpPerson = personList.GetElement(i);
                    Console.WriteLine(tmpPerson.GetInfo());
                }
            }
            else
            {
                Console.WriteLine("Список пуст.");
            }
        }
    }
}