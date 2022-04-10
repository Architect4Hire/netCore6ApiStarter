using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architect4Hire.netCore6ApiStarterDomainLayer.BusinessLayer
{
    public interface IBusinessLayer
    {
        Task<List<string>> Fetch();
    }
}
