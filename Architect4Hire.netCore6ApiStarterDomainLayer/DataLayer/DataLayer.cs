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

        public Task<IEnumerable<string>> Fetch()
        {
            _mediator.Send();
        }
    }
}
