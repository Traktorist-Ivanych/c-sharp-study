using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox8_6
{
    class WorkWithDictionary
    {
        /// <summary>
        /// Выполняет задание работы с Dictionary
        /// </summary>
        public void StartProcess()
        {
            Dictionary<string, string> phoneNumbersFIOs = new Dictionary<string, string>();

            string phoneNumber = string.Empty;
            string fio = string.Empty;

            Console.WriteLine("Для прекращения введите пустую строку");

            for (int i = 0; i < 2; i++)
            {
                Console.Write("Введите номер телефона: ");
                phoneNumber = Console.ReadLine();

                if (phoneNumber == string.Empty)
                {
                    break;
                }

                Console.Write("Введите ФИО владельца номера телефона: ");
                fio = Console.ReadLine();

                if (fio == string.Empty)
                {
                    break;
                }

                phoneNumbersFIOs.Add(phoneNumber, fio);

                i = 0;
            }

            Console.Write("\nВведите номер телефона для поиска ФИО владельца:");
            string PhoneNumberToSearch = Console.ReadLine();
            
            if (phoneNumbersFIOs.TryGetValue(PhoneNumberToSearch, out string foundFIO))
            {
                Console.WriteLine("ФИО владельца указанного номера телефона: " + foundFIO);
            }
            else
            {
                Console.WriteLine("Владельца указанного номера телефона нет в базе!");
            }
        }
    }
}
