using System.ComponentModel.DataAnnotations;

namespace Proyecto03.Models
{
    public enum EstadoVentaServicio
    {
        Evaluada,
        Cancelada,
        Iniciada,
        Completada
    }

    public class VentaServicio
    {
        public int VentaServicioID { get; set; }
        [Display(Name = "Servicio")]
        public int ServicioID { get; set; }
        [Display(Name = "Cliente")]
        public int ClienteID { get; set; }
        public Cliente? Cliente { get; set; }
        public Servicio? Servicio { get; set; }
        [Display(Name = "Estado de servicio")]
        public EstadoVentaServicio EstadoVentaServicio { get; set; }
        [Display(Name = "Total venta")]
        [DataType(DataType.Currency)]
        public int TotalVenta {  get; set; }
        [Display(Name = "Total pagado")]
        [DataType(DataType.Currency)]
        public int TotalPagado { get; set; }
    }
}
