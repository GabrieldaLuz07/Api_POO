using SalaoDeBeleza.Classes;

namespace SalaoDeBeleza.Interfaces
{
    // Interface contendo todos os métodos padrões para manipulação das tabelas do banco
    public interface IServiceRepository
    {
        List<Service> GetAllServices();
        Service GetServiceById(int id);
        void AddService(Service service);
        void UpdateService(Service service);
        void DeleteService(Service service);
    }
}
