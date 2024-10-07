namespace Proyecto02.Models
{
    public interface IMantenedorCompras
    {
        List<Equipo> ObtenerCompras();
        string[] ObtenerModelosPara(TipoEquipo tipo);
        Equipo AgregarCompra(ModeloEquipo modelo, int precio);
        Equipo EliminarCompra(int id);
    }
}
