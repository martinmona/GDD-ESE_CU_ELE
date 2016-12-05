using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    public class Turno
    {
        //agrego horaI horaT y afiliado
        private decimal _codigo;
        private DateTime _fecha;
        private Profesional _profesional;
        private Cancelacion _cancelacion;
        private Afiliado _afiliado;
        private string _horaI;
        private string _horaT;

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
        public Profesional profesional
        {
            get { return _profesional; }
            set { _profesional = value; }
        }
        public Cancelacion cancelacion
        {
            get { return _cancelacion; }
            set { _cancelacion = value; }
        }
        public Afiliado afiliado
        {
            get { return _afiliado; }
            set { _afiliado = value; }
        }
        public string horaI
        {
            get { return _horaI; }
            set { _horaI = value; }
        }
        public string horaT
        {
            get { return _horaT; }
            set { _horaT = value; }
        }
    }
}
