using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_3
{
    public class Tablet : Electronicdevice
    {
        public Tablet() : base() 
        { 
        }


        public override double discountedPrice 
        {
            get
            {
                double discountPercentage = 30;
                double discountedPrice = price - (price * discountPercentage / 100);
                return discountedPrice;
            }
            set
            {
            }
        }

        public override double discountwitharegularcustomercard
        {
            get
            {
                double discount = 5;
                double discountwitharegularcustomercard = discountedPrice - (discountedPrice * discount / 100);
                return discountwitharegularcustomercard;
            }
            set
            {
            }
        }

        public Tablet(string Brand, int Price, int Weight, string Color, double Screendiagonal, double cpufrequency, bool Isthereasimcard,
            bool Isthereamemorycardslot, double DiscountedPrice, double DiscountWithRegularCustomerCard) : base(Brand, Price, Weight, Color, Screendiagonal, cpufrequency, Isthereasimcard, 
                Isthereamemorycardslot, DiscountedPrice, DiscountWithRegularCustomerCard)
        {
        }
    }
}
