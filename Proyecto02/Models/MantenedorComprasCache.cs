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
                    new Equipo(
                        new ModeloEquipo(TipoEquipo.Dosimetro, "Dosímetro Simple"),
                        50000000
                    ),
                    new Equipo(
                        new ModeloEquipo(TipoEquipo.Microscopio, "Microscopio Simple"),
                        150000
                    ),
                    new Equipo(
                        new ModeloEquipo(TipoEquipo.Espectrometro, "Espectrómetro Simple"),
                        35000000
                    )
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

        public void AgregarCompra(Equipo compra)
        {
            Equipos.Add(compra);
        }
    }
}
