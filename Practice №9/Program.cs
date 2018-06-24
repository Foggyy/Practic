using System;

namespace Practice__9
{

    /// <summary>
    /// Линейный список
    /// </summary>
    public class MyList
    {       
        public int data;                //данные
        public MyList nextValue;        //следующий элемент
        static public int count = 0;    //счетчик

        /// <summary>
        /// Конструктор с первым (головным) элементом
        /// </summary>
        /// <param name="data"></param>
        public MyList(int data)
        {
            this.data = data;
            nextValue = null;
            count++;
        }

        /// <summary>
        /// Создание списка с определенным количеством элементов
        /// </summary>
        /// <param name="N"></param>
        /// <returns></returns>
        public static MyList AddElements(int N)
        {
            MyList FirstElement = new MyList(1);        //номер 1 становится первым(головным) элементом спискка
            MyList Element = FirstElement;              //текущий элемент

            for (int i = 2; i <= N; i++)                
            {
                Element.nextValue =  new MyList(i);
                Element = Element.nextValue;            
            }
            return FirstElement;                        //возвращаем список
        }

        /// <summary>
        /// Перегрузка метода ToString для вывода элементов списка
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return String.Format("Номер: " + data);
        }
    }

    class Program
    {

        /// <summary>
        /// Вывод списка
        /// </summary>
        /// <param name="list"></param>
        static public void Show(MyList list)
        {
            Console.Write("Линейный список: ");
            if (list == null)                               // если список пуст
                Console.WriteLine("Список пуст");
            else
            {
                MyList Element = list; // создание нового элемента и запись в него первого
                while (Element != null) // цикл до конца списка
                {
                    Console.Write(Element.data + "  "); // вывод на экран текущего значения
                    Element = Element.nextValue; // переход к след. элементу
                }
                Console.WriteLine("");
            }
        }

        /// <summary>
        /// Удаление элемента с определенным номером
        /// </summary>
        /// <param name="list"></param>
        static public void Remove(ref MyList list) //удаление элемента 
        {
            if (list != null)
            {
                MyList Element = list;
                MyList prev = list;
                int i = 1;

                Console.WriteLine("Введите номер элемента: ");
                int position;
                while (!int.TryParse(Console.ReadLine(), out position) || position < 1)
                    Console.WriteLine("Ошибка ввода, введите номер больше 0");
                try
                {
                    while (Element.data != position)
                    {
                        if (Element != null)
                        {
                            prev = Element;
                            Element = Element.nextValue;
                            i++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                catch (NullReferenceException)
                {
                   
                }
                if (list == Element)
                    list = list.nextValue;
                else if (Element != null)
                {
                    prev.nextValue = Element.nextValue;
                }
                else
                {
                    Console.WriteLine("Такого номера в списке нет");
                }
                MyList.count--;
            }
            else
                Console.WriteLine("Список пуст");
        }

        /// <summary>
        /// Поиск по значению
        /// </summary>
        /// <param name="list"></param>
        static public void FindElement(MyList list)
        {
            bool ok = true;
            Console.WriteLine("Введите номер который надо найти: ");
            int number;
            while (!int.TryParse(Console.ReadLine(), out number) || number < 1)
                Console.WriteLine("Ошибка ввода, введите номер больше 0");

            Console.WriteLine("Результаты поиска: ");
            while (list != null)                                                //пока не дошли до конца списка
            {
                if (list.data == number)                                        //если элемент найден
                {
                    Console.Write(list.data);                                   //вывести найденный элемент
                    ok = false;
                }                    
                list = list.nextValue;                                          //переход к след. элементу
            }
            if(ok)
                Console.WriteLine("Номер не найден");
        }

        /// <summary>
        /// Главное меню
        /// </summary>
        static public void Menu()
        {
            MyList list = null;
            bool ok = true;
            do
            {
                Console.WriteLine("\nМеню для работы с линейным списком:"
                                  + "\n1.Создание списка"
                                  + "\n2.Удаление выбранного элемента"
                                  + "\n3.Поиск элемента"
                                  + "\n4.Вывод списка"
                                  + "\n5.Выход");
                int choice;
                while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 5)
                    Console.WriteLine("Ошибка ввода, выберите пункт (1-5)");

                switch (choice)
                {
                    case 1:
                        int N;
                        Console.WriteLine("Введите N (кол-во номеров в списке):");
                        while (!int.TryParse(Console.ReadLine(), out N) || N < 1)
                            Console.WriteLine("Ошибка ввода, введите кол-во больше 0");
                        list = MyList.AddElements(N);
                        break;
                    case 2:
                        Remove(ref list);
                        break;
                    case 3:
                        FindElement(list);
                        break;
                    case 4:
                        Show(list);
                        break;
                    case 5:
                        ok = false;
                        break;
                }
            } while (ok == true);

        }

        static void Main(string[] args)
        {                     
            Menu();
        }
    }
}
