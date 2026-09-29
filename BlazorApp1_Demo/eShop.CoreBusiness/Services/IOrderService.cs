using eShop.CoreBusiness.models;

namespace eShop.CoreBusiness.Services
{
    public interface IOrderService
    {
        bool ValidateCustomerInformation(Order order);
        bool ValidateCreateOrder(Order order);
        bool ValidateUpdateOrder(Order order);
        bool ValidateProcessOrder(Order order);
    }
}
