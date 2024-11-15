using System.ComponentModel;

namespace SalaoDeBeleza.Enums
{
    public enum ServiceType
    {
        [Description("Cabelo")]
        OptionZero = 0,

        [Description("Maquiagem")]
        OptionOne = 1,

        [Description("Unha")]
        OptionTwo = 2,

        [Description("Sobrancelha")]
        OptionThree = 3
    }
}
