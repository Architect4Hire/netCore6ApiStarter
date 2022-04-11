using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Commands;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Models;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Querries;

namespace Architect4Hire.netCore6ApiStarterDomainLayer.BusinessLayer
{
    public class BusinessLayer:IBusinessLayer
    {
        private readonly IDataLayer _data;

        public BusinessLayer(IDataLayer dl)
        {
            _data = dl;
        }

        public async Task<Product> Create(CreateProductCommand command)
        {
            return await _data.Create(command);
        }

        public async Task<Product> Delete(DeleteProductByIdCommand command)
        {
            return await _data.Delete(command);
        }

        public async Task<Product> Fetch(GetProductByIdQuery query)
        {
            return await _data.Fetch(query);
        }

        public async Task<List<Product>> FetchAll(GetAllProductsQuery query)
        {
            return await _data.FetchAll(query);
        }

        public async Task<Product> Update(UpdateProductCommand command)
        {
            return await _data.Update(command);
        }
    }
}
