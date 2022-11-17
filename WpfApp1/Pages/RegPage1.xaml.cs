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
    /// Логика взаимодействия для RegPage1.xaml
    /// </summary>
    public partial class RegPage1 : Page
    {
        public RegPage1()
        {
            InitializeComponent();
        }

        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();// trim удалят пробелы
            string password = PasswordTb.Text.Trim();
            if (login.Length>0 && password.Length>0) {
                Bdonnect.db.User.Add(new User
                {
                    Login = login,
                    Password = password,
                    RoleId = 2
                }) ;
                Bdonnect.db.SaveChanges();
            MessageBox.Show("Регистрация прошла успешно");
            Navigase.BackPage();
            }
            else
                MessageBox.Show("Заполните поля !");
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            LoginTb.Text = " ";
            PasswordTb.Text = " ";
        }
    }
}
