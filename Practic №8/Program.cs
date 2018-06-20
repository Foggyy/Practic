using System;
using System.Collections.Generic;


namespace Practic__8
{

    class Program
    {
        
        /// <summary>
        /// Класс для ребер графа
        /// </summary>
        public class Edge
        {
            public int Apex1, Apex2;

            public Edge(int Apex1, int Apex2)
            {
                this.Apex1 = Apex1;
                this.Apex2 = Apex2;
            }
        }
    
        /// <summary>
        /// Поиск цепей
        /// </summary>
        /// <param name="V"></param>
        /// <param name="E"></param>
        /// <param name="chains"></param>
        static public void chainsSearch(int ApexAmount, List<Edge> E, ref List<string> chains)
        {
            int[] color = new int[ApexAmount];
            for (int i = 0; i < ApexAmount - 1; i++)
            for (int j = i + 1; j < ApexAmount; j++)
            {
                for (int k = 0; k < ApexAmount; k++)
                    color[k] = 1;
                DFSchain(i, j, E, color, (i + 1).ToString(), ref chains);
                //поскольку в C# нумерация элементов начинается с нуля, то
                //для удобочитаемости результатов в строку передаем i + 1
            }
        }

        /// <summary>
        /// Алгоритм обхода графа в глубину
        /// </summary>
        /// <param name="u"></param>
        /// <param name="endV"></param>
        /// <param name="E"></param>
        /// <param name="color"></param>
        /// <param name="s"></param>
        /// <param name="chains"></param>
        static public void DFSchain(int u, int endV, List<Edge> E, int[] color, string s, ref List<string> chains)
        {
            //вершину не следует перекрашивать, если u == endV (возможно в endV есть несколько путей)
            if (u != endV)
                color[u] = 2;
            else
            {
                chains.Add(s);
                return;
            }
            for (int w = 0; w < E.Count; w++)
            {
                if (color[E[w].Apex2] == 1 && E[w].Apex1 == u)
                {
                    DFSchain(E[w].Apex2, endV, E, color, s + "-" + (E[w].Apex2 + 1),ref chains);
                    color[E[w].Apex2] = 1;
                }
                else if (color[E[w].Apex1] == 1 && E[w].Apex2 == u)
                {
                    DFSchain(E[w].Apex1, endV, E, color, s + "-" + (E[w].Apex1 + 1), ref chains);
                    color[E[w].Apex1] = 1;
                }
            }
        }



        static void Main(string[] args)
        {
            List<Edge> Edges = new List<Edge>();
            List<string> chains = new List<string>();
            int ApexAmount;
            Random rand = new Random();
            Console.WriteLine("Введите количество вершин:");
            while(!int.TryParse(Console.ReadLine(), out ApexAmount) || ApexAmount < 1)
                Console.WriteLine("Ошибка ввода. Введите целое число больше 0");
            int[,] graph = new int[ApexAmount, ApexAmount];

            for (int i = 0; i < ApexAmount; i++)
            {
                for (int j = 0; j < ApexAmount; j++)
                {
                    if (i == j)
                    {
                        graph[i, j] = 0;
                    }
                    else
                    {
                        graph[i, j] = rand.Next(0, 2);
                        graph[j, i] = graph[i, j];                       
                    }
                }
            }

            for (int i = 0; i < ApexAmount; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < ApexAmount; j++)
                {
                    Console.Write(graph[i,j]+" ");
                    if (graph[i, j] == 1)
                        Edges.Add(new Edge(i, j));
                }
            }

            chainsSearch(ApexAmount, Edges,ref chains);
            Console.WriteLine();
            Console.WriteLine("Введите K (кол-во вершин в цепи:)");
            int K;
            bool ok = false;
            while (!int.TryParse(Console.ReadLine(), out K))
                Console.WriteLine("Ошибка ввода.");

            Console.WriteLine("Цепь с заданным количеством вершин:");
            for (int i = 0; i < chains.Count; i++)
            {
                if (chains[i].Split('-').Length == K && ok == false)
                {
                    ok = true;
                    Console.WriteLine(chains[i]);
                }
            }
            if (!ok)
            {
                Console.WriteLine("Цепей с заданным количеством вершин не найдено");
            }
            
            Console.ReadLine();
        }
    }
}
