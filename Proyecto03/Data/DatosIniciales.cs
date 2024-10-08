using Proyecto03.Models;

namespace Proyecto03.Data
{
    public class DatosIniciales
    {
        public static void GenerarDatos(ServiciosContext context)
        {
            if (context.Servicios.Any())
            {
                return;
            }

            var categorias = new CategoriaServicio[]
            {
                new CategoriaServicio { Nombre = "PIM", GrupoServicios = "Irradiación y Caracterización" },
                new CategoriaServicio { Nombre = "Servicios Radiofarmacia" },
                new CategoriaServicio { Nombre = "Análisis Radiológico", GrupoServicios = "Protección Radiológica" },
                new CategoriaServicio { Nombre = "Licencia Operación", GrupoServicios = "Seguridad Nuclear y Radiológica" }
            };

            context.CategoriaServicios.AddRange(categorias);
            context.SaveChanges();

            var servicios = new Servicio[] {
                new Servicio { CategoriaServicioID = 1, Descripcion = "SEMI CONTINUA 1 KGY" },
                new Servicio { CategoriaServicioID = 1, Descripcion = "SEMI CONTINUA 2 KGY" },
                new Servicio { CategoriaServicioID = 2, Descripcion = "Liofilización hasta 300 frascos" },
                new Servicio { CategoriaServicioID = 3, Descripcion = "ANÁLISIS RADIOLÓGICO SEGÚN TABLA 6 DE LA NORMA CHILENA PARA AGUA POTABLE(NCH409/1)" },
                new Servicio { CategoriaServicioID = 3, Descripcion = "ANÁLISIS RADIOLÓGICO DE CS-137 EN ALIMENTOS Y ADITIVOS ALIMENTARIOS POR ESPECTROMETRÍA GAMMA" },
                new Servicio { CategoriaServicioID = 4, Descripcion = "Operación MN LT DF – Laboratorio de alta radiotoxicidad (medicina nuclear, laboratorio industrial)" },
                new Servicio { CategoriaServicioID = 4, Descripcion = "Operación TI – Transferencia anual fuentes no selladas por institución" }
            };

            context.Servicios.AddRange(servicios);
            context.SaveChanges();

            var clientes = new Cliente[]
            {
                new Cliente { RUT = "70.000.000-1", Nombre = "Cliente 1", TipoCliente = TipoCliente.PersonaJuridica },
                new Cliente { RUT = "70.000.001-1", Nombre = "Cliente 2", TipoCliente = TipoCliente.PersonaJuridica },
                new Cliente { RUT = "10.000.002-1", Nombre = "Cliente 3", TipoCliente = TipoCliente.PersonaNatural }
            };

            context.Clientes.AddRange(clientes);
            context.SaveChanges();

            var representantes = new Representante[] {
                new Representante { ClienteID = 1, Correo = "rep100@correo.cl", Nombre = "Representante 100", Telefono = "+56111111" },
                new Representante { ClienteID = 1, Correo = "rep101@correo.cl", Nombre = "Representante 101", Telefono = "+56111112" },
                new Representante { ClienteID = 2, Correo = "rep200@correo.cl", Nombre = "Representante 200", Telefono = "+56111113" },
                new Representante { ClienteID = 3, Correo = "cliente3@correo.cl", Nombre = "Cliente 3", Telefono = "+56111114" }
            };

            context.Representantes.AddRange(representantes);
            context.SaveChanges();

            var ventas = new VentaServicio[] {
                new VentaServicio { ServicioID = 1, ClienteID = 1, EstadoVentaServicio = EstadoVentaServicio.Iniciada, TotalVenta = 100, TotalPagado = 0 },
                new VentaServicio { ServicioID = 4, ClienteID = 2, EstadoVentaServicio = EstadoVentaServicio.Evaluada, TotalVenta = 200, TotalPagado = 0 },
                new VentaServicio { ServicioID = 6, ClienteID = 3, EstadoVentaServicio = EstadoVentaServicio.Iniciada, TotalVenta = 500, TotalPagado = 100 }
            };

            context.VentaServicios.AddRange(ventas);
            context.SaveChanges();
        }
    }
}
