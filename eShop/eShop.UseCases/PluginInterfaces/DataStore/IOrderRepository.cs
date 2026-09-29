using eShop.CoreBusiness.models;

namespace eShop.UseCases.PluginInterfaces.DataStore
{
    public interface IOrderRepository
    {
        int CreateOrder(Order order);
        Order GetOrder(int id);
        void UpdateOrder(Order order);
        IEnumerable<Order> GetOutstandingOrders();
        IEnumerable<Order> GetProcessedOrders();
    }
}
