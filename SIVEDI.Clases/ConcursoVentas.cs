using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class ConcursoVentas
    {
        public int CODIGO { get; set; }
        public string NOMBRE { get; set; }
        public int CAMPANA_ENTREGA { get; set; }
        public bool VALIDA_CAMPANA_ACTUAL { get; set; }
        public bool ESTADO { get; set; }
        public bool ES_PARA_INGRESO { get; set; }
        public bool ENTREGA_PREMIO_ACUMULADO { get; set; }
    }
}
