using SalaoDeBeleza.Enums;

namespace SalaoDeBeleza.Classes
{
    // Classe serviço, contendo o cliente e profissional envolvidos no serviço. 2 Enums para tipo do serviço e status do servico. Preco e duração do serviço também
    public class Service
    {
        public int Id { get; set; }
        public int IdCustomer { get; set; }
        public int IdProfessional { get; set; }
        public ServiceType Type {  get; set; }
        public decimal Price { get; set; }
        public ServiceStatus Status { get; set; }
        public long Duration { get; set; }

        public Service() { }

    }
}
 