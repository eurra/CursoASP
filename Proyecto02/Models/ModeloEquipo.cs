namespace Proyecto02.Models
{
    public class ModeloEquipo
    {
        public TipoEquipo Tipo { get; }
        public string Nombre { get; }

        public ModeloEquipo(TipoEquipo tipo, string modelo)
        {
            Tipo = tipo;
            Nombre = modelo;
        }
    }
}
