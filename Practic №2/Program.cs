using System.IO;

namespace Practic__2
{
    class Line
    {
        public int a;
        public int b;
        public int c;

        public Line(Point p1, Point p2)
        {
            //Общий вид уравнения прямой: (y1 - y2)x + (x2 - x1)y + (x1y2 - x2y1) = 0
            //Общее уравнение прямой на плоскости: Ax + By + C = 0
            a = (p2.y - p1.y);
            b = (p1.x - p2.x);
            c = ((p1.y * p2.x) - (p1.x * p2.y));

        }

        public int Result(Point p)
        {
            return (a * p.x) + (b * p.y) + c;
        }

    }

    class Point
    {
        public int x;
        public int y;

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
            int count = 0;                                 //кол-во квадратов, имеющих общую точку с прямой       

            string dataIn = File.ReadAllText("INPUT.txt"); //ввод всего файла в строку
            string[] temp = dataIn.Split(' ');              //убираем пробелы

            N = int.Parse(temp[0]);
            W = int.Parse(temp[1]);
            E = int.Parse(temp[2]);

            Line line = new Line(new Point(0, W),new Point(100*N,E));       //прямая в декартовой системе координат, заданная точками (0,W) и (100*N,E)

            //Координаты углов квадрата
            for (int i = 1; i <= N; i++)
            {
                for (int j = 1; j <= N; j++)
                {
                    Point p1 = new Point(100*i, 100*j);
                    Point p2 = new Point(100*i, 100*j - 100);
                    Point p3 = new Point(100*i -100, 100*j);
                    Point p4 = new Point(100 * i - 100, 100 * j - 100);

                    int apex1 = line.Result(p1);
                    int apex2 = line.Result(p2);
                    int apex3 = line.Result(p3);
                    int apex4 = line.Result(p4);

                    if (apex1 > 0 && apex2 > 0 && apex3 > 0 && apex4 > 0 ||
                        apex1 < 0 && apex2 < 0 && apex3 < 0 && apex4 < 0)
                    {

                    }
                    else
                    {
                        count++;
                    }
                }
            }
            File.WriteAllText("OUTPUT.txt", count.ToString()); //вывод count с преобразованием в string           
        }
    }
}
