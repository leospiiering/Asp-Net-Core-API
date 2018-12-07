using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Associado.Domain;
using Associado.Repositories.Data;
using Associado.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Associado.Repositories.Repository
{
    public class UserRepository : IUserRepository
    {
        private DataContext dataContext;

        public UserRepository(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        
        public async Task<User> AutUser(User user)
        {
            return await dataContext.User.SingleOrDefaultAsync(u => u.login == user.login && u.password == user.password);
        }
        public async Task Create(User user)
        {
            dataContext.Add(user);
            await dataContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            dataContext.Remove(GetById(id));
            await dataContext.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await dataContext.User.ToListAsync();
        }

        public async Task<User> GetById(int id)
        {
            return await dataContext.User.SingleOrDefaultAsync(x=> x.id == id);
        }

        public async Task Update(User user)
        {
            dataContext.Entry(user).State = EntityState.Modified;
            await dataContext.SaveChangesAsync();
        }
    }
}