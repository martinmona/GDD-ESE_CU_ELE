using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Config
{
    class Usuario
    {
        private int _codigo;
        private string _username;
        private string _contrasena;
        private int _intentos;
        private bool _habilitado; 

        public int codigo
        {
            get { return _codigo; }
            set { _codigo = value; }
        }
        public int intentos
        {
            get { return _intentos; }
            set { _intentos = value; }
        }
        public string username
        {
            get { return _username; }
            set { _username = value; }
        }
        public string contrasena
        {
            get { return _contrasena; }
            set { _contrasena = value; }
        }
        public bool habilitado
        {
            get { return _habilitado; }
            set { _habilitado = value; }
        }

    }
}
