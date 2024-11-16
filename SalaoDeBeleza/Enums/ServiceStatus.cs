using System.ComponentModel;

namespace SalaoDeBeleza.Enums
{
    // Enum criado pensando em ter um melhor controle na hora de manipular essa propriedade
    public enum ServiceStatus
    {
        [Description("Agendado")]
        OptionZero = 0,

        [Description("Finalizado")]
        OptionOne = 1
    }
}
