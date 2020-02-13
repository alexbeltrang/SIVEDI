using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class EstadoActividad
    {
        public int ESA_NID { get; set; }
        public string ESA_CDESCRIPCION { get; set; }
        public bool ESA_OESTADO { get; set; }
        public int? ESA_NESTADO_SIGUIENTE_SIN_PED { get; set; }
        public int? ESA_NESTADO_SIGUIENTE_CON_PED { get; set; }
        public int? ESA_NCAMPANA_CONTROLA { get; set; }
        public int? ESA_NESTADO_PASA_CONTROL_CAMPANA { get; set; }
        public int? ESA_NNUMERO_PEDIDO_CONTROLA { get; set; }
        public int? ESA_NESTADO_PASA_CONTROL_PEDIDO { get; set; }
        public bool ESA_OES_ESTADO_INACTIVIDAD { get; set; }
        public bool ESA_OES_ESTADO_VINCULACION { get; set; }
        public bool ESA_OINGRESA_VINCULACION { get; set; }
    }
}
