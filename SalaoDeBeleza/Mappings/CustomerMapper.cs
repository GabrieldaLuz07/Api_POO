using AutoMapper;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.DTOs;

namespace SalaoDeBeleza.Mappings
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
        }
    }
}
