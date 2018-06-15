using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practic__2
{
    //можем перебрать 10000 квадратов (1<=N<=100) (N^2)
    //Ax+By+C = 0 >0 <0
    //Если 4 угла в одной плоскости есть пересечение
    //Если в разных - есть пересечение

    class Line
    {
        public Point x;
        public Point y;

        public Line(Point x, Point y)
        {
            this.x = x;
            this.y = y;
        }

    }

    class Point
    {
        public double x;
        public double y;

        public Point()
        {
            x = 0;
            y = 0;
        }

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int N, W, E;
            N = Convert.ToInt16(Console.ReadLine());
            W = Convert.ToInt16(Console.ReadLine());
            E = Convert.ToInt16(Console.ReadLine());
            
            
        }
    }
}
