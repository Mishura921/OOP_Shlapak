using System;
using Model;

namespace ConsoleLoader
{
    internal class Program
    {
        /// <summary>
        /// Начало программы
        /// </summary>
        /// <param name="args">Параметры</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Программа для расчёта геометрических " +
                "площадей.\n" + "Для продолжения нажмите любую клавишу...");
            Console.ReadKey();

            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("Доступные операции:");
                Console.WriteLine("1 - Расчёт площади треугольника");
                Console.WriteLine("2 - Расчёт площади прямоугольника");
                Console.WriteLine("3 - Расчёт площади круга");
                Console.WriteLine("4 - Завершение работы");
                var consoleKey = Console.ReadLine();
                switch (consoleKey)
                {   
                    //TODO: RSDN
                    case "1":
                            GetSquareInfo(AddConsoleFigure.
                                GetNewTriangleFromKeyboard());
                        break;
                    case "2":
                            GetSquareInfo(AddConsoleFigure.
                                GetNewRectangleFromKeyboard());
                            break;
                    case "3":
                            GetSquareInfo(AddConsoleFigure.
                                GetNewCircleFromKeyboard());
                            break;
                    case "4":
                            Environment.Exit(0);
                            break;
                    default:
                            Console.WriteLine("Ошибка: " +
                                "ожидается целое число от 1 до 4.");
                            break;
                }
            }
        }

        /// <summary>
        /// Метод вывода информации в консоль
        /// </summary>
        /// <param name="figure">Объект - Фигура</param>
        public static void GetSquareInfo(FigureBase figure)
        {
            Console.WriteLine($"Площадь фигуры равна: " +
                $"{figure.Square} м^2.");
        }
    }
}