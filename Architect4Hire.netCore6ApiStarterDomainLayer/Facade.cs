using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect4Hire.netCore6ApiStarterDomainLayer.BusinessLayer;
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

        public async Task<List<string>> Fetch()
        {
            return await _business.Fetch();
        }
    }
}
