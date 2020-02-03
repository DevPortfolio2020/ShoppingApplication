using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();
            List<Order> productsOrdered = new List<Order>();


            Product product1 = new Product
            {
                ProductId = 1,
                ProductName = "The Guardians",
                Author = "John Grisham",
                Price = 1,

            };
            products.Add(product1);

            Product product2 = new Product
            {
                ProductId = 2,
                ProductName = "Gray Mountain",
                Author = "John Grisham",
                Price = 3,

            };
            products.Add(product2);

            Product product3 = new Product
            {
                ProductId = 3,
                ProductName = "Camino Winds",
                Author = "John Grisham",
                Price = 5,

            };
            products.Add(product3);

            foreach (var prod in products)
            {
                Console.WriteLine("Product Id:" + prod.ProductId);
                Console.WriteLine("Product Name:" + prod.ProductName);
                Console.WriteLine("Product Author:" + prod.Author);
                Console.WriteLine("Price : $" + prod.Price);


            }

            //Build order for each product

            Console.WriteLine("Please type in the quantity for each item. If you do not puchase a product pleasee add 0. ");

            foreach (var product in products)
            {

                Console.WriteLine("Enter the quantity for {0}:", product.ProductName);

                Order order = new Order();
                order.Product = new Product();
                bool validEntry = false;

                do
                {
                    try
                    {
                        order.Quantity = (Convert.ToInt32(Console.ReadLine()));
                        validEntry = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Character Invalid. Please try again. Enter your order amount:");
                    }

                } while (validEntry == false);

                if (order.Quantity > 0)
                {

                    order.Product.ProductId = product.ProductId;
                    order.Product.Price = product.Price;
                    order.PricePerLineItem = product.Price * order.Quantity;

                    if (order.Quantity > 0 && order.Quantity < 10)
                    {
                        order.DiscountPerLineItem = 0;


                    }
                    else if (order.Quantity >= 10 && order.Quantity < 25)
                    {
                        order.DiscountPerLineItem = 0.10;

                    }

                    else if (order.Quantity >= 25 && order.Quantity < 50)
                    {
                        order.DiscountPerLineItem = 0.25;

                    }

                    else if (order.Quantity >= 50)
                    {
                        order.DiscountPerLineItem = 0.50;

                    }


                    order.TotalDiscountPerLineItem = order.DiscountPerLineItem * order.Quantity;
                    order.TotalPricePerLineItem = order.PricePerLineItem - order.TotalDiscountPerLineItem;
                    productsOrdered.Add(order);
                }
            }

            //Print the totals
            var totalPerLineItem = new List<double>();
            var pricePerLineItem = new List<double>();

            foreach (var order in productsOrdered)


            {
                Console.WriteLine("Note: Ordrers must include at least one item to be shown below.");
                Console.WriteLine("Price per line item: {0} * {1} = {2}", order.Quantity, order.Product.Price, order.PricePerLineItem);
                Console.WriteLine("Discount per line item: {0} * {1} = {2} ", order.Quantity, order.DiscountPerLineItem, order.TotalDiscountPerLineItem);
                Console.WriteLine("Total with Discounts: {0} - {1} = {2}", order.PricePerLineItem, order.TotalDiscountPerLineItem, order.TotalPricePerLineItem);

                pricePerLineItem.Add(order.PricePerLineItem);
                totalPerLineItem.Add(order.TotalPricePerLineItem);

            }



            Console.WriteLine("Grand Total: " + pricePerLineItem.Sum() + "=" + String.Join("+", pricePerLineItem));
            Console.WriteLine("Grand Total with Discounts: " + totalPerLineItem.Sum() + "=" + String.Join("+", totalPerLineItem));


            Console.ReadLine();

        }

    
    }

}
