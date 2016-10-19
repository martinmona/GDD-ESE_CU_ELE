using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Clases
{
    public class Afiliado
    {
        public string EstadoCivil { get; set; }
        public int NumeroAfiliado { get; set; }
        public int IdPlan { get; set; }
        public int IdFamiliar { get; set; }
        

        public Afiliado() { }
    }
}
