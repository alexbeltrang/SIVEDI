using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class ProductoAplicaOfertaSimple
    {
        public int CodigoEntrega { get; set; }
        public int CodigoProducto { get; set; }
        public int CodigoOferta { get; set; }
        public decimal Porcentaje { get; set; }
        public int UnidadesAplica { get; set; }
        public decimal ValorEntrega { get; set; }
    }
}
