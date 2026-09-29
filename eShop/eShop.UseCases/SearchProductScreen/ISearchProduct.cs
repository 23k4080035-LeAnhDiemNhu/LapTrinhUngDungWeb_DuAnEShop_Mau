using eShop.CoreBusiness.models;

namespace eShop.UseCases.SearchProductScreen
{
    public interface ISearchProduct
    {
        IEnumerable<Product> Execute(string? filter = null);
    }
}
