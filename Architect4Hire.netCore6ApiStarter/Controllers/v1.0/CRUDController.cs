using Architect4Hire.netCore6ApiStarterDomainLayer;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Architect4Hire.netCore6ApiStarter.Controllers
{
    [ApiVersion("1.0")]
    public class CRUDController : BaseController
    {
        private readonly IFacade _facade;

        public CRUDController(IFacade f)
        {
            _facade = f;
        }

        [HttpGet]
        public async Task<IEnumerable<string>> Get()
        {
            return await _facade.Fetch();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

