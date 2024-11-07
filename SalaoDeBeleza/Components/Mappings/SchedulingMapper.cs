using AutoMapper;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components.DTOs;
using SalaoDeBeleza.DataBase.Modelos;

namespace SalaoDeBeleza.Components.Mappings
{
    public class SchedulingMapper : Profile
    {
        public SchedulingMapper()
        {
            CreateMap<Scheduling, SchedulingDTO>().ReverseMap();
        }
    }
}
