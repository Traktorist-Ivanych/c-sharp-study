using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkillBox11_6
{
    abstract class Worker
    {
        private protected string name;
        private protected string surname;
        private protected string patronymic;
        private protected string phoneNumber;
        private protected string passpordId;
        private protected string id;

        private protected string dateTimeChanges;
        private protected string сhangedFields;
        private protected string changesType;
        private protected string whoseChanges;

        /// <summary>
        /// Конструктор, заполняющий все полня из передаваемого XElement
        /// </summary>
        /// <param name="workerXml"> Передаваемый XElement, из которого берется информация для заполнения полей </param>
        public Worker(XElement workerXml)
        {
            name = workerXml.Attribute("Name").Value;
            surname = workerXml.Attribute("Surname").Value;
            patronymic = workerXml.Attribute("Patronymic").Value;
            phoneNumber = workerXml.Attribute("PhoneNumber").Value;
            passpordId = workerXml.Attribute("PasspordId").Value;
            id = workerXml.Attribute("ID").Value;

            dateTimeChanges = workerXml.Attribute("DateTimeChanges").Value;
            сhangedFields = workerXml.Attribute("ChangedFields").Value;
            changesType = workerXml.Attribute("ChangesType").Value;
            whoseChanges = workerXml.Attribute("WhoseChanges").Value;
        }

        private protected Worker()
        {

        }
    }
}
