using eShop.CoreBusiness.models;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class ViewOrderConfirmationUseCase : IViewOrderConfirmationUseCase
    {
        private readonly IOrderRepository orderRepository;

        public ViewOrderConfirmationUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public Order Execute(int orderId)
        {
            return orderRepository.GetOrder(orderId);
        }
    }
}
