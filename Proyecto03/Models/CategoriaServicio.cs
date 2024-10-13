using System.ComponentModel.DataAnnotations;

namespace Proyecto03.Models
{
    public class CategoriaServicio
    {
        public int CategoriaServicioID { get; set; }
        public string? GrupoServicios { get; set; }
        public string Nombre { get; set; }
    }
}
