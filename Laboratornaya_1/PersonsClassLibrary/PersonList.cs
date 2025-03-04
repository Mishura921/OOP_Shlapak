﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsClassLibrary
{
    //TODO: XML+
    /// <summary>
    /// Класс, содержащий массив персонажей
    /// </summary>
    public class PersonList
    {
        //TODO: RSDN+
        /// <summary>
        /// Коллекция экземпляров класса Person, представляющая людей.
        /// </summary>
        private List<Person> _peopleArray = new List<Person>();

        public List<Person> PeopleArray => _peopleArray;

        /// <summary>
        /// Метод, который проверяет корректность входного индекса.
        /// </summary>
        /// <param name="index">Входной индекс.</param>
        /// <exception cref="IndexOutOfRangeException">
        /// Индекс выходит за пределы допустимого диапазона.
        /// </exception>
        private void IsIndexValid(int index)
        {
            if (index < 0 || index >= PeopleArray.Count)
            {
                throw new IndexOutOfRangeException
                    ("Индекс вне диапазона!");
            }
        }

        // Методы над списком

        /// <summary>
        /// Функция для добавления человека в конец массива.
        /// </summary>
        /// <param name="person">Человек, которого добавляют.</param>
        public void AddElement(Person person)
        {
            PeopleArray.Add(person);
        }
        /// <summary>
        /// Метод, который удаляет человека.
        /// </summary>
        /// <param name="person">Человек, которого удаляют.</param>
        
        public void DeleteElement(Person person)
        {
            PeopleArray.Remove(person);
        }
        /// <summary>
        /// Метод, который находит человека в массиве по индексу.
        /// </summary>
        /// <param name="index">Индекс человека в массиве.</param>
        /// <returns>Человек из массива.</returns>
        public void DeleteElementByIndex(int index)
        {
            IsIndexValid(index);
            PeopleArray.RemoveAt(index);
        }
        /// <summary>
        /// Метод, который находит человека в массиве по индексу.
        /// </summary>
        /// <param name="index">Индекс человека в массиве.</param>
        /// <returns>Человек из массива.</returns>
        public Person GetElementByIndex(int index)
        {
            IsIndexValid(index);
            return PeopleArray[index];
        }
        /// <summary>
        /// Метод, который возвращает индекс элемента в списке.
        /// </summary>
        /// <param name="index">Имя человека</param>
        /// <returns>Индекс человека</returns>
        public int GetIndexElementFromList(Person person)
        {
            return PeopleArray.IndexOf(person);
        }

        /// <summary>
        /// Подсчитывает количество элементов в коллекции.
        /// </summary>
        public int Count => PeopleArray.Count;
        /// <summary>
        /// Очищает коллекцию. Не принимает на вход элементов.
        /// </summary>
        public void ClearList()
        {
            PeopleArray.Clear();
        }

        //TODO: remove+
    }
}

