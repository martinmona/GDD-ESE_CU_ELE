using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    public abstract class Persona
    {
        private decimal _codigoPersona;
        private string _nombre;
        private string _apellido;
        private string _nombreCompleto;
        private string _sexo;
        private DateTime _fechaNacimiento;
        private string _documento;
        private decimal _numeroDocumento;
        private string _mail;
        private string _direccion;
        private decimal _telefono;
        private string _tipoDocumento;
        private string _tipo;
        public virtual Plan plan { get; set; }
        public virtual decimal numeroAfiliado { get; set; }

        public decimal codigoPersona
        {
            get { return _codigoPersona; }
            set { _codigoPersona = value; }
        }
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public string apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string nombreCompleto
        {
            get { return _nombreCompleto; }
            set { _nombreCompleto = value; }
        }

        public string sexo
        {
            get { return _sexo; }
            set { _sexo = value; }
        }
        public DateTime fechaNacimiento
        {
            get { return _fechaNacimiento; }
            set { _fechaNacimiento = value; }
        }
        public string documento
        {
            get { return _documento; }
            set { _documento = value; }
        }
        public string mail
        {
            get { return _mail; }
            set { _mail = value; }
        }
        public string direccion
        {
            get { return _direccion; }
            set { _direccion = value; }
        }
        public decimal telefono
        {
            get { return _telefono; }
            set { _telefono = value; }
        }
        public string tipoDocumento
        {
            get { return _tipoDocumento; }
            set { _tipoDocumento = value; }
        }
        public string tipo
        {
            get { return _tipo; }
            set { _tipo = value; }
        }
        public decimal numeroDocumento
        {
            get { return _numeroDocumento; }
            set { _numeroDocumento = value; }
        }
    }
}
