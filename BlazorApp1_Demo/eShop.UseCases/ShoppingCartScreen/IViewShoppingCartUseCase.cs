using System.Threading.Tasks;
using eShop.CoreBusiness.models;

namespace eShop.UseCases.ShoppingCartScreen
{
    public interface IViewShoppingCartUseCase
    {
        Task<Order> Execute();
    }
}
