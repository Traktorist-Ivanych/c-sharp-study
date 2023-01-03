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
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Data;

namespace SkillBox17_6
{
    /// <summary> 
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnectionStringBuilder sqlConnectionBuilder;
        SqlConnection sqlConnection;
        SqlDataAdapter sqlDataAdapter;
        DataTable dataTable;
        DataRowView dataRow;

        public MainWindow()
        {
            InitializeComponent();

            #region Init
            sqlConnectionBuilder = new SqlConnectionStringBuilder()
            {
                DataSource = @"(localdb)\MSSQLLocalDB",
                InitialCatalog = "MSSQLLocalDemo",
                IntegratedSecurity = true,
                UserID = "admin",
                Password = "qwerty"
            };

            sqlConnection = new SqlConnection(sqlConnectionBuilder.ConnectionString);
            sqlDataAdapter = new SqlDataAdapter();
            dataTable = new DataTable();
            #endregion
        }

        private void SingInButton_Click(object sender, RoutedEventArgs e)
        {
            if (LoginTextBox.Text == sqlConnectionBuilder.UserID &&
                PasswordTextBox.Text == sqlConnectionBuilder.Password)
            {
                string sql;

                #region Select
                sql = @"SELECT * FROM Workers Order By Workers.Id";
                sqlDataAdapter.SelectCommand = new SqlCommand(sql, sqlConnection);
                #endregion

                #region Insert

                sql = @"INSERT INTO Workers (workerName, workerSurname, workerPatronymic,  phoneNumber,  email) 
                                 VALUES (@workerName, @workerSurname, @workerPatronymic, @phoneNumber, @email); 
                     SET @Id = @@IDENTITY;";

                sqlDataAdapter.InsertCommand = new SqlCommand(sql, sqlConnection);

                sqlDataAdapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id").Direction = ParameterDirection.Output;
                sqlDataAdapter.InsertCommand.Parameters.Add("@workerName", SqlDbType.NVarChar, 50, "workerName");
                sqlDataAdapter.InsertCommand.Parameters.Add("@workerSurname", SqlDbType.NVarChar, 50, "workerSurname");
                sqlDataAdapter.InsertCommand.Parameters.Add("@workerPatronymic", SqlDbType.NVarChar, 50, "workerPatronymic");
                sqlDataAdapter.InsertCommand.Parameters.Add("@phoneNumber", SqlDbType.NVarChar, 50, "phoneNumber");
                sqlDataAdapter.InsertCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50, "email");

                #endregion

                #region Update
                sql = @"UPDATE Workers SET 
                           workerName = @workerName,
                           workerSurname = @workerSurname, 
                           workerPatronymic = @workerPatronymic,
                           phoneNumber = @phoneNumber,
                           email = @email,
                    WHERE Id = @Id";

                sqlDataAdapter.UpdateCommand = new SqlCommand(sql, sqlConnection);
                sqlDataAdapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id").SourceVersion = DataRowVersion.Original;
                sqlDataAdapter.UpdateCommand.Parameters.Add("@workerName", SqlDbType.NVarChar, 50, "workerName");
                sqlDataAdapter.UpdateCommand.Parameters.Add("@workerSurname", SqlDbType.NVarChar, 50, "workerSurname");
                sqlDataAdapter.UpdateCommand.Parameters.Add("@workerPatronymic", SqlDbType.NVarChar, 50, "workerPatronymic");
                sqlDataAdapter.UpdateCommand.Parameters.Add("@phoneNumber", SqlDbType.NVarChar, 50, "phoneNumber");
                sqlDataAdapter.UpdateCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50, "email");
                #endregion

                #region Delete
                sql = "DELETE FROM Workers WHERE Id = @Id";

                sqlDataAdapter.DeleteCommand = new SqlCommand(sql, sqlConnection);
                sqlDataAdapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
                #endregion

                sqlDataAdapter.Fill(dataTable);
                gridView.DataContext = dataTable.DefaultView;

                SingInStatus.Text = "Подключение выполнено успешно!";
            }
            else
            {
                SingInStatus.Text = "Неверный логин или пароль";
            }
        }

        private void gridView_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            dataRow = (DataRowView)gridView.SelectedItem;
            dataRow.BeginEdit();
        }

        private void gridView_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dataRow == null) return;
            dataRow.EndEdit();
            sqlDataAdapter.Update(dataTable);
        }

        private void MenuItemDeleteClick(object sender, RoutedEventArgs e)
        {
            dataRow = (DataRowView)gridView.SelectedItem;
            dataRow.Row.Delete();
            sqlDataAdapter.Update(dataTable);
        }

        /// <summary>
        /// Добавление записи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAddClick(object sender, RoutedEventArgs e)
        {
            DataRow dataRow = dataTable.NewRow();
            AddWindow addWindow = new AddWindow(dataRow);
            addWindow.ShowDialog();

            if (addWindow.DialogResult.Value)
            {
                dataTable.Rows.Add(dataRow);
                sqlDataAdapter.Update(dataTable);
            }
        }

        private void UniteDataButton_Click(object sender, RoutedEventArgs e)
        {
            new UnitedData().ShowDialog();
        }
    }
}
