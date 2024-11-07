using AutoMapper;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components.DTOs;

namespace SalaoDeBeleza.Components.Mappings
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
