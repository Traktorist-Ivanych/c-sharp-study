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

namespace SkillBox12_6
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int foundWorkerByPhone;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void JobTitleSelection_SelectionChange(object sender, SelectionChangedEventArgs e)
        {
            MethodPrint();

            JobTitleNotification.Opacity = 0;
            FindByPhoneButton.IsEnabled = true;
            EditButton.IsEnabled = true;
            SortButton.IsEnabled = true;

            if (JobTitleSelection.SelectedIndex == 0)
            {
                AddButton.IsEnabled = false;
                FullNameEditingBox.Opacity = 0;
                PassportEditingBox.Opacity = 0;
            }
            else if (JobTitleSelection.SelectedIndex == 1)
            {
                AddButton.IsEnabled = true;
            }
        }

        /// <summary>
        /// Метод подготовки к выводу на экран данных для кнопки: Показать работников
        /// </summary>
        /// <param name="path"></param>
        private void MethodPrint()
        {
            Employee newData = InitialiseClass();

            if (newData.GetType() == typeof(Consultant))
            {
                for (int i = 0; i < newData.WorkersCount; i++)
                {
                    DataGridFirst.ItemsSource = (newData as Consultant).ReadyToPrintToDataGrid();
                }
            }
            else
            {
                for (int i = 0; i < newData.WorkersCount; i++)
                {
                    DataGridFirst.ItemsSource = (newData as Manager).ReadyToPrintToDataGrid();
                }
            }
        }

        private Employee InitialiseClass()
        {
            Employee newData = new Employee();

            if (JobTitleSelection.SelectedIndex == 0) newData = new Consultant();
            else if (JobTitleSelection.SelectedIndex == 1) newData = new Manager();
            newData.LoadFromFile();

            return newData;
        }

        private void SortButton_Click(object sender, RoutedEventArgs e)
        {
            Employee newData = new Employee();

            newData.LoadFromFile();
            newData.SortBySurname();

            MethodPrint();
        }

        private void FindByPhoneButton_Click(object sender, RoutedEventArgs e)
        {
            Employee newData = InitialiseClass();

            if (newData.GetType() == typeof(Consultant))
            {
                foundWorkerByPhone = (newData as Consultant).FindTelNum(PhoneEditingBox.Text);
                if (foundWorkerByPhone == -1)
                {
                    TextBlockForNumber.Text = "Сотрудника с указанным номером не найдено!";
                }
                else
                {
                    TextBlockForNumber.Text = $"Номер в базе успешно найден. Сотрудник - " +
                                          $"{(newData as Consultant).PrintWorkerWithNumber(foundWorkerByPhone)}. " +
                                          $"Введите новый номер...";
                }
            }
            else
            {
                foundWorkerByPhone = (newData as Manager).FindTelNum(PhoneEditingBox.Text);

                if (foundWorkerByPhone == -1)
                {
                    TextBlockForNumber.Text = "Сотрудника с указанным номером не найдено!";
                }
                else
                {
                    FullNameEditingBox.Opacity = 100;
                    PassportEditingBox.Opacity = 100;

                    TextBlockForNumber.Text = $"Номер в базе успешно найден. Сотрудник - " +
                                              $"{(newData as Manager).PrintWorkerWithNumber(foundWorkerByPhone)}. " +
                                              $"Введите новые данные для редактирования...";
                }
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e)
        {
            Employee newData = InitialiseClass();

            if (newData.GetType() == typeof(Consultant))
            {
                (newData as Consultant).RechargeTelNum(foundWorkerByPhone, PhoneEditingBox.Text);
                TextBlockForNumber.Text = $"Номер в базе успешно изменен.";
            }
            else
            {
                (newData as Manager).RechargeTelNum(foundWorkerByPhone, PhoneEditingBox.Text);
                (newData as Manager).FullNameEditing(foundWorkerByPhone, FullNameEditingBox.Text);
                (newData as Manager).PassportEditing(foundWorkerByPhone, PassportEditingBox.Text);
                TextBlockForNumber.Text = $"Данные в базе успешно изменены.";
            }

            MethodPrint();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Manager newData = new Manager();

            newData.AddNewWorker(FullNameAddingBox.Text, PhoneAddingBox.Text, PassportAddingBox.Text);
            newData.LoadFromFile();

            for (int item = 0; item < newData.WorkersCount; item++)
            {
                DataGridFirst.ItemsSource = newData.ReadyToPrintToDataGrid();
            }
        }
    }
}
