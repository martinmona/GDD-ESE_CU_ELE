using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Clases
{
    public class Cancelacion
    {
        public int Id { get; set; }
        public int IdConsulta { get; set; }
        //public string Tipo { get; set; }
        public string Detalle { get; set; }

        public Cancelacion() { }
    }
}
