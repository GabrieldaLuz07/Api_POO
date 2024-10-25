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

        public virtual DbSet<Agendamento> Agendamentos { get; set; }

        public virtual DbSet<Cliente> Cliente { get; set; }

        public virtual DbSet<Profissional> Profissional { get; set; }

        public virtual DbSet<Servico> Servico { get; set; }
    }
}
