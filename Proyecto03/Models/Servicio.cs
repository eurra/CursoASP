using System.ComponentModel.DataAnnotations;

namespace Proyecto03.Models
{
    public class Servicio
    {
        public int ServicioID { get; set; }
        public int CategoriaServicioID { get; set; }
        [Display(Name = "Categoría")]
        public CategoriaServicio? CategoriaServicio { get; set; }
        public string Descripcion { get; set; }
    }
}
