namespace ejercicio.Models
{
    public class Planilla
    {
        private static readonly Dictionary<Estamento, Planilla> Planillas = new() {
            {
                Estamento.Investigador, new (
                    new()
                    {
                        { 7, 2000000 },
                        { 6, 2300000 },
                        { 5, 2500000 }
                    }
                )
            },
            {
                Estamento.Directivo, new (
                    new()
                    {
                        { 2, 4500000 },
                        { 1, 5000000 }
                    }
                )
            },
            {
                Estamento.Administrativo, new (
                new()
                    {
                        { 11, 1400000 },
                        { 10, 1700000 },
                        { 9, 2000000 },
                        { 8, 2300000 }
                    }
                )
            }
        };

        public static Planilla ObtenerPlanillaPara(Estamento est)
        {
            if (!Planillas.ContainsKey(est))
                throw new Exception("Planilla inválida");

            return Planillas[est];
        }

        private readonly Dictionary<int, int> Sueldos;
        private Planilla(Dictionary<int, int> sueldos)
        {
            Sueldos = sueldos;
        }

        public int ObtenerSueldoBasePara(int grado)
        {
            if (!Sueldos.ContainsKey(grado))
                throw new Exception("Grado no definido");

            return Sueldos[grado];
        }

        public int[] ObtenerGradosValidos()
        {
            return Sueldos.Keys.ToArray();
        }
    }
}
