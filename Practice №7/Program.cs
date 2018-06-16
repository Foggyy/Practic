using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice__7
{
     

    class Program
    {
        /// <summary>
        /// Получение кол-ва частоты букв
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        static Dictionary<char, int> FrequencyCounter(string str)
        {
            Dictionary<char, int> dictionary = new Dictionary<char, int>();

            foreach (var symbol in str)                 
            {
                if (dictionary.ContainsKey(symbol))         //если в словаре уже есть такой символ
                    dictionary[symbol]++;
                else                                    //если символ найден впервые
                    dictionary[symbol] = 1;
            }

            return dictionary;
        }

        static void Main(string[] args)
        {
            string str = "abfdcdscassaacfefwesd";

            var frequencies = FrequencyCounter(str);

            foreach (var item in frequencies)
                Console.WriteLine(item.Key + " - " + item.Value);

            Console.ReadLine();
        }
    }
}
