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
    public class DependenteController : Controller
    {
       private readonly IDependenteRepository repository;

        public DependenteController(IDependenteRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<Dependente>> Get()
        {
            return await this.repository.GetAll();
        }

        // GET api/values/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<Dependente> Get(int id)
        {
            return await this.repository.GetById(id);
        }

        // POST api/values
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Dependente dependente)
        {
            await this.repository.Create(dependente);
            return Ok(dependente);
        }

        // PUT api/values/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Dependente dependente)
        {
            await this.repository.Update(dependente);
            return Ok(dependente);
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