using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class ProductoListaPrecio
    {

        public int CODIGO_PRODUCTO_LISTA { get; set; }
        public int CODIGO_LISTA_PRECIOS { get; set; }
        public decimal PRECIO_LISTA { get; set; }
        public int LIMITE_VENTA { get; set; }
        public bool PERMITE_DIGITAR { get; set; }
        public bool SUMA_VALOR_PUBLICO { get; set; }
        public bool SUMA_LLEGAR_ESCALA { get; set; }
        public bool SE_APLICA_ESCALA { get; set; }
        public bool APLICA_SUPERA_MONTO_MIN { get; set; }
        public bool ES_ACCESORIO { get; set; }
        public bool ES_PRINCIPAL { get; set; }
        public decimal COSTO_PRODUCTO { get; set; }
        public bool ESFALTANTE_ANUNCIADO { get; set; }
        public int CODIGO_VENTA { get; set; }
        public bool SUMA_NETO { get; set; }
        public int PUNTOS { get; set; }
        public decimal PORCENTAJE_IVA { get; set; }
        public string TIPO_PRODUCTO { get; set; }
        public Decimal PRECIO_CATALOGO { get; set; }
    }
}
