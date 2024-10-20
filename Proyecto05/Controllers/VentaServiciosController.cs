using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto03.Data;
using Proyecto03.Models;

namespace Proyecto05.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaServiciosController : ControllerBase
    {
        private readonly ServiciosContext _context;

        public VentaServiciosController(ServiciosContext context)
        {
            _context = context;
        }

        // GET: api/VentaServicios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<VentaServicio>>> GetVentaServicios()
        {
            return await _context.VentaServicios.ToListAsync();
        }

        // GET: api/VentaServicios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<VentaServicio>> GetVentaServicio(int id)
        {
            var ventaServicio = await _context.VentaServicios.FindAsync(id);

            if (ventaServicio == null)
            {
                return NotFound();
            }

            return ventaServicio;
        }

        // PUT: api/VentaServicios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVentaServicio(int id, VentaServicio ventaServicio)
        {
            if (id != ventaServicio.VentaServicioID)
            {
                return BadRequest();
            }

            _context.Entry(ventaServicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaServicioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/VentaServicios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<VentaServicio>> PostVentaServicio(VentaServicio ventaServicio)
        {
            _context.VentaServicios.Add(ventaServicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVentaServicio", new { id = ventaServicio.VentaServicioID }, ventaServicio);
        }

        // DELETE: api/VentaServicios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVentaServicio(int id)
        {
            var ventaServicio = await _context.VentaServicios.FindAsync(id);
            if (ventaServicio == null)
            {
                return NotFound();
            }

            _context.VentaServicios.Remove(ventaServicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchVentaServicio(int id, [FromBody] JsonPatchDocument<VentaServicio> patchDoc)
        {
            if (ModelState.IsValid && patchDoc != null)
            {
                var ventaServicio = await _context.VentaServicios.FindAsync(id);

                if (ventaServicio == null)
                {
                    return NotFound();
                }

                patchDoc.ApplyTo(ventaServicio, ModelState);
                _context.Entry(ventaServicio).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                    return new ObjectResult(ventaServicio);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VentaServicioExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        private bool VentaServicioExists(int id)
        {
            return _context.VentaServicios.Any(e => e.VentaServicioID == id);
        }
    }
}
