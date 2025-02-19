using PersonsClassLibrary;
using System;

namespace Lab1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // Создаём 2 массива
            Console.WriteLine("Нажмите любую клавишу, чтобы создать 2 cписка персон по 3 человека в каждом: \n");
            Console.ReadKey();
            Console.WriteLine("\n");
            PersonList men = new PersonList();
            PersonList women = new PersonList();
            // Массив с актёрами
            Person gosling = new Person ("Ryan", "Gosling", 44, Gender.Male);
            Person bale = new Person ("Christian", "Bale", 51, Gender.Male);
            Person dafoe = new Person ("Willem", "Dafoe", 69, Gender.Male);
            // Массив с актриссами
            Person stone = new Person ("Emma", "Stone", 36, Gender.Female);
            Person aniston = new Person ("Jennifer", "Aniston", 56, Gender.Female);
            Person robbie = new Person ("Margot", "Robbie", 34, Gender.Female);
            // Раскидываем экземпляры по коллекциям
            men.AddElement(gosling);
            men.AddElement(bale);
            men.AddElement(dafoe);
            women.AddElement(stone);
            women.AddElement(aniston);
            women.AddElement(robbie);
            Console.WriteLine("Массивы созданы! Пункт 'a' выполнен! \n\n");

            // Выводим содержимое списков
            Console.WriteLine("Нажмите любую клавишу, чтобы вывести содержимое каждого списка на экран с соответствующими подписями списков: \n");
            Console.ReadKey();
            Console.WriteLine("\n");

            Console.WriteLine("Список актёров: ");
            men.PrintList();
            Console.WriteLine("\n");
            Console.WriteLine("Список актрисс: ");
            women.PrintList();

            Console.WriteLine("Содержимое списков выведено! Пункт 'b' выполнен! \n\n");

            // Добавление нового человека в первый список
            // Console.WriteLine("Нажмите любую клавишу, чтобы добавить нового человека в первый список \n");
        }
    }
}
