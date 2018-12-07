using System.Collections.Generic;
using System.Threading.Tasks;
using Associado.Domain;

namespace Associado.Repositories.Interfaces
{
    public interface IDependenteRepository
    {
        Task Create(Dependente obj);
        Task Update(Dependente obj);
        Task Delete(int id);
        Task<Dependente> GetById(int id);
        Task<List<Dependente>> GetAll();
    }
}