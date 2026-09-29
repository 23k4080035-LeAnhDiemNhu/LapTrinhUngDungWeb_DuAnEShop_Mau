using System;
using eShop.CoreBusiness.Services;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.UseCases.AdminPortalScreen
{
    public class ProcessOrderUseCase : IProcessOrderUseCase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IOrderService orderService;

        public ProcessOrderUseCase(IOrderRepository orderRepository, IOrderService orderService)
        {
            this.orderRepository = orderRepository;
            this.orderService = orderService;
        }

        public bool Execute(int orderId, string adminUserName)
        {
            var order = orderRepository.GetOrder(orderId);
            if (order != null && order.OrderId.HasValue && order.OrderId.Value > 0)
            {
                order.DateProcessed = DateTime.UtcNow;
                order.AdminUser = adminUserName;

                if (orderService.ValidateProcessOrder(order))
                {
                    orderRepository.UpdateOrder(order);
                    return true;
                }
            }
            return false;
        }
    }
}
