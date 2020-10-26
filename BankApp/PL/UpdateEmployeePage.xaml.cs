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
    /// Interaction logic for UpdateEmployeePage.xaml
    /// </summary>
    public partial class UpdateEmployeePage : Page
    {
        private Admin _admin;
        private int _idEmployee;
        public UpdateEmployeePage(int idEmployee)
        {
            InitializeComponent();
            _admin = new Admin();
            _idEmployee = idEmployee;
        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            try
            {
                _admin.UpdateEmployee(_idEmployee, Name.Text, float.Parse(Salary.Text), Password.Text);
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
