using Microsoft.AspNetCore.Mvc;
using Proyecto02.Models;
using System.Reflection;

namespace Proyecto02.Controllers
{
    public enum PasoWorkflow
    {
        SeleccionEquipo = 0,
        SeleccionModelo = 1,
        Confirmacion = 2,
        Agregar = 3
    }

    public class CompraController : Controller
    {
        private IMantenedorCompras _mantenedor;

        [BindProperty]
        public Equipo? Equipo { get; set; }

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

        [HttpPost]
        public IActionResult WorkflowCompra(PasoWorkflow paso)
        {
            switch (paso)
            {
                case PasoWorkflow.SeleccionEquipo: return SeleccionEquipo();
                case PasoWorkflow.SeleccionModelo: return SeleccionModelo();
                case PasoWorkflow.Confirmacion: return Confirmacion();
                case PasoWorkflow.Agregar: return AgregarCompra();
                default: return RedirectToAction("Index");
            }   
        }

        // GET: /Compra/SeleccionEquipo/
        public IActionResult SeleccionEquipo()
        {
            Equipo = new()
            {
                Modelo = new() { Nombre = "", Tipo = TipoEquipo.Microscopio },
                Precio = 100
            };

            ViewData["Paso"] = "Paso I - Selección de equipo";
            ViewData["Tipos"] = Enum.GetValues(typeof(TipoEquipo));

            return View("SeleccionEquipo", Equipo);
        }

        // POST: /Compra/SeleccionModelo/
        [HttpPost]
        public IActionResult SeleccionModelo()
        {
            List<string> modelos = new (
                _mantenedor.ObtenerModelosPara(Equipo.Modelo.Tipo)
            );

            ViewData["Paso"] = "Paso II - Selección de modelo";
            ViewData["Modelos"] = modelos;

            return View("SeleccionModelo", Equipo);
        }

        /*[HttpGet]
        public string Confirmacion()
        {
            return "Acceso restringido";
        }*/

        /*private ModeloEquipo GenerarInstanciaModelo(int tipo, int modelo)
        {
            TipoEquipo tipoE = (TipoEquipo)tipo;
            string modeloT = _mantenedor.ObtenerModelosPara(tipoE)[modelo];

            return new ModeloEquipo(tipoE, modeloT);
        }*/

        [HttpPost]
        public IActionResult Confirmacion()
        {
            if (!ModelState.IsValid)
            {
                return SeleccionModelo();
            }

            ViewData["Paso"] = "Paso III - Confirmación compra";
            return View("Confirmacion", Equipo);
        }

        [HttpPost]
        public IActionResult AgregarCompra()
        {
            _mantenedor.AgregarCompra(Equipo.Modelo, Equipo.Precio);
            return RedirectToAction("Index");
        }

        public IActionResult Eliminar(int id)
        {
            _mantenedor.EliminarCompra(id);
            return RedirectToAction("Index");
        }
    }
}
