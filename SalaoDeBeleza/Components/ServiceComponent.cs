using AutoMapper;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components.DTOs;
using SalaoDeBeleza.Components.Mappings;
using SalaoDeBeleza.DataBase;

namespace SalaoDeBeleza.Components
{
    public class ServiceComponent
    {
        private readonly DBContextInMemory dbContext;
        private readonly IMapper mapper;
        public ServiceComponent(DBContextInMemory db)
        {
            dbContext = db;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ServiceMapper>();
            });
            mapper = config.CreateMapper();
        }

        public List<Service> getServices()
        {
            return dbContext.Service.ToList();
        }

        public ServiceDTO Insert(ServiceDTO dto)
        {
            Service service = mapper.Map<Service>(dto);
            dbContext.Service.Add(service);
            dbContext.SaveChanges();
            return dto;
        }
    }
}
