using BL.Users;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;


namespace PL
{
    /// <summary>
    /// Interaction logic for UpdateAccountPage.xaml
    /// </summary>
    public partial class UpdateAccountPage : Page
    {
        private readonly User _user;
        private readonly int _idAccount;
        private int _idEmployee;
        public UpdateAccountPage(int idAccount, int idEmployee)
        {
            InitializeComponent();
            _user = new User();
            _idEmployee = idEmployee;
            _idAccount = idAccount;
        }

        private void UpdateAccount_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            try
            {
                _user.UpdateAccount(_idAccount, Type.Text, float.Parse(Money.Text), Convert.ToDateTime(CreationDate.Text));
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
