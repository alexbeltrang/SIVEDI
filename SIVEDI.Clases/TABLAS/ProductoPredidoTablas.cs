using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases.TABLAS
{
    public class ProductoPredidoTablas
    {
        public decimal CODIGO { get; set; }
        public string CODIGO_VENTA { get; set; }
        public string REFERENCIA { get; set; }
        public string NOMBRE_PRODUCTO { get; set; }
        public decimal PRECIO_LISTA { get; set; }
        public int LIMITE_VENTA { get; set; }
        public bool ES_CODIGO_PRINCIPAL { get; set; }
        public bool PERMITE_DIGITAR { get; set; }
        public bool SUMA_VALOR_PUBLICO { get; set; }
        public bool SUMA_PARA_LLEGAR_ESCALA { get; set; }
        public bool APLICA_ESCALA { get; set; }
        public bool APLICA_SUPERA_MONTO_MINIMO { get; set; }
        public bool ES_ACCESORIO { get; set; }
        public decimal IVA { get; set; }
        public decimal COSTO_PRODUCTO { get; set; }
        public bool ES_FALTANTE_ANUNCIADO { get; set; }
        public string MOTIVO_VENTA { get; set; }
        public string CENTRO_GASTO_VENTA { get; set; }
        public string MOTIVO_OBSEQUIO { get; set; }
        public string CENTRO_GASTO_OBSEQUIO { get; set; }
        public decimal PRECIO_CATALOGO { get; set; }
        public string CODIGO_TIPO_PRODUCTO { get; set; }
        public bool SUMA_PARA_VALOR_NETO { get; set; }
        public int PUNTOS_PREMIO { get; set; }

    }
}
