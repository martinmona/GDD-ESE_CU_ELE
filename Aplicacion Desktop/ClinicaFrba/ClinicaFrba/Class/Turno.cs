using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    public class Turno
    {
        private decimal _codigo;
        private DateTime _fecha;
        private Profesional _profesional;
        private Cancelacion _cancelacion;

        public decimal codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public Profesional profesional
        {
            get { return _profesional; }
            set { _profesional = value; }
        }
        public Cancelacion cancelacion
        {
            get { return _cancelacion; }
            set { _cancelacion = value; }
        }
    }
}
