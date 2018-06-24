using System;
using System.IO;

namespace Practice__1
{
    class Program
    {
        

        static int[] Addition(int[] a, int[] b, int[] c)
        {
            int[] x = new int[1000];
            int currentValue;

            for (int i = 0; i < x.Length; i++)
            {
                currentValue = a[i] + b[i] + c[i] + x[i];
                x[i] = currentValue % 10;

                if (currentValue > 9)
                    x[i + 1] = (currentValue - x[i]) / 10;
            }

            return x;
        }

        static string Cutting(int[] x)
        {
            string answer = string.Empty;
            string finaly = string.Empty;

            foreach (int i in x)
                if (i != 0 && finaly != string.Empty)
                {
                    answer = i + finaly + answer;
                    finaly = string.Empty;
                }
                else if (i != 0)
                    answer = i + answer;
                else
                    finaly += '0';

            if (answer == string.Empty) return "0";
            return answer;
        }



        static void Main(string[] args)
        {
            int N;
            string dataIn = File.ReadAllText("INPUT.txt"); //ввод всего файла в строку
            N = Convert.ToInt16(dataIn);


            int[] a = new int[1000];
            int[] b = new int[1000];
            int[] c = new int[1000];
            int[] nextA;
            int[] nextB;
            a[0] = 1;

            for (int i = 0; i < N - 1; i++)
            {
                nextA = Addition(a, c, b);
                nextB = Addition(a, a, b);

                c = a;
                b = nextB;
                a = nextA;
            }

            string str = Cutting(Addition(a, b, c));
            File.WriteAllText("OUTPUT.txt", str);       //вывод результата
            Console.WriteLine(str);

        }
    }
}
