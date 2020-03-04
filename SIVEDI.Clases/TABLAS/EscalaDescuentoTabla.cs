using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases.TABLAS
{
    public class EscalaDescuentoTabla
    {
        public int CODIGO { get; set; }
        public string ZONA { get; set; }
        public decimal RANGO_INFERIOR { get; set; }
        public decimal RANGO_SUPERIOR { get; set; }
        public int PORCENTAJE { get; set; }
        public string CLIENTE_NUEVO { get; set; }
        public string TIPO_CLIENTE { get; set; }
        public int DESCUENTO_INICIAL { get; set; }

    }
}
