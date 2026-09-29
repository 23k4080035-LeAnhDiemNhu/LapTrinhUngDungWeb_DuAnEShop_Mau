using eShop.CoreBusiness.models;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class ViewOrderConfirmationUseCase : IViewOrderConfirmationUseCase
    {
        private readonly IOrderRepository orderRepository;
        private readonly IProductRepository productRepository;

        public ViewOrderConfirmationUseCase(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            this.orderRepository = orderRepository;
            this.productRepository = productRepository;
        }

        public Order Execute(int orderId)
        {
            var order = orderRepository.GetOrder(orderId);
            if (order != null && order.LineItems != null)
            {
                foreach (var item in order.LineItems)
                {
                    if (item.Product == null && item.ProductId > 0)
                    {
                        item.Product = productRepository.GetProduct(item.ProductId);
                    }
                }
            }
            return order ?? new Order();
        }

        public Order Execute(string uniqueId)
        {
            var order = orderRepository.GetOrderByUniqueId(uniqueId);
            if (order != null && order.LineItems != null)
            {
                foreach (var item in order.LineItems)
                {
                    if (item.Product == null && item.ProductId > 0)
                    {
                        item.Product = productRepository.GetProduct(item.ProductId);
                    }
                }
            }
            return order ?? new Order();
        }
    }
}
