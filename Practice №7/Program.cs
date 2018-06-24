using System;
using System.Collections.Generic;

//Задание 7 (21) Двоичный суффиксный код Хаффмана

namespace Practice__7
{

    class HuffmanTree : IComparable
    {
        public double Value;
        public string Word;
        public HuffmanTree left;
        public HuffmanTree right;

        /// <summary>
        /// Конструктор без параметров
        /// </summary>
        public HuffmanTree()
        {
            left = null;
            right = null;
            Value = 0;
            Word = null;
        }

        /// <summary>
        /// Конструктор с параметрами
        /// </summary>
        /// <param name="value"></param>
        public HuffmanTree(double value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Вывод
        /// </summary>
        /// <param name="l"></param>
        public void Show(int l = 0)
        {
            if (left != null)
                right.Show(l + 3);   // переход к левому поддереву

            for (int i = 0; i < l; i++)   // формирование отступа
                Console.Write(" ");
            Console.WriteLine(this.Word); // печать узла
            if (right != null)
                right.Show(l + 3);  // переход к правому поддереву
        }

        public int CompareTo(object obj)
        {
            HuffmanTree tree = obj as HuffmanTree;
            if (this.Value < tree.Value)
                return -1;
            if (this.Value > tree.Value)
                return 1;
            else
                return 0;
        }

        public override string ToString()
        {
            return "tree: " + this.Value;
        }
    }

    class Code
    {
        private static List<string> ListOfCode;

        public static List<string> GetCode(HuffmanTree mainTree)
        {
            ListOfCode = new List<string>();
            TreeRunning(mainTree);
            return ListOfCode;
        }
        private static void TreeRunning(HuffmanTree tree, string lastLetters = "")
        {
            if (tree.right == null && tree.left == null)
            {
                tree.Word = lastLetters;
                ListOfCode.Add(lastLetters);
            }
            if (tree.right != null)
                TreeRunning(tree.right, lastLetters + "0");
            if (tree.left != null)
                TreeRunning(tree.left, lastLetters + "1");
        }
    }

    class Program
    {
        static double GetListSum(List<double> list)
        {
            double sum = 0;
            foreach (var t in list)
                sum += t;
            return sum;
        }

        static void Main(string[] args)
        {
            List<double> Frequences = new List<double>();

            Console.WriteLine("Введите частоты символов.");
            Console.WriteLine("Когда сумма элементов дойдет до 1, ввод остановится");
            while (true)
            {
                double current;
                while(!double.TryParse(Console.ReadLine(), out current) || current<0)
                Console.WriteLine("Ошибка ввода, введите вещественное число не больше 1 и не меньше 0.");
                Frequences.Add(current);
                double sum = GetListSum(Frequences);
                if (sum > 1)
                {
                    Console.WriteLine("Сумма частот превысила 1. Введите частоты заново.");
                    Frequences = new List<double>(); // если введённые числа в сумме превысили единицу
                }
                if (sum == 1)
                {
                    Console.WriteLine("Ввод завершен.");
                    break;
                }
            }

            Console.WriteLine("\nВведенные частоты:");
            Frequences.Sort();
            foreach (var t in Frequences)
                Console.WriteLine(t);

            List<HuffmanTree> treeList = new List<HuffmanTree>();
            for (int i = 0; i < Frequences.Count; i++)
            {
                treeList.Add(new HuffmanTree(Frequences[i]));
            }

            while (treeList.Count > 1)
            {
                HuffmanTree first = treeList[0];
                HuffmanTree second = treeList[1];

                treeList[1] = new HuffmanTree(first.Value + second.Value);
                treeList[1].right = first;
                treeList[1].left = second;
                treeList.RemoveAt(0);
                treeList.Sort();
            }

            List<string> HuffmanCode = Code.GetCode(treeList[0]);

            Console.WriteLine("\nКод: ");
            foreach (var t in HuffmanCode)
                Console.WriteLine(t);

            Console.ReadLine();
        }
    }
}
