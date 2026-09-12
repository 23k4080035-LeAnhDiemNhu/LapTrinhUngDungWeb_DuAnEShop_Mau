using eShop.CoreBusiness.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.UseCases.SearchProductScreen
{
    public interface IViewProduct
    {
        Product Execute(int id);
    }
}
