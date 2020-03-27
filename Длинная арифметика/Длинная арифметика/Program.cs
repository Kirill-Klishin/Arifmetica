using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Длинная_арифметика
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string num1 = "";
                string num2 = "";
                Console.WriteLine("1.>>Ввести с консоли\n2.>>Считать из файла");
                int Choice = LA.Incorrect_value(Console.ReadLine());
                switch (Choice)
                {
                    case 2:
                        Console.WriteLine("Укажите путь к числам, должны быть записаны посточно\n");
                        string Number_Name = @Console.ReadLine();
                        while (!File.Exists(Number_Name))
                        {
                            Console.WriteLine("Неверный формат файла. Укажите другой");
                            Number_Name = @Console.ReadLine();
                        }
                        StreamReader Number = new StreamReader(Number_Name);
                        num1 = Number.ReadLine(); Console.WriteLine(num1);
                        num2 = Number.ReadLine(); Console.WriteLine(num2);
                        break;
                    case 1:
                        Console.WriteLine("Введите первое положительное число");
                        num1 = Console.ReadLine();
                        Console.WriteLine("Введите второе положительное число");
                        num2 = Console.ReadLine();
                        break;
                }
                Console.WriteLine("Сложение:>>"+LA.Addition(num1, num2));
                Console.WriteLine("Вычитание:>>" + LA.Subtraction(num1, num2));
                Console.WriteLine("Умножение:>>" + LA.Multiplication(num1, num2));
                Console.WriteLine("Деление:");
                LA.Division(num1, num2);
                Console.ReadLine();
            }
        }
    }
}
