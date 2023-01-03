using System;
using System.Collections.Generic;
using System.Data;
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
using System.Windows.Shapes;

namespace SkillBox17_6
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {
            InitializeComponent();
        }
        public AddWindow(DataRow dataRow) : this()
        {
            cancelBtn.Click += delegate { this.DialogResult = false; };
            okBtn.Click += delegate
            {
                dataRow["workerName"] = AddWorkerName.Text;
                dataRow["workerSurname"] = AddWorkerSurname.Text;
                dataRow["workerPatronymic"] = AddWorkerPatronymic.Text;
                dataRow["phoneNumber"] = AddPhoneNumber.Text;
                dataRow["email"] = AddEmail.Text;
                this.DialogResult = true;
            };
        }
    }
}
