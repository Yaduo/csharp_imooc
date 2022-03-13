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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_CMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SqlConnection _sqlConnection;
        public MainWindow()
        {
            InitializeComponent();
            string connectionString = "Data Source=localhost;Initial Catalog=course565;Persist Security Info=True;User ID=sa;Password=PaSSword12!;Pooling=False";

            _sqlConnection = new SqlConnection(connectionString);

            ShowCustomers();
        }

        private void ShowCustomers()
        {
            try
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select * from Customers", _sqlConnection);

                using (sqlDataAdapter)
                {
                    DataTable customerTable = new DataTable();
                    sqlDataAdapter.Fill(customerTable);

                    customerList.DisplayMemberPath = "Name";
                    customerList.SelectedValuePath = "Id";
                    customerList.ItemsSource = customerTable.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void customerList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string query = "select * from Appointments join Customers on Appointments.CustomerId = Customers.Id where Customers.Id = @CustomerId";

                var customerId = customerList.SelectedValue;
                if (customerId==null)
                {
                    appointmentList.ItemsSource = null;
                    return;
                }

                SqlCommand sqlCommand = new SqlCommand(query, _sqlConnection);

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                sqlCommand.Parameters.AddWithValue("@CustomerId", customerId);

                using (sqlDataAdapter)
                {
                    DataTable appointmentTable = new DataTable();
                    sqlDataAdapter.Fill(appointmentTable);

                    appointmentList.DisplayMemberPath = "Time";
                    appointmentList.SelectedValuePath = "Id";
                    appointmentList.ItemsSource = appointmentTable.DefaultView;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
        }

        private void DeleteAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sql = "delete from Appointments where Id = @AppointmentId";

                var appointmentId = appointmentList.SelectedValue;

                SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);
                sqlCommand.Parameters.AddWithValue("@AppointmentId", appointmentId);

                _sqlConnection.Open();
                sqlCommand.ExecuteScalar();
                
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                _sqlConnection.Close();
                customerList_SelectionChanged(null, null);
            }
        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string sqlDeleteAppointment = "delete from Appointments where CustomerId=@CustomerId";
                string sqlDeleteCustomer = "delete from Customers where id=@CustomerId";

                var customerId = customerList.SelectedValue;

                SqlCommand cmd1 = new SqlCommand(sqlDeleteAppointment, _sqlConnection);
                SqlCommand cmd2 = new SqlCommand(sqlDeleteCustomer, _sqlConnection);

                cmd1.Parameters.AddWithValue("@CustomerId", customerId);
                cmd2.Parameters.AddWithValue("@CustomerId", customerId);

                _sqlConnection.Open();
                cmd1.ExecuteScalar();
                cmd2.ExecuteScalar();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                _sqlConnection.Close();
                ShowCustomers();
                customerList_SelectionChanged(null, null);
            }
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sql = "insert into Customers values (@name, @id, @address)";

                SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);

                sqlCommand.Parameters.AddWithValue("@name", NameTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@id", IdTextBox.Text);
                sqlCommand.Parameters.AddWithValue("@address", AddressTextBox.Text);

                _sqlConnection.Open();
                sqlCommand.ExecuteScalar();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                _sqlConnection.Close();
                ShowCustomers();
            }
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var sql = "insert into Appointments values (@date, @customerId)";

                SqlCommand sqlCommand = new SqlCommand(sql, _sqlConnection);

                sqlCommand.Parameters.AddWithValue("@date", AppointmentDatePicker.Text);
                sqlCommand.Parameters.AddWithValue("@customerId", customerList.SelectedValue);

                _sqlConnection.Open();
                sqlCommand.ExecuteScalar();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                _sqlConnection.Close();
                customerList_SelectionChanged(null, null);
            }
        }
    }
}
