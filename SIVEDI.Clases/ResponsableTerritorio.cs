using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class ResponsableTerritorio
    {
        public int CODIGO { get; set; }
        public String IDENTIFICACION { get; set; }
        public String NOMBRE { get; set; }
        public String NOMBRE_PILA { get; set; }
        public String DIRECCION { get; set; }
        public String BARRIO { get; set; }
        public String TELEFONO_FIJO { get; set; }
        public String TELEFONO_CELULAR { get; set; }
        public String EMAIL { get; set; }
        public bool ESTADO { get; set; }
        public int COD_CIU { get; set; }
        public int COD_CLR { get; set; }
    }
}
