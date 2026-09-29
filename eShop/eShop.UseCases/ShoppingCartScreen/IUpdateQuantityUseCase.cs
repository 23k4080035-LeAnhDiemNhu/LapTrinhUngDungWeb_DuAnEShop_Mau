using System.Threading.Tasks;
using eShop.CoreBusiness.models;

namespace eShop.UseCases.ShoppingCartScreen
{
    public interface IUpdateQuantityUseCase
    {
        Task<Order> ExecuteAsync(int productId, int quantity);
    }
}
