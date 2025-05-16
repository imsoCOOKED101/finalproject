using System;
namespace MiniEcoMarket
{
    class Product
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public string Category { get; set; }
        public Product(string name, decimal price, int stock, string category)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException($"'{nameof(name)}' cannot be null or empty.", nameof(name));
            }

            if (string.IsNullOrEmpty(category))
            {
                throw new ArgumentException($"'{nameof(category)}' cannot be null or empty.", nameof(category));
            }

            Name = name;
            Price = price;
            Stock = stock;
            Category = category;
        }
        public override string ToString()
        {
            return $"Name: {Name}, Category: {Category}, Price: ${Price:F2}, Stock: {Stock}";
        }
        public string ToCsv()
        {
            return $"{Name},{Price},{Stock},{Category}";
        }
        public static Product FromCsv(string csvLine)
        {
            var values = csvLine.Split(',');
            return new Product(
                values[0],
                decimal.Parse(values[1]),
                int.Parse(values[2]),
                values[3]
            );
        }
    }
}
