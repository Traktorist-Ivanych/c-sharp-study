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
        SqlConnection connection;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;
        DataRowView row;

        public MainWindow()
        {
            InitializeComponent();

            #region Init
            SqlConnectionStringBuilder sqlConnection = new SqlConnectionStringBuilder()
            {
                DataSource = @"((localdb)\MSSQLLocalDB",
                InitialCatalog = "MSSQLLocalDemo"
            };

            connection = new SqlConnection(sqlConnection.ConnectionString);
            dataTable = new DataTable();
            dataAdapter = new SqlDataAdapter();

            string sql;
            #endregion

            #region Select
            sql = @"SELECT * FROM Workers Order By Workers.Id";
            dataAdapter.SelectCommand = new SqlCommand(sql, connection);
            #endregion

            #region Insert

            sql = @"INSERT INTO Workers (workerName, workerSurname, workerPatronymic,  phoneNumber,  email) 
                                 VALUES (@workerName, @workerSurname, @workerPatronymic, @phoneNumber, @email); 
                     SET @Id = @@IDENTITY;";

            dataAdapter.InsertCommand = new SqlCommand(sql, connection);

            dataAdapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id").Direction = ParameterDirection.Output;
            dataAdapter.InsertCommand.Parameters.Add("@workerName", SqlDbType.NVarChar, 50, "workerName");
            dataAdapter.InsertCommand.Parameters.Add("@workerSurname", SqlDbType.NVarChar, 50, "workerSurname");
            dataAdapter.InsertCommand.Parameters.Add("@workerPatronymic", SqlDbType.NVarChar, 50, "workerPatronymic");
            dataAdapter.InsertCommand.Parameters.Add("@phoneNumber", SqlDbType.NVarChar, 50, "phoneNumber");
            dataAdapter.InsertCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50, "email");

            #endregion

            #region Update
            sql = @"UPDATE Workers SET 
                           workerName = @workerName,
                           workerSurname = @workerSurname, 
                           workerPatronymic = @workerPatronymic,
                           phoneNumber = @phoneNumber,
                           email = @email,
                    WHERE Id = @Id";

            dataAdapter.UpdateCommand = new SqlCommand(sql, connection);
            dataAdapter.UpdateCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id").SourceVersion = DataRowVersion.Original;
            dataAdapter.UpdateCommand.Parameters.Add("@workerName", SqlDbType.NVarChar, 50, "workerName");
            dataAdapter.UpdateCommand.Parameters.Add("@workerSurname", SqlDbType.NVarChar, 50, "workerSurname");
            dataAdapter.UpdateCommand.Parameters.Add("@workerPatronymic", SqlDbType.NVarChar, 50, "workerPatronymic");
            dataAdapter.UpdateCommand.Parameters.Add("@phoneNumber", SqlDbType.NVarChar, 50, "phoneNumber");
            dataAdapter.UpdateCommand.Parameters.Add("@email", SqlDbType.NVarChar, 50, "email");
            #endregion

            #region Delete
            sql = "DELETE FROM Workers WHERE Id = @Id";

            dataAdapter.DeleteCommand = new SqlCommand(sql, connection);
            dataAdapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.Int, 4, "Id");
            #endregion

            dataAdapter.Fill(dataTable);
            gridView.DataContext = dataTable.DefaultView;

        }
    }
}
