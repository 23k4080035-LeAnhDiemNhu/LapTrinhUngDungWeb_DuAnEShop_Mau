using System.Threading.Tasks;
using eShop.CoreBusiness.models;

namespace eShop.UseCases.PluginInterfaces.UI
{
    public interface IShoppingCart
    {
        Task<Order> GetOrderAsync();
        Task<Order> AddProductAsync(Product product);
        Task<Order> UpdateQuantityAsync(int productId, int quantity);
        Task<Order> DeleteProductAsync(int productId);
        Task EmptyAsync();
    }
}
