using System;
using System.Linq;
using eShop.CoreBusiness.models;

namespace eShop.CoreBusiness.Services
{
    public class OrderService : IOrderService
    {
        public bool ValidateCustomerInformation(Order order)
        {
            if (order == null) return false;

            return ValidateCustomerInfomation(
                order.CustomerName,
                order.CustomerAddress,
                order.CustomerCity,
                order.CustomerStateProvince,
                order.CustomerCountry);
        }

        public bool ValidateCustomerInfomation(string name, string address, string city, string province, string country)
        {
            if (string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(address) ||
                string.IsNullOrWhiteSpace(city) ||
                string.IsNullOrWhiteSpace(province) ||
                string.IsNullOrWhiteSpace(country))
            {
                return false;
            }
            return true;
        }

        public bool ValidateCreateOrder(Order order)
        {
            if (order == null) return false;

            // Order must have at least 1 line item
            if (order.LineItems == null || !order.LineItems.Any()) return false;

            // Validate all line items
            foreach (var item in order.LineItems)
            {
                if (item.ProductId <= 0 || item.Quantity <= 0 || item.Price < 0)
                    return false;
            }

            // Customer information must be valid
            if (!ValidateCustomerInformation(order)) return false;

            return true;
        }

        public bool ValidateUpdateOrder(Order order)
        {
            if (order == null) return false;

            if (!order.OrderId.HasValue || order.OrderId.Value <= 0) return false;
            if (!order.DatePlaced.HasValue) return false;

            if (order.LineItems == null || !order.LineItems.Any()) return false;

            foreach (var item in order.LineItems)
            {
                if (item.ProductId <= 0 || item.Quantity <= 0 || item.Price < 0)
                    return false;
            }

            if (!ValidateCustomerInformation(order)) return false;

            return true;
        }

        public bool ValidateProcessOrder(Order order)
        {
            if (order == null) return false;

            if (!order.DateProcessed.HasValue) return false;
            if (string.IsNullOrWhiteSpace(order.AdminUser)) return false;

            return ValidateUpdateOrder(order);
        }
    }
}
