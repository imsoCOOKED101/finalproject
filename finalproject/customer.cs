using System;
using System.Collections.Generic;
using finalproject;
namespace MiniEcoMarket
{
    class Customer : User
    {
        private List<Product> products;
        private List<Order> orderHistory;

        public Customer(string name, List<Product> sharedProducts) : base(name)
        {
            products = sharedProducts;
            orderHistory = new List<Order>();
        }
        public void BrowseProducts()
        {
            Console.WriteLine("\n--- Available Products -----");
            if (products.Count == 0)
            {
                Console.WriteLine("No products available.");
                return;
            }
            int i = 1;
            foreach (var p in products)
            {
                Console.WriteLine($"{i++}. {p}");
            }
        }
        public void BuyProduct()
        {
            if (products.Count == 0)
            {
                Console.WriteLine("\nNo products available to buy.");
                return;
            }
            BrowseProducts();
            Console.Write("\nEnter product number to buy: ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 1 || choice > products.Count)
            {
                Console.WriteLine("Invalid product selection.");
                return;
            }
            var product = products[choice - 1];
            if (product.Stock <= 0)
            {
                Console.WriteLine("Selected product is out of stock.");
                return;
            }

            Console.Write("Enter quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int quantity) || quantity < 1)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }
            if (quantity > product.Stock)
            {
                Console.WriteLine($"Sorry, only {product.Stock} units available.");
                return;
            }
            product.Stock -= quantity;
            orderHistory.Add(new Order(new Product(product.Name, product.Price, quantity, product.Category), quantity));
            Console.WriteLine($"Successfully bought {quantity} units of '{product.Name}'.");
        }

        public void ViewOrderHistory()
        {
            Console.WriteLine("\n---- Order History ----");
            if (orderHistory.Count == 0)
            {
                Console.WriteLine("No orders placed yet.");
                return;
            }
            int i = 1;
            foreach (var order in orderHistory)
            {
                Console.WriteLine($"{i++}. {order}");
            }
        }
    }
}