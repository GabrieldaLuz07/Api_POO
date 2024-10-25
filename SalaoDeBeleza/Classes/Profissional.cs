namespace SalaoDeBeleza.Classes
{
    public class Profissional
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Especialidade { get; set; }
        public bool Disponivel { get; set; }

        public Profissional(string nome, string especialidade, bool disponivel)
        {
            Nome = nome;
            Especialidade = especialidade;
            Disponivel = disponivel;
        }
    }
}
