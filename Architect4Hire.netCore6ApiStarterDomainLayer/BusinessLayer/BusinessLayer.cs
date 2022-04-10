using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer;

namespace Architect4Hire.netCore6ApiStarterDomainLayer.BusinessLayer
{
    public class BusinessLayer:IBusinessLayer
    {
        private readonly IDataLayer _data;

        public BusinessLayer(IDataLayer dl)
        {
            _data = dl;
        }

        public async Task<List<string>> Fetch()
        {
            return await _data.Fetch();
        }
    }
}
