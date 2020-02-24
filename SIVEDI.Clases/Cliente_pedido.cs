using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class Cliente_pedido
    {
		public decimal CODIGO { get; set; }
		public String IDENTIFICACION { get; set; }
		public String NOMBRE_CLIENTE { get; set; }
		public String EMAIL { get; set; }
		public String DIRECCION_DOMICILIO { get; set; }
		public String DIRECCION_ENTREGA { get; set; }
		public String TELEFONO_FIJO { get; set; }
		public String TELEFONO_CELULAR { get; set; }
		public decimal CUPO_CREDITO { get; set; }
		public bool ES_LIDER { get; set; }
		public bool ES_CABEZA_GRUPO { get; set; }
		public bool COBRA_FLETE { get; set; }
		public bool ES_GEOREFERENCIADO { get; set; }
		public String TERRITORIO { get; set; }
		public String CODIGO_TERRITORIO { get; set; }
		public bool CUENTA_BLOQUEADA { get; set; }
		public String RAZON_BLOQUEO { get; set; }
		public String NOMBRE_LISTA { get; set; }
		public int CODIGO_LISTA { get; set; }
		public String CODIGO_ZONA { get; set; }
		public int ESTADO_ACTIVIDAD_ANTERIOR { get; set; }
		public bool ES_INGRESO { get; set; }
		public int CODIGO_TIPO_CLIENTE { get; set; }
		public int CODIGO_CIUDAD { get; set; }
	}
}
