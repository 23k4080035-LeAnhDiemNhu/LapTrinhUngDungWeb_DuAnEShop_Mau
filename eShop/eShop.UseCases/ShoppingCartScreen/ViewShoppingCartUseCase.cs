using System.Threading.Tasks;
using eShop.CoreBusiness.models;
using eShop.UseCases.PluginInterfaces.UI;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class ViewShoppingCartUseCase : IViewShoppingCartUseCase
    {
        private readonly IShoppingCart shoppingCart;

        public ViewShoppingCartUseCase(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public Task<Order> Execute()
        {
            return shoppingCart.GetOrderAsync();
        }
    }
}
