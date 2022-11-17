using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp1.Componens
{
    public partial class Service
    {
        public decimal CostDicount
        {
            get
            {
                if (Discount == 0 || Discount == null)
                    return Cost;
                else
                    return Cost - (decimal)Cost *(decimal)Discount/100;
            }
        }
     public Visibility BtnVisible 
        {
            get 
            {
                if (Navigase.AutoUser.RoleId ==2)//client
                    return Visibility.Collapsed;
                else 
                    return Visibility.Visible;
            }
        }

        public string StrDiscount
        {
            get
            {
                if (Discount == 0 || Discount == null)
                    return "";
                     else
                    return "* скидка " + Discount;
            }
        }

        public string CostDuratoin 
        {
            get {
                if (Discount == 0 || Discount == null)
                    return $"{Cost: F0} рублей за {DurationInSeconds / 60} минут  ";
                else
                    return $"{(double) - (double)Cost * (double)Discount/ 100:F} рублей за {DurationInSeconds / 60} минут  ";
            }
        }
        public Visibility DiscountVisibility
        {
            get
            {
                if (Discount == 0 || Discount == null)
                    return Visibility.Collapsed;
                else
                    return Visibility.Visible;
            }
        
        }
        public string ColorDis
        {
            get
            {
                if (Discount == 0 || Discount == null)
                    return "#ffffff";
                else
                    return "#D1FFD1";
            }
        }
    }

       

}