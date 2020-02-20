using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases.TABLAS
{
    public class ListaPreciosProducto
    {
        [DisplayName("Código")]
        public decimal CODIGO { get; set; }

        [DisplayName("Código Venta")]
        public string CODIGO_VENTA { get; set; }
        
        [DisplayName("Id Código Venta")]
        public decimal CODIGO_VENTA_ID { get; set; }

        [DisplayName("Referencia")]
        public string REFERENCIA { get; set; }

        [DisplayName("Nombre")]
        public string NOMBRE { get; set; }

        [DisplayName("Precio")]
        public decimal PRECIO { get; set; }

        [DisplayName("Límite Venta")]
        public int LIMITE { get; set; }

        [DisplayName("Es Principal")]
        public string PRINCIPAL { get; set; }

        [DisplayName("Permite Digitar")]
        public string DIGITA { get; set; }

        [DisplayName("Suma para valor público")]
        public string SUMA_PUBLICO { get; set; }

        [DisplayName("Suma para Escala de descuento")]
        public string SUMA_ESCALA { get; set; }

        [DisplayName("Se le aplica escala de descuento")]
        public string APLICA_ESCALA { get; set; }

        [DisplayName("Suma para Monto Mínimo")]
        public string SUMA_MINIMO { get; set; }

        [DisplayName("Suma para Valor Neto")]
        public string SUMA_NETO { get; set; }

        [DisplayName("Es Accesorio")]
        public string ES_ACCESORIO { get; set; }

        [DisplayName("Porcentaje IVA")]
        public decimal IVA { get; set; }

        [DisplayName("Costo Producto")]
        public decimal COSTO { get; set; }

        [DisplayName("Puntos")]
        public int PUNTOS { get; set; }

        [DisplayName("Es Faltante anunciado")]
        public string ES_FALTANTE { get; set; }

        [DisplayName("Precio Catalogo")]
        public decimal PRECIO_CATALOGO { get; set; }
        [DisplayName("Tipo Producto")]
        public String TIPO_PRODUCTO { get; set; }
        [DisplayName("Id Lista")]
        public int CODIGO_LISTA { get; set; }
        [DisplayName("Es Principal bool")] 
        public bool ES_PRINCIPAL { get; set; }
        [DisplayName("Permite Digitar bool")]
        public bool PERMITE_DIGITAR { get; set; }
        [DisplayName("Suma Valor Publico bool")]
        public bool SUMA_VALOR_PUBLICO { get; set; }
        [DisplayName("Suma llegar escala bool")]
        public bool SUMA_LLEGAR_ESCALA { get; set; }
        [DisplayName("Se aplica Escala bool")]
        public bool SE_APLICA_ESCALA { get; set; }
        [DisplayName("Supera Monto Minimo bool")]
        public bool APLICA_SUPERA_MONTO_MIN { get; set; }
        [DisplayName("Es Accesorio bool")]
        public bool OES_ACCESORIO { get; set; }
        [DisplayName("Es faltante bool")]
        public bool ESFALTANTE_ANUNCIADO { get; set; }
        [DisplayName("Suma a Valor Neto bool")]
        public bool SUMA_VALOR_NETO { get; set; }
    }
}
