using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkillBox11_6
{
    class Manager : Consultant
    {
        public Manager(XElement managerXml) : base(managerXml)
        {

        }

        /// <summary>
        /// Конструктор для создания экземпляра класса с введенными передаваемыми данными
        /// </summary>
        /// <param name="newName"> Имя </param>
        /// <param name="newSurname"> Фамилия </param>
        /// <param name="newPatronymic"> Отчество </param>
        /// <param name="newPhoneNumber"> Номер телефона </param>
        /// <param name="newPasspordId"> Серия и номер паспорта </param>
        /// <param name="newId"> ID работника </param>
        public Manager(string newName, string newSurname, string newPatronymic, 
                       string newPhoneNumber, string newPasspordId, string newId)
        {
            id = newId;
            name = newName;
            surname = newSurname;
            patronymic = newPatronymic;
            phoneNumber = newPhoneNumber;
            passpordId = newPasspordId;

            dateTimeChanges = DateTime.Now.ToString();
            сhangedFields = "Все";
            changesType = "Создание";
            whoseChanges = "Manager";
        }
    }
}
