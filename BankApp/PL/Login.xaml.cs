using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;
using BL.Users;

namespace PL
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            var user = new User();
            var admin = new Admin();

            var userHastable = user.GetIdEmployeePassword();
            int userIdEmployee;
            bool ok = false;
            if (admin.Username == username.Text && admin.Password == password.Text)
            {
                ok = true;
                this.NavigationService?.Navigate(new AdminWorkspace());
            }
            else
            {
                try
                {
                   
                    userIdEmployee = Convert.ToInt32(username.Text);
                    if (userHastable.ContainsKey(userIdEmployee))
                    {
                        if (password.Text.Equals(userHastable[userIdEmployee].ToString()))
                        {
                            ok = true;
                            user.Username = username.Text;
                            user.Password = password.Text;
                            this.NavigationService?.Navigate(new UserWorkspace(userIdEmployee));
                        }

                    }
                    
                }
                catch (FormatException)
                {
                    Window popup = new Window();
                    popup.Title = "Warning!";
                    popup.Width = 300;
                    popup.Height = 150;
                    popup.Content = "\n\n\n \t Username format is wrong!";
                    popup.ShowDialog();

                }
            }
            if (ok == false)
            {
                Window popup = new Window();
                popup.Title = "Warning!";
                popup.Width = 300;
                popup.Height = 150;
                popup.Content = "\n\n\n \t Username or password is wrong!";
                popup.ShowDialog();
            }       

        }
    }
}
