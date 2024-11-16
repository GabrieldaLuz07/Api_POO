using AutoMapper;
using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Exceptions;
using SalaoDeBeleza.DataBase;
using SalaoDeBeleza.DTOs;
using SalaoDeBeleza.Mappings;
using SalaoDeBeleza.Repositories;
using SalaoDeBeleza.Validate;

namespace SalaoDeBeleza.Components
{
    public class CustomerComponent
    {
        private CustomerRepository repository;
        private readonly IMapper mapper;
        private CustomerValidate validator;

        public CustomerComponent(DBContextInMemory db)
        {
            // Inicializo as instâncias que vou utilizar
            repository = new CustomerRepository(db);
            validator = new CustomerValidate();

            // Faço a instância do mapper
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CustomerMapper>();
            });
            // Validação do mapper
            config.AssertConfigurationIsValid();
            mapper = config.CreateMapper();
        }

         // Função para verificar se existe um registro com o id informado, para não ter que buscar toda vez e verificar se esta diferente de null
         public bool CustomerExists(int id)
         {
            return repository.VerifyCustomer(id);
         }

         // Função retornando toda a lista de clientes
         public List<Customer> GetAll()
         {
             return repository.GetAllCustomers();
         }

         // Buscando pelo id, validando caso o id seja menor ou igual a 0. Caso não encontre o cliente pelo id informado, uma exception sera disparada.
         // Busquei fazer essa função básica e simplificada para usar nas outras funções.
         public Customer GetById(int id)
         {
             if (id <= 0)
                 throw new Exception("Cliente inválido!");

             return CustomerExists(id) ? repository.GetCustomerById(id) : throw new Exception("Cliente não encontrado!");
         }

         // Insert, validando antes de registrar, mapeando para a classe e depois adicionando.
         public CustomerDTO Insert(CustomerDTO dto)
         {
             validator.ValidateCustomer(dto);

             Customer customer = new Customer();
             customer = mapper.Map<Customer>(dto);
             repository.AddCustomer(customer);
             return dto;
         }

         // Update, validando antes de atualizar, buscando o cliente, atribuindo os valores do DTO para a classe e depois atualizando.
         public void Update(int id, CustomerDTO dto)
         {
            validator.ValidateCustomer(dto);

            Customer customer = repository.GetCustomerById(id);
            customer.Name = dto.Name;
            customer.Telephone = dto.Telephone;
            customer.Email = dto.Email;

            repository.UpdateCustomer(customer);
         }

         // Delete, buscando o cliente pelo id antes de excluir
         public void Delete(int id)
         {
             Customer customer = repository.GetCustomerById(id);
             repository.DeleteCustomer(customer);
         }

    }
}
