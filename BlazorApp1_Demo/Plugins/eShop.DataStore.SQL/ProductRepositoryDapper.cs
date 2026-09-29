using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;
using eShop.CoreBusiness.models;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.DataStore.SQL
{
    public class ProductRepositoryDapper : IProductRepository
    {
        private readonly string connectionString;

        public ProductRepositoryDapper(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Product GetProduct(int id)
        {
            using IDbConnection db = new SqlConnection(connectionString);
            var sql = "SELECT * FROM Product WHERE Id = @Id";
            return db.QueryFirstOrDefault<Product>(sql, new { Id = id }) ?? new Product();
        }

        public IEnumerable<Product> GetProducts(string filter = "")
        {
            using IDbConnection db = new SqlConnection(connectionString);
            if (string.IsNullOrWhiteSpace(filter))
            {
                return db.Query<Product>("SELECT * FROM Product");
            }
            var sql = "SELECT * FROM Product WHERE Name LIKE @Filter";
            return db.Query<Product>(sql, new { Filter = $"%{filter}%" });
        }
    }
}
