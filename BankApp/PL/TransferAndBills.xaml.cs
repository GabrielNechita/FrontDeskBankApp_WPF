using BL.Users;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Navigation;

namespace PL
{
    /// <summary>
    /// Interaction logic for TransferAndBills.xaml
    /// </summary>
    public partial class TransferAndBills : Page
    {
        private int _idAccont;
        private User _user;
        private int _idEmployee;
        public TransferAndBills(int idAccount, int idEmployee)
        {
            InitializeComponent();
            _user = new User();
            _idAccont = idAccount;
            _idEmployee = idEmployee;
        }

        private void Transfer_Click(object sender, RoutedEventArgs e)
        {

            var moneyAmountExisting = _user.GetMoneyAmountByAccountId(_idAccont);
            float moneyAmountTransfered = 0;
            int idAccountTo = 0;
            bool ok = true;
            try
            {
                moneyAmountTransfered = float.Parse(Amount.Text);
                idAccountTo = Convert.ToInt32(TransferTo.Text);
            }
            catch (FormatException)
            {

                Window popup = new Window();
                popup.Title = "Warning!";
                popup.Width = 300;
                popup.Height = 150;
                popup.Content = "\n\n\n \t Amount or IdAccount format is wrong!";
                popup.ShowDialog();
                ok = false;
            }
            if (ok)
            {
                if (moneyAmountTransfered > moneyAmountExisting)
                {
                    Window popup = new Window();
                    popup.Title = "Warning!";
                    popup.Width = 300;
                    popup.Height = 150;
                    popup.Content = "\n\n\n \t Not sufficient funds into the account.";
                    popup.ShowDialog();
                }
                else
                {
                    _user.Transfer(_idAccont, idAccountTo, moneyAmountTransfered);
                    _user.AddActivity(_idEmployee, "transfer", DateTime.Today);

                    NavigationService.Navigate(new UserWorkspace(_idEmployee));
                }
            }
            
        }

        private void PayBill_Click(object sender, RoutedEventArgs e)
        {
            var moneyAmmountExisting = _user.GetMoneyAmountByAccountId(_idAccont);
            float moneyAmountBill = 0;
            bool ok = true;
            try
            {
                moneyAmountBill = float.Parse(Amount.Text);
            }
            catch (FormatException)
            {

                Window popup = new Window();
                popup.Title = "Warning!";
                popup.Width = 300;
                popup.Height = 150;
                popup.Content = "\n\n\n \t Amount format is wrong!";
                popup.ShowDialog();
                ok = false;
            }
            if (ok)
            {
                if (float.Parse(Amount.Text) > moneyAmmountExisting)
                {
                    Window popup = new Window();
                    popup.Title = "Warning!";
                    popup.Width = 300;
                    popup.Height = 150;
                    popup.Content = "\n\n\n \t Not sufficient funds into the account.";
                    popup.ShowDialog();
                }
                else
                {
                    _user.PayBill(_idAccont, moneyAmountBill);
                    _user.AddActivity(_idEmployee, "bill", DateTime.Today);

                    NavigationService.Navigate(new UserWorkspace(_idEmployee));
                }
            }
           
        }
    }
}
