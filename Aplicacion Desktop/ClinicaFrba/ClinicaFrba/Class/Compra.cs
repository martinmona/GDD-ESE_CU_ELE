using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    public class Compra
    {
        private decimal _codigo;
        private DateTime _fecha;
        private List<Bono> _bonos;

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
        public List<Bono> bonos
        {
            get { return _bonos; }
            set { _bonos = value; }
        }

    }
}
