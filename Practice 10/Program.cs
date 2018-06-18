using System;
using System.Collections.Generic;

namespace Zadacha
{
    class TwoWayList // двунаправленный список
    {
        public int dataTwo; //информационное поле

        public TwoWayList nextTwo, //адрес следующего элемента
            predTwo; //адрес предыдущего элемента

        public TwoWayList()
        {
            dataTwo = 0;
            nextTwo = null;
            predTwo = null;
        }

        public TwoWayList(int d)
        {
            dataTwo = d;
            nextTwo = null;
            predTwo = null;
        }

        public void AddToEnd(int data) //добавление элементов списка (в конец)
        {
            if (nextTwo == null)
            {
                nextTwo = new TwoWayList(data);
            }
            else
            {
                nextTwo.AddToEnd(data);
            }
        }

        public override string ToString()
        {
            return dataTwo + " ";
        }


        class Program
        {
            static TwoWayList VvodElemTwoList() //двунаправленный список, ввод элементов списка пользователем
            {
                int N;
                int dataTwo;
                Console.WriteLine("Введите сколько элементов вы хотите добавить в список");
                while (!int.TryParse(Console.ReadLine(), out N) || N < 2)
                    Console.WriteLine("Ошибка ввода. Введите целое число больше 1");

                Console.WriteLine("Введите элементы списка");
                while (!int.TryParse(Console.ReadLine(), out dataTwo))
                    Console.WriteLine("Ошибка ввода. Введите целое число.");

                TwoWayList myLList = new TwoWayList(dataTwo); //ввод первого элемента списка

                for (int i = 0; i < N - 1; i++)
                {
                    while (!int.TryParse(Console.ReadLine(), out dataTwo))
                        Console.WriteLine("Ошибка ввода. Введите целое число.");
                    myLList.AddToEnd(dataTwo); //ввод остальных элементов списка
                }
                return myLList;
            }

            static void ShowList2(TwoWayList MyList)        //вывод двунаправленного списка
            {

                if (MyList == null)                         //проверка на пустой список
                {
                    Console.WriteLine("Список пуст.");
                    return;
                }
                TwoWayList p = MyList;
                while (p != null)
                {
                    Console.Write(p);
                    p = p.nextTwo;                          //переход к следующему элементу
                }
                Console.WriteLine();
            }

            static public int Recurse(TwoWayList CurrentList , TwoWayList NextList)      //вычислить можно где-то здесь
            {
                int result = 0;                
                while (CurrentList.nextTwo != null)
                {
                    NextList = CurrentList.nextTwo;
                    result = CurrentList.dataTwo - CurrentList.nextTwo.dataTwo;

                    result = 0;
                }
                
                return result;
            }

            static void Main(string[] args)
            {

                TwoWayList List = new TwoWayList();
                List = VvodElemTwoList();
                ShowList2(List);

                Console.ReadLine();
            }
        }
    }
}
