using ejercicio.Models;
using Microsoft.Extensions.Caching.Memory;

namespace Proyecto01.Models
{
    public class RegistroFuncionariosCache : IRegistroFuncionarios
    {
        private List<Funcionario> Lista { get; set; } = [];
        public int Cantidad { get => ObtenerFuncionarios().Count; }        

        [ActivatorUtilitiesConstructor]
        public RegistroFuncionariosCache(IMemoryCache cache)
        {
            Lista = cache.GetOrCreate<List<Funcionario>>("Lista", e =>
            {
                return [];
            });

            ActualizarLista();
        }

        private void ActualizarLista()
        {
            if (Lista.Count == 0)
            {
                Lista.AddRange([
                    new Funcionario("1.234.567-8", Estamento.Investigador)
                    {
                        Grado = 6,
                        Antiguedad = 6
                    },
                    new Funcionario("6.624.954-5", Estamento.Directivo)
                    {
                        Grado = 2,
                        Antiguedad = 10
                    },
                    new Funcionario("16.549.354-K", Estamento.Administrativo)
                    {
                        Grado = 10,
                        Antiguedad = 2
                    }
                ]);
            };
        }

        public List<Funcionario> ObtenerFuncionarios()
        {
            return new (Lista);
        }

        public Funcionario BuscarFuncionario(string rut)
        {
            Funcionario found = (from func in Lista where func.RUT == rut select func).First();
            return found;
        }

        public void EliminarFuncionario(string rut)
        {
            Funcionario elim = BuscarFuncionario(rut);            
            Lista.Remove(elim);
            ActualizarLista();
        }

        public void AgregarFuncionario(Funcionario funcionario)
        {
            Lista.Add(funcionario);
        }
    }
}
