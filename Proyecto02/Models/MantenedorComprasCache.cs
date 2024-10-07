using Microsoft.Extensions.Caching.Memory;
using System;
using System.Reflection;

namespace Proyecto02.Models
{  
    public class MantenedorComprasCache : IMantenedorCompras
    {
        private List<Equipo>? Equipos { get; }

        [ActivatorUtilitiesConstructor]
        public MantenedorComprasCache(IMemoryCache cache)
        {
            Equipos = cache.GetOrCreate<List<Equipo>>("Equipos", e =>
            {
                return [
                    new() {
                        Id = 0,
                        Modelo = new() {
                            Tipo = TipoEquipo.Dosimetro,
                            Nombre = "Dosímetro Simple"
                        },
                        Precio = 50000000
                    },
                    new() {
                        Id = 1,
                        Modelo = new() {
                            Tipo = TipoEquipo.Microscopio,
                            Nombre = "Microscopio Simple"
                        },
                        Precio = 150000
                    },
                    new() {
                        Id = 2,
                        Modelo = new() {
                            Tipo = TipoEquipo.Espectrometro,
                            Nombre = "Espectrómetro Simple"
                        },
                        Precio = 3500000
                    }
                ];
            });
        }

        public List<Equipo> ObtenerCompras()
        {
            return new(Equipos);
        }

        public string[] ObtenerModelosPara(TipoEquipo tipo)
        {
            switch(tipo)
            {
                case TipoEquipo.Microscopio: return [
                    "Microscopio Simple",
                    "MA",
                    "MB",
                ];
                case TipoEquipo.Espectrometro: return [
                    "Espectrómetro Simple",
                    "EX",
                    "EY",
                ];
                case TipoEquipo.Dosimetro: return [
                    "Dosímetro Simple",
                    "D1",
                    "D2",
                ];
                default: return [];
            }
        }

        public Equipo AgregarCompra(ModeloEquipo modelo, int precio)
        {
            Equipo nuevo = new() 
            {
                Modelo = modelo,
                Precio = precio
            };

            Equipos.Add(nuevo);
            return nuevo;
        }

        public Equipo EliminarCompra(int id)
        {
            int pos = Equipos.FindIndex(e => e.Id == id);
            Equipo toRem = Equipos[pos];
            Equipos.RemoveAt(pos);

            return toRem;
        }
    }
}
