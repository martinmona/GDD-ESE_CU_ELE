using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Clases
{
    public class ConsultaMedica
    {
        public int Id { get; set; }
        public bool Concretada { get; set; }
        public string Resultado { get; set; }

        public ConsultaMedica() { }
    }
}
