using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class ZonaConcursoVentasIns
    {
        public decimal CODIGO_ZONA_CONCURSO_VENTA { get; set; }
        public string CODIGO_ZONA { get; set; }
        public bool ES_ACUMULADO { get; set; }
        public decimal PORCENTAJE_COLCHON { get; set; }
        public int CODIGO_CONCURSO { get; set; }
    }
}
