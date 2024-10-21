using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_6_3
{
    public abstract class Electronicdevice
    {
        public string brand { get; set; }
        public int price { get; set; }
        public int weight { get; set; }
        public string color { get; set; }
        public double screendiagonal { get; set; }
        public double CPUfrequency { get; set; }
        public bool isthereasimcard { get; set; }
        public bool isthereamemorycardslot { get; set; }

        public Electronicdevice()
        {
        }

        public Electronicdevice(string Brand, int Price, int Weight, string Color, double Screendiagonal, double cpufrequency, bool Isthereasimcard,
            bool Isthereamemorycardslot, double DiscountedPrice, double DiscountWithRegularCustomerCard)
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

        public abstract double discountedPrice { get; set; }
        public abstract double discountwitharegularcustomercard { get; set; }

    }
}
