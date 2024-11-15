using AutoMapper;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.DTOs;

namespace SalaoDeBeleza.Mappings
{
    public class ProfessionalMapper : Profile
    {
        public ProfessionalMapper()
        {
            CreateMap<Professional, ProfessionalDTO>().ReverseMap();
        }
    }
}
