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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace BankCustomerManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SqlConnection sqlConnection;

        public MainWindow()
        {
            InitializeComponent();

            string connectionString = ConfigurationManager.ConnectionStrings["BankCustomerManager.Properties.Settings.CMSConnectionString"].ConnectionString;
            sqlConnection = new SqlConnection(connectionString);

            //ShowCustomers();
            //ShowAddresses();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            RenderPages.Children.Clear();
            if (sender.Equals(CustomerManagementBtn))
            {
                RenderPages.Children.Add(new CustomerManagement());
            }
            else if (sender.Equals(AppointmentBtn))
            {
                RenderPages.Children.Add(new Appointment());
            }
            else
            {
                RenderPages.Children.Add(new Dashboard());
            }
            //RenderPages.Children.Add(new CustomerManagement());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        //private void ShowCustomers()
        //{
        //    try
        //    {
        //        string query = "select * from Customer";

        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

        //        using (sqlDataAdapter)
        //        {
        //            DataTable customerTable = new DataTable();

        //            sqlDataAdapter.Fill(customerTable);

        //            CustomerListBox.DisplayMemberPath = "Name";
        //            CustomerListBox.SelectedValuePath = "Id";
        //            CustomerListBox.ItemsSource = customerTable.DefaultView;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.ToString());
        //    }
        //}

        //private void ShowAddresses()
        //{
        //    try
        //    {
        //        string query = "select * from Address";

        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

        //        using (sqlDataAdapter)
        //        {
        //            DataTable addressTable = new DataTable();

        //            sqlDataAdapter.Fill(addressTable);

        //            AddressListBox.DisplayMemberPath = "Value";
        //            AddressListBox.SelectedValuePath = "Id";
        //            AddressListBox.ItemsSource = addressTable.DefaultView;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        MessageBox.Show(e.ToString());
        //    }
        //}

        //private void ShowCustomerAddresses()
        //{
        //    if (CustomerListBox.SelectedValue == null)
        //    {
        //        return;
        //    }
        //    try
        //    {
        //        string query = "select * from Address a join CustomerAddress ca on a.Id = ca.AddressId where ca.CustomerId = @CustomerId";

        //        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

        //        using (sqlDataAdapter)
        //        {
        //            sqlCommand.Parameters.AddWithValue("@CustomerId", CustomerListBox.SelectedValue);
        //            DataTable addressTable = new DataTable();

        //            sqlDataAdapter.Fill(addressTable);

        //            CustomerAddressListBox.DisplayMemberPath = "Value";
        //            CustomerAddressListBox.SelectedValuePath = "Id";
        //            CustomerAddressListBox.ItemsSource = addressTable.DefaultView;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void ShowCustomerAccount()
        //{
        //    if (CustomerListBox.SelectedValue == null)
        //    {
        //        return;
        //    }
        //    try
        //    {
        //        string query = "select * from Account where CustomerId = @CustomerId";

        //        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

        //        using (sqlDataAdapter)
        //        {
        //            sqlCommand.Parameters.AddWithValue("@CustomerId", CustomerListBox.SelectedValue);
        //            DataTable accountTable = new DataTable();

        //            sqlDataAdapter.Fill(accountTable);

        //            AccountDataGrid.SelectedValuePath = "Id";
        //            AccountDataGrid.ItemsSource = accountTable.DefaultView;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //}

        //private void CustomerListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    ShowCustomerAddresses();
        //    ShowCustomerAccount();
        //}

        //private void New_Customer_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string query = "insert into Customer values (@Name)";
        //        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue("@Name", NewCustomerTextBox.Text);
        //        sqlCommand.ExecuteScalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());

        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //        ShowCustomers();
        //    }
        //}

        //private void New_Address_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string query = "insert into Address values (@Value)";
        //        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue("@Value", NewAddressTextBox.Text);
        //        sqlCommand.ExecuteScalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());

        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //        ShowAddresses();
        //    }
        //}

        //private void AddAddressToCustomer_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string query = "insert into CustomerAddress values (@CustomerId, @AddressId)";
        //        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue("@CustomerId", CustomerListBox.SelectedValue);
        //        sqlCommand.Parameters.AddWithValue("@AddressId", AddressListBox.SelectedValue);
        //        sqlCommand.ExecuteScalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());

        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //        ShowCustomerAddresses();
        //    }
        //}

        //private void UpdateCustomer_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string query = "update Customer Set Name = @Name where Id = @CustomerId";
        //        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue("@CustomerId", CustomerListBox.SelectedValue);
        //        sqlCommand.Parameters.AddWithValue("@Name", NewCustomerTextBox.Text);
        //        sqlCommand.ExecuteScalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());

        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //        ShowCustomers();
        //    }

        //}

        //private void DeleteCustomer_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string query = "delete from Customer where id = @CustomerId";
        //        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue("@CustomerId", CustomerListBox.SelectedValue);
        //        sqlCommand.ExecuteScalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //        ShowCustomers();
        //    }
        //}

        //private void DeleteCustomerAddress_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string query = "delete from CustomerAddress where Id = @CustomerAddressId";
        //        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue("@CustomerAddressId", CustomerAddressListBox.SelectedValue);
        //        sqlCommand.ExecuteScalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //        ShowCustomerAddresses();
        //    }
        //}

        //private void AddAccount_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string query = "insert into Account values (@CustomerId, @AccountType, @Amount)";
        //        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue("@CustomerId", CustomerListBox.SelectedValue);
        //        sqlCommand.Parameters.AddWithValue("@AccountType", OpenAccountTextBox.Text);
        //        sqlCommand.Parameters.AddWithValue("@Amount", 0);
        //        sqlCommand.ExecuteScalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //        ShowCustomerAccount();
        //    }
        //}

        //private void Deposit_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string query = "select Amount from Account where Id = @Id";
        //        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue("@Id", AccountDataGrid.SelectedValue);
        //        decimal originalAmount = (decimal)sqlCommand.ExecuteScalar();
        //        decimal deposit = Convert.ToDecimal(DepositAmountTextBox.Text);
        //        decimal newAmount = originalAmount + deposit;

        //        string updateQuery = "update Account Set Amount = @Amount where Id = @Id";
        //        SqlCommand updateSqlCommand = new SqlCommand(updateQuery, sqlConnection);
        //        updateSqlCommand.Parameters.AddWithValue("@Amount", newAmount);
        //        updateSqlCommand.Parameters.AddWithValue("@Id", AccountDataGrid.SelectedValue);
        //        updateSqlCommand.ExecuteScalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //        ShowCustomerAccount();
        //    }
        //}

        //private void Withdrawal_Button_Click(object sender, RoutedEventArgs e)
        //{
        //    try
        //    {
        //        string query = "select Amount from Account where Id = @Id";
        //        SqlCommand sqlCommand = new SqlCommand(query, sqlConnection);
        //        sqlConnection.Open();
        //        sqlCommand.Parameters.AddWithValue("@Id", AccountDataGrid.SelectedValue);
        //        decimal originalAmount = (decimal)sqlCommand.ExecuteScalar();

        //        decimal Withdrawal = Convert.ToDecimal(WithdrawalTextBox.Text);
        //        decimal newAmount = originalAmount - Withdrawal;

        //        string updateQuery = "update Account Set Amount = @Amount where Id = @Id";
        //        SqlCommand updateSqlCommand = new SqlCommand(updateQuery, sqlConnection);
        //        updateSqlCommand.Parameters.AddWithValue("@Amount", newAmount);
        //        updateSqlCommand.Parameters.AddWithValue("@Id", AccountDataGrid.SelectedValue);
        //        updateSqlCommand.ExecuteScalar();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.ToString());
        //    }
        //    finally
        //    {
        //        sqlConnection.Close();
        //        ShowCustomerAccount();
        //    }
        //}
    }
}
