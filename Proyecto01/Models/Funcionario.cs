namespace ejercicio.Models
{   
    public class Funcionario
    {
        public string RUT { get; }

        public Estamento Estamento { get; }

        public int Grado { get; set; } = 10;

        public int Antiguedad { get; set; } = 0;

        public Funcionario(string rut, Estamento estamento)
        {
            RUT = rut;
            Estamento = estamento;
        }

        public int ObtenerRemuneracion()
        {
            int sueldoBase = Planilla.ObtenerPlanillaPara(Estamento).
                ObtenerSueldoBasePara(Grado);

            int bonoAntiguedad = (Antiguedad / 3) * 100000;
            return sueldoBase + bonoAntiguedad;
        }
    }
}
