using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class Cliente
    {
        public decimal CODIGO { get; set; }
        public string NUMERO_IDENTIFICACION { get; set; }
        public string PRIMER_APELLIDO { get; set; }
        public string SEGUNDO_APELLIDO { get; set; }
        public string PRIMER_NOMBRE { get; set; }
        public string SEGUNDO_NOMBRE { get; set; }
        public string EMAIL { get; set; }
        public string DIRECCION_DOMICILIO { get; set; }
        public string DIRECCION_ENTREGA { get; set; }
        public string PROFESION { get; set; }
        public string ESTRATO { get; set; }
        public string TELEFONO_FIJO { get; set; }
        public string TELEFONO_CELULAR { get; set; }
        public string TELEFONO_OFICINA { get; set; }
        public decimal ID_REFERIDO_POR { get; set; }
        public DateTime FECHA_NACIMIENTO { get; set; }
        public decimal CUPO_CREDITO { get; set; }
        public bool LIDER { get; set; }
        public bool CABEZA_GRUPO { get; set; }
        public string ULTIMO_ESTADO_ACTIVIDAD { get; set; }
        public bool CUENTA_BLOQUEADA { get; set; }
        public string RAZON_BLOQUEO { get; set; }
        public bool GEOREFERENCIADO { get; set; }
        public string FORMA_PAGO { get; set; }
        public bool COBRA_FLETE { get; set; }
        public int PAI_NID { get; set; }
        public string REG_CID { get; set; }
        public string ZON_CID { get; set; }
        public string SEC_CID { get; set; }
        public string TER_CID { get; set; }
        public int GEN_NID { get; set; }
        public int CIU_NID { get; set; }
        public int DEP_NID { get; set; }
        public int TDO_NID { get; set; }
        public int ECV_NID { get; set; }
        public int CAM_NID_INGRESO { get; set; }
        public int CAM_NID_ULTIMA_CAMPANA { get; set; }
        public int CAM_NID_PENULTIMA_CAMPANA { get; set; }
        public int CAM_NID_ANTEPENULTIMA_CAMPANA { get; set; }
        public int TIC_NID { get; set; }
        public int FIN_NID { get; set; }
        public int ESA_NID { get; set; }
        public int ESA_NID_ANTERIOR { get; set; }
        public int MTB_NID { get; set; }
        public DateTime FECHA_VINCULACION { get; set; }
        public int FPG_NID { get; set; }
        public bool ESINGRESO { get; set; }

    }
}
