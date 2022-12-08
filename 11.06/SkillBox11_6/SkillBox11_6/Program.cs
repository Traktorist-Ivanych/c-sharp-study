using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox11_6
{
    class Program
    {
        static WorkersXmlInfo xmlInfo = new WorkersXmlInfo();
        static ActionsWithWorkers actionsWithWorkers = new ActionsWithWorkers();

        static void Main(string[] args)
        {
            //xmlInfo.ReadInfo(); // Костыль для первоначального заполнения Xml документа

            Console.WriteLine("Для входа в программу консультанта введите 1.\n" +
                          "Для входа в программу менеджера введите 2.");
            int accessChoice = int.Parse(Console.ReadLine());

            if (accessChoice == 1)
            {
                actionsWithWorkers.ShowAllWorkers();

                actionsWithWorkers.ChangePhoneNumber(accessChoice);
            }
            else if (accessChoice == 2)
            {
                actionsWithWorkers.ShowAllWorkers();

                actionsWithWorkers.ChangePhoneNumber(accessChoice);

                actionsWithWorkers.AddNewWorker();
            }

            Console.ReadKey();
        }
    }
}
