using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class ProductosAplicaOferta
    {
		public decimal CODIGO { get; set; }
		public decimal CODIGO_PRODUCTO { get; set; }
		public string CODIGO_VENTA { get; set; }
		public string NOMBRE_PRODUCTO { get; set; }
		public decimal PORCENTAJE { get; set; }
		public int UNIDADES { get; set; }
		public decimal VALOR_VENTA { get; set; }
		public string TIPO_PRODUCTO { get; set; }
		public decimal PRECIO_CATALOGO { get; set; }
	}
}
