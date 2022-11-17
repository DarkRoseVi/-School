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
using WpfApp1.Pages;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Navigase.main = this;
            Navigase.NextPage(new Nav("Авторизация",new AuthPage()));
         //   Navigation.NextPage(new nav);
            //Componens.Bdonnect.db.Set;
        }

        private void ExitBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigase.isAuth = false;
            Navigase.navs.Clear();
            Navigase.NextPage(new Nav("Авторизация", new AuthPage()));
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigase.BackPage();
        }
    }
}
