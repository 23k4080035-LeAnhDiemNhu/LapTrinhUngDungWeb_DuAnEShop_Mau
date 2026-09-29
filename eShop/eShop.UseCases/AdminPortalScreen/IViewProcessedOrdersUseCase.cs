using System.Collections.Generic;
using eShop.CoreBusiness.models;

namespace eShop.UseCases.AdminPortalScreen
{
    public interface IViewProcessedOrdersUseCase
    {
        IEnumerable<Order> Execute();
    }
}
