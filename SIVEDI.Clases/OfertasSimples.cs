using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class OfertasSimples
    {
        public decimal CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public decimal FACTOR_CONVERSION { get; set; }
        public bool ES_POR_CANTIDAD { get; set; }
        public bool ES_POR_MONTO { get; set; }
        public bool ES_OBSEQUIO { get; set; }
        public bool ES_DESCUENTO { get; set; }
        public int CODIGO_LISTA_PRECIOS { get; set; }
        public bool ESTADO { get; set; }
        public bool ES_PROMOCION { get; set; }
        public decimal VALOR_MONTO { get; set; }
    }
}
