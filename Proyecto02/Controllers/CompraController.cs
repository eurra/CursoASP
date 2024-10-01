using Microsoft.AspNetCore.Mvc;
using Proyecto02.Models;

namespace Proyecto02.Controllers
{
    public class CompraController : Controller
    {
        // GET: /Compra/AccionPrueba/
        public string AccionPrueba()
        {
            return "Prueba controlador";
        }

        // GET: /Compra/
        public IActionResult Index()
        {
            return View();
        }        

        // GET: /Compra/SeleccionEquipo/
        public IActionResult SeleccionEquipo()
        {
            ViewData["Paso"] = "Paso I - Selección de equipo";
            return View();
        }

        // GET: /Compra/SeleccionModelo/
        public IActionResult SeleccionModelo(string equipo = "Equipo NN")
        {
            ViewData["Paso"] = "Paso II - Selección de modelo";
            ViewData["Equipo"] = equipo;

            return View();
        }

        // GET: /Compra/Confirmacion/
        public IActionResult Confirmacion(int precio, string modelo = "Modelo NN")
        {
            var equipo = new Equipo(
                new ModeloEquipo(TipoEquipo.Dosimetro, modelo),
                precio
            );

            ViewData["Paso"] = "Paso III - Confirmación compra";
            ViewData["Equipo"] = equipo.Modelo.Tipo;
            ViewData["Modelo"] = equipo.Modelo.Nombre;

            return View(equipo);
        }
    }
}
