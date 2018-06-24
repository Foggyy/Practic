using System;
using System.Collections.Generic;

namespace Practice__6
{

    class Program
    {
        /// <summary>
        /// Получение элемента последовательности (рекурсия)
        /// </summary>
        /// <param name="specIndex"></param>
        /// <param name="index"></param>
        /// <param name="sequence"></param>
        /// <returns></returns>
        public static double ElementOfSequence(int LastIndex, int ElementIndex, List<double> mas)
        {
            double Element;
            double ak1, ak2, ak3;
            if (LastIndex - ElementIndex <= 3 && ElementIndex > 2)      //если индекс больше чем индексы первых 3 элементов последовательности
            {
                ak1 = (double)3/2 * ElementOfSequence(LastIndex, ElementIndex - 1, mas);
                ak2 = (double)2/3 * ElementOfSequence(LastIndex, ElementIndex - 2, mas);
                ak3 = (double)1/3 * ElementOfSequence(LastIndex, ElementIndex - 3, mas);
                Element = ak1 - ak2 - ak3;
                return Element;
            }
            else                                                        //иначе, вернуть элемент последовательности
                return (double)mas[ElementIndex];
        }

        static void Main(string[] args)
        {
            int N;
            Console.WriteLine("Введите кол-во элементов последовательности:");
            while(!int.TryParse(Console.ReadLine(), out N) || N<4)
                Console.WriteLine("Ошибка ввода. Введите целое число больше 3");

            double M;
            Console.WriteLine("Введите сколь угодно малое вещественное число(эпсилон):");
            while(!double.TryParse(Console.ReadLine(), out M) || M<0)
                Console.WriteLine("Ошибка ввода. Введите целое число больше 0");

            List<double> mas = new List<double>();                              //список для хранения последовательности

            Console.WriteLine("Введите 3 первых элемента последовательности:");
            for (int i = 0; i < 3; i++)
            {
                double Element;
                while (!double.TryParse(Console.ReadLine(), out Element) || Element <= M)
                    Console.WriteLine("Ошибка ввода. Введите число больше чем M (эпсилон)");
                mas.Add(Element);
            }

            int J = 3;                                                              //номер текущего элемента
            double LastElement = ElementOfSequence(J, J, mas);

            while (Math.Abs(LastElement) > M)
            {
                mas.Add(LastElement);
                J++;
                LastElement = ElementOfSequence(J, J, mas);
            }

            Console.Write("Вывод последовательности:: ");
            for (int i = 0; i < mas.Count; i++)
            {
                Console.Write(mas[i] + " ");
            }                
            Console.WriteLine();


            if (LastElement == M)
                Console.WriteLine("Последний элемент последовательности {0} равен M", LastElement);
            else
                Console.WriteLine("Последний элемент последовательности {0} не равен M", LastElement);

            if (N > J)
            {
                Console.WriteLine("N > J");
            }
            if (N == J)
            {
                Console.WriteLine("N = J");
            }
            if (N < J)
            {
                Console.WriteLine("N < J");
            }
               

            Console.ReadLine();
        }        
    }
}