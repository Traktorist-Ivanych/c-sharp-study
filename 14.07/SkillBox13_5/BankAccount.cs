using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox14_7
{
    public class BankAccount : INonDepositBankAccount<NonDepositBankAccount>
    {
        public BankAccount()
        {
            isAccountOpen = false;
            moneyOnAccount = 0;
        }

        public bool isAccountOpen;
        public int moneyOnAccount;
    }
}
