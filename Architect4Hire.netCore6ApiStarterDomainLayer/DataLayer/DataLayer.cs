using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public async Task<List<string>> Fetch()
        {
            return new List<string>(); // _mediator.Send();
        }
    }
}
