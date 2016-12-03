using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    public class Afiliado : Persona
    {
        private string _estadoCivil;
        private decimal _numeroAfiliado;
        private decimal _codigoFamiliar;
        private string _numeroCompleto;
        private Plan _plan;
        private List<Bono> _bonos;
        private List<Turno> _turnos;
        private List<Compra> _compras;
        private int _cantidadFamiliares;

        public string estadoCivil
        {
            get { return _estadoCivil; }
            set { _estadoCivil = value; }
        }
        public override decimal numeroAfiliado
        {
            get { return _numeroAfiliado; }
            set { _numeroAfiliado = value; }
        }
        public decimal codigoFamiliar
        {
            get { return _codigoFamiliar; }
            set { _codigoFamiliar = value; }
        }
        public string numeroCompleto
        {
            get { return _numeroCompleto; }
            set { _numeroCompleto = value; }
        }
        public override Plan plan
        {
            get { return _plan; }
            set { _plan = value; }
        }
        public string planDescripcion
        {
            get { return _plan.descripcion; }
        }
        public List<Bono> bonos
        {
            get { return _bonos; }
            set { _bonos = value; }
        }
        public List<Compra> compras
        {
            get { return _compras; }
            set { _compras = value; }
        }
        public List<Turno> turnos
        {
            get { return _turnos; }
            set { _turnos = value; }
        }
        public int cantidadFamiliares
        {
            get { return _cantidadFamiliares; }
            set { _cantidadFamiliares = value; }
        }
    }
}
