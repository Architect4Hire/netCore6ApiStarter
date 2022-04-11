using Architect4Hire.netCore6ApiStarterDomainLayer;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Commands;
using Architect4Hire.netCore6ApiStarterDomainLayer.DataLayer.Querries;
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await _facade.Create(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _facade.FetchAll(new GetAllProductsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _facade.Fetch(new GetProductByIdQuery { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _facade.Delete(new DeleteProductByIdCommand { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _facade.Update(command));
        }
    }
}

