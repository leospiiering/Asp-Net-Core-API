using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associado.Domain;
using Associado.Repositories.Data;
using Associado.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Associado.Repositories.Repository
{
    public class DependenteRepository : IDependenteRepository
    {
        private DataContext dataContext;

        public DependenteRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public async Task Create(Dependente dependente)
        {
            dataContext.Add(dependente);
            await dataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            dataContext.Remove(GetById(id));
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<Dependente>> GetAll()
        {
            return await dataContext.Dependente.ToListAsync();
        }

        public async Task<Dependente> GetById(int id)
        {
            return await dataContext.Dependente.SingleOrDefaultAsync(x=> x.id == id);
        }

        public async Task Update(Dependente dependente)
        {
            dataContext.Entry(dependente).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
        }
    }
}