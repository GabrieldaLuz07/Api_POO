using SalaoDeBeleza.Classes;
using SalaoDeBeleza.Enums;

namespace SalaoDeBeleza.DTOs
{
    public class ServiceDisplayDTO
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Professional Professional { get; set; }
        public string Type { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }
        public string Duration { get; set; }

        public ServiceDisplayDTO() { }
    }
}
