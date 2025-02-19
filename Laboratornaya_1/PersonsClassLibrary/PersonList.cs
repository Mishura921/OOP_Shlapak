using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsClassLibrary
{
    class PersonList
    {
        /// <summary>
        /// Список, содержащий экземпляры класса Person.
        /// </summary>
        private List<Person> peopleArray = new List<Person>();
        /// <summary>
        /// Проверка индекса на вхождение в диапазон длины списка.
        /// </summary>
        private void IsIndexValid(int index)
        {
            if (index < 0 || index >= peopleArray.Count)
            {
                throw new IndexOutOfRangeException
                    ("Индекс вне диапазона!");
            }
        }
        // Методы над списком
        /// <summary>
        /// Добавляет элемент в коллекцию. Принимает на вход экземпляр класса Person.
        /// </summary>
        public void AddElement(Person person)
        {
            peopleArray.Add(person);
        }
        /// <summary>
        /// Удаляет элемент из коллекции. Принимает на вход экземпляр класса Person.
        /// </summary>
        public void DeleteElement(Person person)
        {
            peopleArray.Remove(person);
        }
        /// <summary>
        /// Удаляет элемент коллекции по индексу. Принимает на вход индекс, по которому нужно найти и удалить элемент.
        /// </summary>
        public void DeleteElementByIndex(int index)
        {
            IsIndexValid(index);
            peopleArray.RemoveAt(index);
        }
        /// <summary>
        /// Получает элемент коллекции по индексу. Принимает на вход индекс, по которому нужно найти и вернуть элемент.
        /// </summary>
        public Person GetElementByIndex(int index)
        {
            IsIndexValid(index);
            return peopleArray[index];
        }
        /// <summary>
        /// Возвращает индекс элемента в списке. Принимает на вход элемент, по которому нужно найти и вернуть индекс.
        /// </summary>
        public int GetIndexElementFromList(Person person)
        {
            return peopleArray.IndexOf(person);
        }
        /// <summary>
        /// Подсчитывает количество элементов в коллекции.
        /// </summary>
        public int CountElements()
        {
            return peopleArray.Count;
        }
        /// <summary>
        /// Очищает коллекцию. Не принимает на вход элементов.
        /// </summary>
        public void ClearList()
        {
            peopleArray.Clear();
        }
        /// <summary>
        /// Возвращает элементы коллекции.
        /// </summary>
        public void PrintList()
        {
            if (peopleArray.Count == 0)
            {
                Console.WriteLine("В коллекции отсутствуют элементы!");
                return;
            }
            foreach (Person person in peopleArray)
            {
                Console.WriteLine(person.ObjectData());
            }

        }
    }
}

