using System;
namespace MiniEcoMarket
{
    class Order
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderTime { get; set; }
        public Order(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
            OrderTime = DateTime.Now;
        }
        public decimal TotalAmount() => Product.Price * Quantity;

        public override string ToString()
        {
            return $"{Product.Name} ({Product.Category}) x {Quantity} @ ${Product.Price:F2} each | Total: ${TotalAmount():F2} | Ordered on {OrderTime}";
        }
    }
}
