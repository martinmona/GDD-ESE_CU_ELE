using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    public class Profesional : Persona
    {
        private decimal _matricula;
        private List<Especialidad> _especialidades;
        private List<Agenda> _agendas;

        public decimal matricula
        {
            get { return _matricula; }
            set { _matricula = value; }
        }
        public List<Especialidad> especialidades
        {
            get { return _especialidades; }
            set { _especialidades = value; }
        }
        public List<Agenda> agendas
        {
            get { return _agendas; }
            set { _agendas = value; }
        }
    }
}
