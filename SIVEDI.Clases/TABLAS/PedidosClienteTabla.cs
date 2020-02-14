using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases.TABLAS
{
    public class PedidosClienteTabla
    {
        public decimal CODIGO { get; set; }
        public string CAMPAÑA { get; set; }
        public DateTime FECHA_REGISTRO { get; set; }
        public int COD_ESTADO { get; set; }
        public string ESTADO { get; set; }
        public string FACTURA { get; set; }
        public string PEDIDO { get; set; }
        public decimal VALOR_PUBLICO { get; set; }
        public decimal VALOR_PAGAR { get; set; }
        public int POR_ESC_DCTO { get; set; }
        public int PUNTOS { get; set; }
    }
}
