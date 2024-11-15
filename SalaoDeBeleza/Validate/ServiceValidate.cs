using SalaoDeBeleza.Exceptions;
using SalaoDeBeleza.DTOs;
using SalaoDeBeleza.Enums;

namespace SalaoDeBeleza.Validate
{
    public class ServiceValidate
    {
        public ServiceValidate() { }

        public void ValidateService(ServiceDTO serviceDTO)
        {
            if (serviceDTO == null)
            {
                throw new Exception("Serviço inválido!");
            }

            if (serviceDTO.IdCustomer <= 0)
            {
                throw new DataValidationException("ID do cliente é obrigatório e deve ser válido!");
            }

            if (serviceDTO.IdProfessional <= 0)
            {
                throw new DataValidationException("ID do profissional é obrigatório e deve ser válido!");
            }

            if (!Enum.IsDefined(typeof(ServiceType), serviceDTO.Type))
            {
                throw new DataValidationException("Tipo de serviço inválido!");
            }
        }

        public void ValidateServiceUpdate(ServiceUpdateDTO updateDTO)
        {
            if (updateDTO.IdCustomer <= 0)
            {
                throw new DataValidationException("ID do cliente é obrigatório e deve ser válido!");
            }

            if (updateDTO.IdProfessional <= 0)
            {
                throw new DataValidationException("ID do profissional é obrigatório e deve ser válido!");
            }

            if (!Enum.IsDefined(typeof(ServiceType), updateDTO.Type))
            {
                throw new DataValidationException("Tipo de serviço inválido!");
            }

            if (updateDTO.Price <= 0)
            {
                throw new DataValidationException("O preço do serviço deve ser maior que zero!");
            }

            if (updateDTO.Duration <= 0)
            {
                throw new DataValidationException("A duração do serviço deve ser maior que zero!");
            }
        }

        public void ValidateServiceFinish(ServiceFinishDTO finishDTO)
        {
            if (finishDTO.Price <= 0)
            {
                throw new DataValidationException("O preço do serviço deve ser maior que zero!");
            }

            if (finishDTO.Duration <= 0)
            {
                throw new DataValidationException("A duração do serviço deve ser maior que zero!");
            }
        }
    }
}
