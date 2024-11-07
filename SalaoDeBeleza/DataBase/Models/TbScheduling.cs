using SalaoDeBeleza.Classes;

namespace SalaoDeBeleza.DataBase.Modelos
{
    public partial class TbScheduling
    {
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Service Service { get; set; }
        public Professional Professional { get; set; }
        public DateTime Time { get; set; }
    }
}
