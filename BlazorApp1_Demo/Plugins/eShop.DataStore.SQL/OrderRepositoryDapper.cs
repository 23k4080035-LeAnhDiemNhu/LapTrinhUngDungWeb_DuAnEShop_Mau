using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using eShop.CoreBusiness.models;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.DataStore.SQL
{
    public class OrderRepositoryDapper : IOrderRepository
    {
        private readonly string connectionString;

        public OrderRepositoryDapper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int CreateOrder(Order order)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            db.Open();
            using var transaction = db.BeginTransaction();

            var sqlOrder = @"INSERT INTO [Order] 
                (DatePlaced, DateProcessing, DateProcessed, CustomerName, CustomerAddress, CustomerCity, CustomerStateProvince, CustomerZipCode, CustomerCountry, AdminUser) 
                VALUES (@DatePlaced, @DateProcessing, @DateProcessed, @CustomerName, @CustomerAddress, @CustomerCity, @CustomerStateProvince, @CustomerZipCode, @CustomerCountry, @AdminUser);
                SELECT CAST(SCOPE_IDENTITY() as int);";

            order.DatePlaced = DateTime.UtcNow;
            int orderId = db.Query<int>(sqlOrder, order, transaction: transaction).Single();

            if (order.LineItems != null)
            {
                var sqlItem = @"INSERT INTO OrderLineItem (ProductId, Price, Quantity, OrderId) 
                    VALUES (@ProductId, @Price, @Quantity, @OrderId);";

                foreach (var item in order.LineItems)
                {
                    item.OrderId = orderId;
                    db.Execute(sqlItem, item, transaction: transaction);
                }
            }

            transaction.Commit();
            return orderId;
        }

        public Order GetOrder(int id)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            var sqlOrder = "SELECT * FROM [Order] WHERE OrderId = @Id";
            var order = db.QueryFirstOrDefault<Order>(sqlOrder, new { Id = id });

            if (order != null)
            {
                var sqlItems = "SELECT * FROM OrderLineItem WHERE OrderId = @Id";
                order.LineItems = db.Query<OrderLineItem>(sqlItems, new { Id = id }).ToList();
            }

            return order ?? new Order();
        }

        public void UpdateOrder(Order order)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            var sql = @"UPDATE [Order] SET 
                DatePlaced = @DatePlaced, 
                DateProcessing = @DateProcessing, 
                DateProcessed = @DateProcessed, 
                CustomerName = @CustomerName, 
                CustomerAddress = @CustomerAddress, 
                CustomerCity = @CustomerCity, 
                CustomerStateProvince = @CustomerStateProvince, 
                CustomerZipCode = @CustomerZipCode, 
                CustomerCountry = @CustomerCountry, 
                AdminUser = @AdminUser 
                WHERE OrderId = @OrderId";
            db.Execute(sql, order);
        }

        public IEnumerable<Order> GetOutstandingOrders()
        {
            using IDbConnection db = new SqlConnection(connectionString);
            var sql = "SELECT * FROM [Order] WHERE DateProcessed IS NULL";
            var orders = db.Query<Order>(sql).ToList();
            foreach (var o in orders)
            {
                var sqlItems = "SELECT * FROM OrderLineItem WHERE OrderId = @Id";
                o.LineItems = db.Query<OrderLineItem>(sqlItems, new { Id = o.OrderId }).ToList();
            }
            return orders;
        }

        public IEnumerable<Order> GetProcessedOrders()
        {
            using IDbConnection db = new SqlConnection(connectionString);
            var sql = "SELECT * FROM [Order] WHERE DateProcessed IS NOT NULL";
            var orders = db.Query<Order>(sql).ToList();
            foreach (var o in orders)
            {
                var sqlItems = "SELECT * FROM OrderLineItem WHERE OrderId = @Id";
                o.LineItems = db.Query<OrderLineItem>(sqlItems, new { Id = o.OrderId }).ToList();
            }
            return orders;
        }

        public IEnumerable<Order> GetOrders()
        {
            using IDbConnection db = new SqlConnection(connectionString);
            return db.Query<Order>("SELECT * FROM [Order]").ToList();
        }

        public IEnumerable<Order> GetOutStandingOrders()
        {
            return GetOutstandingOrders();
        }

        public Order? GetOrderByUniqueId(string uniqueId)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            var sqlOrder = "SELECT * FROM [Order] WHERE UniqueId = @UniqueId";
            var order = db.QueryFirstOrDefault<Order>(sqlOrder, new { UniqueId = uniqueId });

            if (order != null && order.OrderId.HasValue)
            {
                order.LineItems = GetLineItemsByOrderId(order.OrderId.Value).ToList();
            }

            return order;
        }

        public IEnumerable<OrderLineItem> GetLineItemsByOrderId(int orderId)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            var sqlItems = "SELECT * FROM OrderLineItem WHERE OrderId = @OrderId";
            return db.Query<OrderLineItem>(sqlItems, new { OrderId = orderId }).ToList();
        }
    }
}
