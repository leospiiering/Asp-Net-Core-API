using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associado.Domain;
using Associado.Repositories.Data;
using Associado.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Associado.Repositories.Repository
{
    public class AssociadoRepository : IAssociadoRepository
    {
        private DataContext dataContext;

        public AssociadoRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task Create(Associad associado)
        {
            dataContext.Add(associado);
            await dataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            dataContext.Remove(GetById(id));
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<Associad>> GetAll()
        {
            return await dataContext.Associado.ToListAsync();
        }

        public async Task<Associad> GetById(int id)
        {
            return await dataContext.Associado.SingleOrDefaultAsync(x=>x.id == id);
        }

        public async Task Update(Associad associado)
        {
            dataContext.Entry(associado).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<AssociadoDTO>> GetAllDto()
        {
            return await dataContext.Associado.Include(i => i.dependente).Select(a =>
                new AssociadoDTO()
                {
                    id = a.id,
                    nome = a.nome,
                    email = a.email,
                    ceep = a.ceep
                }
            ).ToListAsync();
        }

        public async Task<AssociadoDTO> GetByIdDto(int id)
        {
            return await dataContext.Associado.Include(i => i.dependente).Select(a =>
                new AssociadoDTO()
                {
                    id = a.id,
                    nome = a.nome,
                    ceep = a.ceep,
                    email = a.email,
                }
            ).SingleOrDefaultAsync(i => i.id == id);
        }
    }
}