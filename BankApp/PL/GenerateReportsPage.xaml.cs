using BL.Users;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for GenerateReportsPage.xaml
    /// </summary>
    public partial class GenerateReportsPage : Page
    {

        private int _idEmployee;
        private Admin _admin;
        public GenerateReportsPage(int idEmployee)
        {
            InitializeComponent();
            _idEmployee = idEmployee;
            _admin = new Admin();
        }


        
        private void Generate_Click(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            FileInfo f = new FileInfo("Report.txt");
            StreamWriter w = f.CreateText();

            var activitiesList = _admin.GetActivitiesByIdEmployees(_idEmployee);

            try
            {
                foreach (var activity in activitiesList)
                {
                    var dateProperty = activity.GetType().GetProperty("Date");
                    var date = Convert.ToDateTime(dateProperty.GetValue(activity, null));

                    if (DateTime.Compare(Convert.ToDateTime(PeriodStart.Text), date) <= 0 && DateTime.Compare(date, Convert.ToDateTime(PeriodEnd.Text)) <= 0)
                        w.WriteLine(activity.ToString());                
                }
            }
            catch (FormatException)
            {

                Window popup = new Window();
                popup.Title = "Warning!";
                popup.Width = 300;
                popup.Height = 150;
                popup.Content = "\n\n\n \t Date format is wrong!";
                popup.ShowDialog();
                ok = false;
            }
            w.Close();


            if (ok)
            {
                NavigationService.Navigate(new AdminWorkspace());
            }
           
        }
    }
}
