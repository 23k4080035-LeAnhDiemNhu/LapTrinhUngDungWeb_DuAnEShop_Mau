using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [Required(ErrorMessage = "Customer Name is required.")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Street Address is required.")]
        public string CustomerAddress { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required.")]
        public string CustomerCity { get; set; } = string.Empty;

        [Required(ErrorMessage = "State/Province is required.")]
        public string CustomerStateProvince { get; set; } = string.Empty;

        [Required(ErrorMessage = "Zip Code is required.")]
        public string CustomerZipCode { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        public string CustomerCountry { get; set; } = string.Empty;

        public string AdminUser { get; set; } = string.Empty;

        public List<OrderLineItem> LineItems { get; set; } = new List<OrderLineItem>();

        // Domain Logic Helper Methods
        public void AddProduct(int productId, int qty, double price)
        {
            var item = LineItems.FirstOrDefault(x => x.ProductId == productId);
            if (item != null)
            {
                item.Quantity += qty;
            }
            else
            {
                LineItems.Add(new OrderLineItem 
                { 
                    ProductId = productId, 
                    Quantity = qty, 
                    Price = price, 
                    OrderId = OrderId 
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
