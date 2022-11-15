using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox2_7
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullName;
            string Surname = "Кравчук";
            string Name = "Кирилл";
            string Patronymic = "Игоревич";
            fullName = "Фамилия :{0} \nИмя: {1} \nОтчество: {2}";
            Console.WriteLine(fullName, Surname, Name, Patronymic);

            int age = 23;
            Console.WriteLine("Возраст: " + age.ToString());

            string email = "nissan.cyril@gmail.com";
            Console.WriteLine("Email: " + email);

            string scoresOutput = "Набранные баллы:\nПрограммирование - {0} \nМатематика - {1} \nФизика - {2}";
            double programmingScores = 79.1;
            double mathScores = 99.9;
            double physicsScores = 92.2;
            Console.WriteLine(scoresOutput, programmingScores, mathScores, physicsScores);

            Console.ReadKey();

            Console.WriteLine();

            double scoresSum = programmingScores + mathScores + physicsScores;
            Console.WriteLine("Сумма набранных баллов: " + scoresSum.ToString());
            double scoreAvarage = Math.Round(scoresSum / 3, 1, MidpointRounding.AwayFromZero);
            Console.WriteLine("Среднее арифметическое набранных баллов: " + scoreAvarage.ToString());

            Console.ReadKey();
        }
    }
}
