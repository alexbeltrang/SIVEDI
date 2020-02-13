using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases.TABLAS
{
    public class RegionalesTabla
    {
        public string CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string ESTADO { get; set; }
        public int GRUPO_FACTURACION { get; set; }
        public string RESPONSABLE { get; set; }
        public string PAIS { get; set; }
        public int CODIGO_RESPONSABLE { get; set; }
        public int CODIGO_PAIS { get; set; }
    }
}
