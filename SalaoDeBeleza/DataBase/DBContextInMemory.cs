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

        // Tabela para armazenar os clientes
        public virtual DbSet<Customer> Customer { get; set; }

        // Tabela para armazenar os profissionais
        public virtual DbSet<Professional> Professional { get; set; }

        // Tabela para armazenar os serviços
        public virtual DbSet<Service> Service { get; set; }
    }
}
