using System;
using System.Collections.Generic;
using System.Linq;

namespace eShop.CoreBusiness.models
{
    public class Order
    {
        public int? OrderId { get; set; }
        public int? Id { get => OrderId; set => OrderId = value; }
        public DateTime? DatePlaced { get; set; }
        public DateTime? DateProcessing { get; set; }
        public DateTime? DateProcessed { get; set; }

        public string CustomerName { get; set; } = string.Empty;
        public string CustomerAddress { get; set; } = string.Empty;
        public string CustomerCity { get; set; } = string.Empty;
        public string CustomerStateProvince { get; set; } = string.Empty;
        public string CustomerZipCode { get; set; } = string.Empty;
        public string CustomerCountry { get; set; } = string.Empty;

        public string AdminUser { get; set; } = string.Empty;

        public List<OrderLineItem> LineItems { get; set; } = new List<OrderLineItem>();
        public string UniqueId { get; set; } = string.Empty;

        // Domain Logic Helper Methods
        public void AddProduct(int productId, int qty, double price, Product? product = null)
        {
            var item = LineItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                item.Quantity += qty;
                if (product != null) item.Product = product;
            }
            else
            {
                LineItems.Add(new OrderLineItem 
                { 
                    ProductId = productId, 
                    Quantity = qty, 
                    Price = price, 
                    OrderId = OrderId,
                    Product = product
                });
            }
        }

        public void RemoveProduct(int productId)
        {
            var item = LineItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                LineItems.Remove(item);
            }
        }

        public void UpdateQuantity(int productId, int quantity)
        {
            var item = LineItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                if (quantity <= 0)
                    LineItems.Remove(item);
                else
                    item.Quantity = quantity;
            }
        }
    }
}
