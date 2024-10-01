using Microsoft.AspNetCore.Mvc;

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
        public string SeleccionEquipo()
        {
            return "Paso I: selección equipo.";
        }

        // GET: /Compra/SeleccionModelo/
        public string SeleccionModelo(string? nombre = "SIN NOMBRE")
        {
            return "Paso II: selección modelo para equipo : '" + nombre + "'";
        }

        // GET: /Compra/Confirmacion/
        public string Confirmación()
        {
            return "Paso III: selección modelo";
        }
    }
}
