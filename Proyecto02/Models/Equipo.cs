using System.ComponentModel.DataAnnotations;

namespace Proyecto02.Models
{
    public class Equipo
    {
        public int Id { get; set; }
        public ModeloEquipo Modelo { get; set; }
        [Range(100, Int32.MaxValue, ErrorMessage = "Debe ingresar un precio mayor o igual a 100.")]
        public int Precio { get; set; }
    }
}
