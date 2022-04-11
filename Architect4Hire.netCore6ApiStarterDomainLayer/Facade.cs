using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect4Hire.netCore6ApiStarterDomainLayer.BusinessLayer;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Commands;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Models;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Querries;
using MediatR;

namespace Architect4Hire.netCore6ApiStarterDomainLayer
{
    public class Facade: IFacade
    {
        private readonly IBusinessLayer _business;

        public Facade(IMediator m,IBusinessLayer bl)
        {
            _business = bl;
        }

        public async Task<Product> Create(CreateProductCommand command)
        {
            return await _business.Create(command);
        }

        public async Task<Product> Delete(DeleteProductByIdCommand command)
        {
            return await _business.Delete(command);
        }

        public async Task<Product> Fetch(GetProductByIdQuery query)
        {
            return await _business.Fetch(query);
        }

        public async Task<List<Product>> FetchAll(GetAllProductsQuery query)
        {
            return await _business.FetchAll(query);
        }

        public async Task<Product> Update(UpdateProductCommand command)
        {
            return await _business.Update(command);
        }
    }
}
