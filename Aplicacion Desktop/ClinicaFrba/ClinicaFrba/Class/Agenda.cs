using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    public class Agenda
    {
        private decimal _codigo;
        private Byte _dia;
        private DateTime _horaInicio;
        private DateTime _horaFin;
        private DateTime _fechaFin;
        private Especialidad _especialidad;

        public decimal codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public Byte dia
        {
            get { return _dia; }
            set { _dia = value; }
        }
        public DateTime horaInicio
        {
            get { return _horaInicio; }
            set { _horaInicio = value; }
        }
        public DateTime horaFin
        {
            get { return _horaFin; }
            set { _horaFin = value; }
        }
        public DateTime fechaFin
        {
            get { return _fechaFin; }
            set { _fechaFin = value; }
        }
        public Especialidad especialidad
        {
            get { return _especialidad; }
            set { _especialidad = value; }
        }
    }
}
