using System;

public class Program
{
    public static void Main(string[] args)
    {
        Console.Write("Введите число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Проверяем, является ли число четным
        bool isEven = number % 2 == 0;

        // Проверяем, является ли число палиндромом
        bool isPalindrome = IsPalindrome(number);

        // Выводим результат
        if (isEven)
        {
            Console.WriteLine("Число четное");
        }
        else
        {
            Console.WriteLine("Число нечетное");
        }

        if (isPalindrome)
        {
            Console.WriteLine("Число палиндром");
        }
        else
        {
            Console.WriteLine("Число не палиндром");
        }
    }

    private static bool IsPalindrome(int number)
    {
        string numString = number.ToString();
        string reversedString = new string(numString.Reverse().ToArray());
        return numString == reversedString;
    }
}