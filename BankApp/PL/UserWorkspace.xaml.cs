using System;
using System.Windows;
using System.Windows.Controls;
using BL.Users;

namespace PL
{
    /// <summary>
    /// Interaction logic for UserWorkspace.xaml
    /// </summary>
    public partial class UserWorkspace : Page
    {
        private readonly User _user;
        private int _idEmployee;
        public UserWorkspace(int idEmployee)
        {
            InitializeComponent();

            _user = new User();
            _idEmployee = idEmployee;
            clientsListView.ItemsSource = _user.GetAllClients();
        }

        private void AddClient_OnClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddClientPage(_idEmployee));
        }

        private void UpdateClient_OnClick(object sender, RoutedEventArgs e)
        {
            int selectedClientId = GetSelectedClientId();
            if (selectedClientId != 0)
            {
                this.NavigationService?.Navigate(new EditClientPage(selectedClientId, _idEmployee));
            }
            
        }

        private void ClientsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RefreshAccountsListView();
        }

        private void DeleteAccount_Click(object sender, RoutedEventArgs e)
        {
            int selectedAccountId = GetSelectedAccountId();
            if (selectedAccountId != 0)
            {
                _user.DeleteAccount(GetSelectedAccountId());

                RefreshAccountsListView();
            }
            
        }

        private void RefreshAccountsListView()
        {
            accountsListView.ItemsSource = _user.GetAccountsByClientId(GetSelectedClientId());
        }

        private int GetSelectedClientId()
        {
            int returnSelected = 0;
            try
            {
                var selectedItem = clientsListView.SelectedItem.GetType().GetProperty("Id");
                returnSelected = (int)selectedItem.GetValue(clientsListView.SelectedItem, null);
            }
            catch (NullReferenceException)
            {

                Window popup = new Window();
                popup.Title = "Warning!";
                popup.Width = 300;
                popup.Height = 150;
                popup.Content = "\n\n\n \t Select Client!";
                popup.ShowDialog();
            }

            return returnSelected;
        }

        private int GetSelectedAccountId()
        {
            int returnSelected = 0;
            try
            {
                var selectedItem = accountsListView.SelectedItem.GetType().GetProperty("Id");
                returnSelected = (int)selectedItem.GetValue(accountsListView.SelectedItem, null);
            }
            catch(NullReferenceException)
            {
                Window popup = new Window();
                popup.Title = "Warning!";
                popup.Width = 300;
                popup.Height = 150;
                popup.Content = "\n\n\n \t Select Account!";
                popup.ShowDialog();
            }

            return returnSelected;
        }

        private void AddAccount_Click(object sender, RoutedEventArgs e)
        {
            int selectedClientId = GetSelectedClientId();
            if (selectedClientId != 0)
            {
                NavigationService.Navigate(new AddAccountPage(selectedClientId, _idEmployee));
            }
        }

        private void UpdateAccount_Click(object sender, RoutedEventArgs e)
        {
            int selectedAccountId = GetSelectedAccountId();
            if (selectedAccountId != 0)
            {
                this.NavigationService?.Navigate(new UpdateAccountPage(selectedAccountId, _idEmployee));
            }
        }

        private void TransferAndBills_Click(object sender, RoutedEventArgs e)
        {
            int selectedAccountId = GetSelectedAccountId();
            if (selectedAccountId != 0)
            {
                this.NavigationService?.Navigate(new TransferAndBills(selectedAccountId, _idEmployee));
            }
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            
            this.NavigationService?.Navigate(new Login());
        }
    }
}
