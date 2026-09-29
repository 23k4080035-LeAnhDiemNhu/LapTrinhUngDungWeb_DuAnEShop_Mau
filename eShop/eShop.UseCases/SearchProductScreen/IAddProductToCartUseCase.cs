using System.Threading.Tasks;

namespace eShop.UseCases.SearchProductScreen
{
    public interface IAddProductToCartUseCase
    {
        Task ExecuteAsync(int productId);
    }
}
