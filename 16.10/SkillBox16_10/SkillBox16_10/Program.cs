using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkillBox16_10
{
    class Program
    {
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Main запущен.");

            Task[] tasks = new Task[5];

            tasks[0] = new Task(AcyncMethod, "415, я база, ответьте.");
            tasks[1] = new Task(AcyncMethod, "415, почему не отвечаете? Я база, ответьте.");
            tasks[2] = new Task(AcyncMethod, "15, (кое-кто не хороший), как понял? Прием.");
            tasks[3] = new Task(AcyncMethod, "15, понял, (кое-кто не хороший), Принято.");
            tasks[4] = new Task<int>(AcuncSum, 16);

            foreach (Task task in tasks)
            {
                task.Start();
            }

            Task.WaitAll(tasks);

            Console.WriteLine("Main завершил свою работу.");

            Console.ReadKey();
        }

        static void AcyncMethod(object message)
        {
            Console.WriteLine($"CurrentID = {Task.CurrentId} - Начал работу.");

            int timeToWait = random.Next(200, 501);

            for (int i = 0; i <= 25; i++)
            {
                Console.WriteLine($"{message} {Task.CurrentId} - работает. Результат: {i}.");
                Thread.Sleep(timeToWait);
            }

            Console.WriteLine($"CurrentID = {Task.CurrentId} - Работу закончил.");
        }

        static int AcuncSum(object inputNum)
        {
            Console.WriteLine($"CurrentID = {Task.CurrentId} - Начал работу.");

            int sum = 0;

            for (int i = 0; i <= (int)inputNum; i++)
            {
                sum += i;
                Console.WriteLine($"CurrentID = {Task.CurrentId} - считаю. Предварительный результат = {sum}");
                Thread.Sleep(250);
            }

            Console.WriteLine($"CurrentID = {Task.CurrentId} - работу закончил.");

            return sum;
        }
    }
}
