using System.Collections.Generic;
using eShop.CoreBusiness.models;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.UseCases.AdminPortalScreen
{
    public class ViewOutstandingOrdersUseCase : IViewOutstandingOrdersUseCase
    {
        private readonly IOrderRepository orderRepository;

        public ViewOutstandingOrdersUseCase(IOrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        public IEnumerable<Order> Execute()
        {
            return orderRepository.GetOutstandingOrders();
        }
    }
}
