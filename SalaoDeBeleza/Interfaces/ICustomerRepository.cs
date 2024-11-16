using SalaoDeBeleza.Classes;

namespace SalaoDeBeleza.Interfaces
{
    // Interface contendo todos os métodos padrões para manipulação das tabelas do banco
    public interface ICustomerRepository
    {
        List<Customer> GetAllCustomers();
        Customer GetCustomerById(int id);
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
    }
}
