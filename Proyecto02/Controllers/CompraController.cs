using Microsoft.AspNetCore.Mvc;
using Proyecto02.Models;

namespace Proyecto02.Controllers
{
    public class CompraController : Controller
    {
        private IMantenedorCompras _mantenedor;

        public CompraController(IMantenedorCompras mantenedor)
        {
            _mantenedor = mantenedor;
        }

        // GET: /Compra/AccionPrueba/
        public string AccionPrueba()
        {
            return "Prueba controlador";
        }

        // GET: /Compra/
        public IActionResult Index()
        {
            return View(_mantenedor);
        }        

        // GET: /Compra/SeleccionEquipo/
        public IActionResult SeleccionEquipo()
        {
            ViewData["Paso"] = "Paso I - Selección de equipo";
            return View();
        }

        // GET: /Compra/SeleccionModelo/
        [HttpGet]
        public string SeleccionModelo()
        {
            return "Acceso restringido";
        }

        // POST: /Compra/SeleccionModelo/
        [HttpPost]
        public IActionResult SeleccionModelo(int tipo)
        {
            ViewData["Paso"] = "Paso II - Selección de modelo";
            ViewData["Tipo"] = tipo;

            return View(_mantenedor);
        }

        // GET: /Compra/SeleccionModelo/
        [HttpGet]
        public string Confirmacion()
        {
            return "Acceso restringido";
        }

        private Equipo GenerarInstanciaEquipo(int tipo, int precio, int modelo)
        {
            TipoEquipo tipoE = (TipoEquipo)tipo;
            string modeloT = _mantenedor.ObtenerModelosPara(tipoE)[modelo];

            return new Equipo(
                new ModeloEquipo(tipoE, modeloT),
                precio
            );
        }

        [HttpPost]
        public IActionResult Confirmacion(int tipo, int precio, int modelo)
        {
            var equipo = GenerarInstanciaEquipo(tipo, precio, modelo);

            ViewData["Paso"] = "Paso III - Confirmación compra";
            ViewData["ModeloNum"] = modelo;

            return View(equipo);
        }

        public IActionResult AgregarCompra(int tipo, int precio, int modelo)
        {
            var equipo = GenerarInstanciaEquipo(tipo, precio, modelo);
            _mantenedor.AgregarCompra(equipo);

            return RedirectToAction("Index");
        }
    }
}
