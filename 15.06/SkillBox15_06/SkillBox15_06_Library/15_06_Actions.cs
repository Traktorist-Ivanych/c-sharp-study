using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox15_06_Library
{
    public class Actions15_06
    {
        public static void RandomNumbers()
        {
            Random random = new Random();
            int[] numbers = new int[random.Next(0, 51)];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = random.Next(0, 51);
            }

            Console.WriteLine("Введите номер числа, который вы хотите вывести на экран");

            try
            {
                int inputNumber = int.Parse(Console.ReadLine());
                numbers[inputNumber].Print();
                if (inputNumber == 5)
                {
                    throw new EasterEggException();
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine($"Введен неверный формат! {e.Message}");
            }
            catch (IndexOutOfRangeException e)
            {
                Console.WriteLine($"Данного числа не существует! {e.Message}");
            }
            catch (EasterEggException e)
            {
                Console.WriteLine($"Какая-то забавная ошибка! {e.Message}");
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка!");
            }

            Console.ReadKey();
        }
    }
}
