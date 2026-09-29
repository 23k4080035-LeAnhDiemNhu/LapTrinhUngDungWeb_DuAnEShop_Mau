using eShop.CoreBusiness.models;

namespace eShop.CoreBusiness.Services
{
    public interface IOrderService
    {
        bool ValidateCustomerInformation(Order order);
        bool ValidateCustomerInfomation(string name, string address, string city, string province, string country);
        bool ValidateCreateOrder(Order order);
        bool ValidateUpdateOrder(Order order);
        bool ValidateProcessOrder(Order order);
    }
}
