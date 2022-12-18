using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SkillBox13_5
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BankClient BankClient1;
        public BankClient BankClient2;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            BankClient1 = new BankClient("Тракторист Петр Иваныч");
            BankClient2 = new BankClient("Тракторист Евгений Иваныч");

            Client1.Text = BankClient1.ClienFIO;
            Client2.Text = BankClient2.ClienFIO;
        }

        private void OpenDepositButton1_Click(object sender, RoutedEventArgs e)
        {
            if (BankClient1.OpenBankAccount(ref BankClient1.ClientDepositBankAccount) == true)
            {
                DepositStatus1.Text = "Открыт";
            }
        }

        private void CloseDepositButton1_Click(object sender, RoutedEventArgs e)
        {
            if (BankClient1.CloseBankAccount(ref BankClient1.ClientDepositBankAccount) == true)
            {
                DepositStatus1.Text = "Закрыт";
            }
        }

        private void TopUpDepositButton1_Click(object sender, RoutedEventArgs e)
        {
            IBankAccount<BankAccount> iBankAccount = BankClient1.ClientDepositBankAccount;

            BankAccount bankAccount1 = (BankAccount)iBankAccount;
            if (BankClient1.TopUpBankAccount(ref bankAccount1, int.Parse(TopUpDepositAmount1.Text)) == true)
            {
                BankClient1.ClientDepositBankAccount = (DepositBankAccount)bankAccount1;
                DepositMoney1.Text = BankClient1.ClientDepositBankAccount.moneyOnAccount.ToString();
            }
        }

        private void OpenNonDepositButton1_Click(object sender, RoutedEventArgs e)
        {
            if (BankClient1.OpenBankAccount(ref BankClient1.ClientNonDepositBankAccount) == true)
            {
                NonDepositStatus1.Text = "Открыт";
            }
        }

        private void CloseNonDepositButton1_Click(object sender, RoutedEventArgs e)
        {
            if (BankClient1.CloseBankAccount(ref BankClient1.ClientNonDepositBankAccount) == true)
            {
                NonDepositStatus1.Text = "Закрыт";
            }
        }

        private void TopUpNonDepositButton1_Click(object sender, RoutedEventArgs e)
        {
            IBankAccount<BankAccount> iBankAccount = BankClient1.ClientNonDepositBankAccount;

            BankAccount bankAccount1 = (BankAccount)iBankAccount;
            if (BankClient1.TopUpBankAccount(ref bankAccount1, int.Parse(TopUpNonDepositAmount1.Text)) == true)
            {
                BankClient1.ClientNonDepositBankAccount = (NonDepositBankAccount)bankAccount1;
                NonDepositMoney1.Text = BankClient1.ClientNonDepositBankAccount.moneyOnAccount.ToString();
            }
        }

        private void TransferButton1_Click(object sender, RoutedEventArgs e)
        {
            BankClient bankClient1Temp = BankClient1;

            if (BankClient1.WithdrawBankAccount(ref BankClient1.ClientNonDepositBankAccount, int.Parse(TransferAmount1.Text)) == true &&
                BankClient1.TopUpBankAccount(ref BankClient1.ClientDepositBankAccount, int.Parse(TransferAmount1.Text)) == true)
            {
                NonDepositMoney1.Text = BankClient1.ClientNonDepositBankAccount.moneyOnAccount.ToString();
                DepositMoney1.Text = BankClient1.ClientDepositBankAccount.moneyOnAccount.ToString();
            }
            else
            {
                BankClient1 = bankClient1Temp;
            }
        }

        private void OpenDepositButton2_Click(object sender, RoutedEventArgs e)
        {
            if (BankClient2.OpenBankAccount(ref BankClient2.ClientDepositBankAccount) == true)
            {
                DepositStatus2.Text = "Открыт";
            }
        }

        private void CloseDepositButton2_Click(object sender, RoutedEventArgs e)
        {
            if (BankClient2.CloseBankAccount(ref BankClient2.ClientDepositBankAccount) == true)
            {
                DepositStatus2.Text = "Закрыт";
            }
        }

        /// <summary>
        /// Реализация ковариантности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopUpDepositButton2_Click(object sender, RoutedEventArgs e)
        {
            IBankAccount<BankAccount> iBankAccount = BankClient2.ClientDepositBankAccount;

            BankAccount bankAccount2 = (BankAccount)iBankAccount;
            if (BankClient2.TopUpBankAccount(ref bankAccount2, int.Parse(TopUpDepositAmount2.Text)) == true)
            {
                BankClient2.ClientDepositBankAccount = (DepositBankAccount)bankAccount2;
                DepositMoney2.Text = BankClient2.ClientDepositBankAccount.moneyOnAccount.ToString();
            }
        }

        private void OpenNonDepositButton2_Click(object sender, RoutedEventArgs e)
        {
            if (BankClient2.OpenBankAccount(ref BankClient2.ClientNonDepositBankAccount) == true)
            {
                NonDepositStatus2.Text = "Открыт";
            }
        }

        private void CloseNonDepositButton2_Click(object sender, RoutedEventArgs e)
        {
            if (BankClient2.CloseBankAccount(ref BankClient2.ClientNonDepositBankAccount) == true)
            {
                NonDepositStatus2.Text = "Закрыт";
            }
        }

        /// <summary>
        /// Реализация ковариантности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TopUpNonDepositButton2_Click(object sender, RoutedEventArgs e)
        {
            IBankAccount<BankAccount> iBankAccount = BankClient2.ClientNonDepositBankAccount;
            BankAccount bankAccount2 = (BankAccount)iBankAccount;

            if (BankClient2.TopUpBankAccount(ref bankAccount2, int.Parse(TopUpNonDepositAmount2.Text)) == true)
            {
                BankClient2.ClientNonDepositBankAccount = (NonDepositBankAccount)bankAccount2;
                NonDepositMoney2.Text = BankClient2.ClientNonDepositBankAccount.moneyOnAccount.ToString();
            }
        }

        private void TransferButton2_Click(object sender, RoutedEventArgs e)
        {
            BankClient bankClient1Temp = BankClient2;

            if (BankClient2.WithdrawBankAccount(ref BankClient2.ClientNonDepositBankAccount, int.Parse(TransferAmount2.Text)) == true &&
                BankClient2.TopUpBankAccount(ref BankClient2.ClientDepositBankAccount, int.Parse(TransferAmount2.Text)) == true)
            {
                NonDepositMoney2.Text = BankClient2.ClientNonDepositBankAccount.moneyOnAccount.ToString();
                DepositMoney2.Text = BankClient2.ClientDepositBankAccount.moneyOnAccount.ToString();
            }
            else
            {
                BankClient2 = bankClient1Temp;
            }
        }

        /// <summary>
        /// Реализация контравариантности
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TransferBetweenClients_Click(object sender, RoutedEventArgs e)
        {
            INonDepositBankAccount<NonDepositBankAccount> iNonDepositBankAccount1 = BankClient1.ClientNonDepositBankAccount;
            BankAccount bankAccount1 = (BankAccount)iNonDepositBankAccount1;

            INonDepositBankAccount<NonDepositBankAccount> iNonDepositBankAccount2 = BankClient2.ClientNonDepositBankAccount;
            BankAccount bankAccount2 = (BankAccount)iNonDepositBankAccount2;

            if (BankClient1.WithdrawBankAccount(ref bankAccount1, int.Parse(TransferBetweenClientsAmount1.Text)) == true &&
                BankClient2.TopUpBankAccount(ref bankAccount2, int.Parse(TransferBetweenClientsAmount1.Text)) == true)
            {
                BankClient1.ClientNonDepositBankAccount = (NonDepositBankAccount)bankAccount1;
                BankClient2.ClientNonDepositBankAccount = (NonDepositBankAccount)bankAccount2;

                NonDepositMoney1.Text = BankClient1.ClientNonDepositBankAccount.moneyOnAccount.ToString();
                NonDepositMoney2.Text = BankClient2.ClientNonDepositBankAccount.moneyOnAccount.ToString();
            }
        }
    }
}
