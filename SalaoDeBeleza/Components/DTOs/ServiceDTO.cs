using SalaoDeBeleza.Classes;

namespace SalaoDeBeleza.Components.DTOs
{
    public class ServiceDTO
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Professional Professional { get; set; }
        public decimal Price { get; set; }
    }
}
