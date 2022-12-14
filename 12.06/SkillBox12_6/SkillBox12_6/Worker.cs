using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox12_6
{
    public class Worker
    {
        public string FIO { get; set; }
        public string PhoneNumber { get; set; }
        public string PassportNumber { get; set; }
        public string ChangesDataTime { get; set; }
        public string JobTitle { get; set; }

        /// <summary>
        /// Создание работника
        /// </summary>
        /// <param name="fio"></param>
        /// <param name="phoneNumber"></param>
        /// <param name="passportNumber"></param>
        /// <param name="changesDataTime"></param>
        /// <param name="jobTitle"></param>
        public Worker(string fio, string phoneNumber, string passportNumber, string changesDataTime, string jobTitle)
        {
            FIO = fio;
            PhoneNumber = phoneNumber;
            PassportNumber = passportNumber;
            ChangesDataTime = changesDataTime;
            JobTitle = jobTitle;
        }
    }
}
