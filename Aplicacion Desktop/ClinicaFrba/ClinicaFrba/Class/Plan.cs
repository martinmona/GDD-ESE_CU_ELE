using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    public class Plan
    {
        private int _codigo;
        private string _descripcion;
        private int _bonoConsulta;
        private int _bonoFarmacia;

        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public int bonoConsulta
        {
            get { return _bonoConsulta; }
            set { _bonoConsulta = value; }
        }
        public int bonoFarmacia
        {
            get { return _bonoFarmacia; }
            set { _bonoFarmacia = value; }
        }
    }
}
