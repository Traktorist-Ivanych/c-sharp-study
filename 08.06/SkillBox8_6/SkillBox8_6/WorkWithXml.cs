using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkillBox8_6
{
    class WorkWithXml
    {
        /// <summary>
        /// Выполняет задание работы с XML
        /// </summary>
        public void StartProcess()
        {
            Console.Write("Введите ФИО контакта: ");
            string fio = Console.ReadLine();

            Console.Write("Введите улицу проживания контакта: ");
            string street = Console.ReadLine();

            Console.Write("Введите номер дом контакта: ");
            string houseNumber = Console.ReadLine();

            Console.Write("Введите номер квартиры контакта: ");
            string flatNumber = Console.ReadLine();

            Console.Write("Введите номер мобильного телефона контакта: ");
            string mobilePhoneNumber = Console.ReadLine();

            Console.Write("Введите номер домашнего телефона контакта: ");
            string flatPhoneNumber = Console.ReadLine();

            XElement personXE = new XElement("Person");
            XAttribute perconXEName = new XAttribute("name", fio);

            XElement addressXE = new XElement("Address");
            XAttribute addressXEStreet = new XAttribute("Street", street);
            XAttribute addressXEHouseNumber = new XAttribute("HouseNumber", houseNumber);
            XAttribute addressXEFlatNumber = new XAttribute("FlatNumber", flatNumber);

            XElement phonesXE = new XElement("Phones");
            XAttribute phonesXEMobile = new XAttribute("MobilePhone", mobilePhoneNumber);
            XAttribute phonesXEFlat = new XAttribute("FlatPhone", flatPhoneNumber);

            phonesXE.Add(phonesXEMobile, phonesXEFlat);
            addressXE.Add(addressXEStreet, addressXEHouseNumber, addressXEFlatNumber);
            personXE.Add(perconXEName, addressXE, phonesXE);

            personXE.Save("PersonInfo.xml");
        }

    }
}
