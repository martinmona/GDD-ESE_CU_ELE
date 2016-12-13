using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    public class Plan
    {
        private decimal _codigo;
        private string _descripcion;
        private decimal _bonoConsulta;
        private decimal _bonoFarmacia;

        public decimal codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public decimal bonoConsulta
        {
            get { return _bonoConsulta; }
            set { _bonoConsulta = value; }
        }
        public decimal bonoFarmacia
        {
            get { return _bonoFarmacia; }
            set { _bonoFarmacia = value; }
        }
    }
}
