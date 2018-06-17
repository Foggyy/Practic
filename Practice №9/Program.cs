using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice__9
{

    public class MyList
    {       
        int data;
        public MyList nextValue;
        public int count = 0;

        public MyList(int data)
        {
            this.data = data;
            nextValue = null;
            count++;
        }

        public int this[int index]
        {
            get
            {
                MyList current = this;

                for (int i = 0; i <= index && current != null; i++)
                    if (i == index)
                        return current.data;
                    else
                        current = current.nextValue;

                return -1;
            }
        }

        public static MyList AddElements(int N)
        {
            MyList FirstElement = new MyList(1);
            MyList current = FirstElement;

            for (int i = 2; i <= N; i++)
            {
                current.nextValue =  new MyList(i);
                current = current.nextValue;
            }

            return FirstElement;
        }

        //public static MyList Remove(int index)
        //{
        //    Console.WriteLine("Введите номер удаляемого элемента:");
        //    while (!int.TryParse(Console.ReadLine(), out index) || index < 0)
        //        Console.WriteLine("Ошибка ввода, введите кол-во больше 0");

        //    for(int i)

        //}

        public override string ToString()
        {
            return String.Format("Номер: " + data);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Введите N (кол-во номеров в списке):");
            int N;
            while(!int.TryParse(Console.ReadLine(), out N) || N<1)
                Console.WriteLine("Ошибка ввода, введите кол-во больше 0");
            MyList list = MyList.AddElements(N);

            for (int i = 0; i < N; i++)
            {
                if (list != null)
                {
                    Console.WriteLine(list.ToString());
                    list = list.nextValue;
                }
            }

            Console.WriteLine(list[4]);

            Console.ReadLine();
        }
    }
}
