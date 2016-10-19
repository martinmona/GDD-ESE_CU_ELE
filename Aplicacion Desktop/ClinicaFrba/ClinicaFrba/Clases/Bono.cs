using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Clases
{
    public class Bono
    {
        public int Id { get; set; }
        public int IdConsultaMedica{ get; set; }
        public int idPlan { get; set; }
        public int IdAfiliado { get; set; }
        public int Precio { get; set; }

        public Bono() { }
    }
}
