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
using WpfApp1.Componens;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
            if (Properties.Settings.Default.Login !=null)
                LoginTb.Text = Properties.Settings.Default.Login;
            if(Properties.Settings.Default.Password !=null)
                PasswordTb.Text = Properties.Settings.Default.Password; 
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            Navigase.NextPage(new Nav("Регистрация",new RegPage1()));
        }

        private void Entrance_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Text.Trim();
            if (login.Length == 0 && password.Length == 0)
            {
                MessageBox.Show("Заполните поля");
            }
            else

            {
                Navigase.AutoUser = Bdonnect.db.User.ToList().Find(x => x.Login == login && x.Password == password);
                if (Navigase.AutoUser == null)
                    MessageBox.Show("такого пользователя не существует ");
                else 
                {
                    if (SaveCb.IsChecked == true)
                    {
                        Properties.Settings.Default.Login = LoginTb.Text;
                        Properties.Settings.Default.Password = PasswordTb.Text;
                        Properties.Settings.Default.Save();
                    }
                    else
                    {
                        Properties.Settings.Default.Login =null;
                        Properties.Settings.Default.Password = null;
                        Properties.Settings.Default.Save();
                    }
                    Navigase.isAuth = true;
                    Navigase.NextPage(new Nav("Список услуг", new ServicesListPage()));
                  //  MessageBox.Show("Hellow ");
                   
                }
            }
        }
    }
}
