using ejercicio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;

namespace ejercicio.Pages.Funcionarios
{
    public class IndexModel : PageModel
    {
        public List<Funcionario> Lista { get; set; } = [];

        private readonly IMemoryCache _cache;

        [ActivatorUtilitiesConstructor]
        public IndexModel(IMemoryCache cache)
        {
            _cache = cache;
        }

        private void ActualizarLista()
        {
            Lista = _cache.GetOrCreate<List<Funcionario>>("Lista", e =>
            {
                return [];
            });

            if (Cantidad == 0)
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
            }
        }

        public int Cantidad { get => Lista.Count(); }

        public void OnGet()
        {
            ActualizarLista();
        }

        public void OnGetEliminarFuncionario(string rut)
        {
            ActualizarLista();

            Funcionario found = (from func in Lista where func.RUT == rut select func).First();
            Lista.Remove(found);
        }

        public void OnGetAjustarGrado(string rut, int grado)
        {
            ActualizarLista();
            Funcionario found = (from func in Lista where func.RUT == rut select func).First();
            found.Grado = grado;
        }
    }
}
