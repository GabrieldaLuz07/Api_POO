using SalaoDeBeleza.Classes;

namespace SalaoDeBeleza.Interfaces
{
    public interface IServiceRepository
    {
        List<Service> GetAllServices();
        Service GetServiceById(int id);
        void AddService(Service service);
        void UpdateService(Service service);
        void DeleteService(Service service);
    }
}
