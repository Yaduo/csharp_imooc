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

namespace CMS_Wpf
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
            string connectionString = "Data Source=localhost\\SQLEXPRESS01;Initial Catalog=master;Integrated Security=True";

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
                if(customerId==null)
                {
                    appointmentList.ItemsSource = null;
                    return;
                }

                DataRowView selectedItem = customerList.SelectedItem as DataRowView;
                NameTextbox.Text = selectedItem["Name"] as string;
                IdTextbox.Text = selectedItem["IdNnumber"] as string;
                AddressTextbox.Text = selectedItem["Address"] as string;

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
                string query = "delete from Appointments where Id = @AppointmentId";

                var appointmentId = appointmentList.SelectedValue;

                SqlCommand sqlCommand = new SqlCommand(query, _sqlConnection);
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
                this.customerList_SelectionChanged(null, null);
            }

        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string queryDeleteAppointments = "delete from Appointments where CustomerId = @CustomerId";
                string queryDeleteCustomer = "delete from Customers where Id = @CustomerId";
                var customerId = customerList.SelectedValue;

                SqlCommand sqlCommandDeleteAppointments = new SqlCommand(queryDeleteAppointments, _sqlConnection);
                sqlCommandDeleteAppointments.Parameters.AddWithValue("@CustomerId", customerId);

                SqlCommand sqlCommandDeleteCustomer = new SqlCommand(queryDeleteCustomer, _sqlConnection);
                sqlCommandDeleteCustomer.Parameters.AddWithValue("@CustomerId", customerId);

                _sqlConnection.Open();
                sqlCommandDeleteAppointments.ExecuteScalar();
                sqlCommandDeleteCustomer.ExecuteScalar();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                _sqlConnection.Close();
                ShowCustomers();
                this.customerList_SelectionChanged(null, null);
            }
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "insert into Customers values (@name, @id, @address)";

                SqlCommand sqlCommand = new SqlCommand(query, _sqlConnection);
                sqlCommand.Parameters.AddWithValue("@name", NameTextbox.Text);
                sqlCommand.Parameters.AddWithValue("@id", IdTextbox.Text);
                sqlCommand.Parameters.AddWithValue("@address", AddressTextbox.Text);

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
                string query = "insert into Appointments values (@date, @customerId)";

                SqlCommand sqlCommand = new SqlCommand(query, _sqlConnection);
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
                this.customerList_SelectionChanged(null, null);
            }
        }

        private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string query = "UPDATE Customers set Name=@name, IdNnumber=@idNumber, Address=@address where Id=@customerId";
               
                SqlCommand sqlCommand = new SqlCommand(query, _sqlConnection);
                sqlCommand.Parameters.AddWithValue("@name", NameTextbox.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@idNumber", IdTextbox.Text.Trim());
                sqlCommand.Parameters.AddWithValue("@address", AddressTextbox.Text.Trim());
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
                ShowCustomers();
            }
        }
    }
}
