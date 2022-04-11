using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Commands;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Models;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Querries;

namespace Architect4Hire.netCore6ApiStarterDomainLayer
{
    public interface IFacade
    {
        Task<Product> Fetch(GetProductByIdQuery query);
        Task<List<Product>> FetchAll(GetAllProductsQuery query);
        Task<Product> Create(CreateProductCommand command);
        Task<Product> Delete(DeleteProductByIdCommand command);
        Task<Product> Update(UpdateProductCommand command);
    }
}
