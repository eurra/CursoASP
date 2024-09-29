using ejercicio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Win32;
using Proyecto01.Models;

namespace ejercicio.Pages.Funcionarios
{
    public class IndexModel : PageModel
    {
        private readonly IRegistroFuncionarios _registro;
        public List<Funcionario> Lista { get; set; }

        [ActivatorUtilitiesConstructor]
        public IndexModel(IRegistroFuncionarios registro)
        {
            _registro = registro;
        }

        public void OnGet()
        {
            Lista = _registro.ObtenerFuncionarios();
        }

        public void OnGetEliminarFuncionario(string rut)
        {
            _registro.EliminarFuncionario(rut);
            Lista = _registro.ObtenerFuncionarios();
        }
    }
}
