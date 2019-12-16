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
using TidalMusicPlayer.DataModels;

namespace TidalMusicPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private string _username, _password;
        private AccountsContext _accountContext;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            _username = username.Text;
            _password = password.Password.ToString();

            if(LoginSuccess(_username,_password) == true)
            {
                var conWindow = new Content();
                this.Close();
                conWindow.Show();
            } else
            {
                MessageBox.Show("Incorrect Login Details", "Login Error");
            }


        }

        private bool LoginSuccess(string username, string password)
        {
            _accountContext = new AccountsContext();
            var users = _accountContext.Users.ToList().Count;

            User user = _accountContext.Users.Where(p => p.Username == username).FirstOrDefault();
            if(user != null)
            {
                var pass1 = user.Password;
                if(password == pass1)
                {
                    return true;
                } else
                {
                    return false;
                }
            }
            return false;
        }
    }
}
