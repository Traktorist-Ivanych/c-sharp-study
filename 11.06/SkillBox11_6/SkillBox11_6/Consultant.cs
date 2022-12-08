using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkillBox11_6
{
    class Consultant : Worker, IWorkerChanges
    {
        public Consultant(XElement consultantXml) : base(consultantXml)
        {

        }

        public Consultant()
        {

        }

        public string Name
        {
            get => name;
        }

        public string Surname
        {
            get => surname;
        }

        public string Patronymic
        {
            get => patronymic;
        }

        /// <summary>
        /// Свойство для вывода и ввода нового номера телефона
        /// </summary>
        public string PhoneNumber
        {
            get => phoneNumber;
            set => SetPhoneNumber(value);
        }

        /// <summary>
        /// Свойство для вывода скрытой информации паспорта
        /// </summary>
        public string PasspordId
        {
            get { return "*********"; }
        }

        public string ID
        {
            get => id;
        }

        public string WhoseChanges
        {
            get => whoseChanges;
            set => whoseChanges = value;
        }

        /// <summary>
        /// Метод проверки заполнения передаваемого нового номера телефона и записи нового номера
        /// </summary>
        /// <param name="inputPhoneNumber"> Новый номер телефона </param>
        private protected void SetPhoneNumber(string inputPhoneNumber)
        {
            if (inputPhoneNumber.Length == 13)
            {
                phoneNumber = inputPhoneNumber;
                ChangePhoneNumber();
            }
            else
            {
                Console.WriteLine("Введен неверный формат номера телефона");
            }
        }

        /// <summary>
        /// Описание метода интерфейса для заполнения информации об изменениях
        /// </summary>
        public void ChangePhoneNumber()
        {
            dateTimeChanges = DateTime.Now.ToString();
            сhangedFields = "PhoneNumber";
            changesType = "Change";
        }

        /// <summary>
        /// Выводит всю информацию о сотруднике на экран
        /// </summary>
        public void ShowWorkerInfo()
        {
            string workerInfo = "ID: {0}\n" +
                                "Имя: {1}\n" +
                                "Фамилия: {2}\n" +
                                "Отчество: {3}\n" +
                                "Номер телефона: {4}\n" +
                                "Серия и номер паспорта: {5}\n" +
                                "\n" +
                                "Время и дата изменений: {6}\n" +
                                "Измененные полня: {7}\n" +
                                "Тип изменений: {8}\n" +
                                "Кто изменил данные: {9}\n";
            Console.WriteLine(workerInfo, ID, Name, Surname, Patronymic, PhoneNumber, PasspordId, 
                                          dateTimeChanges, сhangedFields, changesType, whoseChanges);
        }

        /// <summary>
        /// Запись всей информации о сотруднике в XElement для дальнейшей сериализации
        /// </summary>
        /// <returns></returns>
        public XElement WorkersInfoXEToSave()
        {
            XElement workerXE = new XElement("Worker");
            XAttribute workerXEName = new XAttribute("Name", name);
            XAttribute workerXESurname = new XAttribute("Surname", surname);
            XAttribute workerXEPatronymic = new XAttribute("Patronymic", patronymic);
            XAttribute workerXEPhoneNumber = new XAttribute("PhoneNumber", phoneNumber);
            XAttribute workerXEPasspordId = new XAttribute("PasspordId", passpordId);
            XAttribute workerXEId = new XAttribute("ID", id);

            XAttribute workerXEdateTimeChanges = new XAttribute("DateTimeChanges", dateTimeChanges);
            XAttribute workerXEсhangedFields = new XAttribute("ChangedFields", сhangedFields);
            XAttribute workerXEchangesType = new XAttribute("ChangesType", changesType);
            XAttribute workerXEwhoseChanges = new XAttribute("WhoseChanges", whoseChanges);

            workerXE.Add(workerXEName, workerXESurname, workerXEPatronymic,
                         workerXEPhoneNumber, workerXEPasspordId, workerXEId,
                         workerXEdateTimeChanges, workerXEсhangedFields,
                         workerXEchangesType, workerXEwhoseChanges);

            return workerXE;
        }
    }
}
