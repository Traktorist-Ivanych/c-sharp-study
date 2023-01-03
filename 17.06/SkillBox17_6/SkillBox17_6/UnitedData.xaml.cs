using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для UnitedData.xaml
    /// </summary>
    public partial class UnitedData : Window
    {
        public UnitedData()
        {
            InitializeComponent();

            SqlConnectionStringBuilder connectionStringBuilder = new SqlConnectionStringBuilder
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "MSSQLLocalDemo"
            };
            SqlConnection sqlConnection = new SqlConnection(connectionStringBuilder.ConnectionString);

            var sql = @"SELECT 
                        Workers.Id as 'ID',
                        Workers.workerName as 'Имя',
                        Workers.workerSurname as 'Фамилия',
                        Workers.workerPatronymic as 'Отчество',
                        Workers.phoneNumber as 'Номер телефона',
                        Workers.email as 'Email',
                        [Product].[productId] as 'Id продукта',
                        [Product].[productName] as 'Наименование продукта'
                        FROM Workers, [Product]
                        WHERE Workers.email = [Product].[email]
                        Order By Workers.email";

            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter();

            dataAdapter.SelectCommand = new SqlCommand(sql, sqlConnection);
            dataAdapter.Fill(dataTable);

            gridAllView.DataContext = dataTable.DefaultView;
        }
    }
}
