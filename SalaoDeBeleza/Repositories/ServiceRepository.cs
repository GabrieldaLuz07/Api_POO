using SalaoDeBeleza.Classes;
using SalaoDeBeleza.DataBase;
using SalaoDeBeleza.Interfaces;

namespace SalaoDeBeleza.Repositories
{
    public class ServiceRepository : IServiceRepository
    {
        private readonly DBContextInMemory dbContext;
        public ServiceRepository(DBContextInMemory db)
        {
            dbContext = db;
        }

        public List<Service> GetAllServices()
        {
            return dbContext.Service.ToList();
        }

        public Service GetServiceById(int id)
        {
            return dbContext.Service.FirstOrDefault(s => s.Id == id);
        }

        public void AddService(Service service)
        {
            dbContext.Service.Add(service);
            dbContext.SaveChanges();
        }

        public void UpdateService(Service service)
        {
            dbContext.Service.Update(service);
            dbContext.SaveChanges();
        }

        public void DeleteService(Service service)
        {
            dbContext.Service.Remove(service);
            dbContext.SaveChanges();
        }

        public bool VerifyService(int it)
        {
            return dbContext.Service.Any(c => c.Id == it);
        }
    }
}
