using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases.TABLAS
{
    public class CombosTabla
    {
        public int CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string ESTADO { get; set; }
        public int CODIGO_LISTA_PRECIOS { get; set; }
        public string CODIGO_VENTA { get; set; }
        public decimal PRECIO_VENTA { get; set; }
        public decimal PORC_DESCUENTO { get; set; }
    }
}
