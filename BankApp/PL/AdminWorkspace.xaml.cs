using BL.Users;
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

namespace PL
{
    /// <summary>
    /// Interaction logic for AdminWorkspace.xaml
    /// </summary>
    public partial class AdminWorkspace : Page
    {
        private readonly Admin _admin;
        public AdminWorkspace()
        {
            InitializeComponent();

            _admin = new Admin();

            EmployeesListView.ItemsSource = _admin.GetAllEmployees();
        }

        private void AddEmployeeButton(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmployeePage());
        }

        private void UpdateEmployeeButton(object sender, RoutedEventArgs e)
        {
            int selectedIdEmployee = GetSelectedIdEmployee();
            if (selectedIdEmployee != 0)
            {
                NavigationService.Navigate(new UpdateEmployeePage(selectedIdEmployee));
            }
        }

        private void DeleteEmployeeButton(object sender, RoutedEventArgs e)
        {
            int selectedIdEmployee = GetSelectedIdEmployee();
            if (selectedIdEmployee != 0)
            {
                _admin.DeleteEmployee(selectedIdEmployee);
            }
            

            EmployeesListView.ItemsSource = _admin.GetAllEmployees();
        }

        private int GetSelectedIdEmployee()
        {
            int returnSelected = 0;
            try
            {
                var selectedItem = EmployeesListView.SelectedItem.GetType().GetProperty("Id");
                returnSelected = (int)selectedItem.GetValue(EmployeesListView.SelectedItem, null);
            }
            catch (NullReferenceException)
            {

                Window popup = new Window();
                popup.Title = "Warning!";
                popup.Width = 300;
                popup.Height = 150;
                popup.Content = "\n\n\n \t Select Employee!";
                popup.ShowDialog();
            }

            return returnSelected;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {

            this.NavigationService?.Navigate(new Login());
        }

        private void GenerateReports_Click(object sender, RoutedEventArgs e)
        {
            int selectedIdEmployee = GetSelectedIdEmployee();
            if (selectedIdEmployee != 0)
            {
                NavigationService.Navigate(new GenerateReportsPage(selectedIdEmployee));
            }
        }
    }
}
