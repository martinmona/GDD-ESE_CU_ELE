using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Clases
{
    public class Agenda
    {
        public int Id { get; set; }
        public int IdProfesional { get; set; }
        public int IdEspecialidad { get; set; }
        public DateTime Dia { get; set; }
        public DateTime HoraComienzo { get; set; }
        public DateTime HoraFin { get; set; }
        public DateTime FechaFin { get; set; }

        public Agenda() { }
    }
}
