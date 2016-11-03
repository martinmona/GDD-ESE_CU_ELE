﻿using System;
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
        private Plan _plan;
        private List<Modificacion> _modificaciones;
        private List<Bono> _bonos;
        private List<Turno> _turnos;
        private List<Compra> _compras;

        public string estadoCivil
        {
            get { return _estadoCivil; }
            set { _estadoCivil = value; }
        }
        public decimal numeroAfiliado
        {
            get { return _numeroAfiliado; }
            set { _numeroAfiliado = value; }
        }
        public decimal codigoFamiliar
        {
            get { return _codigoFamiliar; }
            set { _codigoFamiliar = value; }
        }
        public Plan plan
        {
            get { return _plan; }
            set { _plan = value; }
        }
        public List<Modificacion> modificaciones
        {
            get { return _modificaciones; }
            set { _modificaciones = value; }
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
    }
}
