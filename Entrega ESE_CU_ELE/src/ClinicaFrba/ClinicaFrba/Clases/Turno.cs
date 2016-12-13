using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Clases
{
    public class Turno
    {
        public int Id { get; set; }
        public int IdAgenda { get; set; }
        public int IdAfiliado { get; set; }
        public DateTime Hora { get; set; }
        public DateTime HoraLlegada { get; set; }

        public Turno() { }
    }
}
