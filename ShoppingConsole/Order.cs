using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingConsole
{
    class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public double PricePerLineItem { get; set; }
        public double DiscountPerLineItem { get; set; }
        public double TotalPricePerLineItem { get; set; } 
        public double TotalDiscountPerLineItem { get; set; }
    }
}
