using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    public class Turno
    {

        private decimal _codigo;
        private DateTime _fecha;
        private Afiliado _afiliado;
        private Profesional _profesional;
        private Cancelacion _cancelacion;
        private Especialidad _especialidad;
        private string _estado;


        
        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public decimal codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string afiliadoNumeroCompleto
        {
            get { return _afiliado.numeroCompleto; }
            set { _afiliado.numeroCompleto = value; }
        }
        public string afiliadoNombre
        {
            get { return _afiliado.nombre; }
            set { _afiliado.nombre = value; }
        }
        public Afiliado afiliado
        {
            get { return _afiliado; }
            set { _afiliado = value; }
        }
        public DateTime fecha
        {
            get { return _fecha; }
            set { _fecha = value; }
        }
        public string mostrarFecha
        {
            get { return (_fecha.Hour.ToString()+":"+_fecha.Minute.ToString()); }
            
        }
        public Profesional profesional
        {
            get { return _profesional; }
            set { _profesional = value; }
        }
        public Especialidad especialidad
        {
            get { return _especialidad; }
            set { _especialidad = value; }
        }
        public Cancelacion cancelacion
        {
            get { return _cancelacion; }
            set { _cancelacion = value; }
        }
        
    }
}
