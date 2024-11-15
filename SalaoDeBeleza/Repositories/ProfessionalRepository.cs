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

        public List<Professional> GetAllProfessionals()
        {
            return dbContext.Professional.ToList();
        }

        public Professional GetProfessionalById(int id)
        {
            return dbContext.Professional.FirstOrDefault(p => p.Id == id);
        }

        public List<Professional> GetAvaibleProfessionals()
        {
            return dbContext.Professional.Where(p => p.Available == true).ToList();
        }

        public void AddProfessional(Professional professional)
        {
            dbContext.Professional.Add(professional);
            dbContext.SaveChanges();
        }

        public void UpdateProfessional(Professional professional)
        {
            dbContext.Professional.Update(professional);
            dbContext.SaveChanges();
        }

        public void DeleteProfessional(Professional professional)
        {
            dbContext.Professional.Remove(professional);
            dbContext.SaveChanges();
        }

        public bool VerifyProfessional(int it)
        {
            return dbContext.Professional.Any(c => c.Id == it);
        }

    }
}
