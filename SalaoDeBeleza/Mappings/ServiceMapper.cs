using AutoMapper;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.DTOs;

namespace SalaoDeBeleza.Mappings
{
    public class ServiceMapper : Profile
    {
        public ServiceMapper()
        {
            CreateMap<Service, ServiceFinishDTO>().ReverseMap();
        }
    }
}
