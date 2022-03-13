using CMS_Wpf.Models;
using Microsoft.EntityFrameworkCore;
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
        public MainWindow()
        {
            InitializeComponent();
            ShowCustomers();
        }

        private void ShowCustomers()
        {
            try
            {
                using (var db = new AddDbContext())
                {
                    var customers = db.Customers.ToList();
                    customerList.DisplayMemberPath = "Name";
                    customerList.SelectedValuePath = "Id";
                    customerList.ItemsSource = customers;
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
                var customerId = customerList.SelectedValue;
                if(customerId==null)
                {
                    appointmentList.ItemsSource = null;
                    return;
                }

                Customer customer = customerList.SelectedItem as Customer;
                NameTextbox.Text = customer.Name;
                IdTextbox.Text = customer.IdNnumber;
                AddressTextbox.Text = customer.Address;

                using (var db = new AddDbContext())
                {
                    var appointments = db.Appointments.Where(a => a.CustomerId == (int)customerId).ToList();
                    appointmentList.DisplayMemberPath = "Time";
                    appointmentList.SelectedValuePath = "Id";
                    appointmentList.ItemsSource = appointments;
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
                var appointmentId = appointmentList.SelectedValue;
                using (var db = new AddDbContext())
                {
                    var appointmentToRmove = db.Appointments.Where(a => a.Id == (int)appointmentId).FirstOrDefault();
                    db.Appointments.Remove(appointmentToRmove);
                    db.SaveChanges();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                this.customerList_SelectionChanged(null, null);
            }

        }

        private void DeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var customerId = customerList.SelectedValue;
                using (var db = new AddDbContext())
                {
                    var customerToRmove = db.Customers
                        .Include(c => c.Appointments)
                        .Where(c => c.Id == (int)customerId)
                        .FirstOrDefault();
                    db.Customers.Remove(customerToRmove);
                    db.SaveChanges();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                ShowCustomers();
                this.customerList_SelectionChanged(null, null);
            }
        }

        private void AddCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new AddDbContext())
                {
                    var newCustomer = new Customer()
                    {
                        Name = NameTextbox.Text,
                        IdNnumber = IdTextbox.Text,
                        Address = AddressTextbox.Text
                    };
                    db.Customers.Add(newCustomer);
                    db.SaveChanges();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                ShowCustomers();
            }
        }

        private void AddAppointment_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new AddDbContext())
                {
                    var newAppointment = new Appointment()
                    {
                        Time = DateTime.Parse(AppointmentDatePicker.Text),
                        CustomerId = (int)customerList.SelectedValue,
                    };
                    db.Appointments.Add(newAppointment);
                    db.SaveChanges();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                this.customerList_SelectionChanged(null, null);
            }
        }

        private void UpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (var db = new AddDbContext())
                {
                    var customer = db.Customers
                        .Where(c => c.Id == (int)customerList.SelectedValue)
                        .FirstOrDefault();

                    customer.Name = NameTextbox.Text.Trim();
                    customer.IdNnumber = IdTextbox.Text.Trim();
                    customer.Address = AddressTextbox.Text.Trim();

                    db.SaveChanges();
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.ToString());
            }
            finally
            {
                ShowCustomers();
            }
        }
    }
}
