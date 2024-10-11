using System.ComponentModel.DataAnnotations;

namespace Proyecto03.Models
{
    public enum TipoCliente
    {
        [Display(Name = "Persona natural")]
        PersonaNatural,
        [Display(Name = "Persona jurídica")]
        PersonaJuridica
    }
    public class Cliente
    {
        [Display(Name = "ID Cliente")]
        public int ClienteID { get; set; }
        public string RUT { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get => RUT + ": " + Nombre; }
        [Display(Name = "Tipo de cliente")]
        public TipoCliente TipoCliente { get; set; }
        public ICollection<Representante> Representantes { get; set; }
    }
}
