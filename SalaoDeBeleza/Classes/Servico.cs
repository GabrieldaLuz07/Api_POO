namespace SalaoDeBeleza.Classes
{
    public class Servico
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public TimeSpan Duracao { get; set; }

        public Servico(string nome, decimal preco, TimeSpan duracao)
        {
            Nome = nome;
            Preco = preco;
            Duracao = duracao;
        }
    }
}
