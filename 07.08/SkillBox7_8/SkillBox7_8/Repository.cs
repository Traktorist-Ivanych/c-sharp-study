using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox7_8
{
    class Repository
    {
        private string workersInfoPath;

        /// <summary>
        /// Создает файл для хранения информации о сотрудниках на жестком диске и сохраняет путь к нему
        /// </summary>
        public void OnStart()
        {
            string thisProgramPath = Path.GetFullPath("Repository");
            workersInfoPath = (thisProgramPath.Remove(thisProgramPath.LastIndexOf(@"\")) + @"\WorkersInfo.txt");
            if (!File.Exists(workersInfoPath))
            {
                File.Create(workersInfoPath);
            }
        }

        /// <summary>
        /// Запускает выполнение вывода информации о сотрудниках на экран
        /// </summary>
        public void PrintAllWorkers()
        {
            PrintAllWorkersHepler(GetAllWorkers());
        }

        /// <summary>
        /// Выводит на экран передаваемый массив сотрудников
        /// </summary>
        /// <param name="workersToPrint"> Массив сотрудников </param>
        private void PrintAllWorkersHepler(Worker[] workersToPrint)
        {
            foreach (Worker workerToPrint in workersToPrint)
            {
                PrintWorkerHelper(workerToPrint);
            }
        }

        /// <summary>
        /// Считывает информацию из файла и создает массив сотрудников, если информация в файле есть
        /// </summary>
        /// <returns> Массив сотрудников </returns>
        private Worker[] GetAllWorkers()
        {
            string[] workersLines = File.ReadAllLines(workersInfoPath);
            if (workersLines.Length < 1)
            {
                Worker[] workersEmpty = new Worker[1];
                workersEmpty[0].Id = -1;
                workersEmpty[0].CrecreationDataTime = new DateTime();
                workersEmpty[0].FIO = "Файл пуст";
                workersEmpty[0].Age = "Файл пуст";
                workersEmpty[0].Height = "Файл пуст";
                workersEmpty[0].BirthDataTime = new DateTime();
                workersEmpty[0].BirthTown = "Файл пуст";
                return workersEmpty;
            }
            else
            {
                Worker[] workers = new Worker[workersLines.Length];
                for (int i = 0; i < workersLines.Length; i++)
                {
                    string[] workerInfo = workersLines[i].Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries);
                    workers[i].Id = int.Parse(workerInfo[0]);
                    workers[i].CrecreationDataTime = DateTime.Parse(workerInfo[1]);
                    workers[i].FIO = workerInfo[2];
                    workers[i].Age = workerInfo[3];
                    workers[i].Height = workerInfo[4];
                    workers[i].BirthDataTime = DateTime.Parse(workerInfo[5]);
                    workers[i].BirthTown = workerInfo[6];
                }
                return workers;
            }
        }

        /// <summary>
        /// Выводит на экран информацию об одном сотруднике
        /// </summary>
        /// <param name="workerToPrint"></param>
        private void PrintWorkerHelper(Worker workerToPrint)
        {
            Console.WriteLine("ID: " + workerToPrint.Id);
            Console.WriteLine("Дата создания записи: " + workerToPrint.CrecreationDataTime);
            Console.WriteLine("ФИО: " + workerToPrint.FIO);
            Console.WriteLine("Возраст: " + workerToPrint.Age);
            Console.WriteLine("Рост: " + workerToPrint.Height);
            Console.WriteLine("Дата рождения: " + workerToPrint.BirthDataTime.ToString("dd.MM.yyyy"));
            Console.WriteLine("Город рождения: " + workerToPrint.BirthTown + " \n");
        }

        /// <summary>
        /// Выводит на экран информацию сотрудника под определенным ID
        /// </summary>
        /// <param name="idToPrint"> ID для поиска </param>
        public void PrintWorkerById(int idToPrint)
        {
            Worker[] workers = GetAllWorkers();

            int foundWorkerElementToPrint = FoundWorkerById(workers, idToPrint);

            if (foundWorkerElementToPrint == -1)
            {
                Console.WriteLine("Работник с введенным ID не найден!");
            }
            else
            {
                PrintWorkerHelper(workers[foundWorkerElementToPrint]);
            }
        }

        /// <summary>
        /// Выполняет поиск сотрудника из массива сотрудников по введенному ID
        /// </summary>
        /// <param name="workersToSearch"> Массив сотрудников, в котором будет поиск </param>
        /// <param name="idToSerch"> ID для поиска </param>
        /// <returns></returns>
        private int FoundWorkerById(Worker[] workersToSearch, int idToSerch)
        {
            int foundWorkerElement = -1;
            for (int i = 0; i < workersToSearch.Length; i++)
            {
                if (workersToSearch[i].Id == idToSerch)
                {
                    foundWorkerElement = i;
                }
            }
            return foundWorkerElement;
        }

        /// <summary>
        /// Удаляет сотрудника под введенным ID и записывает получившуюся информацию в файл
        /// </summary>
        /// <param name="idToDelete"> ID для удаления </param>
        public void DeleteWorkerById(int idToDelete)
        {
            Worker[] workers = GetAllWorkers();

            int foundWorkerElementToDelete = FoundWorkerById(workers, idToDelete);

            if (foundWorkerElementToDelete == -1)
            {
                Console.WriteLine("Работник с введенным ID не найден!");
            }
            else
            {
                File.WriteAllText(workersInfoPath, string.Empty);
                for (int i = 0; i < workers.Length; i++)
                {
                    if (i == foundWorkerElementToDelete)
                    {
                        continue;
                    }
                    else
                    {
                        File.AppendAllText(workersInfoPath, WorkerInfoToWrite(workers[i]) + "\n");
                    }
                }
                Console.WriteLine("Информация об указанном работнике успешно удалена!");
            }
        }

        /// <summary>
        /// Преобразует информацию из передаваемой структуры сотрудника в строку
        /// </summary>
        /// <param name="workerToWrite"> Информация о сотруднике для преобразования в строку </param>
        /// <returns> Информация о сотруднике в строковом формате </returns>
        private string WorkerInfoToWrite(Worker workerToWrite)
        {
            string currentWorkerInfo = workerToWrite.Id.ToString() + "#" + workerToWrite.CrecreationDataTime.ToString() + "#" +
                                       workerToWrite.FIO.ToString() + "#" + workerToWrite.Age.ToString() + "#" +
                                       workerToWrite.Height.ToString() + "#" + workerToWrite.BirthDataTime.Date.ToString() + "#" +
                                       workerToWrite.BirthTown.ToString();
            return currentWorkerInfo;
        }

        /// <summary>
        /// Организует ввод информации о сотруднике с клавиатуры и запись ее в файл
        /// </summary>
        public void AddWorker()
        {
            Worker[] workers = GetAllWorkers();
            int newWorkerId = workers[workers.Length - 1].Id + 1;
            Worker newWorker = new Worker();
            newWorker.Id = newWorkerId;
            newWorker.CrecreationDataTime = DateTime.Now;
            newWorker.FIO = AddWorkerHelperString("Введите ФИО");
            newWorker.Age = AddWorkerHelperString("Введите возраст");
            newWorker.Height = AddWorkerHelperString("Введите рост");
            newWorker.BirthDataTime = AddWorkerHelperDataTime("Введите дату рождения");
            newWorker.BirthTown = AddWorkerHelperString("Введите город рождения");

            File.AppendAllText(workersInfoPath, "\n" + WorkerInfoToWrite(newWorker));
        }

        /// <summary>
        /// Выводин на экран подсказку для ввода информации и считывает информацию с клавиатуры в формате строки
        /// </summary>
        /// <param name="message"> Подсказка для ввода информации, выводящаяся на экран </param>
        /// <returns> Считанная информация с клавиатуры в формате строки </returns>
        private string AddWorkerHelperString(string message)
        {
            Console.WriteLine(message);
            string inputDataString = Console.ReadLine();
            return inputDataString;
        }

        /// <summary>
        /// Выводин на экран подсказку для ввода информации и считывает информацию с клавиатуры в формате даты
        /// </summary>
        /// <param name="message"> Подсказка для ввода информации, выводящаяся на экран </param>
        /// <returns> Считанная информация с клавиатуры в формате даты </returns>
        private DateTime AddWorkerHelperDataTime(string message)
        {
            Console.WriteLine(message);
            DateTime inputDataDateTime = DateTime.Parse(Console.ReadLine()).Date;
            return inputDataDateTime;
        }

        /// <summary>
        /// Выводит на экран массив сотрудников между двумя датами, введенными с клавиатуры
        /// </summary>
        public void ShowWorkersBetweenTwoDates()
        {
            Console.WriteLine("Введите дату начала сортировки");
            DateTime dateFrom = DateTime.Parse(Console.ReadLine()).Date;
            Console.WriteLine("Введите дату конца сортировки");
            DateTime dateTo = DateTime.Parse(Console.ReadLine()).Date;
            Console.WriteLine("\nОтсортированный список:\n");

            Worker[] workers = GetAllWorkers();
            foreach (Worker worker in workers)
            {
                if (worker.BirthDataTime > dateFrom && worker.BirthDataTime < dateTo)
                {
                    PrintWorkerHelper(worker);
                }
            }
        }

        /// <summary>
        /// Сортирует всех сотрудников по введенному с клавиатуры параметру
        /// </summary>
        public void SortAllWorkers()
        {
            Console.WriteLine("Сортировать информацию по: ");
            string sortBy = Console.ReadLine();

            Worker[] workers = GetAllWorkers();

            switch (sortBy)
            {
                case "ID":
                    var orderedWorkersById = workers.OrderBy(w => w.Id);
                    OrderByPrintHelper(orderedWorkersById);
                    break;
                case "Дате создания записи":
                    var orderedWorkersByCreation = workers.OrderBy(w => w.CrecreationDataTime);
                    OrderByPrintHelper(orderedWorkersByCreation);
                    break;
                case "ФИО":
                    var orderedWorkersByFIO = workers.OrderBy(w => w.FIO);
                    OrderByPrintHelper(orderedWorkersByFIO);
                    break;
                case "Возрасту":
                    var orderedWorkersByAge = workers.OrderBy(w => w.Age);
                    OrderByPrintHelper(orderedWorkersByAge);
                    break;
                case "Росту":
                    var orderedWorkersByHeight = workers.OrderBy(w => w.Height);
                    OrderByPrintHelper(orderedWorkersByHeight);
                    break;
                case "Дате рождения":
                    var orderedWorkersByBirth = workers.OrderBy(w => w.BirthDataTime);
                    OrderByPrintHelper(orderedWorkersByBirth);
                    break;
                case "Городу рождения":
                    var orderedWorkersByTown = workers.OrderBy(w => w.BirthTown);
                    OrderByPrintHelper(orderedWorkersByTown);
                    break;
                default:
                    Console.WriteLine("Данные для сортировки введены неправильно!");
                    break;
            }
        }

        /// <summary>
        /// Выводит на экран отортированный массив сотрудников
        /// </summary>
        /// <param name="sordedWorkerToPrint"> Отсортированный массив сотрудников </param>
        private void OrderByPrintHelper(IOrderedEnumerable<Worker> sordedWorkerToPrint)
        {
            foreach (var workerToPrint in sordedWorkerToPrint)
            {
                PrintWorkerHelper(workerToPrint);
            }
        }
    }
}
