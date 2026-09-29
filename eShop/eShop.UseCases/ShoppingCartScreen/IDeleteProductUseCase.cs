using System.Threading.Tasks;
using eShop.CoreBusiness.models;

namespace eShop.UseCases.ShoppingCartScreen
{
    public interface IDeleteProductUseCase
    {
        Task<Order> ExecuteAsync(int productId);
        Task<Order> Execute(int productId);
    }
}
