using System.Threading.Tasks;
using eShop.CoreBusiness.models;
using eShop.UseCases.PluginInterfaces.DataStore;
using eShop.UseCases.PluginInterfaces.UI;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class ViewShoppingCartUseCase : IViewShoppingCartUseCase
    {
        private readonly IShoppingCart shoppingCart;
        private readonly IProductRepository productRepository;

        public ViewShoppingCartUseCase(IShoppingCart shoppingCart, IProductRepository productRepository)
        {
            this.shoppingCart = shoppingCart;
            this.productRepository = productRepository;
        }

        public async Task<Order> Execute()
        {
            var order = await shoppingCart.GetOrderAsync();
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
