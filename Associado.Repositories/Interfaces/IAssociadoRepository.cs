using System.Collections.Generic;
using System.Threading.Tasks;
using Associado.Domain;

namespace Associado.Repositories.Interfaces
{
    public interface IAssociadoRepository
    {
        Task Create(Associad obj);
        Task Update(Associad obj);
        Task Delete(int id);
        Task<Associad> GetById(int id);
        Task<List<Associad>> GetAll();
        Task<List<AssociadoDTO>> GetAllDto();
        Task<AssociadoDTO> GetByNameDto(string nome);
    }
}