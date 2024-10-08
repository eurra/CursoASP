namespace Proyecto03.Models
{
    public class Representante
    {
        public int RepresentanteID { get; set; }
        public int ClienteID { get; set; }
        public Cliente Cliente { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
    }
}
