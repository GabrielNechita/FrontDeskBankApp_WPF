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
    /// Interaction logic for AddClientPage.xaml
    /// </summary>
    public partial class AddClientPage : Page
    {
        private User _user;
        private int _idEmployee;
        public AddClientPage(int idEmployee)
        {
            InitializeComponent();

            _user = new User();
            _idEmployee = idEmployee;
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            _user.InsertClient(clientName.Text, clientCnp.Text, clientAddress.Text, clientPhone.Text);
            NavigationService.Navigate(new UserWorkspace(_idEmployee));
        }
    }
}
