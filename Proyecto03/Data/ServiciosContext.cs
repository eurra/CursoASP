using Microsoft.EntityFrameworkCore;
using Proyecto03.Models;

namespace Proyecto03.Data
{
    public class ServiciosContext : DbContext
    {
        public ServiciosContext(DbContextOptions<ServiciosContext> options) : base(options)
        {
        }

        public DbSet<CategoriaServicio> CategoriaServicios { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Representante> Representantes { get; set; }
        public DbSet<VentaServicio> VentaServicios { get; set; }
    }
}
