using SalaoDeBeleza.Exceptions;
using SalaoDeBeleza.DTOs;
using SalaoDeBeleza.Enums;

namespace SalaoDeBeleza.Validate
{
    // Validar todos os campos do dto
    public class ProfessionalValidate
    {
        public ProfessionalValidate() { }

        public void ValidateProfessional(ProfessionalDTO professionalDTO)
        {
            if (professionalDTO == null)
            {
                throw new Exception("Profissional inválido!");
            }

            if (string.IsNullOrWhiteSpace(professionalDTO.Name))
            {
                throw new DataValidationException("O nome do profissional é obrigatório!");
            }

            if (string.IsNullOrWhiteSpace(professionalDTO.Telephone))
            {
                throw new DataValidationException("O telefone do cliente é obrigatório!");
            }

            if (professionalDTO.Telephone.Length < 8 || professionalDTO.Telephone.Length > 13)
            {
                throw new DataValidationException("O número de telefone é inválido!");
            }
        }

    }
}
