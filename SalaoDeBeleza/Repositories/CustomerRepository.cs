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

        public List<Customer> GetAllCustomers()
        {
            return dbContext.Customer.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            return dbContext.Customer.FirstOrDefault(c => c.Id == id);
        }

        public void AddCustomer(Customer customer)
        {
            dbContext.Customer.Add(customer);
            dbContext.SaveChanges();
        }

        public void UpdateCustomer(Customer customer)
        {
            dbContext.Customer.Update(customer);
            dbContext.SaveChanges();
        }

        public void DeleteCustomer(Customer customer)
        {
            dbContext.Customer.Remove(customer);
            dbContext.SaveChanges();
        }

        public bool VerifyCustomer(int it)
        {
            return dbContext.Customer.Any(c => c.Id == it);
        }
        
    }
}
