using Associado.Domain;
using Microsoft.EntityFrameworkCore;

namespace Associado.Repositories.Data
{
    public class DataContext : DbContext
    {
         public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        public DbSet<Associad> Associado { get; set; }
        public DbSet<Dependente> Dependente { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<AssociadoDTO> AssociadoDTO { get; set; }
    }
}