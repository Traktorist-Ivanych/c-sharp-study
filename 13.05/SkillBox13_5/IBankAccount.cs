using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox13_5
{
    public interface IBankAccount<out T>
        where T: BankAccount
    {
        
    }
}
