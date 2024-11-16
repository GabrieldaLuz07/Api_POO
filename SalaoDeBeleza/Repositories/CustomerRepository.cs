using SalaoDeBeleza.Classes;
using SalaoDeBeleza.DataBase;
using SalaoDeBeleza.Interfaces;
using System.Collections.Immutable;

namespace SalaoDeBeleza.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DBContextInMemory dbContext;
        public CustomerRepository(DBContextInMemory db)
        {
            dbContext = db;
        }

        // Buscar todos os clientes do banco
        public List<Customer> GetAllCustomers()
        {
            return dbContext.Customer.ToList();
        }

        // Buscar um cliente do banco com base no seu Id
        public Customer GetCustomerById(int id)
        {
            return dbContext.Customer.FirstOrDefault(c => c.Id == id);
        }

        // Cadastrar um novo cliente
        public void AddCustomer(Customer customer)
        {
            dbContext.Customer.Add(customer);
            dbContext.SaveChanges();
        }

        // Atualizar um cliente existente
        public void UpdateCustomer(Customer customer)
        {
            dbContext.Customer.Update(customer);
            dbContext.SaveChanges();
        }

        // Excluír um cliente existente
        public void DeleteCustomer(Customer customer)
        {
            dbContext.Customer.Remove(customer);
            dbContext.SaveChanges();
        }

        // Verificar se existe um cliente cadastrado com o Id passado no parâmetro
        public bool VerifyCustomer(int it)
        {
            return dbContext.Customer.Any(c => c.Id == it);
        }
        
    }
}
