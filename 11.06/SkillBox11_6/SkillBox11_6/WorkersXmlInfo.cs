using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkillBox11_6
{
    class WorkersXmlInfo
    {
        private string fileName = "WorkersInfo.xml";

        /// <summary>
        /// Заполнение и сохранение информации о сотруднике (использовал для создания файла Xml в начале выполнения задания)
        /// </summary>
        public void ReadInfo()
        {
            FileCreatedCheck();

            string inputName = ReadInfoHelper("Введите имя: ");
            string inputSurname = ReadInfoHelper("Введите фамилию: ");
            string inputPatronymic = ReadInfoHelper("Введите отчество: ");
            string inputPhoneNumber = ReadInfoHelper("Введите номер телефона: ");
            string inputPasspordId = ReadInfoHelper("Введите серию и номер паспорта: ");

            XDocument workersInfo = XDocument.Load(fileName);

            XElement workerXE = new XElement("Worker");
            XAttribute workerXEName = new XAttribute("Name", inputName);
            XAttribute workerXESurname = new XAttribute("Surname", inputSurname);
            XAttribute workerXEPatronymic = new XAttribute("Patronymic", inputPatronymic);
            XAttribute workerXEPhoneNumber = new XAttribute("PhoneNumber", inputPhoneNumber);
            XAttribute workerXEPasspordId = new XAttribute("PasspordId", inputPasspordId);

            string workersXml = File.ReadAllText(fileName);
            List<XElement> workersXE = XDocument.Parse(workersXml)
                                              .Descendants("Workers")
                                              .Descendants("Worker")
                                              .ToList();

            XAttribute workerXEId = new XAttribute("ID", workersXE.Count + 1);

            XAttribute workerXEdateTimeChanges = new XAttribute("DateTimeChanges", "Изменений не было");
            XAttribute workerXEсhangedFields = new XAttribute("ChangedFields", "Изменений не было");
            XAttribute workerXEchangesType = new XAttribute("ChangesType", "Изменений не было");
            XAttribute workerXEwhoseChanges = new XAttribute("WhoseChanges", "Изменений не было");

            workerXE.Add(workerXEName, workerXESurname, workerXEPatronymic,
                         workerXEPhoneNumber, workerXEPasspordId, workerXEId,
                         workerXEdateTimeChanges, workerXEсhangedFields,
                         workerXEchangesType, workerXEwhoseChanges);
            workersInfo.Root.Add(workerXE);
            workersInfo.Save(fileName);
        }

        /// <summary>
        /// Помощник ввода информации с клавиатуры
        /// </summary>
        /// <param name="message"> Сообщение для отображения на экране </param>
        /// <returns> Ввод с клавиатуры </returns>
        private string ReadInfoHelper(string message)
        {
            Console.Write(message);
            string readInfo = Console.ReadLine();
            return readInfo;
        }

        /// <summary>
        /// Проверка создания файла для сохранения
        /// </summary>
        private void FileCreatedCheck()
        {
            if (File.Exists(fileName))
            {
                return;
            }
            else
            {
                XDocument newWorkersInfo = CreateNewWorkersInfoXD();
                newWorkersInfo.Save(fileName);
            }
        }

        /// <summary>
        /// Создание XDocument для записи в него XElements
        /// </summary>
        /// <returns> Созданный XDocument с Root XElement </returns>
        private XDocument CreateNewWorkersInfoXD()
        {
            XDocument newWorkersInfo = new XDocument();
            XElement rootXE = new XElement("Workers");
            newWorkersInfo.AddFirst(rootXE);
            return newWorkersInfo;
        }

        /// <summary>
        /// Десериализация Xml файла в List<XElement>
        /// </summary>
        /// <returns> Список XElement каждого сотрудника </returns>
        public List<XElement> GetAllWorkersXE()
        {
            string workersXml = File.ReadAllText(fileName);
            List<XElement> workersXE = XDocument.Parse(workersXml)
                                              .Descendants("Workers")
                                              .Descendants("Worker")
                                              .ToList();

            return workersXE;
        }

        /// <summary>
        /// Сериализация передаваемого списка XElement, содержащих информацию о сотрудниках
        /// </summary>
        /// <param name="workersXE"> Передаваемый список XElement для сериализации </param>
        public void SaveWorkers(List<XElement> workersXE)
        {
            XDocument newWorkersInfoToSave = CreateNewWorkersInfoXD();

            foreach(XElement workerXE in workersXE)
            {
                newWorkersInfoToSave.Root.Add(workerXE);
            }

            newWorkersInfoToSave.Save(fileName);
        }
    }
}
