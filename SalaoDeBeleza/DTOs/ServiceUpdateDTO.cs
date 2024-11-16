using SalaoDeBeleza.Enums;

namespace SalaoDeBeleza.DTOs
{
    // DTO criado para atualizar serviços existentes
    public class ServiceUpdateDTO
    {
        public int IdCustomer { get; set; }
        public int IdProfessional { get; set; }
        public ServiceType Type { get; set; }
        public decimal Price { get; set; }
    }
}
