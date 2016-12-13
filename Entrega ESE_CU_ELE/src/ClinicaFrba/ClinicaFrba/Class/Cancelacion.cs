using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    public class Cancelacion
    {
        private decimal _codigo;
        private decimal _tipo;
        private string _detalle;

        public decimal codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public decimal tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public string detalle
        {
            get { return _detalle; }
            set { _detalle = value; }
        }
    }
}
