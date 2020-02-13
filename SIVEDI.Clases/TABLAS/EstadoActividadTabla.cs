using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases.TABLAS
{
    public class EstadoActividadTabla
    {
        public int CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public string ES_INAC { get; set; }
        public string ES_VINC { get; set; }
        public string ING_VINC { get; set; }
        public string ESTADO_CON_PEDIDO { get; set; }
        public string ESTADO_SIN_PEDIDO { get; set; }
        public int CTRL_CAMP { get; set; }
        public string CTRL_SUPERA_CAMPAÑA { get; set; }
        public int CTRL_PEDIDO { get; set; }
        public string ESTADO_NUMERO_PEDIDO { get; set; }

    }
}
