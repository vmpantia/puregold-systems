using Microsoft.EntityFrameworkCore;
using Puregold.API.Models;

namespace Puregold.API.DataAccess
{
    public class PuregoldDbContext : DbContext
    {
        public PuregoldDbContext() : base() { }
        public PuregoldDbContext(DbContextOptions options) : base(options) { }
        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
    }
}
