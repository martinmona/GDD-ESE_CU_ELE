﻿using System;
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
        private Afiliado _afiliado;
        private string _nombreAfiliado;
        private string _nombreProfesional;
        private Profesional _profesional;
        private Cancelacion _cancelacion;
        private string _horaI;
        private string _horaT;
        private string _estado;
        public Turno()
        {

        }

        
        public string estado
        {
            get { return _estado; }
            set { _estado = value; }
        }
        public string nombreProfesional
        {
            get { return _nombreProfesional; }
            set { _nombreProfesional = value; }
        }
        public string nombreAfiliado
        {
            get { return _nombreAfiliado; }
            set { _nombreAfiliado = value; }
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
        public Cancelacion cancelacion
        {
            get { return _cancelacion; }
            set { _cancelacion = value; }
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
