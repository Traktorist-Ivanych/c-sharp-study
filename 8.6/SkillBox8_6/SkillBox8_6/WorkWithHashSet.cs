using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox8_6
{
    class WorkWithHashSet
    {
        /// <summary>
        /// Выполняет задание работы с HashSet
        /// </summary>
        public void StartProcess()
        {
            HashSet<int> hashSetNumbers = new HashSet<int>();
            Console.WriteLine("Для прекращения введите любой не числовой символ");

            for (int i = 0; i < 2; i++)
            {
                Console.Write("Введите число: ");
                if (int.TryParse(Console.ReadLine(), out int parseResult))
                {
                    if (hashSetNumbers.Add(parseResult))
                    {
                        Console.WriteLine("Число успешно добавлено в массив");
                    }
                    else
                    {
                        Console.WriteLine("Данное число уже записано в массиве!");
                    }

                    i = 0;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
