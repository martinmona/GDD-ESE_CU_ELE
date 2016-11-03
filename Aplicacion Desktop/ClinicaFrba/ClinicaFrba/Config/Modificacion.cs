using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Config
{
    class Modificacion
    {
        private int _codigo;
        private DateTime _fecha;
        private string _motivo;
        private Plan _planAntiguo;

        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public string motivo
        {
            get { return _motivo; }
            set { _motivo = value; }
        }
        public Plan planAntiguo
        {
            get { return _planAntiguo; }
            set { _planAntiguo = value; }
        }
    }
}
