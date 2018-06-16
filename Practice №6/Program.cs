using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice__6
{

    class Program
    {
        public static double Recursion(int index, int decreasingIndex)
        {
            double result=0;
            if (decreasingIndex > 2 && index - decreasingIndex >= 3)
            {
                result = (double)3 / 2 * Recursion(index, decreasingIndex - 1) - (double)2 / 3 * Recursion(index, decreasingIndex - 2) -
                         (double)1 / 3 * Recursion(index, decreasingIndex);
            }

            return result;
        }

        static void Main(string[] args)
        {

            int M;                                                                  //
            Console.WriteLine("Введите максимум последовательности:");
            while (!int.TryParse(Console.ReadLine(), out M) || M < 0)
                Console.WriteLine("Ошибка ввода, введите целое число больше 0");

            double a1, a2, a3;
            Console.WriteLine("Введите первый элемент последовательности:");
            while (!double.TryParse(Console.ReadLine(), out a1) || a1 <= M)
                Console.WriteLine("Ошибка ввода, введите число больше 0");

            Console.WriteLine("Введите второй элемент последовательности:");
            while (!double.TryParse(Console.ReadLine(), out a2) || a2 <= M)
                Console.WriteLine("Ошибка ввода, введите целое число больше 0");

            Console.WriteLine("Введите третий элемент последовательности:");
            while (!double.TryParse(Console.ReadLine(), out a3) || a3 <= M)
                Console.WriteLine("Ошибка ввода, введите целое число больше 0");

            int J = 3;      //final index
            double сurrent = Recursion(J,J);

            while (Math.Abs(сurrent) > M)
            {
                J++;
                сurrent = Recursion(J, J);
            }

            Console.WriteLine("Элемент последовательности: "+сurrent);

            Console.ReadLine();
        }
    }
}
