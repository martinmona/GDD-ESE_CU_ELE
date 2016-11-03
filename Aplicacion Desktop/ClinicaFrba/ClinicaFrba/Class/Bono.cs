using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Config
{
    public class Bono
    {
        private int _codigo;
        //private ConsultaMedica _numeroConsultaMedica;
        private Plan _plan;
        private int _precio;
        private DateTime _fechaCompra;

        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        /*public int numeroConsultaMedica
        {
            get { return _numeroConsultaMedica; }
            set { _numeroConsultaMedica = value; }
        }*/
        public int precio
        {
            get { return _precio; }
            set { _precio = value; }
        }
        public Plan plan
        {
            get { return _plan; }
            set { _plan = value; }
        }
        public DateTime fechaCompra
        {
            get { return _fechaCompra; }
            set { _fechaCompra = value; }
        }
    }
}
