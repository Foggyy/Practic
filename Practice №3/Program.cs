using System;
namespace Practic__3
{

    //Задание 3 (60а)

    class Program
    {
        static void Main(string[] args)
        {
            double x, y, u;

            Console.WriteLine("В данном задании проверяется принадлежность точки заштрихованной части плоскости.");
            Console.WriteLine("Если u = 0, то точка принадлежит плоскости, иначе u = x");
            Console.WriteLine("Введите X");
            while (!double.TryParse(Console.ReadLine(), out x))
                Console.WriteLine("Ошибка ввода, введите действительное число.");
            Console.WriteLine("Введите Y");
            while (!double.TryParse(Console.ReadLine(), out y))
                Console.WriteLine("Ошибка ввода, введите действительное число.");
            if (y >= 0 && (x * x + y * y >= 1) && (x * x + y * y <= 2 * 2))           //x^2 + y^2 = R^2 - уравнение окружности
            {
                Console.WriteLine("Точка принадлежит плоскости:");
                u = 0;
            }
            else
            {
                Console.WriteLine("Точка не принадлежит плоскости:");
                u = x;
            }
            Console.WriteLine("u = " + u);
            Console.ReadLine();
        }
    }
}

