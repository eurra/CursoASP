namespace Proyecto03.Models
{
    public enum TipoCliente
    {
        PersonaNatural,
        PersonaJuridica
    }
    public class Cliente
    {
        public int ClienteID { get; set; }
        public string RUT { get; set; }
        public string Nombre { get; set; }
        public TipoCliente TipoCliente { get; set; }

        public ICollection<Representante> Representantes { get; set; }
    }
}
