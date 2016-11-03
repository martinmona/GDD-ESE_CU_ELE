using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Config
{
    class Funcionalidad
    {
        private int _codigo;
        private string _descripcion;

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
    }
}
