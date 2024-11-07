using SalaoDeBeleza.Classes;

namespace SalaoDeBeleza.Components.DTOs
{
    public class SchedulingDTO
    {
        public int Id { get; set; }
        public int idCustomer { get; set; }
        public int idService { get; set; }
        public int idProfessional { get; set; }
        public DateTime Time { get; set; }
    }
}
