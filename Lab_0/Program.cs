using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Проверяем, является ли число четным
        bool isEven = number % 2 == 0;

        // Выводим результат
        if (isEven)
        {
            Console.WriteLine("Число четное");
        }
        else
        {
            Console.WriteLine("Число нечетное");
        }
    }
}