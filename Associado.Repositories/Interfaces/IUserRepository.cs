using System.Collections.Generic;
using System.Threading.Tasks;
using Associado.Domain;

namespace Associado.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AutUser(User user);
        Task Create(User user);
        Task Update(User user);
        Task Delete(int id);
        Task<User> GetById(int id);
        Task<List<User>> GetAll();
    }
}