using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using finalproject;

namespace MiniEcoMarket
{
    class Farmer : User
    {
        private List<Product> products;

        public Farmer(string name, List<Product> sharedProducts) : base(name)
        {
            products = sharedProducts;
        }

        public void AddProduct()
        {
            Console.WriteLine("\n--- Add New Product ---");
            Console.Write("Product name: ");
            string? name = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Invalid name. Operation cancelled.");
                return;
            }

            Console.Write("Category: ");
            string? category = Console.ReadLine()?.Trim();
            if (string.IsNullOrEmpty(category))
            {
                Console.WriteLine("Invalid category. Operation cancelled.");
                return;
            }

            Console.Write("Price: $");
            if (!decimal.TryParse(Console.ReadLine(), out decimal price) || price <= 0)
            {
                Console.WriteLine("Invalid price. Operation cancelled.");
                return;
            }

            Console.Write("Stock: ");
            if (!int.TryParse(Console.ReadLine(), out int stock) || stock <= 0)
            {
                Console.WriteLine("Invalid stock. Operation cancelled.");
                return;
            }

            var existing = products.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase)
                                                       && p.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
            {
                existing.Stock += stock;
                existing.Price = price;
                Console.WriteLine("Existing product updated with additional stock and price updated.");
            }
            else
            {
                products.Add(new Product(name, price, stock, category));
                Console.WriteLine("Product added successfully.");
            }
            SaveProductsToFile("products.txt");
        }
        public void ListProducts()
        {
            Console.WriteLine("\n--- Farmer's Products ---");
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
        public void SaveProductsToFile(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var product in products)
                {
                    writer.WriteLine(product.ToCsv());
                }
            }
        }
    }
}
