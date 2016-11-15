using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    public class Modificacion
    {
        private decimal _codigo;
        private DateTime _fecha;
        private string _motivo;
        private Plan _planAntiguo;
        private decimal _afiliado;

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
        public decimal afiliado
        {
            get { return _afiliado; }
            set { _afiliado = value; }
        }
    }
}
