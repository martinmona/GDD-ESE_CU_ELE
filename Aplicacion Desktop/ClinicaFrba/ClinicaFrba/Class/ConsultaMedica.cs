using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    public class ConsultaMedica
    {
        private decimal _codigo;

        private DateTime _horaLlegada;
        private string _sintomas;
        private string _enfermedades;

        public decimal codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }

        public string sintomas
        {
            get { return _sintomas; }
            set { _sintomas = value; }
        }
        public string enfermedades
        {
            get { return _enfermedades; }
            set { _enfermedades = value; }
        }
        public DateTime horaLlegada
        {
            get { return _horaLlegada; }
            set { _horaLlegada = value; }
        }
    }
}
