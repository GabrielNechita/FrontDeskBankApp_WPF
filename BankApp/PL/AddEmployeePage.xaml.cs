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
    /// Interaction logic for AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        private Admin _admin;
        public AddEmployeePage()
        {
            InitializeComponent();
            _admin = new Admin();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            try
            {
                _admin.InsertEmployee(Name.Text, float.Parse(Salary.Text), Password.Text);
            }
            catch (FormatException)
            {
                Window popup = new Window();
                popup.Title = "Warning!";
                popup.Width = 300;
                popup.Height = 150;
                popup.Content = "\n\n\n \t Money format is wrong!";
                popup.ShowDialog();
                ok = false;
            }
            if (ok)
            {
                NavigationService.Navigate(new AdminWorkspace());
            }
           
        }
    }
}
