using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.JSInterop;
using eShop.CoreBusiness.models;
using eShop.UseCases.PluginInterfaces.UI;

namespace eShop.ShoppingCart.LocalStorage
{
    public class ShoppingCart : IShoppingCart
    {
        private readonly IJSRuntime jsRuntime;
        private const string cstrShoppingCart = "eShop.ShoppingCart";

        public ShoppingCart(IJSRuntime jsRuntime)
        {
            this.jsRuntime = jsRuntime;
        }

        public async Task<Order> GetOrderAsync()
        {
            Order? order = null;
            try
            {
                var strOrder = await jsRuntime.InvokeAsync<string>("localStorage.getItem", cstrShoppingCart);
                if (!string.IsNullOrEmpty(strOrder))
                {
                    order = JsonSerializer.Deserialize<Order>(strOrder);
                }

                if (order == null)
                {
                    order = new Order();
                    await SetOrder(order);
                }
            }
            catch (InvalidOperationException)
            {
                order = new Order();
            }
            catch (JSException)
            {
                order = new Order();
            }

            return order ?? new Order();
        }

        public async Task<Order> AddProductAsync(Product product)
        {
            var order = await GetOrderAsync();
            order.AddProduct(product.Id, 1, product.Price);
            await SetOrder(order);
            return order;
        }

        public async Task<Order> UpdateQuantityAsync(int productId, int quantity)
        {
            var order = await GetOrderAsync();
            order.UpdateQuantity(productId, quantity);
            await SetOrder(order);
            return order;
        }

        public async Task<Order> DeleteProductAsync(int productId)
        {
            var order = await GetOrderAsync();
            order.RemoveProduct(productId);
            await SetOrder(order);
            return order;
        }

        public async Task EmptyAsync()
        {
            try
            {
                await jsRuntime.InvokeVoidAsync("localStorage.removeItem", cstrShoppingCart);
            }
            catch (InvalidOperationException)
            {
            }
        }

        private async Task SetOrder(Order order)
        {
            try
            {
                var strOrder = JsonSerializer.Serialize(order);
                await jsRuntime.InvokeVoidAsync("localStorage.setItem", cstrShoppingCart, strOrder);
            }
            catch (InvalidOperationException)
            {
            }
        }
    }
}
