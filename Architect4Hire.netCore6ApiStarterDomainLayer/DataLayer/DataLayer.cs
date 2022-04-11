using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Commands;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Models;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Querries;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer
{
    public class DataLayer:IDataLayer
    {
        private IMediator _mediator;
        
        public DataLayer(IMediator m)
        {
            _mediator = m;
        }

        public async Task<Product> Create(CreateProductCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Delete(DeleteProductByIdCommand command)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Fetch(GetProductByIdQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> FetchAll(GetAllProductsQuery query)
        {
            throw new NotImplementedException();
        }

        public async Task<Product> Update(UpdateProductCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
