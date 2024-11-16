using SalaoDeBeleza.Enums;

namespace SalaoDeBeleza.Classes
{

    // Classe Profissional, contendo apenas as informações básicas e necessárias
    public class Professional
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Telephone { get; set; }
        public bool Available { get; set; }

        public Professional() { }

    }
}
