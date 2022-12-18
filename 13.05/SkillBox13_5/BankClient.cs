using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox13_5
{
    public class BankClient
    {
        public BankClient(string clientFIO)
        {
            ClienFIO = clientFIO;
            ClientDepositBankAccount = new DepositBankAccount();
            ClientNonDepositBankAccount = new NonDepositBankAccount();
        }

        public DepositBankAccount ClientDepositBankAccount;
        public NonDepositBankAccount ClientNonDepositBankAccount;
        public string ClienFIO { get; set; }

        /// <summary>
        /// Открытие счета
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bankAccountToOpen"> Счет для открытия </param>
        /// <returns> True - если открытие произошло успешно, False - если счет уже открыт </returns>
        public bool OpenBankAccount<T>(ref T bankAccountToOpen)
            where T : BankAccount
        {
            if (bankAccountToOpen.isAccountOpen == false)
            {
                bankAccountToOpen.isAccountOpen = true;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Закрытие счета
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="bankAccountToClose"></param>
        /// <returns> True - если закрытие произошло успешно, False - если счет уже закрыт </returns>
        public bool CloseBankAccount<T>(ref T bankAccountToClose)
            where T : BankAccount
        {
            if (bankAccountToClose.isAccountOpen == true)
            {
                bankAccountToClose.isAccountOpen = false;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Пополнение банковского счета
        /// </summary>
        /// <param name="bankAccountToTopUp"></param>
        /// <param name="TopUpAmount"></param>
        /// <returns> True - если пополнение произошло успешно, False - если пополнение не произошло </returns>
        public bool TopUpBankAccount<T>(ref T bankAccountToTopUp, int TopUpAmount)
            where T : BankAccount
        {
            if (bankAccountToTopUp.isAccountOpen == true)
            {
                bankAccountToTopUp.moneyOnAccount += TopUpAmount;
                return true;
            }
            else
            {
                return false;
            }
        }


        /// <summary>
        /// Списание средств с банковского счета
        /// </summary>
        /// <param name="bankAccountWithdra"></param>
        /// <param name="WithdraAmount"></param>
        /// <returns> True - если списание произошло успешно, False - если списание не произошло </returns>
        public bool WithdrawBankAccount<T>(ref T bankAccountWithdra, int WithdraAmount)
            where T : BankAccount
        {
            if (bankAccountWithdra.isAccountOpen == true && bankAccountWithdra.moneyOnAccount - WithdraAmount >= 0)
            {
                bankAccountWithdra.moneyOnAccount -= WithdraAmount;
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
