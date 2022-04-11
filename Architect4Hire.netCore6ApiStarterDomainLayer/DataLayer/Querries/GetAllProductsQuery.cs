using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Context;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Querries
{
    public class GetAllProductsQuery : IRequest<IList<Product>>
    {
        public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IList<Product>>
        {
            private readonly IApplicationContext _context;

            public GetAllProductsQueryHandler(IApplicationContext context)
            {
                _context = context;
            }

            public async Task<IList<Product>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Products.ToListAsync();
                if (productList == null)
                {
                    return null;
                }
                return productList.AsReadOnly();
            }
        }
    }
}

