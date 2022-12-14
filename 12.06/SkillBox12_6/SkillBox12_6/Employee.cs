using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SkillBox12_6
{
    public class Employee : ISorting
    {
        public int WorkersCount
        {
            get => workers.Count;
        }

        protected List<Worker> workers;

        public Employee()
        {
            workers = new List<Worker>();
        }

        /// <summary>
        /// Десериализация данных из txt
        /// </summary>
        /// <param name="newWorker"></param>
        private void AddToArrayFromFile(Worker newWorker)
        {
            workers.Add(newWorker);
        }

        /// <summary>
        /// Десериализация данных из txt
        /// </summary>
        public void LoadFromFile()
        {
            using (StreamReader sr = new StreamReader(Constants.Path))
            {
                workers.Clear();

                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('#');
                    AddToArrayFromFile(new Worker(args[0], args[1], args[2], args[3], args[4]));
                }
            }
        }

        /// <summary>
        /// Метод необходим для вывода на экран работника с необходимым номером телефона
        /// </summary>
        /// <returns></returns>
        public string PrintWorkerWithNumber(int item)
        {
            string workerWithNumber = workers[item].FIO;
            return workerWithNumber;
        }

        /// <summary>
        /// Сортируем данные и выводим
        /// </summary>
        public void SortBySurname()
        {
            List<Worker> sortedWorkers = new List<Worker>();

            int indexOfWorkers;

            string[] sortedFIO = new string[workers.Count];
            string[] notSortedFIO = new string[workers.Count];

            for (int i = 0; i < workers.Count; i++)
            {
                string fioFromWorker = workers[i].FIO;
                sortedFIO[i] = fioFromWorker;
                notSortedFIO[i] = fioFromWorker;
            }

            Array.Sort(sortedFIO);

            for (int i = 0; i < workers.Count; i++)
            {
                indexOfWorkers = Array.IndexOf(notSortedFIO, sortedFIO[i]);
                sortedWorkers.Add(workers[indexOfWorkers]);
            }

            WriteDataToTxt(sortedWorkers);
        }

        /// <summary>
        /// Удаление и перезапись в txt
        /// </summary>
        /// <param name="newWorkerArray"></param>
        protected void WriteDataToTxt(List<Worker> newWorkerArray)
        {
            File.Delete(@"Workers.txt");

            using (StreamWriter sw = new StreamWriter("Workers.txt", true))
            {
                for (int i = 0; i < workers.Count; i++)
                {
                    sw.WriteLine($"{newWorkerArray[i].FIO}" +
                                 $"#{newWorkerArray[i].PhoneNumber}" +
                                 $"#{newWorkerArray[i].PassportNumber}" +
                                 $"#{newWorkerArray[i].ChangesDataTime}" +
                                 $"#{newWorkerArray[i].JobTitle}");
                }
            }
        }
    }
}
