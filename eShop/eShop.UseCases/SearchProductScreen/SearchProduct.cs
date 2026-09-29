using eShop.CoreBusiness.models;
using eShop.UseCases.PluginInterfaces.DataStore;

namespace eShop.UseCases.SearchProductScreen
{
    public class SearchProduct : ISearchProduct
    {
        private readonly IProductRepository productRepository;
        public SearchProduct(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public IEnumerable<Product> Execute(string? filter = null)
        {
            return productRepository.GetProducts(filter ?? string.Empty);
        }
    }
}
