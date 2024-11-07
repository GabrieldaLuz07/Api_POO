using AutoMapper;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components.DTOs;

namespace SalaoDeBeleza.Components.Mappings
{
    public class ServiceMapper : Profile
    {
        public ServiceMapper()
        {
            CreateMap<Service, ServiceDTO>().ReverseMap();
        }
    }
}
