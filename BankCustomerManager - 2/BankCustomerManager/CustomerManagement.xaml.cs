using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace BankCustomerManager
{
    /// <summary>
    /// Interaction logic for CustomerManagement.xaml
    /// </summary>
    public partial class CustomerManagement : UserControl
    {
        public CustomerManagement()
        {
            InitializeComponent();
            var users = new List<User>();
            for (int i = 0; i < 10; ++i)
            {
                users.Add(new User { ID = i, Name = "Name " + i.ToString(), Age = 20 + i });
            }

            myListView.ItemsSource = users;

            dddddd.SelectedDates.Add(new DateTime(2021, 7, 1));
            dddddd.SelectedDates.Add(new DateTime(2021, 7, 2));
            dddddd.SelectedDates.AddRange(new DateTime(2021, 7, 12), new DateTime(2009, 7, 15));
            dddddd.SelectedDates.Add(new DateTime(2021, 7, 28));
            //dddddd.SelectedDates.Add(new DateTime(2021, 7, 10));
        }



        public class User
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }

            public override string ToString()
            {
                return this.Name.ToString();
            }
        }
    }
}