using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox3_10
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task 1
            #region
            Console.Write("Введите целое число: ");
            int value = int.Parse(Console.ReadLine());
            if (value % 2 == 0)
            {
                Console.WriteLine("Введенное число является четным");
            }
            else
            {
                Console.WriteLine("Введенное число является нечетный");

            }

            Console.WriteLine();
            #endregion

            // Task 2
            #region
            Console.WriteLine("Введите количество Ваших карт");
            int cardValue = int.Parse(Console.ReadLine());
            int cardWeightSum = 0;

            for (int i = 0; i < cardValue; i++)
            {
                Console.Write("Введите номинал карты: ");
                string cardWeight = Console.ReadLine();

                if (cardWeight == "J" || cardWeight == "Q"|| cardWeight == "K" || cardWeight == "T")
                {
                    cardWeightSum += 10;
                }
                else
                {
                    int cardWeigntInt = int.Parse(cardWeight);
                    switch (cardWeigntInt)
                    {
                        case 6:
                            cardWeightSum += cardWeigntInt;
                            break;
                        case 7:
                            cardWeightSum += cardWeigntInt;
                            break;
                        case 8:
                            cardWeightSum += cardWeigntInt;
                            break;
                        case 9:
                            cardWeightSum += cardWeigntInt;
                            break;
                        case 10:
                            cardWeightSum += cardWeigntInt;
                            break;
                    }
                }
            }

            Console.WriteLine("Сумма номеналов всех карт: " + cardWeightSum.ToString());

            Console.WriteLine();
            #endregion

            // Task 3
            #region
            Console.Write("Введите целое число: ");
            int number = int.Parse(Console.ReadLine());
            int count = 2;
            bool isNumerSimple = true;
            while (count < number)
            {
                if (number % count == 0)
                {
                    isNumerSimple = false;
                    break;
                }
                count++;
            }

            if (isNumerSimple)
            {
                Console.WriteLine("Введенное число является простым!");
            }
            else
            {
                Console.WriteLine("Введенное число не является простым!");
            }

            Console.WriteLine();
            #endregion

            // Task 4
            #region
            Console.Write("Введите длину последовательности целых чисел: ");
            int rangeLenght = int.Parse(Console.ReadLine());

            int[] rangeValues = new int[rangeLenght];

            for (int i = 0; i < rangeLenght; i++)
            {
                Console.WriteLine("Введите число номер " + (i + 1).ToString() + ": ");
                rangeValues[i] = int.Parse(Console.ReadLine());
            }

            int minRangeValue = int.MaxValue;

            foreach (int rangeValue in rangeValues)
            {
                if (minRangeValue > rangeValue)
                {
                    minRangeValue = rangeValue;
                }
            }

            Console.WriteLine("Наименьшее число из введенной последовательности: " + minRangeValue.ToString());

            Console.WriteLine();
            #endregion

            // Task 5
            #region
            Console.Write("Введите максимальное целое число диапазона: ");
            int gameMaxRangeValue = int.Parse(Console.ReadLine());

            Random randomValue = new Random();
            int gameRightValue = randomValue.Next(gameMaxRangeValue + 1);
            int playerValue;

            do
            {
                Console.Write("Введите число: ");

                string inputValue = Console.ReadLine();

                if (inputValue != "")
                {
                    playerValue = int.Parse(inputValue);

                    if (playerValue > gameRightValue)
                    {
                        Console.WriteLine("Введенное число больше загаданного");
                    }
                    else if (playerValue < gameRightValue)
                    {
                        Console.WriteLine("Введенное число меньше загаданного");
                    }
                    else
                    {
                        Console.WriteLine("Вы угадали!");
                        break;
                    }
                }
                else
                {
                    Console.WriteLine("Вы решили выйти? Загаданное число: " + gameRightValue.ToString());
                    break;
                }
                
            }
            while (playerValue != gameRightValue);
            #endregion

            Console.ReadKey();
        }
    }
}
