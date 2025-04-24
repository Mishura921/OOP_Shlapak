using ClassLibrary;
using System;

// <summary>
// Класс программ
// </summary>
internal class Program
{
    /// <summary>
    /// Исполнение программы
    /// </summary>
    /// <param name="args">аргумент</param>
    public static void Main(string[] args)
    {
        var personList = new List<PersonBase>()
        {            
            new Student("Иван", "Иванов", 20, "О-5КМ31"),
            new Teacher("Сергей", "Сергеевич", 48, "Лютиковедения")
        };




        foreach (var person in personList) 
        {
            Console.WriteLine(person.DoSomeWork());
            Console.ReadKey();
        }
    }
}