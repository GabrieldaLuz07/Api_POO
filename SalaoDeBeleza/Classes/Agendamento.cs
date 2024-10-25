namespace SalaoDeBeleza.Classes
{
    public class Agendamento
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Servico Servico { get; set; }
        public Profissional Profissional { get; set; }
        public DateTime Horario { get; set; }

        public Agendamento(Cliente cliente, Servico servico, Profissional profissional, DateTime horario)
        {
            this.Cliente = cliente;
            this.Servico = servico;
            this.Profissional = profissional;
            this.Horario = horario;
        }
    }
}
