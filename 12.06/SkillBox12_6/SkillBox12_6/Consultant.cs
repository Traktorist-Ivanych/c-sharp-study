using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox12_6
{
    public class Consultant : Employee, IEditing
    {
        public Consultant()
        {

        }

        /// <summary>
        /// Вовзращает индекс найденного по передаваемому номеру работника
        /// </summary>
        /// <param name="phoneNumber"></param>
        /// <returns> Индекс работника, если он найден. -1 - если работник не найден </returns>
        public int FindTelNum(string phoneNumber)
        {
            int phoneIndex = -1;

            for (int i = 0; i < workers.Count; i++)
            {
                if (workers[i].PhoneNumber == phoneNumber)
                {
                    phoneIndex = i;
                }
            }

            return phoneIndex;
        }

        /// <summary>
        /// Изменение номера телефона
        /// </summary>
        /// <param name="foundIndex"> Индекс изменяемого работника </param>
        /// <param name="phoneNumber"> Новый номер телефона </param>
        public void RechargeTelNum(int foundIndex, string phoneNumber)
        {
            workers[foundIndex].PhoneNumber = phoneNumber;
            workers[foundIndex].JobTitle = "Консультант";

            WriteDataToTxt(workers);
        }

        public void FullNameEditing(int indexFind, string fullName)
        {
            throw new NotImplementedException();
        }

        public void PassportEditing(int indexFind, string passportData)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Готовим к выводу данные из List<Worker> в DataGrid
        /// </summary>
        /// <returns> Готовый List<Worker> для вывода в DataGrid </returns>
        public List<Worker> ReadyToPrintToDataGrid()
        {
            List<Worker> publicWorkersArray = new List<Worker>();

            for (int i = 0; i < workers.Count; i++)
            {
                publicWorkersArray.Add(workers[i]);
                publicWorkersArray[i].PassportNumber = "*********";
            }

            return publicWorkersArray;
        }
    }
}
