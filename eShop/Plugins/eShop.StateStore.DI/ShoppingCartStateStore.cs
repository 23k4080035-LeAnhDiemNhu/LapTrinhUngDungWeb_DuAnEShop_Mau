using eShop.UseCases.PluginInterfaces.StateStore;
using eShop.UseCases.PluginInterfaces.UI;

namespace eShop.StateStore.DI
{
    public class ShoppingCartStateStore : StateStoreBase, IShoppingCartStateStore
    {
        private readonly IShoppingCart shoppingCart;

        public ShoppingCartStateStore(IShoppingCart shoppingCart)
        {
            this.shoppingCart = shoppingCart;
        }

        public async Task<int> GetItemsCount()
        {
            var order = await shoppingCart.GetOrderAsync();
            if (order != null && order.LineItems != null)
            {
                return order.LineItems.Sum(x => x.Quantity);
            }
            return 0;
        }

        public async Task<int> GetItemCount()
        {
            return await GetItemsCount();
        }

        public void UpdateLineItemsCount()
        {
            BroadCastStateChange();
        }

        public void UpdateProductQuantity()
        {
            BroadCastStateChange();
        }
    }
}
