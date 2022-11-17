using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
    /// Логика взаимодействия для ServicesListPage.xaml
    /// </summary>
    public partial class ServicesListPage : Page
    {
        int actualPage = 0;
        public ServicesListPage()
        {
            InitializeComponent();
            ServiceList.Items.Clear();
            if (Navigase.AutoUser.RoleId == 2)
                AddSetviseBtn.Visibility = Visibility.Collapsed;
            //ServiceList.ItemsSource = Bdonnect.db.Service.ToList();
            ServiceList.ItemsSource = Bdonnect.db.Service.Where(x => x.IsDelete != true).ToList();
            //GeneralCount.Text = Bdonnect.db.Service.Count().ToString();
            GeneralCount.Text = Bdonnect.db.Service.Where(x=> x.IsDelete != true).Count().ToString();

        }
        private void Refresh() {
            //IEnumerable<Service> filterSevice = Bdonnect.db.Service;коллекция  IEnumerable<Service> имя и откуда берет данные с бд
            IEnumerable<Service> filterSevice = Bdonnect.db.Service.Where(x=> x.IsDelete != true );
            if (SortCb.SelectedIndex>0)
            {
                if (SortCb.SelectedIndex ==1 )
                    filterSevice = filterSevice.OrderByDescending(x => x.CostDicount);
                else
                    filterSevice = filterSevice.OrderBy(x => x.CostDicount);// по убыванию 
            }
            //if (SortCb.Text == "По возрастанию")
            //    filterSevice = filterSevice.OrderByDescending(x => x.CostDicount);
            //else
            //    filterSevice = filterSevice.OrderBy(x => x.CostDicount);// по убыванию 

            var DiscountCb = DiscountSortCb.SelectedItem as ComboBoxItem;
            if (DiscountCb != null ) {
                if (DiscountCb.Tag.ToString() == "1")
                    filterSevice = filterSevice.ToList();
                else if (DiscountCb.Tag.ToString() == "2")
                    filterSevice = filterSevice.Where(x => x.Discount >= 0 && x.Discount < 5||x.Discount == null);
                else if (DiscountCb.Tag.ToString() == "3")
                    filterSevice = filterSevice.Where(x => x.Discount >= 5 && x.Discount < 15);
                else if (DiscountCb.Tag.ToString() == "4")
                    filterSevice = filterSevice.Where(x => x.Discount >= 15 && x.Discount < 30);
                else if (DiscountCb.Tag.ToString() == "5")
                    filterSevice = filterSevice.Where(x => x.Discount >= 30 && x.Discount < 70);
                else if (DiscountCb.Tag.ToString() == "6")
                    filterSevice = filterSevice.Where(x => x.Discount >= 70 && x.Discount < 100);
            }
            if (NameDisSearch.Text.Length > 0)
                filterSevice = filterSevice.Where(x => x.Title.StartsWith(NameDisSearch.Text) || x.Description.StartsWith(NameDisSearch.Text));

            if (CountCb.SelectedIndex>0 && filterSevice.Count()>0)
            {
                int selCount =Convert.ToInt32((CountCb.SelectedItem as ComboBoxItem).Content);
                filterSevice = filterSevice.Skip(selCount* actualPage).Take(selCount);
                if (filterSevice.Count() == 0 )
                {
                    actualPage--;
                    Refresh();
                }
            }
        
            ServiceList.ItemsSource = filterSevice.ToList();
            FondCount.Text = filterSevice.Count().ToString() + " из ";
        }

        private void SortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            actualPage = 0;
            Refresh();
        }

        private void DiscountSortCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            actualPage = 0;
            Refresh();
        }

        //private void NameDisSearch_TextChanged(TextChangedEventArgs e)
        //{

        //}

        private void NameDisSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            actualPage = 0;
            Refresh();
        }

        private void AddSetviseBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigase.NextPage(new Nav("Добавление услуг ", new AddEditServicePage(new Service())));
        }



        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            
            var selServise = (sender as Button).DataContext as Service;
            if (MessageBox.Show("Вы точно хотите удалить эту запись ","Уведомление ",MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                // удалить вообще из базы
                //Bdonnect.db.Service.Remove(selServise);
                //помечает на удаление 
                selServise.IsDelete = true; 
                MessageBox.Show("Запись удалена");
                Bdonnect.db.SaveChanges();
                ServiceList.ItemsSource = Bdonnect.db.Service.ToList(); 
            }
        
        }

        private void CreatBtn_Click(object sender, RoutedEventArgs e)
        {
            // редактирование 
            var selServise = (sender as Button).DataContext as Service;
            Navigase.NextPage(new Nav("Редактирование услуг",new AddEditServicePage(selServise)));
        }

        private void LeftBtn_Click(object sender, RoutedEventArgs e)
        { 
            actualPage--;
            if(actualPage<0)
                actualPage = 0; 
          
            Refresh();
        }

        private void RightBtn_Click(object sender, RoutedEventArgs e)
        {
           
            actualPage++;
            Refresh();
        }
    }
}
