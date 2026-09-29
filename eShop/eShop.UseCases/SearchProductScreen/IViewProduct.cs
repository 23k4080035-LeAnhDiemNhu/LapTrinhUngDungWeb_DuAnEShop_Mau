using eShop.CoreBusiness.models;

namespace eShop.UseCases.SearchProductScreen
{
    public interface IViewProduct
    {
        Product Execute(int id);
    }
}
