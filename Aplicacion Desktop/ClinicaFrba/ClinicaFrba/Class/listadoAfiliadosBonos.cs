using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicaFrba.Class
{
    class listadoAfiliadosBonos
    {
        
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal NumeroAfiliado { get; set; }
        public decimal NumeroFamiliar { get; set; }
        public int CantidadBonos { get; set; }
        public string perteneceGrupoFamiliar { get; set; }
        

        public string NumeroCompleto
        {
            get { return NumeroAfiliado.ToString()+NumeroFamiliar.ToString(); }
        }
    }
}
