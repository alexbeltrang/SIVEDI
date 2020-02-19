using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases.TABLAS
{
    public class ProductoTabla
    {
        public int CODIGO { get; set; }
        public string REFERENCIA { get; set; }
        public string NOMBRE { get; set; }
        public decimal IVA { get; set; }
        public string MOTIVO_VENTA { get; set; }
        public string CENTRO_GASTO_VENTA { get; set; }
        public string MOTIVO_OBSEQUIO { get; set; }
        public string CENTRO_GASTO_OBSEQUIO { get; set; }
        public string ESTADO { get; set; }
        public int CODIGO_UNIDAD_MEDIDA { get; set; }
        public string UNIDAD_MEDIDA { get; set; }
        public int PUNTOS { get; set; }
    }
}
