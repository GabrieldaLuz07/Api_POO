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

        // Buscar todos os serviços do banco
        public List<Service> GetAllServices()
        {
            return dbContext.Service.ToList();
        }

        // Buscar um serviço do banco com base no seu Id
        public Service GetServiceById(int id)
        {
            return dbContext.Service.FirstOrDefault(s => s.Id == id);
        }

        // Cadastrar um novo serviço
        public void AddService(Service service)
        {
            dbContext.Service.Add(service);
            dbContext.SaveChanges();
        }

        // Atualizar um serviço existente
        public void UpdateService(Service service)
        {
            dbContext.Service.Update(service);
            dbContext.SaveChanges();
        }

        // Excluír um serviço existente
        public void DeleteService(Service service)
        {
            dbContext.Service.Remove(service);
            dbContext.SaveChanges();
        }

        // Verificar se existe um serviço cadastrado com o Id passado no parâmetro
        public bool VerifyService(int it)
        {
            return dbContext.Service.Any(c => c.Id == it);
        }
    }
}
