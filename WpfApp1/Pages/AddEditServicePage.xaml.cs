using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
using WpfApp1.Componens;

namespace WpfApp1.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddEditServicePage.xaml
    /// </summary>
    public partial class AddEditServicePage : Page
    {
        Service service; 
        public AddEditServicePage(Service _service)
        {
            InitializeComponent();
            service = _service;
            DataContext = service;

        }

        //private void SaveBtn_Click(object sender, RoutedEventArgs e)
        //{
        //    if (service.ID == 0)
        //        Bdonnect.db.Service.Add(service);

        //    Bdonnect.db.SaveChanges();
        //    MessageBox.Show("Успешно выполнено!");
                    
        //}

        //private void SaveBth_Click(object sender, RoutedEventArgs e)
        //{
        //    service.DurationInSeconds *= 60;
        //    if (service.ID == 0)
        //    {
        //        Bdonnect.db.Service.Add(service);

        //        Bdonnect.db.SaveChanges();
        //        MessageBox.Show("Успешно выполнено! ");
        //        Navigase.NextPage(new Nav("Список услуг", new ServicesListPage()));
        //    }
        //}

        private void SaveBtn_Click_1(object sender, RoutedEventArgs e)
        {
            service.DurationInSeconds *= 60;
            if (service.ID == 0)
            {
                Bdonnect.db.Service.Add(service);

                Bdonnect.db.SaveChanges();
                MessageBox.Show("Успешно выполнено! ");
                Navigase.NextPage(new Nav("Список услуг", new ServicesListPage()));
            }
        }

        private void SaveImgBth_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpeg|*.jpeg|*.jpg|*.jpg",
            
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            { 
                service.MainImage = File.ReadAllBytes(openFile.FileName);
                ServicePhoto.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }
    }
}
