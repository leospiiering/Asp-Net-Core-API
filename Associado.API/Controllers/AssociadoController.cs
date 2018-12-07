using System.Collections.Generic;
using System.Threading.Tasks;
using Associado.Domain;
using Associado.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Associado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssociadoController : Controller
    {
        private readonly IAssociadoRepository repository;

         public AssociadoController(IAssociadoRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<AssociadoDTO>> Get()
        {
            return await this.repository.GetAllDto();
        }

        // GET api/values/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<AssociadoDTO> GetBy(int id)
        {
            return await this.repository.GetByIdDto(id);
        }
        // POST api/values  
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Associad associado)
        {
            await this.repository.Create(associado);
            return Ok(associado);
        }

        // PUT api/values/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Associad associado)
        {
            await this.repository.Update(associado);
            return Ok(associado);
        }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.repository.Delete(id);
            return Ok(id);
        }
    }
}