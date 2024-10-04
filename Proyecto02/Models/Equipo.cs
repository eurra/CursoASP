using System.ComponentModel.DataAnnotations;

namespace Proyecto02.Models
{
    public class Equipo
    {
        public ModeloEquipo Modelo { get; }
        public int Precio { get; set; }

        public Equipo(ModeloEquipo modelo, int precio)
        {
            Modelo = modelo;
            Precio = precio;
        }
    }
}
