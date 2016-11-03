using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Config
{
    public class ConsultaMedica
    {
        private int _codigo;
        private Bono _bono;
        private string _resultado;
        private DateTime _horaLlegada;
        private string _sintomas;
        private string _enfermedades;

        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public Bono bono
        {
            get { return _bono; }
            set { _bono = value; }
        }
        public string resultado
        {
            get { return _resultado; }
            set { _resultado = value; }
        }
        public string sintomas
        {
            get { return _sintomas; }
            set { _sintomas = value; }
        }
        public string enfermedades
        {
            get { return _sintomas; }
            set { _sintomas = value; }
        }
        public DateTime horaLlegada
        {
            get { return _horaLlegada; }
            set { _horaLlegada = value; }
        }
    }
}
