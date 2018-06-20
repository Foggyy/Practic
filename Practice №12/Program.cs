using System;


namespace Practice__12
{
    class Program
    {
        /// <summary>
        /// Выстраиваем элементы массива в виде сортирующего дерева
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="i"></param>
        /// <param name="n"></param>
        public static void HeapBuilder(int[] mas, int index, int N, ref int count, ref int counter)
        {
            int SupElement;
            while (2 * index + 1 < N)
            {
                int t = 2 * index + 1;
                if (2 * index + 2 < N && mas[2 * index + 2] >= mas[t])      //проверка на наличие элемента
                {
                    count++;
                    t = 2 * index + 2;
                }
                if (mas[index] < mas[t])                                    //перестановка меньших элементов ближе к корню дерева
                {
                    SupElement = mas[index];
                    mas[index] = mas[t];
                    mas[t] = SupElement;
                    index = t;
                    counter++;
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Метод с циклом для построения кучи(пирамиды)
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="n"></param>
        public static void BuildingHeap(int[] mas, int N, ref int count, ref int counter)
        {
            for (int i = N - 1; i >= 0; i--)
            {
                HeapBuilder(mas, i, N, ref count, ref counter);
            }
        }

        /// <summary>
        /// Пирамидальная сортировка
        /// </summary>
        /// <param name="mas"></param>
        /// <param name="N"></param>
        public static void HeapSort(ref int[] mas, int N)
        {
            int count = 0;                      //счетчик сравнений
            int counter = 0;                    //счетчик перемещений
            int temp;
            Console.WriteLine("\nПирамидальная сортировка:");
            BuildingHeap(mas, N,ref count, ref counter);
            while (N > 0)
            {
                temp = mas[0];
                mas[0] = mas[N - 1];
                mas[N - 1] = temp;
                N--;
                counter++;
                HeapBuilder(mas, 0, N, ref count, ref counter);
            }

            Console.WriteLine("Количество сравнений = " + count);
            Console.WriteLine("Количество перемещений (пересылок) = " + counter);
        }

        /// <summary>
        /// Сортировка перемешиванием
        /// </summary>
        /// <param name="myint"></param>
        static void ShakerSort(ref int[] myint)
        {
            int left = 0;                       //левая граница
            int right = myint.Length - 1;       //правая граница
            int count = 0;                      //счетчик сравнений
            int counter = 0;                    //счетчик перемещений

            Console.WriteLine("\nСортировка перемешиванием:");
            while (left <= right)
            {
                for (int i = left; i < right; i++)  //Сдвигаем к концу массива "тяжелые элементы"
                {
                    count++;
                    if (myint[i] > myint[i + 1])
                    {
                        Swap(myint, i, i + 1);      //меняем местами
                        counter++;
                    }
                }
                right--;                            // уменьшаем правую границу

                for (int i = right; i > left; i--)  //Сдвигаем к началу массива "легкие элементы"
                {
                    count++;
                    if (myint[i - 1] > myint[i])
                    {
                        Swap(myint, i - 1, i);      //меняем местами
                        counter++;
                    }
                }
                left++; // увеличиваем левую границу
            }
            Console.WriteLine("Количество сравнений = " + count);
            Console.WriteLine("Количество перемещений (пересылок) = " + counter);
        }

        /// <summary>
        /// Меняем элементы массива местами
        /// </summary>
        /// <param name="myint"></param>
        /// <param name="i"></param>
        /// <param name="j"></param>
        static void Swap(int[] myint, int i, int j) //swap функция обмена
        {
            int glass = myint[i];
            myint[i] = myint[j];
            myint[j] = glass;
        }

        /// <summary>
        /// Вывод массива
        /// </summary>
        /// <param name="a"></param>
        static void Show(int[] a)
        {
            foreach (int i in a)
                Console.Write("{0} ", i);
            Console.WriteLine();
        }

        static void Menu()
        {
            Console.WriteLine("Выберите способ: 1 - использовать заранее подготовленные значения, 2 - ввести свои значения");
            int choice;
            while(!int.TryParse(Console.ReadLine(), out choice) || choice>2 || choice<1)
                Console.WriteLine("Ошибка ввода, введите 1 или 2");

            switch (choice)
            {
                case 1:
                    int[] mas1 = new[] { 1, 2, 3, 4, 5 };
                    Console.WriteLine("Первый массив:");
                    Show(mas1);
                    HeapSort(ref mas1, mas1.Length);
                    Show(mas1);
                    mas1 = new[] { 1, 2, 3, 4, 5 };
                    Console.WriteLine("\nВозвращаем значения массива:");
                    Show(mas1);
                    ShakerSort(ref mas1);
                    Show(mas1);

                    int[] mas2 = new[] { 5, 4, 3, 2, 1 };
                    Console.WriteLine("\n\nВторой массив:");
                    Show(mas2);
                    HeapSort(ref mas2, mas2.Length);
                    Show(mas2);
                    mas2 = new[] { 5, 4, 3, 2, 1 };
                    Console.WriteLine("\nВозвращаем значения массива:");
                    Show(mas2);
                    ShakerSort(ref mas2);
                    Show(mas2);

                    int[] mas3 = new[] { 5, 2, 4, 3, 1 };
                    Console.WriteLine("\n\nТретий массив:");
                    Show(mas3);
                    HeapSort(ref mas3, mas2.Length);
                    Show(mas3);
                    mas3 = new[] { 5, 2, 4, 3, 1 };
                    Console.WriteLine("\nВозвращаем значения массива:");
                    Show(mas3);
                    ShakerSort(ref mas3);
                    Show(mas3);

                    break;

                case 2:
                    int length;
                    Console.WriteLine("Введите длину массива:");
                    while(!int.TryParse(Console.ReadLine(), out length) || length<1)
                        Console.WriteLine("Ошибка ввода. Введите кол-во больше 0");
                    int[] mas = new int[length];
                    int[] SupMas = new int[length];
                    Console.WriteLine("Введите значения массива:");
                    for (int i = 0; i < length; i++)
                    {
                        while (!int.TryParse(Console.ReadLine(), out mas[i]))
                            Console.WriteLine("Ошибка ввода. Введите число");
                        SupMas[i] = mas[i];
                    }
                                                                   
                    HeapSort(ref mas,length);
                    Show(mas);
                    Console.WriteLine("\nВозвращаем значения массива:");
                    mas = SupMas;
                    Show(mas);
                    ShakerSort(ref mas);
                    Show(mas);

                    break;
            }
        }

        static void Main(string[] args)
        {
           Menu();
            
            Console.ReadLine();
        }
    }
}
