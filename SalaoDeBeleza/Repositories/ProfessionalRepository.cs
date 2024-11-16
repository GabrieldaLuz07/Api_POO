using SalaoDeBeleza.Classes;
using SalaoDeBeleza.DataBase;
using SalaoDeBeleza.Interfaces;

namespace SalaoDeBeleza.Repositories
{
    public class ProfessionalRepository : IProfessionalRepository
    {
        private readonly DBContextInMemory dbContext;
        public ProfessionalRepository(DBContextInMemory db)
        {
            dbContext = db;
        }

        // Buscar todos os profissionais do banco
        public List<Professional> GetAllProfessionals()
        {
            return dbContext.Professional.ToList();
        }

        // Buscar um profissional do banco com base no seu Id
        public Professional GetProfessionalById(int id)
        {
            return dbContext.Professional.FirstOrDefault(p => p.Id == id);
        }

        // Buscar todos os profissionais disponíveis
        public List<Professional> GetAvaibleProfessionals()
        {
            return dbContext.Professional.Where(p => p.Available == true).ToList();
        }

        // Cadastrar um novo profissional
        public void AddProfessional(Professional professional)
        {
            dbContext.Professional.Add(professional);
            dbContext.SaveChanges();
        }

        // Atualizar um profissional existente
        public void UpdateProfessional(Professional professional)
        {
            dbContext.Professional.Update(professional);
            dbContext.SaveChanges();
        }

        // Excluír um profissional existente
        public void DeleteProfessional(Professional professional)
        {
            dbContext.Professional.Remove(professional);
            dbContext.SaveChanges();
        }

        // Verificar se existe um profissional cadastrado com o Id passado no parâmetro
        public bool VerifyProfessional(int it)
        {
            return dbContext.Professional.Any(c => c.Id == it);
        }

    }
}
