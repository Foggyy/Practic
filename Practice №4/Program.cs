using System;

namespace Practice__4
{
    class Program
    {
        //Задание 4 (725а)
        
        //x + ln (x + 0.5) - 0.5 = 0  - уравнение f(x)=0
        //[0,2] - отрезок, содержащий корень

        /// <summary>
        /// Возврат результата вычислений функции
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        static public double Func(double x)
        {
            return x + Math.Log(x + 0.5) - 0.5;
        }

        static void Main(string[] args)
        {            
            double left = 0;                     //начало отрезка по X
            double right = 2;                    //конец отрезка по X
            double eps;                          //точность вычислений
            double X;                            //найденный корень

            Console.WriteLine("Введите точность вычислений:");
            while (!double.TryParse(Console.ReadLine(), out eps) || eps<=0 || eps>2)
                Console.WriteLine("Ошибка ввода, введите точность больше 0 и не больше 2");

            do
            {
                X = (left + right) / 2;                 //находим середину отрезка
                if (Func(X) * Func(left) <= 0)
                    right = X;                          //смещаем правый край отрезка, если искомый корень находится левее правой границы отрезка
                else
                {
                    left = X;                           //смещаем левый край отрезка, если искомый корень находится правее левой границы отрезка
                }
            } while (Math.Abs(left - right) > eps);

            Console.WriteLine("Найденный корень: " + X);
            Console.ReadLine();
        }
    }
}
