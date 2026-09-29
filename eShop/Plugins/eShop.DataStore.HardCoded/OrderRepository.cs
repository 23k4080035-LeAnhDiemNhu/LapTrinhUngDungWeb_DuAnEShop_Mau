using System;
using System.Collections.Generic;
using System.Linq;
using eShop.CoreBusiness.models;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.DataStore.HardCoded
{
    public class OrderRepository : IOrderRepository
    {
        private readonly Dictionary<int, Order> orders;

        public OrderRepository()
        {
            orders = new Dictionary<int, Order>();
        }

        public int CreateOrder(Order order)
        {
            order.Id = orders.Count + 1;
            order.DatePlaced = DateTime.UtcNow;
            orders[order.Id.Value] = order;
            return order.Id.Value;
        }

        public Order GetOrder(int id)
        {
            if (orders.TryGetValue(id, out var order))
            {
                return order;
            }
            return new Order();
        }

        public void UpdateOrder(Order order)
        {
            if (order.Id.HasValue && orders.ContainsKey(order.Id.Value))
            {
                orders[order.Id.Value] = order;
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            return orders.Values;
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            return orders.Values.Where(x => !x.DateProcessed.HasValue).ToList();
        }

        public IEnumerable<Order> GetOutStandingOrders()
        {
            return GetOutstandingOrders();
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            return orders.Values.Where(x => x.DateProcessed.HasValue).ToList();
        }

        public Order? GetOrderByUniqueId(string uniqueId)
        {
            return orders.Values.FirstOrDefault(x => x.UniqueId == uniqueId);
        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId)
        {
            var order = GetOrder(orderId);
            return order?.LineItems ?? new List<OrderLineItem>();
        }
    }
}
