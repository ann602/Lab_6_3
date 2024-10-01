using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_3
{
    public class Tablet : Electronic_device
    {
        public string brand { get; set; }
        public int price { get; set; }
        public int weight { get; set; }
        public string color { get; set; }
        public double screendiagonal { get; set; }
        public double CPUfrequency { get; set; }
        public bool isthereasimcard { get; set; }
        public bool isthereamemorycardslot { get; set; }

        public override double discountedPrice()
        {
            double discountPercentage = 30;
            double discountedPrice = price - (price * discountPercentage / 100);
            return discountedPrice;
        }

        public override double discountwitharegularcustomercard()
        {
            double discount = 5;
            double discountwitharegularcustomercard = discountedPrice() - (discountedPrice() * discount / 100);
            return discountwitharegularcustomercard;
        }

        public double DiscountedPrice
        {
            get
            {
                return discountedPrice();
            }
            set
            {

            }
        }

        public double DiscountWithRegularCustomerCard
        {
            get
            {
                return discountwitharegularcustomercard();
            }
            set
            {
             
            }
        }

        public Tablet()
        {
        }

        public Tablet(string Brand, int Price, int Weight, string Color, double Screendiagonal, double cpufrequency, bool Isthereasimcard,
            bool Isthereamemorycardslot, double DiscountedPrice, double Discountwitharegularcustomercard)
        {
            brand = Brand;
            price = Price;
            weight = Weight;
            color = Color;
            screendiagonal = Screendiagonal;
            CPUfrequency = cpufrequency;
            isthereasimcard = Isthereasimcard;
            isthereamemorycardslot = Isthereamemorycardslot;
        }
    }
}
