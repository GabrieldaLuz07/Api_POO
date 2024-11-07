using AutoMapper;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Components.DTOs;
using SalaoDeBeleza.Components.Mappings;
using SalaoDeBeleza.DataBase;

namespace SalaoDeBeleza.Components
{
    public class CustomerComponent
    {
        private readonly DBContextInMemory dbContext;
        private readonly IMapper mapper;
        public CustomerComponent(DBContextInMemory db)
        {
            dbContext = db;
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomerMapper>();
            });
            mapper = config.CreateMapper();
        }

        public List<Customer> getCustomers()
        {
            return dbContext.Customer.ToList();
        }

        public CustomerDTO Insert(CustomerDTO dto)
        {
            Customer customer = mapper.Map<Customer>(dto);
            dbContext.Customer.Add(customer);
            dbContext.SaveChanges();
            return dto;
        }
    }
}
