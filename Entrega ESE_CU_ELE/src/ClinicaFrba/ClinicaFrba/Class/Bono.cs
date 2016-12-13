using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    public class Bono
    {
        private decimal _codigo;
        private ConsultaMedica _consultaMedica;
        private int _numeroconsulta;
        private Plan _plan;
        private decimal _precio;
        private DateTime _fechaCompra;

        public decimal codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public ConsultaMedica consultaMedica
        {
            get { return _consultaMedica; }
            set { _consultaMedica = value; }
        }
        public decimal precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public int numeroconsulta
        {
            get { return _numeroconsulta; }
            set { _numeroconsulta = value; }
        }
        public Plan plan
        {
            get { return _plan; }
            set { _plan = value; }
        }
        public string planDescripcion
        {
            get { return _plan.descripcion; }
            set { _plan.descripcion = value; }
        }
        public DateTime fechaCompra
        {
            get { return _fechaCompra; }
            set { _fechaCompra = value; }
        }
    }
}
