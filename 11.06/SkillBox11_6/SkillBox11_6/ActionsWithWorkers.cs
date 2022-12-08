using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkillBox11_6
{
    class ActionsWithWorkers
    {
        private WorkersXmlInfo xmlInfo = new WorkersXmlInfo();

        /// <summary>
        /// Выводит информацию о всех сотрудниках на экран
        /// </summary>
        public void ShowAllWorkers()
        {
            List<Consultant> consultants = CreateConsultantsList();

            foreach (Consultant consultant in consultants)
            {
                consultant.ShowWorkerInfo();
            }
        }

        /// <summary>
        /// Изменение номера телефона сотрудника
        /// </summary>
        /// <param name="accessLvl"> Уровень доступа для определения, кем изменяется информация </param>
        public void ChangePhoneNumber(int accessLvl)
        {
            List<Consultant> consultants = CreateConsultantsList();

            Console.Write("Введите ID работника, номер которого вы хотите изменить: ");
            string inputIdToChange = Console.ReadLine();

            for (int i = 0; i < consultants.Count; i++)
            {
                if (consultants[i].ID == inputIdToChange)
                {
                    Console.Write("Введите новый номер телефона: ");
                    string newPhoneNumber = Console.ReadLine();
                    consultants[i].PhoneNumber = newPhoneNumber;
                    if (accessLvl == 1)
                    {
                        consultants[i].WhoseChanges = "Consultant";
                    }
                    else if (accessLvl == 2)
                    {
                        consultants[i].WhoseChanges = "Manager";
                    }
                    SaveConsultantsList(consultants);
                    break;
                }
                else if (consultants[i].ID == consultants[consultants.Count - 1].ID)
                {
                    Console.WriteLine("Работник под данным ID не найден");
                }
            }
        }

        /// <summary>
        /// Ввод информации о новом сотруднике с клавиатуры и последующее ее сохранение
        /// </summary>
        public void AddNewWorker()
        {
            string inputName = ReadInfoHelper("Введите имя: ");
            string inputSurname = ReadInfoHelper("Введите фамилию: ");
            string inputPatronymic = ReadInfoHelper("Введите отчество: ");
            string inputPhoneNumber = ReadInfoHelper("Введите номер телефона: ");
            string inputPasspordId = ReadInfoHelper("Введите серию и номер паспорта: ");

            List<Consultant> consultantsForAddingNew = CreateConsultantsList();

            string newWorkerId = (consultantsForAddingNew.Count + 1).ToString();

            Manager newWorker = new Manager(inputName, inputSurname, inputPatronymic,
                                            inputPhoneNumber, inputPasspordId, newWorkerId);

            Consultant newConsultantFromManager = new Consultant();

            newConsultantFromManager = newWorker;

            consultantsForAddingNew.Add(newConsultantFromManager);

            SaveConsultantsList(consultantsForAddingNew);
        }

        /// <summary>
        /// Сериализация передаваемого списка сотрудников
        /// </summary>
        /// <param name="consultantsToSave"> Список передаваемых сотрудников для сериализации </param>
        private void SaveConsultantsList(List<Consultant> consultantsToSave)
        {
            List<XElement> consultantsXEToSave = new List<XElement>();

            foreach(Consultant consultantToSave in consultantsToSave)
            {
                consultantsXEToSave.Add(consultantToSave.WorkersInfoXEToSave());
            }

            xmlInfo.SaveWorkers(consultantsXEToSave);
        }

        /// <summary>
        /// Десериализация всей информации о сотрудниках
        /// </summary>
        /// <returns> Список информации о каждом сотруднике по отдельности </returns>
        private List<Consultant> CreateConsultantsList()
        {
            List<Consultant> consultants = new List<Consultant>();
            List<XElement> workersXE = xmlInfo.GetAllWorkersXE();

            foreach (XElement workerXE in workersXE)
            {
                consultants.Add(new Consultant(workerXE));
            }
            
            return consultants;
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
    }
}
