using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proyecto03.Data;
using Proyecto03.Models;

namespace Proyecto03.Controllers
{
    public class ItemReporte
    {
        public string RUTCliente { get; set; }
        public string Categoria { get; set; }
    }

    public class VentaServiciosController : Controller
    {
        private readonly ServiciosContext _context;

        public VentaServiciosController(ServiciosContext context)
        {
            _context = context;
        }

        // GET: VentaServicios
        public async Task<IActionResult> Index()
        {
            var serviciosContext = _context.VentaServicios.
                Include(v => v.Cliente).
                Include(v => v.Servicio).
                Include(v => v.Servicio.CategoriaServicio);

            return View(await serviciosContext.ToListAsync());
        }

        // GET: VentaServicios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaServicio = await _context.VentaServicios
                .Include(v => v.Cliente)
                .Include(v => v.Servicio)
                .Include(v => v.Cliente.Representantes)
                .FirstOrDefaultAsync(m => m.VentaServicioID == id);
            if (ventaServicio == null)
            {
                return NotFound();
            }

            return View(ventaServicio);
        }

        // GET: VentaServicios/Create
        public IActionResult Create()
        {
            var servicios = new List<SelectListItem>();

            foreach (var servicio in _context.Servicios)
            {
                var item = new SelectListItem();
                item.Value = servicio.ServicioID.ToString();
                item.Text = servicio.ServicioID + " - " + servicio.Descripcion;
                servicios.Add(item);
            }

            //ViewData["ServicioID"] = new SelectList(_context.Servicios, "ServicioID", "Descripcion");
            ViewData["ServicioID"] = new SelectList(servicios, "Value", "Text");
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ClienteID", "Descripcion");
            
            return View();
        }

        // POST: VentaServicios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VentaServicioID,ServicioID,ClienteID,EstadoVentaServicio,TotalVenta,TotalPagado")] VentaServicio ventaServicio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ventaServicio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ClienteID", "ClienteID", ventaServicio.ClienteID);
            ViewData["ServicioID"] = new SelectList(_context.Servicios, "ServicioID", "ServicioID", ventaServicio.ServicioID);
            return View(ventaServicio);
        }

        // GET: VentaServicios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaServicio = await _context.VentaServicios.FindAsync(id);

            if (ventaServicio == null)
            {
                return NotFound();
            }

            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ClienteID", "RUT", ventaServicio.ClienteID);
            ViewData["ServicioID"] = new SelectList(_context.Servicios, "ServicioID", "Descripcion", ventaServicio.ServicioID);
            return View(ventaServicio);
        }

        // POST: VentaServicios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VentaServicioID,ServicioID,ClienteID,EstadoVentaServicio,TotalVenta,TotalPagado")] VentaServicio ventaServicio)
        {
            if (id != ventaServicio.VentaServicioID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ventaServicio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaServicioExists(ventaServicio.VentaServicioID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteID"] = new SelectList(_context.Clientes, "ClienteID", "ClienteID", ventaServicio.ClienteID);
            ViewData["ServicioID"] = new SelectList(_context.Servicios, "ServicioID", "ServicioID", ventaServicio.ServicioID);
            return View(ventaServicio);
        }

        // GET: VentaServicios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ventaServicio = await _context.VentaServicios
                .Include(v => v.Cliente)
                .Include(v => v.Servicio)
                .FirstOrDefaultAsync(m => m.VentaServicioID == id);
            if (ventaServicio == null)
            {
                return NotFound();
            }

            return View(ventaServicio);
        }

        // POST: VentaServicios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ventaServicio = await _context.VentaServicios.FindAsync(id);
            if (ventaServicio != null)
            {
                _context.VentaServicios.Remove(ventaServicio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VentaServicioExists(int id)
        {
            return _context.VentaServicios.Any(e => e.VentaServicioID == id);
        }

        public async Task<IActionResult> GenerarReporte()
        {
            var servicios = await _context.VentaServicios.
                Include(v => v.Servicio).
                Include(v => v.Servicio.CategoriaServicio).ToListAsync();

            /* Versión simple - solo listado
            ViewData["TipoReporte"] = 1;

            var reporte = from cliente in _context.Clientes
                          join venta in _context.VentaServicios on cliente.ClienteID equals venta.ClienteID
                          select new
                          {
                              RUTCliente = cliente.RUT,
                              Categoria = venta.Servicio.CategoriaServicio.Nombre
                          };
            */

            /* Versión agrupada - listado por cliente
            ViewData["TipoReporte"] = 2;

            var reporte = from cliente in _context.Clientes
                          join venta in _context.VentaServicios on cliente.ClienteID equals venta.ClienteID into ventasGroup
                          select new
                          {
                              RUTCliente = cliente.RUT,
                              Ventas = ventasGroup
                          };

            return View(await reporte.ToListAsync());
            */

            ViewData["TipoReporte"] = 3;

            var reporteIndex = (from cliente in _context.Clientes
                          join venta in _context.VentaServicios on cliente.ClienteID equals venta.ClienteID
                          select new
                          {
                              ClienteID = cliente.ClienteID,
                              RUT = cliente.RUT,
                              CategoriaServicioID = venta.Servicio.CategoriaServicio.CategoriaServicioID,
                              Categoria = venta.Servicio.CategoriaServicio.Nombre
                          }).Distinct().ToList();

            var reporte = from fila in reporteIndex
                          join venta in _context.VentaServicios 
                          on new { fila.ClienteID, fila.CategoriaServicioID } equals new { venta.ClienteID, venta.Servicio.CategoriaServicio.CategoriaServicioID } 
                          into ventasGroup
                          select new
                          {
                              RUT = fila.RUT,
                              Categoria = fila.Categoria,
                              TotalVentas = ventasGroup.Count(),
                              MontoVentas = ventasGroup.Sum(v => v.TotalVenta)
                          };

            return View(reporte.ToList());
        }
    }
}
