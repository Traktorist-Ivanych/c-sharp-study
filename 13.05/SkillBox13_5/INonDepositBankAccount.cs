using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox13_5
{
    public interface INonDepositBankAccount<in T>
        where T : NonDepositBankAccount
    {
    }
}
