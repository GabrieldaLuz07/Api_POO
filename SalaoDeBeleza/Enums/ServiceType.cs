using System.ComponentModel;
using System.Reflection;

namespace SalaoDeBeleza.Enums
{
    // Enum criado pensando em ter um melhor controle na hora de manipular essa propriedade
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

    // Classe para retornar todos os enums cadastrados
    public class ServiceTypeHelper
    {
        public static List<string> GetDescriptions<TEnum>() where TEnum : Enum
        {
            var type = typeof(TEnum);
            var descriptions = new List<string>();

            foreach (var value in Enum.GetValues(type))
            {
                var info = type.GetField(value.ToString());
                var attribute = info.GetCustomAttribute<DescriptionAttribute>();
                descriptions.Add(attribute.Description);
            }

            return descriptions;
        }
    }
}
