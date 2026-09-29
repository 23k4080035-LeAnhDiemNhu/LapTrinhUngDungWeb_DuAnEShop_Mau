using eShop.CoreBusiness.models;

namespace eShop.UseCases.ShoppingCartScreen
{
    public interface IViewOrderConfirmationUseCase
    {
        Order Execute(int orderId);
    }
}
