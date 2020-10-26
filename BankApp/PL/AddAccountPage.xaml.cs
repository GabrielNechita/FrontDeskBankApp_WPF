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
    /// Interaction logic for AddAccountPage.xaml
    /// </summary>
    public partial class AddAccountPage : Page
    {
        private User _user;
        private int _idEmployee;
        public AddAccountPage(int idClient, int idEmployee)
        {
            InitializeComponent();
            _user = new User();
            _idClient = idClient;
            _idEmployee = idEmployee;
        }
        private int _idClient;
        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            try
            {
                _user.InsertAccount(Type.Text, float.Parse(Money.Text), Convert.ToDateTime(CreationDate.Text),_idClient);
            }
            catch (FormatException)
            {

                Window popup = new Window();
                popup.Title = "Warning!";
                popup.Width = 300;
                popup.Height = 150;
                popup.Content = "\n\n\n \t Money or Date format is wrong!";
                popup.ShowDialog();
                ok = false;
            }
            if (ok)
            {
                NavigationService.Navigate(new UserWorkspace(_idEmployee));
            }

        }
    }
}
