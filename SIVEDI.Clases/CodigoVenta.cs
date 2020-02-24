using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class CodigoVenta
    {
        public decimal CODIGO { get; set; }
        public int CODIGO_PRODUCTO { get; set; }
        public string CODIGO_VENTA { get; set; }
        public bool ESTADO { get; set; }
        public bool ES_PRINCIPAL { get; set; }
        public string REFERENCIA { get; set; }
    }
}
