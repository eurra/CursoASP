using System.ComponentModel;
using System.Reflection;

namespace Proyecto02.Models
{
    public enum TipoEquipo
    {
        [Description("Microscopio")]
        Microscopio = 0,

        [Description("Dosímetro")]
        Dosimetro = 1,

        [Description("Espectrómetro")]
        Espectrometro = 2
    }
    static class Extension
    {
        public static string Nombre(this TipoEquipo equipo)
        {
            return typeof(TipoEquipo).
                GetField(equipo.ToString()).
                GetCustomAttribute<DescriptionAttribute>(false).
                Description;
        }
    }
}
