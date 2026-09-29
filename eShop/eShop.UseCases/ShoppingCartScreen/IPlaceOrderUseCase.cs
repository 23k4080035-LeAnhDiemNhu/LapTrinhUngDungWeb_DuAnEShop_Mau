using System.Threading.Tasks;
using eShop.CoreBusiness.models;

namespace eShop.UseCases.ShoppingCartScreen
{
    public interface IPlaceOrderUseCase
    {
        Task<int> ExecuteAsync(Order order);
    }
}
