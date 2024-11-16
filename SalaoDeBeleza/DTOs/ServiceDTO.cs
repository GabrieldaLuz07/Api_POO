using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Enums;

namespace SalaoDeBeleza.DTOs
{
    // DTO criado para inserir serviços
    public class ServiceDTO
    {
        public int IdCustomer { get; set; }
        public int IdProfessional { get; set; }
        public ServiceType Type {  get; set; }
    }
}
