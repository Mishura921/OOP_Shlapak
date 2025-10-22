using System;
using System.Collections.Generic;
using Model;

namespace ConsoleLoader
{
    /// <summary>
    /// Добавление параметров фигур с консоли
    /// </summary>
    public static class AddConsoleFigure
    {
        /// <summary>
        /// Метод ввода данных о прямоугольнике
        /// </summary>
        /// <returns>Объект - Прямоугольник</returns>
        public static Rectangle GetNewRectangleFromKeyboard()
        {
            var rectangle = new Rectangle();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    string parameter = "Длина";
                    Console.WriteLine($"{parameter} прямоугольника, м: ");
                    rectangle.Length = ReadFromConsoleAndParse();
                }),
                new Action(() =>
                {
                    string parameter = "Ширина";
                    Console.WriteLine($"{parameter} прямоугольника, м: ");
                    rectangle.Width = ReadFromConsoleAndParse();
                }),          
            };
            actions.ForEach(SetValue);
            return rectangle;
        }

        /// <summary>
        /// Метод ввода данных о треугольнике
        /// </summary>
        /// <returns>Объект - Треугольник</returns>
        public static Triangle GetNewTriangleFromKeyboard()
        {
            var triangle = new Triangle();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    string parameter = "Длина стороны";
                    Console.WriteLine($"{parameter} треугольника, м: ");
                    triangle.EdgeLenght =
                        ReadFromConsoleAndParse();
                }),
                new Action(() =>
                {
                    string parameter = "Высота";
                    Console.WriteLine($"{parameter} треугольника, м: ");
                    triangle.Height =
                        ReadFromConsoleAndParse();
                }),
            };
            actions.ForEach(SetValue);
            return triangle;
        }

        /// <summary>
        /// Метод ввода данных о М.Круге
        /// </summary>
        /// <returns>Объект - Круг</returns>
        public static Circle GetNewCircleFromKeyboard()
        {
            var circle = new Circle();
            var actions = new List<Action>()
            {
                new Action(() =>
                {
                    Console.WriteLine("Радиус круга, м: ");
                    circle.Radius =
                        ReadFromConsoleAndParse();
                }),
            };
            actions.ForEach(SetValue);
            return circle;
        }

        /// <summary>
        /// Метод чтения с консоли с преобразованием 
        /// в тип данных double
        /// </summary>
        public static double ReadFromConsoleAndParse()
        {
            return double.Parse(Console.ReadLine().Replace('.', ','));
        }

        // <summary>
        /// Метод получения пользовательского ввода
        /// и задания параметра
        /// </summary>
        public static void SetValue(Action action)
        {
            while (true)
            {
                try
                {
                    action.Invoke();
                    return;
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n{e.Message}\n");
                }
            }
        }
    }
}