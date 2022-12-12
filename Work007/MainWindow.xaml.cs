using System;
using System.Data;
using System.Net;
using System.Linq;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel;
using System.Windows;
using System.Drawing;
using System.Windows.Navigation;
using Work007.Models;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Configuration;

namespace Work007
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string connectionString;
        SqlDataAdapter adapter;
        DataTable Data;

        private BindingList <Todo> todoData;

        public MainWindow()
        {
            InitializeComponent();
            connectionString = ConfigurationManager.ConnectionStrings["Data"].ConnectionString;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            todoData = new BindingList<Todo>()
            {/*
            new Todo(){Text="test"},
            new Todo(){ Text="djsad"},
            new Todo(){ Text="test 2", IsDone = true}*/
            };
            dgTodoList.ItemsSource = todoData;
            todoData.ListChanged += TodoData_ListChanged;

            string sql = "SELECT * FROM Data";
            Data = new DataTable();
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand(sql, connection);
                adapter = new SqlDataAdapter(command);

                // установка команды на добавление для вызова хранимой процедуры
                adapter.InsertCommand = new SqlCommand("Data", connection);
                adapter.InsertCommand.CommandType = CommandType.StoredProcedure;
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Text", SqlDbType.NVarChar, 50, "Text"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Todo", SqlDbType.Bit, 0, "Todo"));
                adapter.InsertCommand.Parameters.Add(new SqlParameter("@Date", SqlDbType.DateTime,0 , "Date"));
                SqlParameter parameter = adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.Int, 0, "Id");
                parameter.Direction = ParameterDirection.Output;

                connection.Open();
                adapter.Fill(Data);
                dgTodoList.ItemsSource = Data.DefaultView;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection != null)
                    connection.Close();
            }
        }

        private void UpdateDB()
        {
            SqlCommandBuilder comandbuilder = new SqlCommandBuilder(adapter);
            adapter.Update(Data);
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            UpdateDB();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (dgTodoList.SelectedItems != null)
            {
                for (int i = 0; i < dgTodoList.SelectedItems.Count; i++)
                {
                    DataRowView datarowView = dgTodoList.SelectedItems[i] as DataRowView;
                    if (datarowView != null)
                    {
                        DataRow dataRow = (DataRow)datarowView.Row;
                        dataRow.Delete();
                    }
                }
            }
            UpdateDB();
        }
            private void TodoData_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || 
                e.ListChangedType == ListChangedType.ItemDeleted ||
                e.ListChangedType == ListChangedType.ItemChanged)
            { }
        }
    }
}
