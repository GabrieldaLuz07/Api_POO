namespace SalaoDeBeleza.Classes
{
    public class Professional
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }
        public bool Available { get; set; }

        public Professional() { }

        public Professional(string nome, string specialty, bool available)
        {
            Name = nome;
            Specialty = specialty;
            Available = available;
        }
    }
}
