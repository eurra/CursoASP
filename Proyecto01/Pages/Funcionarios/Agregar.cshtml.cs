using ejercicio.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Proyecto01.Models;
using System;

namespace Proyecto01.Pages.Funcionarios
{
    public class AgregarModel : PageModel
    {
        private readonly IRegistroFuncionarios _registro;

        [ActivatorUtilitiesConstructor]
        public AgregarModel(IRegistroFuncionarios registro)
        {
            _registro = registro;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPostAgregar(string rut, int grado, int antig, int estamento)
        {
            Funcionario nuevo = new Funcionario(rut, (Estamento) estamento)
            {
                Grado = grado,
                Antiguedad = antig
            };

            _registro.AgregarFuncionario(nuevo);

            return RedirectToPage("/Funcionarios/Index");
        }
    }
}
