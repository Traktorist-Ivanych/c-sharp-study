using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox15_06_Library
{
    class EasterEggException : Exception
    {
        public EasterEggException()
        {
            Message = "Пасхалка!";
        }

        public new string Message;
    }
}
