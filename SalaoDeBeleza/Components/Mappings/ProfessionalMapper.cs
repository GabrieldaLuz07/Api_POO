using AutoMapper;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components.DTOs;

namespace SalaoDeBeleza.Components.Mappings
{
    public class ProfessionalMapper : Profile
    {
        public ProfessionalMapper()
        {
            CreateMap<Professional, ProfessionalDTO>().ReverseMap();
        }
    }
}
