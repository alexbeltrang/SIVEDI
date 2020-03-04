using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class EscalaDescuento
    {
        public int CODIGO { get; set; }
        public decimal PRECIO { get; set; }
        public int DESCUENTO_INICIAL { get; set; }
        public bool ES_PARA_CLIENTE_NUEVO { get; set; }
        public int TIPO_CLIENTE { get; set; }
        public string ZONA { get; set; }
        public decimal RANGO_SUPERIOR { get; set; }
        public decimal PRECIO_FINAL { get; set; }



    }
}
