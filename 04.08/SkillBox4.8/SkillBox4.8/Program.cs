using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox4._8
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1

            Console.Write("Введите количество строк в будущей матрице: ");
            int linesNumber = int.Parse(Console.ReadLine());
            Console.Write("Введите количество столбцов в будущей матрице: ");
            int columsNumber = int.Parse(Console.ReadLine());

            int[,] matrix = new int[linesNumber, columsNumber];
            Random random = new Random();
            Console.WriteLine("\nПолученная матрица:\n");

            for (int i = 0; i < linesNumber; i++)
            {
                for (int j = 0; j < columsNumber; j++)
                {
                    matrix[i, j] = random.Next(100);
                    Console.Write($"{ matrix[i, j],4}");
                }
                Console.WriteLine();
            }
            #endregion

            #region Task 2

            int[,] matrixToSum = new int[linesNumber, columsNumber];

            Console.WriteLine("\nЕще одна матрица:\n");

            for (int i = 0; i < linesNumber; i++)
            {
                for (int j = 0; j < columsNumber; j++)
                {
                    matrixToSum[i, j] = random.Next(100);
                    Console.Write($"{ matrixToSum[i, j],4}");
                }
                Console.WriteLine();
            }

            int[,] matrixSumResult = new int[linesNumber, columsNumber];

            Console.WriteLine("\nМатрица, получившаяся в результате суммы двух других матриц:\n");

            for (int i = 0; i < linesNumber; i++)
            {
                for (int j = 0; j < columsNumber; j++)
                {
                    matrixSumResult[i, j] = matrixToSum[i, j] + matrix[i, j];
                    Console.Write($"{ matrixSumResult[i, j],4}");
                }
                Console.WriteLine();
            }
            #endregion

            Console.ReadKey();
        }
    }
}
