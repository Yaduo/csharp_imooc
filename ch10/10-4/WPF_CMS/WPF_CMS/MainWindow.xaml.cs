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
    }
}
