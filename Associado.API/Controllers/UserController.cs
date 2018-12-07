using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Threading.Tasks;
using Associado.Domain;
using Associado.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Associado.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserRepository repository;

        public UserController(IUserRepository repository)
        {
            this.repository = repository;
        }

        // GET api/values
        [Authorize]
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await this.repository.GetAll();
        }

        // GET api/values/5
        [Authorize]
        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await this.repository.GetById(id);
        }

        // POST api/values
        [Authorize]
        [HttpPost("authenticate")]
        public IActionResult Authentication([FromBody] User user)
        {
            var getUser = this.repository.AutUser(user);

            if(getUser == null)
            {
                return BadRequest(new{
                    message = "Login ou Senha INCORRETOS!"
                });
            }

            return Ok(new{
                token = BuildToken()
            });
        }

        // PUT api/values/5
        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            await this.repository.Update(user);
            return Ok(user);
        }

        // DELETE api/values/5
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await this.repository.Delete(id);
            return Ok(id);
        }

        public string BuildToken()
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("AssociadoAssync15"));
            var creed = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                audience: "Associado15",
                issuer: "Associados15",
                signingCredentials: creed
        );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}