using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIVEDI.Clases
{
    public class PreliquidaConcursos
    {
        public int CODIGO { get; set; }
        public int CAMPANA_ENTREGA { get; set; }
        public bool VALIDA_CAMPANA_ACTUAL { get; set; }
        public string NOMBRE_CONCURSO { get; set; }
        public bool ES_ACUMULADO { get; set; }
        public decimal PORCENTAJE_COLCHON { get; set; }
        public bool ENTREGA_PREMIO_ACUMULADO { get; set; }
    }
}
