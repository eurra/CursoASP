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
        public int ServicioID { get; set; }
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
        public Servicio Servicio { get; set; }
        public EstadoVentaServicio EstadoVentaServicio { get; set; }
        public int TotalVenta {  get; set; }
        public int TotalPagado { get; set; }
    }
}
