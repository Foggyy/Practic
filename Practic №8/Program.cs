using System;
using System.Collections.Generic;


namespace Practic__8
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

    class Program
    {
              
        /// <summary>
        /// Поиск цепей
        /// </summary>
        /// <param name="V"></param>
        /// <param name="E"></param>
        /// <param name="chains"></param>
        static public void SearchChains(int ApexAmount, List<Edge> E, ref List<string> chains)
        {
            int[] colors = new int[ApexAmount];
            for (int i = 0; i < ApexAmount - 1; i++)
            for (int j = i + 1; j < ApexAmount; j++)
            {
                for (int k = 0; k < ApexAmount; k++)
                    colors[k] = 1;                                           //окрашиваем все вершины в белый цвет          
                DFS(i, j, E, colors, (i + 1).ToString(), ref chains);        //передаем i+1 для нумерации вершин
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
        static public void DFS(int i, int j, List<Edge> Edges, int[] colors, string CurrentChain, ref List<string> chains)
        {
            
            if (i != j)                             //если i != j то не дошли до конца цепи
                colors[i] = 2;                      //2 - черный цвет
            else
            {
                chains.Add(CurrentChain);                      //добавляем цепь если дошли до конца
                return;
            }
            for (int vertex = 0; vertex < Edges.Count; vertex++)
            {
                if (colors[Edges[vertex].Apex2] == 1 && Edges[vertex].Apex1 == i)
                {
                    DFS(Edges[vertex].Apex2, j, Edges, colors, CurrentChain + "-" + (Edges[vertex].Apex2 + 1),ref chains);
                    colors[Edges[vertex].Apex2] = 1;                            //возвращаем вершине белый цвет для проверки на другие цепи
                }
                else if (colors[Edges[vertex].Apex1] == 1 && Edges[vertex].Apex2 == i)
                {
                    DFS(Edges[vertex].Apex1, j, Edges, colors, CurrentChain + "-" + (Edges[vertex].Apex1 + 1), ref chains);
                    colors[Edges[vertex].Apex1] = 1;                            //возвращаем вершине белый цвет для проверки на другие цепи
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

            SearchChains(ApexAmount, Edges,ref chains);                 //передаем кол-во вершин, список с ребрами и список для записи цепей
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
