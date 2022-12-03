using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox5_5
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Task 1
            Console.WriteLine("Введите предложение:");
            string inputText = Console.ReadLine();
            string[] outputWords = SplitText(inputText);
            Console.WriteLine("\nОбработанный вывод:");
            WriteWords(outputWords);
            #endregion

            Console.WriteLine(); // разделение вывода заданий пустой строчкой

            #region Task 2
            Console.WriteLine("Введите следующее предложение:");
            string inputTextSecond = Console.ReadLine();
            Console.WriteLine("\nПреобразованное предложение:");
            Console.WriteLine(ReversWordsInText(inputTextSecond));
            #endregion

            Console.ReadLine();
        }

        /// <summary>
        /// Разделяет слова из предложения.
        /// </summary>
        /// <param name="text"> Входное предложение. </param>
        /// <returns> Массив слов, из которых состоит предложение. </returns>
        static string[] SplitText(string text)
        {
            string[] wordsResult = text.Split(' ');
            return wordsResult;
        }

        /// <summary>
        /// Выводит на экран каждое слово из входящего массива в новой строчке.
        /// </summary>
        /// <param name="wordsToWrite"> Массив слов для вывода. </param>
        static void WriteWords(string[] wordsToWrite)
        {
            foreach (string wordToWrite in wordsToWrite)
            {
                Console.WriteLine(wordToWrite);
            }
        }

        /// <summary>
        /// Перестанавливает слова в предложении в обратном порядке.
        /// </summary>
        /// <param name="textToRevers"> Предложение для перестановки. </param>
        /// <returns> Выводит предложение, в котором слова перестановлены в обратном порядке. </returns>
        static string ReversWordsInText (string textToRevers)
        {
            string[] wordsToRevers = SplitText(textToRevers);
            string reversTextResult = "";

            for (int i = wordsToRevers.Length-1; i >= 0; i--) // перебирает массив слов в обратном порядке для перестановки
            {
                if (i == wordsToRevers.Length - 1) // для первого слова пробел не нужен
                {
                    reversTextResult = wordsToRevers[i];
                }
                else
                {
                    reversTextResult += " " + wordsToRevers[i];
                }
            }

            return reversTextResult;
        }
    }
}
