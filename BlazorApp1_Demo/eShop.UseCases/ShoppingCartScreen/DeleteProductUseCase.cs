using System.Threading.Tasks;
using eShop.CoreBusiness.models;
using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;

namespace eShop.UseCases.ShoppingCartScreen
{
    public class DeleteProductUseCase : IDeleteProductUseCase
    {
        private readonly IShoppingCart shoppingCart;
        private readonly IShoppingCartStateStore shoppingCartStateStore;

        public DeleteProductUseCase(IShoppingCart shoppingCart, IShoppingCartStateStore shoppingCartStateStore)
        {
            this.shoppingCart = shoppingCart;
            this.shoppingCartStateStore = shoppingCartStateStore;
        }

        public async Task<Order> ExecuteAsync(int productId)
        {
            var order = await shoppingCart.DeleteProductAsync(productId);
            this.shoppingCartStateStore.UpdateLineItemsCount();
            return order;
        }

        public async Task<Order> Execute(int productId)
        {
            return await ExecuteAsync(productId);
        }
    }
}
