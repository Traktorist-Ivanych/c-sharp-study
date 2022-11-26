using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox8_6
{
    class WorkWithLists
    {
        /// <summary>
        /// Выполняет задание работы с List
        /// </summary>
        public void StartProcess()
        {
            List<int> intNumbers = new List<int>();
            Random random = new Random();

            for (int i = 0; i < 100; i++)
            {
                intNumbers.Add(random.Next(101));
            }

            Console.WriteLine("Лист из 100 целых чисел:\n");
            PrintIntList(intNumbers);

            for (int i = 0; i < intNumbers.Count; i++)
            {
                if (intNumbers[i] > 25 && intNumbers[i] < 50)
                {
                    intNumbers.RemoveAt(i);
                    i--;
                }
            }

            Console.WriteLine("\nОбработанный лист из 100 целых чисел:\n");
            PrintIntList(intNumbers);

            Console.WriteLine("\n");
        }

        /// <summary>
        /// Выводит на экран передаваемый лист целых чисел
        /// </summary>
        /// <param name="intListToPrint"> Передаваемый лист целых чисел </param>
        private void PrintIntList(List<int> intListToPrint)
        {
            for (int i = 0; i < intListToPrint.Count; i++)
            {
                Console.Write($"{intListToPrint[i],4}");
                if ((i + 1) % 10 == 0)
                {
                    Console.WriteLine();
                }
            }
        }
    }
}
