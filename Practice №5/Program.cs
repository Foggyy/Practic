using System;

namespace Practice__5
{
    //Задание 5 (402б)

    class Program
    {
        static void Main(string[] args)
        {
            int i, j, n;
            Random rand = new Random();
            Console.WriteLine("Введите n (размерность матрицы):");
            while(!int.TryParse(Console.ReadLine(), out n) || n<2)
                Console.WriteLine("Ошибка ввода, введите целое число больше 1");

            int[,] mas = new int[n,n];                                                  //матрица (двумерный массив)
            int[]b = new int[n];                                                        //последовательность
            bool ok;

            //заполнение матрицы случайными числами
            for (i = 0; i < n; i++)
            {
                ok = true;                                  //переменная для проверки на возрастание
                Console.WriteLine();

                for (j = 0; j < n; j++)
                {
                    mas[i, j] = rand.Next(0, 100);
                    if (j > 0)                              //если в строке не 1 элемент
                    {
                        if (mas[i, j] < mas[i, j - 1])      //если предыдущий элемент меньше чем текущий
                        {
                            ok = false;                     
                        }
                    }
                    Console.Write(mas[i, j] + " ");
                }

                if (ok)                                     //если ok = true (возрастающая последовательность)
                {
                    b[i] = 1;
                }
                else                                        //если ok = false
                {
                    b[i] = 0;
                }
            }

            Console.WriteLine();
            for (i = 0; i < b.Length; i++)                  //цикл для вывода последовательности
            {
                Console.Write(b[i] + " ");
            }

            Console.ReadLine();
        }
    }
}
