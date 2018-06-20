using System;


namespace Practice_10
{
       //Задание 10 (531 Абрамов)    

       class Program
       {
            
           /// <summary>
           /// Ввод значений
           /// </summary>
           /// <param name="mas"></param>
           /// <param name="N"></param>
           /// <returns></returns>
           public static double[] Input(int N)
           {
               double[] mas = new double[N];
               double value;
               Console.WriteLine("Введите значения:");
               for (int i = 0; i < N; i++)
               {
                     while (!double.TryParse(Console.ReadLine(), out value))
                     Console.WriteLine("Ошибка ввода, введите целое число.");
                     mas[i] = value;
               }
               return mas;
           }
           
           /// <summary>
           /// Вывод последовательности
           /// </summary>
           /// <param name="mas"></param>
           /// <param name="N"></param>
           public static void Show(double[] mas, int N)
           {
               for (int i = 0; i < N; i++)
               {

                     Console.Write(mas[i] + " ");

               }
           }
         
           /// <summary>
           /// Получаем последовательность
           /// </summary>
           /// <param name="mas"></param>
           /// <param name="N"></param>
           /// <returns></returns>
           public static double[] Sequence(double[] mas, ref int N)
           {
               
               double[] NewMas = new double[N-1];

               for (int i = 0; i < N-1; i++)
               {
                     NewMas[i] = mas[i] - mas[N-1];
               }
               N--;

               return NewMas;
           }

           static void Main(string[] args)
           {
                int N;

                Console.WriteLine("Введите длину последовательности (N):");
                while (!int.TryParse(Console.ReadLine(), out N) || N<2)
                    Console.WriteLine("Ошибка ввода, введите целое число больше 1");
                double[] mas = new double[N];
                mas = Input(N);
                
                Console.WriteLine("Вывод введенных значений:");
                Show(mas, N);
                                
                Console.WriteLine("\nВывод последовательности:");
                mas = Sequence(mas, ref N);
                Show(mas,N);
                
                Console.ReadLine();
           }
       }
}

