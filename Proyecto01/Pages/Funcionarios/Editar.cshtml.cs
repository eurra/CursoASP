using ejercicio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Caching.Memory;
using Proyecto01.Models;
using System;

namespace Proyecto01.Pages.Funcionarios
{
    public class EditarModel : PageModel
    {
        public Funcionario Func { get; set; }

        private readonly IRegistroFuncionarios _registro;

        [ActivatorUtilitiesConstructor]
        public EditarModel(IRegistroFuncionarios registro)
        {
            _registro = registro;
        }

        public void OnGet(string rut)
        {
            Func = _registro.BuscarFuncionario(rut);
        }

        public IActionResult OnPostModificar(string rut, int grado, int antig)
        {
            Func = _registro.BuscarFuncionario(rut);
            Func.Grado = grado;
            Func.Antiguedad = antig;

            return RedirectToPage("/Funcionarios/Index");
        }
    }
}
