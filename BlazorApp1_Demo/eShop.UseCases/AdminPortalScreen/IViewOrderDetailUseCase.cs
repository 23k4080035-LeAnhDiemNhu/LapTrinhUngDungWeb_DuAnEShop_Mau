using eShop.CoreBusiness.models;

namespace eShop.UseCases.AdminPortalScreen
{
    public interface IViewOrderDetailUseCase
    {
        Order Execute(int orderId);
    }
}
