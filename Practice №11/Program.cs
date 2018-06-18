using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice__11
{
    class Program
    {
        /// <summary>
        /// Шифрование последовательности
        /// </summary>
        /// <param name="a"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        static public int[] Encrypt(int [] a, int N)
        {
            int[] b = new int[N];                                       //последовательность для хранения шифровки
            Console.WriteLine("\nЗашифрованная последовательность:");
            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                {
                    b[i] = a[i];
                }
                else
                if (a[i - 1] == a[i])
                {
                    b[i] = 1;
                }
                else
                {
                    b[i] = 0;
                }

                Console.Write(b[i] + " ");
            }
            return b;
        }

        /// <summary>
        /// Возвращаем расшифрованный массив (в параметры передаем массив, содержащий значения элементов последовательности до шифрования)
        /// </summary>
        /// <param name="a"></param>
        /// <returns></returns>
        static public int[] Decrypt(int[] a, int N)
        {
            int[] b = new int[N];
            Console.WriteLine("\nРасшифрованная последовательность:");
            for (int i = 0; i < N; i++)
            {
                if (i == 0)
                {
                    b[i] = a[i];
                }
                if (i != N-1 && a[i] == a[i+1])
                {
                    b[i] = a[i];
                }
                else
                {
                    b[i] = a[i];
                }
                
                Console.Write(b[i] + " ");
            }
            return b;
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Введите длину последовательности:");
            int N;  
            while(!int.TryParse(Console.ReadLine(), out N) || N<1)              
                Console.WriteLine("Ошибка ввода, введите число не меньше 2");
            int [] a = new int[N];
                   
            Console.WriteLine("Введите элементы последовательности:");
            for (int i = 0; i < N; i++)
            {
                while (!int.TryParse(Console.ReadLine(), out a[i]))              
                    Console.WriteLine("Ошибка ввода, введите целое число");
            }
            int[] b = Encrypt(a, N);                                            //шифрование
            b = Decrypt(a, N);                                                  //расшифровка

            Console.ReadLine();
        }
    }
}
