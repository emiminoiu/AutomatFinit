using AutomatFinit.MainMenuView;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace AutomatFinit
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Form : Window
    {
        public Form()
        {

            //SqlConnection thisConnection = new SqlConnection(@"Server=(local);Database=Sample_db;Trusted_Connection=Yes;");
            //thisConnection.Open();

            //string Get_Data = "SELECT * FROM emp";

            //SqlCommand cmd = thisConnection.CreateCommand();
            //cmd.CommandText = Get_Data;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //if ((username.GetLineText(1).Equals("123")) && (password.GetLineText(1).Equals("123")))
            //{
            //    Form1 form1 = new Form1();
            //    form1.Show();
            //}
            MessageBox.Show("hELLOW");
        }
        private void goToMainMenu(object sender, RoutedEventArgs e)
        {
            bool ok = true;
            var x = username.Text.Trim().ToString();
            var y = password.Password.Trim().ToString();
            Console.WriteLine(x);
            Console.WriteLine(y);
            var users = new AutomatFinitEntities();
            var usernames = users.Users.ToList();
            foreach(var user in usernames)
            {
               if(user.Username.Equals(x) && user.Password.Equals(y))
                {
                    ok = true;
                }
            }         
          if (ok)
            {
                this.Hide();
                Window1 window = new Window1();
                
                window.Show();
            }
            else
            {
                MessageBox.Show("Invalid Username or Password");
            }
        }
    }



}
