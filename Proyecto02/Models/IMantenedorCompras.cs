namespace Proyecto02.Models
{
    public interface IMantenedorCompras
    {
        List<Equipo> ObtenerCompras();
        string[] ObtenerModelosPara(TipoEquipo tipo);
        void AgregarCompra(Equipo compra);
    }
}
