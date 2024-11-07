using Microsoft.EntityFrameworkCore;
using SalaoDeBeleza.Classes;

namespace SalaoDeBeleza.DataBase
{
    public class DBContextInMemory : DbContext
    {
        public DBContextInMemory(DbContextOptions<DBContextInMemory> options)
    : base(options)
        {
        }

        public virtual DbSet<Scheduling> Scheduling { get; set; }

        public virtual DbSet<Customer> Customer { get; set; }

        public virtual DbSet<Professional> Professional { get; set; }

        public virtual DbSet<Service> Service { get; set; }
    }
}
