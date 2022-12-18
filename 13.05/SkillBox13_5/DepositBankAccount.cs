using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox13_5
{
    public class DepositBankAccount : BankAccount, IBankAccount<BankAccount>
    {
        public DepositBankAccount() : base()
        {

        }
    }
}
