using SalaoDeBeleza.Exceptions;
using SalaoDeBeleza.DTOs;

namespace SalaoDeBeleza.Validate
{
    public class CustomerValidate
    {
        public CustomerValidate() { }

        public void ValidateCustomer(CustomerDTO customerDTO)
        {
            if (customerDTO == null)
            {
                throw new Exception("Cliente inválido!");
            }

            if (string.IsNullOrWhiteSpace(customerDTO.Name))
            {
                throw new DataValidationException("O nome do cliente é obrigatório!");
            }

            if (string.IsNullOrWhiteSpace(customerDTO.Email))
            {
                throw new DataValidationException("O email do cliente é obrigatório!");
            }

            if (string.IsNullOrWhiteSpace(customerDTO.Telephone))
            {
                throw new DataValidationException("O telefone do cliente é obrigatório!");
            }

            if (customerDTO.Telephone.Length < 8 || customerDTO.Telephone.Length > 13)
            {
                throw new DataValidationException("O número de telefone é inválido!");
            }

        }

    }
}
