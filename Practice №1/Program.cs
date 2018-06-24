using System;
using System.IO;

namespace Practice__1
{
    class Program
    {
        

        static int[] MasCounting(int[] mas1, int[] mas2, int[] mas3)
        {
            int[] x = new int[1000];
            int CurrentValue;

            for (int i = 0; i < x.Length; i++)
            {
                CurrentValue = mas1[i] + mas2[i] + mas3[i] + x[i];
                x[i] = CurrentValue % 10;

                if (CurrentValue > 9)
                    x[i + 1] = (CurrentValue - x[i]) / 10;
            }

            return x;
        }

        static string GettingAnswer(int[] x)
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


            int[] mas1 = new int[1000];
            int[] mas2 = new int[1000];
            int[] mas3 = new int[1000];
            int[] NextMas1;
            int[] NextMas2;
            mas1[0] = 1;

            for (int i = 0; i < N - 1; i++)
            {
                NextMas1 = MasCounting(mas1, mas2, mas3);
                NextMas2 = MasCounting(mas1, mas2, mas3);

                mas3 = mas1;
                mas2 = NextMas2;
                mas1 = NextMas1;
            }

            string str = GettingAnswer(MasCounting(mas1, mas2, mas3));
            File.WriteAllText("OUTPUT.txt", str);       //вывод результата
            Console.WriteLine(str);

        }
    }
}
