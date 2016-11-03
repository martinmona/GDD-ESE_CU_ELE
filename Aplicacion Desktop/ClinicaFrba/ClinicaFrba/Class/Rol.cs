using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Config
{
    class Rol
    {
        private decimal _codigo;
        private string _nombre;
        private bool _habilitado;
        private List<Funcionalidad> _listaFuncionalidades;

        public decimal codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public string nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public bool habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }
        public List<Funcionalidad> listaFuncionalidades
        {
            get { return _listaFuncionalidades; }
            set { _listaFuncionalidades = value; }
        }

        public Rol() { }
    }
}
