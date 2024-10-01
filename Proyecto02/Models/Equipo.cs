namespace Proyecto02.Models
{
    public class Equipo
    {
        public ModeloEquipo Modelo { get; }
        public int Precio { get; }

        public Equipo(ModeloEquipo modelo, int precio)
        {
            Modelo = modelo;
            Precio = precio;
        }
    }
}
