using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox7_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository repository = new Repository();
            repository.OnStart();

            repository.PrintAllWorkers();

            repository.PrintWorkerById(int.Parse(Console.ReadLine()));

            repository.DeleteWorkerById(int.Parse(Console.ReadLine()));

            repository.AddWorker();

            repository.ShowWorkersBetweenTwoDates();

            repository.SortAllWorkers();

            Console.ReadKey();
        }
    }
}
