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
    /// Interaction logic for EditClientPage.xaml
    /// </summary>
    public partial class EditClientPage : Page
    {
        private readonly User _user;
        private readonly int _id;
        private int _idEmployee;
        public EditClientPage(int id, int idEmployee)
        {
            InitializeComponent();

            _id = id;
            _idEmployee = idEmployee;
            _user = new User();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            _user.UpdateClient(_id, clientName.Text, clientCnp.Text, clientAddress.Text, clientPhone.Text);
            NavigationService.Navigate(new UserWorkspace(_idEmployee));
        }
    }
}
