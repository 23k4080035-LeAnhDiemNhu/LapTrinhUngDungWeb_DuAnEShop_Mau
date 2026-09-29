using System.Threading.Tasks;
using eShop.CoreBusiness.models;
using eShop.CoreBusiness.Services;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class PlaceOrderUseCase : IPlaceOrderUseCase
    {
        private readonly IOrderService orderService;
        private readonly IOrderRepository orderRepository;
        private readonly IShoppingCart shoppingCart;
        private readonly IShoppingCartStateStore shoppingCartStateStore;

        public PlaceOrderUseCase(
            IOrderService orderService,
            IOrderRepository orderRepository,
            IShoppingCart shoppingCart,
            IShoppingCartStateStore shoppingCartStateStore)
        {
            this.orderService = orderService;
            this.orderRepository = orderRepository;
            this.shoppingCart = shoppingCart;
            this.shoppingCartStateStore = shoppingCartStateStore;
        }

        public async Task<int> ExecuteAsync(Order order)
        {
            if (orderService.ValidateCreateOrder(order))
            {
                int orderId = orderRepository.CreateOrder(order);
                await shoppingCart.EmptyAsync();
                shoppingCartStateStore.UpdateLineItemsCount();
                return orderId;
            }
            return 0;
        }
    }
}
