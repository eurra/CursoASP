using ejercicio.Models;

namespace Proyecto01.Models
{
    public interface IRegistroFuncionarios
    {
        List<Funcionario> ObtenerFuncionarios();
        int Cantidad { get; }
        Funcionario? BuscarFuncionario(string rut);
        void EliminarFuncionario(string rut);
        void AgregarFuncionario(Funcionario funcionario);
    }
}
