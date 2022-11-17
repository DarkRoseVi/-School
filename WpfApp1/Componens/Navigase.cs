using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Model;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.Componens
{
   
    internal class Navigase
    {
        public static bool isAuth = false;//авторизовался ли пользователь
        public static User AutoUser;//авторизированный клиент 
        public static MainWindow main;// доступ к элементам к MainWindow
        public static List<Nav> navs = new List<Nav>();// история посещений пользователя    

        public static void NextPage(Nav nav)
        {
           
                navs.Add(nav);
                Update(nav);
           
           
        }
        public static void BackPage()
        {
            if (navs.Count>1)
                navs.Remove(navs[navs.Count-1]);
            Update(navs[navs.Count - 1]);
        }
        private static void Update(Nav nav)
        {
            main.TitalePage.Text = nav.Title;
            main.BackBtn.Visibility = navs.Count > 1 ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            main.ExitBtn.Visibility = isAuth == true ? System.Windows.Visibility.Visible : System.Windows.Visibility.Collapsed;
            main.MyFrame.Navigate(nav.Page);
        }
    }
    class Nav { 
    public string Title { get; set; }
        public Page Page { get; set; }
        public Nav(string Title, Page Page)
        {
            this.Title = Title;
            this.Page = Page;
        }
    }
}
