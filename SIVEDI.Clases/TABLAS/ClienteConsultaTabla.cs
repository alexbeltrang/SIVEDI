using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases.TABLAS
{
    public class ClienteConsultaTabla
    {
        public decimal CODIGO { get; set; }
        public string IDENTIFICACION { get; set; }

        public string TIPO_DOCUMENTO { get; set; }

        public string NOMBRE { get; set; }
        public string FECHA_NACIMIENTO { get; set; }
        public string ESTADO_CIVIL { get; set; }
        public string TIPO_CLIENTE { get; set; }
        public string EMAIL { get; set; }
        public string DIRECCION_DOMICILIO { get; set; }
        public string DIRECCION_ENTREGA { get; set; }
        public string TELEFONO_FIJO { get; set; }
        public string TELEFONO_CELULAR { get; set; }
        public string TELEFONO_OFICINA { get; set; }
        public decimal CUPO_CREDITO { get; set; }
        public string FORMA_PAGO { get; set; }
        public bool ES_LIDER { get; set; }
        public bool ES_CABEZA_GRUPO { get; set; }
        public bool COBRA_FLETE { get; set; }
        public bool GEOREFERENCIADO { get; set; }
        public string PAIS { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string CIUDAD { get; set; }
        public string REGIONAL { get; set; }
        public string ZONA { get; set; }
        public string SECCION { get; set; }
        public string TERRITORIO { get; set; }
        public string TER_CID { get; set; }
        public bool CUENTA_BLOQUEADA { get; set; }
        public string MOTIVO_BLOQUEO { get; set; }
        public string RAZON_BLOQUEO { get; set; }
        public string FECHA_VINCULACION { get; set; }
        public string CAMPANA_VINCULACION { get; set; }
        public string ESTADO_ACTIVIDAD_ACTUAL { get; set; }
        public string ESTADO_ACTIVIDAD_ANTERIOR { get; set; }
        public string ULTIMA_CAMPANA_PEDIDO { get; set; }
        public string PENULTIMA_CAMPANA_PEDIDO { get; set; }
        public string ANTERIOR_CAMPANA_PEDIDO { get; set; }
        public string IDENTIFICACION_REFERENTE { get; set; }
        public string NOMBRE_REFERENTE { get; set; }
        public bool ESINGRESO { get; set; }

    }
}
