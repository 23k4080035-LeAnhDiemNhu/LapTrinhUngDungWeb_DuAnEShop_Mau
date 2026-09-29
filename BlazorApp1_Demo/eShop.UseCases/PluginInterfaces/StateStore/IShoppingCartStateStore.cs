namespace eShop.UseCases.PluginInterfaces.StateStore
{
    public interface IShoppingCartStateStore : IStateStore
    {
        Task<int> GetItemsCount();
        Task<int> GetItemCount();
        void UpdateLineItemsCount();
        void UpdateProductQuantity();
    }
}
