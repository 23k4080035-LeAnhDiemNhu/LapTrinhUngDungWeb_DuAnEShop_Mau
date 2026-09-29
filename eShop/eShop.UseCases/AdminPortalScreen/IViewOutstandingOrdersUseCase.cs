using System.Collections.Generic;
using eShop.CoreBusiness.models;

namespace eShop.UseCases.AdminPortalScreen
{
    public interface IViewOutstandingOrdersUseCase
    {
        IEnumerable<Order> Execute();
    }
}
