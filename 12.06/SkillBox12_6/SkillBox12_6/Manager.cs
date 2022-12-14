using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox12_6
{
    public class Manager : Consultant
    {
        public Manager()
        {

        }

        /// <summary>
        /// Готовим к выводу данные из List<Worker> в DataGrid
        /// </summary>
        /// <returns> Готовый List<Worker> для вывода в DataGrid </returns>
        public new List<Worker> ReadyToPrintToDataGrid()
        {
            return workers;
        }

        /// <summary>
        /// Добавляем нового сотрудника
        /// </summary>
        /// <param name="fullName"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="passport"></param>
        public void AddNewWorker(string fullName, string phoneNumber, string passport)
        {
            using (StreamWriter sw = new StreamWriter(Constants.Path, true))
            {
                string note = $"{fullName}#{phoneNumber}#{passport}#" + DateTime.Now.ToString() + "#Менеджер";
                sw.WriteLine(note);
            }
        }

        /// <summary>
        /// Изменение ФИО
        /// </summary>
        /// <param name="foundIndex"> Индекс изменяемого работника </param>
        /// <param name="fullName"> Новое ФИО </param>
        public new void FullNameEditing(int foundIndex, string fullName)
        {
            workers[foundIndex].FIO = fullName;

            WriteDataToTxt(workers);
        }

        /// <summary>
        /// Изменение номера телефона
        /// </summary>
        /// <param name="foundIndex"> Индекс изменяемого работника </param>
        /// <param name="phoneNumber"> Новый номер телефона </param>
        public new int FindTelNum(string phoneNumber)
        {
            int foundIndex = base.FindTelNum(phoneNumber);
            return foundIndex;
        }

        /// <summary>
        /// Изменение номер телефона
        /// </summary>
        /// <param name="foundIndex"></param>
        /// <param name="phoneNumber"></param>
        public new void RechargeTelNum(int foundIndex, string phoneNumber)
        {
            workers[foundIndex].PhoneNumber = phoneNumber;
            workers[foundIndex].JobTitle = "Менеджер";

            WriteDataToTxt(workers);
        }

        /// <summary>
        /// Изменение паспортных данных
        /// </summary>
        /// <param name="foundIndex"></param>
        /// <param name="passportData"></param>
        public new void PassportEditing(int foundIndex, string passportData)
        {
            workers[foundIndex].PassportNumber = passportData;

            WriteDataToTxt(workers);
        }
    }
}
