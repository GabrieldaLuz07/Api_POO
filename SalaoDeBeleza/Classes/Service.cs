using SalaoDeBeleza.Enums;

namespace SalaoDeBeleza.Classes
{
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
 